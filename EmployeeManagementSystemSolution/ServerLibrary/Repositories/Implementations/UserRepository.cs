using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServerLibrary.Data;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace ServerLibrary.Repositories.Implementations
{
    public class UserRepository(IOptions<JwtSection> config, AppDbContext appDbContext) : IUserAccount
    {
        public async Task<LoginResponse> SigninAsync(Login user)
        {
            if (user == null) return new LoginResponse(false, "Model is empty");

            var applicationUser = await FindUserByEmail(user.Email);
            if (applicationUser == null) return new LoginResponse(false, "User not found!");

            //Verify password
            if (!BCrypt.Net.BCrypt.Verify(user.Password, applicationUser.Password))
                return new LoginResponse(false, "Email/Password not valid");

            var getUserRole = await FindUserRole(applicationUser.ID);
            if (getUserRole == null) return new LoginResponse(false, "User role not found!");

            var getRoleName = await FindRoleName(getUserRole.RoleID);
            if (getRoleName == null) return new LoginResponse(false, "User role not found!");

            string jwtToken = GenerateToken(applicationUser, getRoleName!.Name);
            string refreshToken = GenerateRefreshToken();

            //Sae the Refresh token to the database
            var findUser = await appDbContext.RefreshTokenInfos.FirstOrDefaultAsync(_ => _.UserID == applicationUser.ID);
            if (findUser != null)
            {
                findUser!.Token = refreshToken;
                await appDbContext.SaveChangesAsync();

            }
            else
            {
                await AddToDatabase(new RefreshTokenInfo() { Token = refreshToken, UserID = applicationUser.ID });
            }
            return new LoginResponse(true, "Login successfully!", jwtToken, refreshToken);

        }

        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            if (user is null) return new GeneralResponse(false, "Model is empty");

            var checkUser = await FindUserByEmail(user.Email);
            if (checkUser != null) return new GeneralResponse(false, "User registered already");

            //Save user
            var applicationUser = await AddToDatabase(new User()
            {
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                Username = user.Username,
                Email = user.Email
            });

            //Check, create and assign role
            var checkAdminRole = await appDbContext.SystemRoles.FirstOrDefaultAsync(_ => _.Name!.Equals(Constants.Admin));
            if (checkAdminRole == null)
            {
                var createAdminRole = await AddToDatabase(new SystemRole() { Name = Constants.Admin });
                await AddToDatabase(new UserRole() { RoleID = createAdminRole.ID, UserID = applicationUser.ID });
                return new GeneralResponse(true, "Account created!");
            }

            var checkUserRole = await appDbContext.SystemRoles.FirstOrDefaultAsync(_ => _.Name!.Equals(Constants.User));
            SystemRole response = new();
            if (checkUserRole == null)
            {
                response = await AddToDatabase(new SystemRole() { Name = Constants.User });
                await AddToDatabase(new UserRole() { RoleID = response.ID, UserID = applicationUser.ID });
            }
            else
            {
                await AddToDatabase(new UserRole { RoleID = checkUserRole.ID, UserID = applicationUser.ID });
            }
            return new GeneralResponse(true, "Account created!");

        }

        private async Task<User> FindUserByEmail(string email) =>
            await appDbContext.Users.FirstOrDefaultAsync(_ => _.Email.ToLower()!.Equals(email!.ToLower()));

        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = appDbContext.Add(model!);
            await appDbContext.SaveChangesAsync();
            return (T)result.Entity;
        }

        private string GenerateToken(User user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,role!)
            };
            var token = new JwtSecurityToken(
                issuer: config.Value.Issuer,
                audience: config.Value.Audience,
                claims: userClaims,
                expires: DateTime.Now.AddSeconds(2),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private async Task<UserRole> FindUserRole(int userID) => await appDbContext.UserRoles.FirstOrDefaultAsync(_ => _.UserID == userID);
        private async Task<SystemRole> FindRoleName(int roleID) => await appDbContext.SystemRoles.FirstOrDefaultAsync(_ => _.ID == roleID);

        private static string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
        {
            if (token == null) return new LoginResponse(false, "Model is empty");

            var findToken = await appDbContext.RefreshTokenInfos.FirstOrDefaultAsync(_ => _.Token!.Equals(token.Token));
            if (findToken == null) return new LoginResponse(false, "Refresh token is requierd!");

            //Get user details
            var user = await appDbContext.Users.FirstOrDefaultAsync(_ => _.ID == findToken.UserID);
            if (user == null) return new LoginResponse(false, "Refresh token could not be generated because user not found!");

            var userRole = await FindUserRole(user.ID);
            var roleName = await FindRoleName(userRole.RoleID);
            var jwtToken = GenerateToken(user, roleName.Name);
            string refreshToken = GenerateRefreshToken();

            var updateRefreshToken = await appDbContext.RefreshTokenInfos.FirstOrDefaultAsync(_ => _.UserID == user.ID);
            if (updateRefreshToken == null) return new LoginResponse(false, "Refresh token could not be generated because user has not signed in");

            updateRefreshToken.Token = refreshToken;
            await appDbContext.SaveChangesAsync();
            return new LoginResponse(true, "Token refreshed successfully", jwtToken, refreshToken);
        }

        public async Task<List<ManageUser>> GetUsers()
        {
            var allUsers = await GetAllUsers();
            var allUserRoles = await UserRoles();
            var allRoles = await SystemRoles();

            if (allUsers.Count == 0 || allRoles.Count == 0)
                return null!;

            var users = new List<ManageUser>();
            foreach (var user in allUsers)
            {
                var userRole = allUserRoles.FirstOrDefault(u => u.UserID == user.ID);
                var roleName = allRoles.FirstOrDefault(u => u.ID == userRole!.RoleID);
                users.Add(new ManageUser() { UserID = user.ID, Username = user.Username!, Email = user.Email!, Role = roleName!.Name! });
            }
            return users;
        }

        public async Task<GeneralResponse> UpdateUser(ManageUser user)
        {
            var getRole = (await SystemRoles()).FirstOrDefault(r => r.Name!.Equals(user.Role));
            var userRole = await appDbContext.UserRoles.FirstOrDefaultAsync(U => U.UserID == user.UserID);
            userRole!.RoleID = getRole!.ID;
            await appDbContext.SaveChangesAsync();
            return new GeneralResponse(true, "User role updated successfully");
        }

        public async Task<List<SystemRole>> GetRoles() => await SystemRoles();

        public async Task<GeneralResponse> DeleteUser(int id)
        {
            var user =await appDbContext.Users.FirstOrDefaultAsync(u=>u.ID==id);
            appDbContext.Users.Remove(user!);
            await appDbContext.SaveChangesAsync();
            return new GeneralResponse(true, "User successfully deleted!");
        }


        private async Task<List<SystemRole>> SystemRoles() => await appDbContext
            .SystemRoles
            .AsNoTracking()
            .ToListAsync();

        private async Task<List<UserRole>> UserRoles() => await appDbContext
            .UserRoles
            .AsNoTracking()
            .ToListAsync();

        public async Task<List<User>> GetAllUsers() => await appDbContext
            .Users
            .AsNoTracking()
            .ToListAsync();
    }


}

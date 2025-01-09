using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Response;


namespace ServerLibrary.Repositories.Contracts
{
    public interface IUserAccount
    {
        Task<LoginResponse> SigninAsync(Login user);
        Task<GeneralResponse> CreateAsync(Register user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);
    }
}

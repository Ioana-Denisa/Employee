using BaseLibrary.DTOs;
using BaseLibrary.Response;

namespace ClientLibrary.Services.Contracts
{
    public interface IUserAccountService
    {
        Task<GeneralResponse> CreateAsync(Register user);
        Task<LoginResponse> SigninAsync(Login user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);
        Task<WeatherForecast[]> GetWeatherForecast();

    }
}

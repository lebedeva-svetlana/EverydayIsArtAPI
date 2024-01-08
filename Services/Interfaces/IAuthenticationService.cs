using EverydayIsArtAPI.Models;

namespace EverydayIsArtAPI.Services
{
    public interface IAuthenticationService
    {
        Task<string> Login(LoginRequest request);

        Task<string> Register(RegisterRequest request);
    }
}
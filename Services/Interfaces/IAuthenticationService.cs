using EverydayIsArtAPI.Models;

namespace EverydayIsArtAPI.Services
{
    /// <summary>
    ///     An authentication service.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        ///     Authorizes a user.
        /// </summary>
        /// <param name="request">
        ///     A login request data.
        /// </param>
        /// <returns>
        ///     An authentication token.
        /// </returns>
        Task<string> Login(LoginRequest request);

        /// <summary>
        ///     Registers a new user.
        /// </summary>
        /// <param name="request">
        ///     A registration request data.
        /// </param>
        /// <returns>
        ///     An authentication token.
        /// </returns>
        Task<string> Register(RegisterRequest request);
    }
}
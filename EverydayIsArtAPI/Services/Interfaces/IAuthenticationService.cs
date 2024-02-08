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
        ///     A result of login.
        /// </returns>
        Task<AuthorizationResult> Login(LoginRequest request);

        /// <summary>
        ///     Registers a new user.
        /// </summary>
        /// <param name="request">
        ///     A registration request data.
        /// </param>
        /// <returns>
        ///     A result of registration.
        /// </returns>
        Task<AuthorizationResult> Register(RegisterRequest request);
    }
}
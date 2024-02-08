using EverydayIsArtAPI.Exceptions;
using EverydayIsArtAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EverydayIsArtAPI.Services
{
    /// <inheritdoc cref="IAuthenticationService"/>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;

        public AuthenticationService(IConfiguration configuration, UserManager<User> userManager)
        {
            _config = configuration;
            _userManager = userManager;
        }

        public async Task<AuthorizationResult> Login(LoginRequest request)
        {
            User? user = await _userManager.FindByNameAsync(request.Username);
            user ??= await _userManager.FindByEmailAsync(request.Username);

            if (user is null)
            {
                return new AuthorizationResult(new BadUserRequestException($"Пользователя {request.Username} не существует."));
            }

            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return new AuthorizationResult(new BadUserRequestException($"Введён неверный пароль."));
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = GetToken(claims);

            return new AuthorizationResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<AuthorizationResult> Register(RegisterRequest request)
        {
            User? userByEmail = await _userManager.FindByEmailAsync(request.Email);
            User? userByUsername = await _userManager.FindByNameAsync(request.Username);

            if (userByEmail is not null || userByUsername is not null)
            {
                return new AuthorizationResult(new BadUserRequestException($"Пользователь с почтой {request.Email} или логином {request.Username} уже существует."));
            }

            User user = new()
            {
                Email = request.Email,
                UserName = request.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                //$"Unable to register user {request.Username} errors: {GetErrorsText(result.Errors)}";
                return new AuthorizationResult(new ArgumentException($"Невозможно зарегистрировать пользователя. Повторите позже."));
            }

            return await Login(new LoginRequest { Username = request.Email, Password = request.Password });
        }

        private string GetErrorsText(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(error => error.Description).ToArray());
        }

        private JwtSecurityToken GetToken(IEnumerable<Claim> claims)
        {
            SymmetricSecurityKey? signinKey = new(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

            JwtSecurityToken token = new(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(2),
                claims: claims,
                signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
using CuriousCatClone.Application.Features.Commands.User.Login;
using CuriousCatClone.Application.Features.Commands.User.Register;
using CuriousCatClone.Application.Services;
using CuriousCatClone.Domain.Entities;
using CuriousCatClone.Infrastructure.Utils;
using Microsoft.AspNetCore.Identity;

namespace CuriousCatClone.Presistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtTokenHandler _jwtHandler;

        public AuthService(UserManager<AppUser> userManager, JwtTokenHandler jwtHandler)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        public async Task<LoginCommandResponse> Login(LoginCommandRequest request)
        {
            AppUser? user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
                throw new Exception("Email or password is not valid");

            string accessToken = _jwtHandler.GenerateAccessToken(user);

            return new()
            {
                Token = accessToken
            };
        }

        public async Task<RegisterCommandResponse> Register(RegisterCommandRequest request)
        {
            string password = request.Password;

            if (password != request.PasswordConfirm)
                throw new Exception("Password and PasswordConfirm have to be the same");

            AppUser newUser = new()
            {
                Email = request.Email,
                UserName = request.Email
            };

            var result = await _userManager.CreateAsync(newUser, password);

            if (!result.Succeeded)
                // exception class
                //throw new Exception(result.Errors);
                throw new Exception("User could not be created");

            return new();
        }
    }
}

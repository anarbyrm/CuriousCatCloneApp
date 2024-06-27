using CuriousCatClone.Application.Features.Commands.User.Login;
using CuriousCatClone.Application.Features.Commands.User.Register;

namespace CuriousCatClone.Application.Services
{
    public interface IAuthService
    {
        Task<RegisterCommandResponse> Register(RegisterCommandRequest request);
        Task<LoginCommandResponse> Login(LoginCommandRequest request);
    }
}

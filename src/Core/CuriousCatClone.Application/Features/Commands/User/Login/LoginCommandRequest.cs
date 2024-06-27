using MediatR;

namespace CuriousCatClone.Application.Features.Commands.User.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

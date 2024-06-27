using MediatR;

namespace CuriousCatClone.Application.Features.Commands.User.Register
{
    public class RegisterCommandRequest : IRequest<RegisterCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}

using CuriousCatClone.Application.Services;
using MediatR;

namespace CuriousCatClone.Application.Features.Commands.User.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            LoginCommandResponse result = await _authService.Login(request);
            return result;
        }
    }
}

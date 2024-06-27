using CuriousCatClone.Application.Services;
using MediatR;

namespace CuriousCatClone.Application.Features.Commands.User.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            RegisterCommandResponse result = await _authService.Register(request);
            return result;
        }
    }
}

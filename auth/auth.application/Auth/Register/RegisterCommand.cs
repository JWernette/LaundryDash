using auth.application.Common.Interfaces;
using MediatR;

namespace auth.application.Auth.Register;

public record RegisterCommand(string email, string password) : IRequest<Unit>;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly IAuthRepository _authRepository;

    public RegisterCommandHandler(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _authRepository.RegisterAsync(request.email, request.password);

        return Unit.Value;
    }
}

using auth.application.Common.Interfaces;
using MediatR;

namespace auth.application.Auth.Register;

public record RegisterCommand(string email, string password, string accountType) : IRequest<Unit>;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly IAuthRepository _authRepository;

    public RegisterCommandHandler(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // tries to parse account type based on request, defaults to CUSTSOMER
        Enum.TryParse(request.accountType.ToUpper(), out AccountType accountType);

        await _authRepository.RegisterAsync(request.email, request.password, accountType);

        return Unit.Value;
    }
}

using auth.application.Common.Interfaces;
using MediatR;

namespace auth.application.Auth.Login;

public record LoginCommand(string email, string password) : IRequest<Unit>;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Unit>
{
    private readonly IAuthRepository _authRepository;

    public LoginCommandHandler(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        await _authRepository.LoginAsync(request.email, request.password);

        return Unit.Value;
    }
}

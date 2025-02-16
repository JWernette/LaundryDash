using auth.application.Common.Interfaces;

namespace auth.infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly Supabase.Client _client;

    public AuthRepository(Supabase.Client client)
    {
        _client = client;
    }

    public async Task LoginAsync(string username, string password)
    {
        await _client.Auth.SignIn(username, password);
    }

    public async Task RegisterAsync(string username, string password)
    {
        await _client.Auth.SignUp(username, password);
    }
}

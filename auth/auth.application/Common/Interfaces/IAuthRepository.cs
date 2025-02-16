namespace auth.application.Common.Interfaces;

/// <summary>
/// Creating interface in case we change providers
/// </summary>
public interface IAuthRepository
{
    public Task RegisterAsync(string username, string password);
    public Task LoginAsync(string username, string password);
}

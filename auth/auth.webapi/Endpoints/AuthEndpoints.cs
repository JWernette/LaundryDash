using auth.application.Auth.Login;
using auth.application.Auth.Register;
using auth.webapi.Common.Endpoints;
using MediatR;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapEndpoints(typeof(AuthEndpoints));
    }

    [Mapable]
    public static void Login(WebApplication app)
    {
        app.MapPost(
            AuthRoutes.Login,
            async (ISender sender, string email, string password) =>
            {
                var response = await sender.Send(new LoginCommand(email, password));
                return Results.Ok(response);
            }
        );
    }

    [Mapable]
    public static void Register(WebApplication app)
    {
        app.MapPost(
            AuthRoutes.Register,
            async (ISender sender, string email, string password) =>
            {
                var response = await sender.Send(new RegisterCommand(email, password));
                return Results.Ok(response);
            }
        );
    }
}

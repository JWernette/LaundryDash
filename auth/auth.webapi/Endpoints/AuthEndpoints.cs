using auth.application.Auth.Login;
using auth.application.Auth.Register;
using auth.webapi.Common.Endpoints;
using auth.webapi.Dtos;
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
                async (ISender sender, LoginDto login) =>
                {
                    var response = await sender.Send(new LoginCommand(login.email, login.password));
                    return Results.Ok(response);
                }
            )
            .RequireCors("AllowCors");
    }

    [Mapable]
    public static void Register(WebApplication app)
    {
        app.MapPost(
                AuthRoutes.Register,
                async (ISender sender, RegisterDto register) =>
                {
                    var response = await sender.Send(
                        new RegisterCommand(register.email, register.password, register.accountType)
                    );
                    return Results.Ok(response);
                }
            )
            .RequireCors("AllowCors");
    }
}

using Auth.Common;
using JobAssignments.API.Common;
using Supabase.Interfaces;

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
            async (Supabase.Client client, string email, string password) =>
            {
                // need to do something with the response
                var response = await client.Auth.SignIn(email, password);
                return Results.Ok(response);
            }
        );
    }

    [Mapable]
    public static void Register(WebApplication app)
    {
        app.MapPost(
            AuthRoutes.Register,
            async (Supabase.Client client, string email, string password) =>
            {
                // need to do something with the response
                var response = await client.Auth.SignUp(email, password);
                return Results.Ok(response);
            }
        );
    }
}

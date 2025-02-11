using Microsoft.Extensions.Diagnostics.HealthChecks;

public static class AuthRoutes
{
    // Get these routes from SupaBase
    public static string BaseApi = "auth";
    public static string Login = BaseApi + "/login";
    public static string Register = BaseApi + "/register";
}

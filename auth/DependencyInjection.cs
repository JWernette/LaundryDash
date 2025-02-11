namespace Auth;

public static class AuthServices
{
    public static IServiceCollection AddAuthServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddSupaBase(configuration);
        return services;
    }

    public static IServiceCollection AddSupaBase(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Supabase stuff?
        var url = configuration.GetValue<string>("SUPABASE_URL"); //Environment.GetEnvironmentVariable("SUPABASE_URL");
        var key = configuration.GetValue<string>("SUPABASE_KEY"); //Environment.GetEnvironmentVariable("SUPABASE_KEY");

        var options = new Supabase.SupabaseOptions { AutoConnectRealtime = true };

        services.AddSingleton(provider => new Supabase.Client(url, key, options));

        return services;
    }
}

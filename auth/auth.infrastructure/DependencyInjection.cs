using auth.application.Common.Interfaces;
using auth.infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace auth.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.RegisterServices();
        services.AddSupaBase(configuration);

        return services;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();

        return services;
    }

    public static IServiceCollection AddSupaBase(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var url = configuration.GetValue<string>("SUPABASE_URL");
        var key = configuration.GetValue<string>("SUPABASE_KEY");

        if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException("Supabase config is missing.");
        }

        var options = new Supabase.SupabaseOptions { AutoConnectRealtime = true };

        services.AddSingleton(provider => new Supabase.Client(url, key, options));

        return services;
    }
}

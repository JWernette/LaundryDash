namespace auth.webapi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                "AllowCors",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .WithMethods(
                            HttpMethod.Get.Method,
                            HttpMethod.Put.Method,
                            HttpMethod.Post.Method,
                            HttpMethod.Delete.Method
                        )
                        .AllowAnyHeader();
                }
            );
        });
        return services;
    }
}

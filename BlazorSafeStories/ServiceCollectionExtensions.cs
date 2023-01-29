using Microsoft.Extensions.DependencyInjection;

namespace BlazorSafeStories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDefaultUIExceptionHandler(this IServiceCollection services)
    {
        services.AddScoped<IUIExceptionReceiver, DefaultUIExceptionReceiver>();
        services.AddScoped<Run>();
        return services;
    }

    public static IServiceCollection AddUIExceptionHandler<T>(this IServiceCollection services)
        where T : class, IUIExceptionReceiver
    {
        services.AddScoped<IUIExceptionReceiver, T>();
        services.AddScoped<Run>();
        return services;
    }
}

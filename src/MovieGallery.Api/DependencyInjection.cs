using MovieGallery.Api.Mapping;

namespace MovieGallery.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();

        return services;
    }
}
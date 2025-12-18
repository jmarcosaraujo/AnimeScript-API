using Microsoft.Extensions.DependencyInjection;
using AnimeScript.Application.Interfaces;
using AnimeScript.Application.Services;

namespace AnimeScript.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRoteiroAppService, RoteiroAppService>();
        return services; // <--- ESSA LINHA É ESSENCIAL
    }
}
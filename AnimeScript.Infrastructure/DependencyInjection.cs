using Microsoft.Extensions.DependencyInjection;
using AnimeScript.Domain.Interfaces;
using AnimeScript.Infrastructure.Services;
using AnimeScript.Infrastructure.Repositories; // Agora este namespace existe!

namespace AnimeScript.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IScriptGeneratorService, ScriptGeneratorService>();
        services.AddScoped<IRoteiroRepository, RoteiroRepository>(); // Registro crucial
        
        return services;
    }
}
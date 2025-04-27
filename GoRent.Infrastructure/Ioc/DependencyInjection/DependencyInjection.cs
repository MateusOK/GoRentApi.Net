using GoRent.Domain.Repositories;
using GoRent.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GoRent.Infrastructure.Ioc.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICarRepository, CarRepository>();
        return services;
    }
}
using alabarre.Application.Intefaces.Authentication;
using alabarre.Application.Intefaces.Utiles;
using alabarre.Infrastructure.Authentication;
using alabarre.Infrastructure.Utiles;
using Microsoft.Extensions.DependencyInjection;

namespace alabarre.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}

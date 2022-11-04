using alabarre.Application.Intefaces.Authentication;
using alabarre.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace alabarre.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}

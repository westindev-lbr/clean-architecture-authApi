using alabarre.Application.Services;
using alabarre.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace alabarre.Application;

// permet d'injecter l'ensemble des services de notre couche Application et Infrastructure
public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}

﻿using alabarre.Application.Intefaces.Authentication;
using alabarre.Application.Intefaces.Utiles;
using alabarre.Infrastructure.Authentication;
using alabarre.Infrastructure.Utiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using alabarre.Application.Intefaces.Repository;
using alabarre.Infrastructure.Repository;

namespace alabarre.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}

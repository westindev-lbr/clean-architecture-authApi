using alabarre.Application;
using alabarre.Application.Services.Authentication;
using alabarre.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.         
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
}

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.UseAuthentication(); // Détermine l'identité de l'utilisateur
    app.UseAuthorization(); // Vérifie si l'utilisateur est autorisé à accéder au end-point
    app.MapControllers();
    app.Run();
}

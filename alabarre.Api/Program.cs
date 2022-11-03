using alabarre.Application;
using alabarre.Application.Services.Authentication;
using alabarre.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    // permet d'injecter l'ensemble des services de notre couche Application et Infrastructure
    builder.Services
        .AddApplication()
        .AddInfrastructure();

    builder.Services.AddControllers();
}

// Add services to the container.

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

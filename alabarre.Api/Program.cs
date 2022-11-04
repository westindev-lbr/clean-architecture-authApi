using alabarre.Application;
using alabarre.Application.Services.Authentication;
using alabarre.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.         
    builder.Services
        .AddApplication()
        .AddInfrastructure();

    builder.Services.AddControllers();
}

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

using alabarre.Application.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddScoped<IAuthService, AuthService>();
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

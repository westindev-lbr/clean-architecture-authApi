var builder = WebApplication.CreateBuilder(args);

{
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

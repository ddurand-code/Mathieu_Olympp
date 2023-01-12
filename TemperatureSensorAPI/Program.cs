var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

var app = builder.Build();

app.AddMiddlewares();

app.MapControllers();

app.Run();
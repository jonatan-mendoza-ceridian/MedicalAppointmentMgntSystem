using DataLayer;
using RabbitMQ;
using Users.RabbitMQ;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepositoryContrib>();
builder.Services.AddScoped<IRabbitDatalayer, RabbitDatalayer>();
var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
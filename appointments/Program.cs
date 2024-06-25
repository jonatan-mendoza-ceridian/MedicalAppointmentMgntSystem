using DataLayer;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
var app= builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
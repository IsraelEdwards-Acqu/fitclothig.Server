using FITClothing.API.Data;
using FITClothing.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    Environment.GetEnvironmentVariable(
        "DATABASE_CONNECTION_STRING")
    ?? builder.Configuration.GetConnectionString(
        "DefaultConnection");

// Database
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseNpgsql(connectionString);
    });

// Controllers
builder.Services.AddControllers();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("FitClothingPolicy",
        policy =>
        {
            policy
                .WithOrigins(
                    "https://fitclothing.vercel.app",
                    "https://www.fitclothing.vercel.app")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Services
builder.Services.AddScoped<CloudinaryService>();

var app = builder.Build();

app.UseCors("FitClothingPolicy");

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();

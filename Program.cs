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
// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "FitClothingPolicy",
        policy =>
        {
            policy
                .SetIsOriginAllowed(origin =>
                    origin.Contains("vercel.app") ||
                    origin.Contains("localhost"))
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Services
builder.Services.AddScoped<CloudinaryService>();

var app = builder.Build();

app.UseCors("FitClothingPolicy");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

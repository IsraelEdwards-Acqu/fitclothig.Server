using FITClothing.API.Data;
using FITClothing.Shared.Models;
using FITClothing.Shared.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        RegisterRequest request)
    {
        var user = new AppUser
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,

            // Temporary
            PasswordHash =
    BCrypt.Net.BCrypt.HashPassword(
        request.Password)
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return Ok();
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(
    LoginRequest request)
    {
        var user =
            _context.Users.FirstOrDefault(
                x => x.Email == request.Email);

        if (user is null)
        {
            return Unauthorized();
        }

        var valid =
            BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash);

        if (!valid)
        {
            return Unauthorized();
        }

        return Ok(
     new LoginResponse
     {
         UserId = user.Id,
         FirstName = user.FirstName,
         LastName = user.LastName,
         Email = user.Email,
         Role = user.Role
     });

    }
}
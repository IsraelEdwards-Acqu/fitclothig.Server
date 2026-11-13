using FITClothing.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/menu")]
public class MenuController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MenuController(
        ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{parent}")]
    public async Task<IActionResult> Get(
        string parent)
    {
        var items =
            await _context.MenuItems
                .Where(x =>
                    x.ParentCategory == parent &&
                    x.IsActive)
                .OrderBy(x =>
                    x.DisplayOrder)
                .ToListAsync();

        return Ok(items);
    }
}
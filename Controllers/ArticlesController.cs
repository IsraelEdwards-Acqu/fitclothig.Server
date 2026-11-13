using FITClothing.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticlesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ArticlesController(
        ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var articles =
            await _context.Articles
                .Where(x => x.IsPublished)
                .OrderByDescending(
                    x => x.PublishedDate)
                .ToListAsync();

        return Ok(articles);
    }
}
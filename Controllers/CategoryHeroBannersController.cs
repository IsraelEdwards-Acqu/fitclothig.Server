using FITClothing.API.Data;
using FITClothing.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/category-hero")]
public class CategoryHeroBannersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoryHeroBannersController(
        ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{slug}")]
    public async Task<ActionResult<CategoryHeroBanner>>
        Get(string slug)
    {
        var banner =
            await _context.CategoryHeroBanners
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x =>
                        x.CategorySlug == slug &&
                        x.IsActive);

        if (banner is null)
        {
            return NotFound();
        }

        return Ok(banner);
    }
}
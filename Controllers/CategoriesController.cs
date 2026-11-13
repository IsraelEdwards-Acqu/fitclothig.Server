using FITClothing.API.Data;
using FITClothing.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> Get()
    {
        var categories = await _context.Categories
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();

        return Ok(categories);
    }
    [HttpGet("{slug}/sections")]
    public async Task<IActionResult>
    GetSections(string slug)
    {
        var sections = await _context
            .CategorySections
            .Where(x =>
                x.CategorySlug == slug &&
                x.IsActive)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync();

        return Ok(sections);
    }

}
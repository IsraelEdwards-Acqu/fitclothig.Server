using FITClothing.API.Data;
using FITClothing.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _context.Products
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .AsNoTracking()
            .ToListAsync();

        return Ok(products);
    }

    [HttpGet("{slug}")]
    public async Task<ActionResult<Product>> GetProduct(string slug)
    {
        var product = await _context.Products
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .FirstOrDefaultAsync(x => x.Slug == slug);

        if (product == null)
            return NotFound();

        return Ok(product);
    }
    [HttpGet("category/{slug}")]
    public async Task<ActionResult<IEnumerable<Product>>>
    GetByCategory(string slug)
    {
        var products = await _context.Products
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .Where(x => x.Category!.Slug == slug)
            .ToListAsync();

        return Ok(products);
    }
    [HttpGet("id/{id:guid}")]
    public async Task<ActionResult<Product>>
    GetById(Guid id)
    {
        var product = await _context.Products
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }
    [HttpGet("featured")]
    public async Task<IActionResult> GetFeatured()
    {
        var products = await _context.Products
            .Where(x => x.IsFeatured)
            .ToListAsync();

        return Ok(products);
    }
}
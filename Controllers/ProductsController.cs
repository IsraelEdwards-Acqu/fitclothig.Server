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
    [HttpGet("new-arrivals")]
    public async Task<IActionResult> GetNewArrivals()
    {
        var products = await _context.Products
            .Where(x => x.IsActive)
            .Where(x => x.IsNewArrival)
            .OrderByDescending(x => x.DateAdded)
            .Take(12)
            .ToListAsync();

        return Ok(products);
    }
    [HttpGet("featured")]
    public async Task<IActionResult>
    GetFeaturedProducts()
    {
        var products =
            await _context.Products
                .Where(x => x.IsFeatured)
                .OrderBy(x => x.Name)
                .Take(8)
                .ToListAsync();

        return Ok(products);
    }
    [HttpGet("trending")]
    public async Task<IActionResult> GetTrendingProducts()
    {
        var products = await _context.Products
            .Where(x => x.IsTrending)
            .OrderBy(x => x.Name)
            .Take(12)
            .ToListAsync();

        return Ok(products);
    }
    [HttpGet("{slug}")]
    public async Task<IActionResult>
    GetBySlug(string slug)
    {
        var product =
            await _context.Products
                .FirstOrDefaultAsync(
                    x => x.Slug == slug);

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }
    [HttpGet("related/{categoryId}")]
    public async Task<IActionResult>
    GetRelatedProducts(
        Guid categoryId)
    {
        var products =
            await _context.Products
                .Where(x =>
                    x.CategoryId == categoryId &&
                    x.IsActive)
                .Take(8)
                .ToListAsync();

        return Ok(products);
    }
    [HttpGet("search")]
    public async Task<IActionResult>
    Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return Ok(new List<Product>());
        }

        var products =
            await _context.Products
                .Where(p =>
                    p.IsActive &&
                    (
                        p.Name.Contains(query) ||
                        p.Description.Contains(query) ||
                        p.BrandName.Contains(query)
                    ))
                .Take(10)
                .ToListAsync();

        return Ok(products);
    }
}
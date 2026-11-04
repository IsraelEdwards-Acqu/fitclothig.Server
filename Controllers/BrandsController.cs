using FITClothing.API.Data;
using FITClothing.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BrandsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Brand>>> Get()
    {
        var brands = await _context.Brands
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();

        return Ok(brands);
    }
}
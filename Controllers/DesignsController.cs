using FITClothing.API.Data;
using FITClothing.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DesignsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DesignsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Save(
     SaveDesignRequest request)
    {
        var design = new Design
        {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            Name = request.Name,
            DesignJson = request.DesignJson,
            PreviewImageUrl = request.PreviewImageUrl,
            CreatedAt = DateTime.UtcNow
        };

        _context.Designs.Add(design);

        await _context.SaveChangesAsync();

        return Ok(
            new DesignSaveResponse
            {
                Id = design.Id,
                Name = design.Name
            });
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(
    Guid id)
    {
        var design = await _context.Designs
            .FindAsync(id);

        if (design is null)
            return NotFound();

        return Ok(design);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var designs = await _context.Designs
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return Ok(designs);
    }
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
    Guid id,
    SaveDesignRequest request)
    {
        var design =
            await _context.Designs
                .FindAsync(id);

        if (design is null)
            return NotFound();

        design.Name = request.Name;
        design.DesignJson = request.DesignJson;
        design.PreviewImageUrl =
            request.PreviewImageUrl;

        design.UpdatedAt =
            DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(design);
    }
}

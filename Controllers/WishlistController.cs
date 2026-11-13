using FITClothing.API.Data;
using FITClothing.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WishlistController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public WishlistController(
        ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(
            await _context.WishlistItems
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Add(
        WishlistItem item)
    {
        item.Id = Guid.NewGuid();

        await _context.WishlistItems
            .AddAsync(item);

        await _context.SaveChangesAsync();

        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {
        var item =
            await _context.WishlistItems
                .FirstOrDefaultAsync(
                    x => x.Id == id);

        if (item is null)
            return NotFound();

        _context.WishlistItems.Remove(item);

        await _context.SaveChangesAsync();

        return Ok();
    }
}
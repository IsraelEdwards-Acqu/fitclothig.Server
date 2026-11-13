using FITClothing.API.Data;
using FITClothing.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddToCart(
        CartItem item)
    {
        _context.CartItems.Add(item);

        await _context.SaveChangesAsync();

        return Ok(item);
    }
    [HttpGet]
    public async Task<IActionResult>
    GetCartItems()
    {
        var items =
            await _context.CartItems
                .ToListAsync();

        return Ok(items);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult>
    Remove(Guid id)
    {
        var item =
            await _context.CartItems
                .FirstOrDefaultAsync(
                    x => x.Id == id);

        if (item == null)
            return NotFound();

        _context.CartItems.Remove(item);

        await _context.SaveChangesAsync();

        return Ok();
    }
}
using FITClothing.API.Data;
using FITClothing.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReviewsController(
        ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult>
        GetReviews(Guid productId)
    {
        var reviews =
            await _context.Reviews
                .Where(x =>
                    x.ProductId == productId)
                .OrderByDescending(
                    x => x.CreatedAt)
                .ToListAsync();

        return Ok(reviews);
    }

    [HttpPost]
    public async Task<IActionResult>
        Create(Review review)
    {
        review.Id = Guid.NewGuid();

        await _context.Reviews.AddAsync(review);

        await _context.SaveChangesAsync();

        return Ok(review);
    }
}
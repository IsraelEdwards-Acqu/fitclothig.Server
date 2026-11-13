using FITClothing.API.Data;
using FITClothing.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuoteRequestsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public QuoteRequestsController(
        ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        QuoteRequest request)
    {
        request.Id = Guid.NewGuid();

        request.QuoteNumber =
            $"QT-{DateTime.UtcNow:yyyy}-{Random.Shared.Next(10000, 99999)}";

        request.Status =
            "Quote Submitted";

        request.CreatedAt =
            DateTime.UtcNow;

        _context.QuoteRequests.Add(request);
        _context.QuoteStatusHistories.Add(
        new QuoteStatusHistory
        {
            Id = Guid.NewGuid(),
            QuoteRequestId = request.Id,
            Status = "Quote Submitted",
            Notes = "Quote request received.",
            CreatedAt = DateTime.UtcNow
        });
        await _context.SaveChangesAsync();

        return Ok(request);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(
            await _context.QuoteRequests
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync());
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
    Guid id,
    QuoteRequest request)
    {
        var quote =
            await _context.QuoteRequests
                .FindAsync(id);

        if (quote is null)
            return NotFound();

        quote.Status =
            request.Status;

        quote.QuotedAmount =
            request.QuotedAmount;

        await _context.SaveChangesAsync();

        return Ok(quote);
    }
}
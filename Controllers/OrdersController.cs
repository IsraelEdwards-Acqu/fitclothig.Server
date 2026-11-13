using FITClothing.API.Data;
using FITClothing.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;
public class UpdateOrderStatusRequest
{
    public string Status { get; set; } = "";

    public string Notes { get; set; } = "";
}
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrdersController(
        ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders =
            await _context.Orders
                .OrderByDescending(
                    x => x.CreatedAt)
                .ToListAsync();

        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(
     Order order)
    {
        order.Id = Guid.NewGuid();

        order.CreatedAt =
            DateTime.UtcNow;

        order.Status =
            "Quote Submitted";

        order.OrderNumber =
            $"FT-{DateTime.UtcNow:yyyy}-{Random.Shared.Next(10000, 99999)}";

        _context.Orders.Add(order);

        await _context.SaveChangesAsync();

        _context.OrderStatusHistories.Add(
            new OrderStatusHistory
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Status = "Quote Submitted",
                Notes =
                    "Order received successfully.",
                CreatedAt = DateTime.UtcNow
            });

        await _context.SaveChangesAsync();

        return Ok(order);
    }
    //[HttpPut("{id}/status")]
    //public async Task<IActionResult>
    //UpdateStatus(
    //    Guid id,
    //    string status)
    //{
    //    var order =
    //        await _context.Orders
    //            .FindAsync(id);

    //    if (order is null)
    //        return NotFound();

    //    order.Status = status;

    //    _context.OrderStatusHistories.Add(
    //        new OrderStatusHistory
    //        {
    //            Id = Guid.NewGuid(),
    //            OrderId = order.Id,
    //            Status = status,
    //            CreatedAt = DateTime.UtcNow
    //        });

    //    await _context.SaveChangesAsync();

    //    return Ok(order);
    //}
    [HttpGet("{id}/history")]
    public async Task<IActionResult> GetHistory(
    Guid id)
    {
        var history =
            await _context.OrderStatusHistories
                .Where(x => x.OrderId == id)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();

        return Ok(history);
    }
    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(
    Guid id,
    UpdateOrderStatusRequest request)
    {
        var order =
            await _context.Orders.FindAsync(id);

        if (order is null)
        {
            return NotFound();
        }

        order.Status = request.Status;

        _context.OrderStatusHistories.Add(
            new OrderStatusHistory
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Status = request.Status,
                Notes = request.Notes,
                CreatedAt = DateTime.UtcNow
            });

        await _context.SaveChangesAsync();

        return Ok(order);
    }
}
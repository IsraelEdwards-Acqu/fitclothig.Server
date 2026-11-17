using FITClothing.API.Data;
using FITClothing.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FITClothing.API.Controllers;
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
    [Authorize]
    public async Task<IActionResult> GetOrders()
    {
        var ordersQuery = _context.Orders
            .OrderByDescending(x => x.CreatedAt)
            .AsQueryable();

        if (!User.IsInRole("Admin"))
        {
            ordersQuery = ordersQuery.Where(
                x => x.CustomerId == GetUserId());
        }

        var orders = await ordersQuery.ToListAsync();

        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var isAdmin = User.IsInRole("Admin");
        var userId = isAdmin ? Guid.Empty : GetUserId();

        var order = await _context.Orders
            .AsNoTracking()
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x =>
                x.Id == id
                && (isAdmin || x.CustomerId == userId));

        return order is null
            ? NotFound()
            : Ok(order);
    }

    [HttpGet("track/{orderNumber}")]
    public async Task<IActionResult> Track(string orderNumber)
    {
        var order = await _context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.OrderNumber == orderNumber);

        return order is null
            ? NotFound()
            : Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(
     Order order)
    {
        order.Id = Guid.NewGuid();

        if (User.Identity?.IsAuthenticated == true)
        {
            order.CustomerId = GetUserId();
        }

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
    [Authorize(Roles = "Admin")]
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

    private Guid GetUserId()
    {
        var value = User.FindFirstValue(
            ClaimTypes.NameIdentifier);

        return Guid.Parse(value!);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class Order
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public string CustomerName { get; set; } = "";

    public string Email { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public string ShippingAddress { get; set; } = "";

    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;
    private readonly Dictionary<Guid, string> Notes = new(); 
    public ICollection<OrderItem> Items { get; set; }
        = new List<OrderItem>();
    public string Status { get; set; }
     = "Quote Submitted";
    public ICollection<OrderStatusHistory>
    StatusHistory
    { get; set; }
    = new List<OrderStatusHistory>();
    public string OrderNumber { get; set; }
    = "";
    public int ProgressPercentage =>
    Status switch
    {
        "Quote Submitted" => 10,
        "Artwork Review" => 20,
        "Quote Sent" => 30,
        "Approved" => 40,
        "Production" => 60,
        "Printing" => 80,
        "Quality Check" => 90,
        "Ready For Delivery" => 95,
        "Delivered" => 100,
        _ => 0
    };
}
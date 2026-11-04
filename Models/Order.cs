using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class Order
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; }
        = "Pending";

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;
}

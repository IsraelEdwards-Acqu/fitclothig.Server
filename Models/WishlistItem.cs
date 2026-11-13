using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class WishlistItem
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = "";

    public string ProductSlug { get; set; } = "";

    public string ImageUrl { get; set; } = "";

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class Cart
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public ICollection<CartItem> Items { get; set; }
        = new List<CartItem>();

    public decimal GrandTotal =>
        Items.Sum(x => x.TotalPrice);
}

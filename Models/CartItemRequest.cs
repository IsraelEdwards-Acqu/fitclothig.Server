using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class CartItemRequest
{
    public Guid ProductId { get; set; }

    public Guid DesignId { get; set; }

    public int Quantity { get; set; }
}

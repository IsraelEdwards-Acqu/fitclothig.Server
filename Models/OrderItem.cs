using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public Guid DesignId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}

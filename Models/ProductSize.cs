using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class ProductSize
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid ProductId { get; set; }
}

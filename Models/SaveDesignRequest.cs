using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class SaveDesignRequest
{
    public Guid ProductId { get; set; }

    public string DesignName { get; set; } = string.Empty;

    public string DesignJson { get; set; } = string.Empty;
}

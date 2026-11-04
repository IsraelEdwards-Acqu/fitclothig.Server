using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FITClothing.Shared.Models;

public class Design
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string DesignJson { get; set; } = string.Empty;

    public string PreviewImageUrl { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;
}

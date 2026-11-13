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

    public Guid? CustomerId { get; set; }

    public string Name { get; set; } = "";

    public string DesignJson { get; set; } = "";

    public string PreviewImageUrl { get; set; } = "";

    public bool IsDraft { get; set; } = true;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

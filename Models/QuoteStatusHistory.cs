using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class QuoteStatusHistory
{
    public Guid Id { get; set; }

    public Guid QuoteRequestId { get; set; }

    public string Status { get; set; } = "";

    public string Notes { get; set; } = "";

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;
}

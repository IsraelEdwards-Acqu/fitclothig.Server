using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class QuoteRequest
{
    public Guid Id { get; set; }

    public string QuoteNumber { get; set; } = "";

    public string CustomerName { get; set; } = "";

    public string Email { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public string OrganizationName { get; set; } = "";

    public string ProductType { get; set; } = "";

    public int Quantity { get; set; }

    public string ArtworkUrl { get; set; } = "";

    public string Notes { get; set; } = "";

    public decimal? QuotedAmount { get; set; }

    public string Status { get; set; }
        = "Quote Submitted";

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;
    public ICollection<QuoteStatusHistory>
    StatusHistory
    { get; set; }
    = new List<QuoteStatusHistory>();
    public int ProgressPercentage =>
        Status switch
        {
            "Quote Submitted" => 10,
            "Artwork Review" => 20,
            "Quote Sent" => 40,
            "Approved" => 60,
            "Production" => 75,
            "Printing" => 85,
            "Quality Check" => 95,
            "Delivered" => 100,
            _ => 0
        };
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class CategoryHeroBanner
{
    public Guid Id { get; set; }

    public string CategorySlug { get; set; } = "";

    public string Title { get; set; } = "";

    public string Subtitle { get; set; } = "";

    public string ButtonText { get; set; } = "";

    public string ButtonLink { get; set; } = "";

    public string ImageUrl { get; set; } = "";

    public bool IsActive { get; set; }
}

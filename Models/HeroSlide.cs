using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class HeroSlide
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Subtitle { get; set; } = string.Empty;

    public string ButtonText { get; set; } = string.Empty;

    public string ButtonLink { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;
}

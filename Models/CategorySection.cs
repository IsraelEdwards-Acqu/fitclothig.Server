using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class CategorySection
{
    public Guid Id { get; set; }

    public string CategorySlug { get; set; } = "";

    public string SectionType { get; set; } = "";

    public string Title { get; set; } = "";

    public string ImageUrl { get; set; } = "";

    public string LinkUrl { get; set; } = "";

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }
}

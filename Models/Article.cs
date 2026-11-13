using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class Article
{
    public Guid Id { get; set; }

    public string Title { get; set; } = "";

    public string Summary { get; set; } = "";

    public string ImageUrl { get; set; } = "";

    public string Slug { get; set; } = "";

    public DateTime PublishedDate { get; set; }

    public bool IsPublished { get; set; }
}

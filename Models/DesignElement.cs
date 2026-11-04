using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class DesignElement
{
    public Guid Id { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public double X { get; set; }

    public double Y { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Rotation { get; set; }
}
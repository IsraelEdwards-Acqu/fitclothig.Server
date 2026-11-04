using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class DesignDocument
{
    public List<DesignTextDto> TextElements { get; set; }
        = new();

    public List<LogoElementDto> Logos { get; set; }
        = new();
}

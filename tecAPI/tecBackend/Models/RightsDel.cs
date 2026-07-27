using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class RightsDel
{
    public sbyte IdLink { get; set; }

    public int IdUser { get; set; }

    /// <summary>
    /// тип права
    /// </summary>
    public string Type { get; set; } = null!;
}

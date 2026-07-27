using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Link
{
    public sbyte Id { get; set; }

    public sbyte Nn { get; set; }

    public string Name { get; set; } = null!;

    public string Link1 { get; set; } = null!;

    public bool IdGroup { get; set; }

    public string IdGroupAll { get; set; } = null!;
}

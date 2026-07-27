using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Section
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public string Link { get; set; } = null!;

    public short IdLink { get; set; }

    public int ParentId { get; set; }

    public string? ImgLink { get; set; }

    public int? Sort { get; set; }
}

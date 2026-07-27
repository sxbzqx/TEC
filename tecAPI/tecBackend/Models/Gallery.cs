using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Gallery
{
    public short Id { get; set; }

    public string NameFolder { get; set; } = null!;

    public short IdState { get; set; }

    public string NameGallery { get; set; } = null!;

    public DateTime DateAdd { get; set; }

    public string Directory { get; set; } = null!;
}

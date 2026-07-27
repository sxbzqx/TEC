using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Techdoc
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string User { get; set; } = null!;

    public string Department { get; set; } = null!;

    public int? OtdId { get; set; }

    public DateTime DateFirst { get; set; }

    public DateTime DateNext { get; set; }

    public string Shifr { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Sootv
{
    public short Id { get; set; }

    public short IdDepNo { get; set; }

    public short IdDep { get; set; }

    public string IdDepOld { get; set; } = null!;

    public string? Name { get; set; }

    public int? IdOtdBuhgalter { get; set; }
}

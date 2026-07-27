using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Otdel
{
    public int Id { get; set; }

    public short IdOtd { get; set; }

    public string NameOtd { get; set; } = null!;

    public int? IdDep { get; set; }

    public sbyte? IdOtdBuhgalter { get; set; }
}

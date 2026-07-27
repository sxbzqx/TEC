using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class SootvOldForDel
{
    public short Id { get; set; }

    public short IdDep { get; set; }

    public string? Name { get; set; }

    public int? IdOtdBuhgalter { get; set; }
}

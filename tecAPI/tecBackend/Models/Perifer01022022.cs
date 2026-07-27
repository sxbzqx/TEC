using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Perifer01022022
{
    public short Id { get; set; }

    public string IdOtd { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string UserDep { get; set; } = null!;

    public string InvNum { get; set; } = null!;

    public string TypeSelen { get; set; } = null!;

    public short ReplaceSelen { get; set; }

    public short NumZaprSelen { get; set; }

    public short NumZapr { get; set; }

    public string TypeCartr { get; set; } = null!;

    public string SerialNumber { get; set; } = null!;

    public string TypeToner { get; set; } = null!;

    public short KolToner { get; set; }

    public short InputMonth { get; set; }

    public int InputYear { get; set; }
}

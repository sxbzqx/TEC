using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class OfficeRepairDo31012022
{
    public short Id { get; set; }

    public short IdUstr { get; set; }

    public short IdResource { get; set; }

    public DateTime DateRepair { get; set; }

    public string TypeUstr { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public short IdClaim { get; set; }

    public string OtherOption { get; set; } = null!;
}

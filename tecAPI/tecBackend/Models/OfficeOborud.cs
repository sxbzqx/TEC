using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class OfficeOborud
{
    public short Id { get; set; }

    public string IdOtd { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string UserDep { get; set; } = null!;

    public string InvNum { get; set; } = null!;

    public string SerialNumber { get; set; } = null!;

    public short InputMonth { get; set; }

    public int InputYear { get; set; }

    /// <summary>
    /// комментарий
    /// </summary>
    public string Comment { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class ComputersOriginaldo31012022
{
    public short Id { get; set; }

    public string IdOtd { get; set; } = null!;

    public string NameObj { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string UserDep { get; set; } = null!;

    public string UserFio { get; set; } = null!;

    public int InvNum { get; set; }

    public string Cpu { get; set; } = null!;

    public string Ram1 { get; set; } = null!;

    public string Ram2 { get; set; } = null!;

    public string Hdd1 { get; set; } = null!;

    public string Hdd2 { get; set; } = null!;

    public string Optical1 { get; set; } = null!;

    public string Video { get; set; } = null!;

    public string Audio { get; set; } = null!;

    public string Speakers { get; set; } = null!;

    public string Fdd { get; set; } = null!;

    public string Monitor { get; set; } = null!;

    public short InputMonth { get; set; }

    public short InputYear { get; set; }

    /// <summary>
    /// если комп=0, если ноут=1
    /// </summary>
    public string Nout { get; set; } = null!;
}

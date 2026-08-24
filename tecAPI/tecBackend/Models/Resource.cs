using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Resource
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Код отдела, который исполняет эту заявку
    /// </summary>
    public string IdOtd { get; set; } = null!;

    public short? IdParent { get; set; }

    /// <summary>
    /// 1=замена, 2=установка
    /// </summary>
    public string Priznak { get; set; } = null!;
}

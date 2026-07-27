using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class BiznesplanoksVariant
{
    public int Id { get; set; }

    /// <summary>
    /// ТИП БП: 1 - Ремонты, 2 - ОКС
    /// </summary>
    public string TypeBp { get; set; } = null!;

    public string Year { get; set; } = null!;

    public sbyte Variant { get; set; }

    public string Comment { get; set; } = null!;

    /// <summary>
    /// =1 -тот БП, с которым работаем сейчас
    /// </summary>
    public string Main { get; set; } = null!;

    /// <summary>
    /// дата создания копии БП
    /// </summary>
    public DateTime Datecreate { get; set; }
}

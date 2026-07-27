using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Archiveld
{
    public int Id { get; set; }

    /// <summary>
    /// ссылка на таблицу уволенных OK_TESB
    /// </summary>
    public int KodOk { get; set; }

    public string Tabel { get; set; } = null!;

    public string Fio { get; set; } = null!;

    public DateTime DatePriem { get; set; }

    public DateTime DateUvol { get; set; }

    public string Comment { get; set; } = null!;
}

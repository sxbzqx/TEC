using System;
using System.Collections.Generic;

namespace tecBackend.Models;

/// <summary>
/// Справочник сотрудников
/// </summary>
public partial class WorkersEmpty
{
    public string Ids { get; set; } = null!;

    public string Tabel { get; set; } = null!;

    public string Fio { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Mphone { get; set; } = null!;

    public string Doljnost { get; set; } = null!;

    public string Otdel { get; set; } = null!;

    public string OtdelId { get; set; } = null!;

    /// <summary>
    /// категория работника (начальники/мастера и т.д.)
    /// </summary>
    public string KategoriyaId { get; set; } = null!;

    public string KategoriyaName { get; set; } = null!;

    public DateTime Dr { get; set; }

    public DateTime DatePriem { get; set; }

    public int Id { get; set; }
}

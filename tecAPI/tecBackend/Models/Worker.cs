using System;
using System.Collections.Generic;

namespace tecBackend.Models;

/// <summary>
/// Справочник сотрудников
/// </summary>
public partial class Worker
{
    public string Ids { get; set; } = null!;

    public string Tabel { get; set; } = null!;

    public string Fio { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Doljnost { get; set; } = null!;

    /// <summary>
    /// отдел рус.полностью
    /// </summary>
    public string Otdel { get; set; } = null!;

    public string OtdelId { get; set; } = null!;

    /// <summary>
    /// категория работника (начальники/мастера и т.д.)
    /// </summary>
    public string KategoriyaId { get; set; } = null!;

    /// <summary>
    /// наименование категории работника
    /// </summary>
    public string KategoriyaName { get; set; } = null!;

    public DateTime Dr { get; set; }

    public DateTime DatePriem { get; set; }

    public int Id { get; set; }

    /// <summary>
    /// отдел рус. кратко
    /// </summary>
    public string OtdelRusS { get; set; } = null!;

    /// <summary>
    /// отдел кирг. полностью
    /// </summary>
    public string OtdelKyrB { get; set; } = null!;

    /// <summary>
    /// отдел кирг.кратко
    /// </summary>
    public string OtdelKyrS { get; set; } = null!;
}

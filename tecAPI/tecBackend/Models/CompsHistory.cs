using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class CompsHistory
{
    public int Id { get; set; }

    /// <summary>
    /// id записи в таблице
    /// </summary>
    public short IdStr { get; set; }

    /// <summary>
    /// имя столбца
    /// </summary>
    public string Field { get; set; } = null!;

    /// <summary>
    /// старое значение
    /// </summary>
    public string Old { get; set; } = null!;

    /// <summary>
    /// новое значение
    /// </summary>
    public string New { get; set; } = null!;

    /// <summary>
    /// ФИО изменившего пользователя
    /// </summary>
    public string User { get; set; } = null!;

    /// <summary>
    /// дата изменения
    /// </summary>
    public DateTime Date { get; set; }
}

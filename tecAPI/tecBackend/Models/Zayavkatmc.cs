using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Zayavkatmc
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string IdDep { get; set; } = null!;

    public DateTime Date { get; set; }

    /// <summary>
    /// действие: 0-новая,1-прочитанная,2-выполненная,3-отложенная,4-отказная
    /// </summary>
    public string Action { get; set; } = null!;

    /// <summary>
    /// дата разрешения заявки
    /// </summary>
    public DateTime DateAction { get; set; }

    public string Rem { get; set; } = null!;

    public string Sposob { get; set; } = null!;

    public string Kvartal { get; set; } = null!;

    public string IdOborud { get; set; } = null!;

    public string IdWork { get; set; } = null!;
}

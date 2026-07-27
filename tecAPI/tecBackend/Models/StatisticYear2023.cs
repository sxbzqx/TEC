using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class StatisticYear2023
{
    public int Id { get; set; }

    public short? Year { get; set; }

    public int? IdResource { get; set; }

    public short? Amount { get; set; }

    public string IdDep { get; set; } = null!;

    public string IdDepReceiver { get; set; } = null!;

    public DateTime? Date { get; set; }
}

using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class PerMe
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public int? IdReceiver { get; set; }

    public string IdSender { get; set; } = null!;

    public DateTime? Date { get; set; }

    public int Readed { get; set; }

    public string? Comment { get; set; }

    public string? Knopka { get; set; }

    public short? IdDoc { get; set; }
}

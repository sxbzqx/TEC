using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Message
{
    public short Id { get; set; }

    public string? Text { get; set; }

    public DateTime Date { get; set; }

    public int IdAuthor { get; set; }
}

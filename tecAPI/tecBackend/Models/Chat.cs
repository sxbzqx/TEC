using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Chat
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int User { get; set; }

    public string Message { get; set; } = null!;
}

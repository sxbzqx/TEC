using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Announ
{
    public short Id { get; set; }

    public string? Name { get; set; }

    public string? Text { get; set; }

    public DateTime Date { get; set; }

    public int IdAuthor { get; set; }

    public int IdAuthorEdit { get; set; }
}

using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class State
{
    public short Id { get; set; }

    public string? About { get; set; }

    public short? Section { get; set; }

    public string Name { get; set; } = null!;

    public string? Text { get; set; }

    public int IdAuthor { get; set; }

    public DateTime Date { get; set; }

    public DateTime? DateEdit { get; set; }

    public int IdAuthorEdit { get; set; }

    public int IdHozState { get; set; }

    public int MainPage { get; set; }
}

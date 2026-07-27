using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Comment
{
    public int Id { get; set; }

    public short IdState { get; set; }

    public short IdUser { get; set; }

    public string FioUser { get; set; } = null!;

    public string Comment1 { get; set; } = null!;

    public DateTime Date { get; set; }

    public DateTime DateEdit { get; set; }

    public string FioUserEdit { get; set; } = null!;

    public string ReasonEdit { get; set; } = null!;
}

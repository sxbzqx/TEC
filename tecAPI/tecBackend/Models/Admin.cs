using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Admin
{
    public short Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Question { get; set; }

    public string? Answer { get; set; }
}

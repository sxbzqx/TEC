using System;
using System.Collections.Generic;

namespace tecBackend.Models;

/// <summary>
/// prikazy
/// </summary>
public partial class Order
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public DateTime Date { get; set; }

    public sbyte Type { get; set; }

    public string Text { get; set; } = null!;
}

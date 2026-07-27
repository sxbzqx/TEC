using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class TypeDoc
{
    public sbyte Id { get; set; }

    public string Name { get; set; } = null!;

    public sbyte IdParent { get; set; }
}

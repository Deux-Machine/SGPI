using System;
using System.Collections.Generic;

namespace SGPI.Models;

public partial class TipoHomologacion
{
    public int IdTipoHomologacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdHomologacion { get; set; }
}

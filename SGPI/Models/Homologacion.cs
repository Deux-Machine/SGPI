using System;
using System.Collections.Generic;

namespace SGPI.Models;

public partial class Homologacion
{
    public int IdHomologacion { get; set; }

    public string AsignaturaAnterior { get; set; } = null!;

    public int CreditoAnterioro { get; set; }

    public int Nivel { get; set; }

    public int IdPrograma { get; set; }

    public string AsigntauraNueva { get; set; } = null!;

    public int CreditoNuevo { get; set; }

    public int Nota { get; set; }

    public int IdUsuario { get; set; }
}

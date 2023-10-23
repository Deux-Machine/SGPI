using System;
using System.Collections.Generic;

namespace SGPI.Models;

public partial class Pago
{
    public double IdPago { get; set; }

    public string FechaPago { get; set; } = null!;

    public string Recibo { get; set; } = null!;

    public int IdUsuario { get; set; }
}

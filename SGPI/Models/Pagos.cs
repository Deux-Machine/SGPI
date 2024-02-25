using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SGPI.Models;

public partial class Pagos
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id_Pagos")]
    public int Id_Pagos { get; set; }

    public string Fecha_Pago { get; set; } = null!;

    public byte[]? ArchivoRecibo { get; set; } = null!;

    public int Valor { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SGPI.Models;

public partial class Homologacion
{
    [Key] // Esto indica que IdGenero es la clave primaria
    [Column("Id_Homologacion")]
    public int Id_Homologacion { get; set; }

    public string AsignaturaAnterior { get; set; } = null!;

    public int CreditoAnterioro { get; set; }

    public int Nivel { get; set; }

    public int Id_Programa { get; set; }

    public string AsigntauraNueva { get; set; } = null!;

    public int CreditoNuevo { get; set; }

    public int Nota { get; set; }

    public int Id_Usuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}

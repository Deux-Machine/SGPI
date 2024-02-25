using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SGPI.Models;

public partial class TipoHomologacion
{
    [Key] // Esto indica que Id_Doc es la clave primaria
    [Column("Id_TipoHomologacion")]
    public int Id_TipoHomologacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Id_Homologacion { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

}

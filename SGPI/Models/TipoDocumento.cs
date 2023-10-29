using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SGPI.Models;


public partial class TipoDocumento
{
    [Key] // Esto indica que Id_Doc es la clave primaria
    [Column("Id_Doc")]
    public int Id_Doc { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

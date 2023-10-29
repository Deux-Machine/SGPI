using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SGPI.Models;

public partial class Genero
{
    [Key] // Esto indica que IdGenero es la clave primaria
    [Column("Id_Genero")]
    public int Id_Genero { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
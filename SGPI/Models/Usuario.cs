using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGPI.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string PrimerApellido { get; set; } = null!;

    public string SegundoApellido { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int NumDoc { get; set; }

    public bool Activo { get; set; }

    public int IdDoc { get; set; }

    public int IdGenero { get; set; }

    public int IdPrograma { get; set; }

    public int IdRol { get; set; }

    public virtual TipoDocumento IdDocNavigation { get; set; } = null!;

    public virtual Genero IdGeneroNavigation { get; set; } = null!;

    public virtual Rol IdRolNavigation { get; set; } = null!;

}

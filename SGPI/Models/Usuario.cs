using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SGPI.Models;

public partial class Usuario
{


    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id_Usuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string PrimerApellido { get; set; } = null!;

    public string SegundoApellido { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int NumDoc { get; set; }

    public bool Activo { get; set; }

    public int Id_Doc { get; set; }

    public int Id_Genero { get; set; }

    public int Id_Programa { get; set; }

    public int Id_Rol { get; set; }

    //Quitar si no funciona el programa
    public virtual TipoDocumento IdDocNavigation { get; set; } = null!;
    public virtual Genero IdGeneroNavigation { get; set; } = null!;
    public virtual Rol IdRolNavigation { get; set; } = null!;
    //public virtual Programa IdProgramaNavigation { get; set; } = null!;

}

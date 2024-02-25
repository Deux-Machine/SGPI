using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGPI.Models;
using System;
using System.Linq;


namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {

        SgpiContext contexto;

        public EstudianteController(SgpiContext context)
        {
            contexto = new SgpiContext();
        }



        public IActionResult ModificarUsuario(int? Id_Usuario)
        {
            Usuario usuario = contexto.Usuarios.Find(Id_Usuario);

            if (usuario == null)
            {
                return ViewBag.mensaje = "Error al editar el Usuario";
            }

            ViewBag.Genero = contexto.Generos.ToList();
            ViewBag.documento = contexto.TipoDocumentos.ToList();
            ViewBag.rol = contexto.Rols.ToList();
            ViewBag.programa = contexto.Programas.ToList();

            return View(usuario);
        }

        [HttpPost]
        public IActionResult ModificarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return ViewBag.mensaje = "Error al editar el Usuario";
            }

            Usuario user = contexto.Usuarios.Find(usuario.Id_Usuario);

            if (user != null)
            {
                user.Nombre = usuario.Nombre;
                user.PrimerApellido = usuario.PrimerApellido;
                user.SegundoApellido = usuario.SegundoApellido;
                user.Id_Genero = usuario.Id_Genero;
                user.Email = usuario.Email;
                user.Id_Programa = usuario.Id_Programa;
                user.Password = usuario.Password;
                user.Id_Rol = usuario.Id_Rol;
                user.NumDoc = usuario.NumDoc;
                user.Activo = usuario.Activo;

                contexto.Update(user);
                contexto.SaveChanges();
            }

            return RedirectToAction("Pagos", "Estudiante");
        }




        public IActionResult Pagos()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Pagos(Pagos usuario, IFormFile ArchivoRecibo)
        {
            if (ModelState.IsValid && ArchivoRecibo != null)
            {
                // Convertir el archivo a un arreglo de bytes
                using (var memoryStream = new MemoryStream())
                {
                    ArchivoRecibo.CopyTo(memoryStream);
                    usuario.ArchivoRecibo = memoryStream.ToArray();
                }

                // Guardar el pago en la base de datos
                contexto.Pagos.Add(usuario);
                contexto.SaveChanges();

                // Redirigir a la vista de pagos
                return RedirectToAction("Pagos");
            }

            // Si hay errores de validación o el archivo es nulo, regresar a la vista de pagos
            return View(usuario);
        }




    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGPI.Models;
using System;
using System.Linq;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SgpiContext contexto;

        public AdministradorController(SgpiContext context)
        {
            contexto = new SgpiContext();
        }

        // GET: AdministradorController
        public ActionResult MenuAdministrador()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            ViewBag.Genero = contexto.Generos.ToList();
            ViewBag.rol = contexto.Rols.ToList();
            ViewBag.documento = contexto.TipoDocumentos.ToList();
            ViewBag.programa = contexto.Programas.ToList();

            return View();
        }
        /// <summary>
        /// POST: Crea el usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Datos guardados</returns>
        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            ViewBag.Genero = contexto.Generos.ToList();
            ViewBag.rol = contexto.Rols.ToList();
            ViewBag.documento = contexto.TipoDocumentos.ToList();
            ViewBag.programa = contexto.Programas.ToList();

            // Consulta la tabla para obtener el valor más alto actual en Id_Usuario
            //Con el fin de evitar duplicados en el ID
            //int maxId = contexto.Usuarios.Max(u => u.Id_Usuario);

            // Asigna un valor único incrementado el mas alto encontrado
            //usuario.Id_Usuario = maxId + 1;

            contexto.Add(usuario);
            contexto.SaveChanges();


            return View();
        }

        public IActionResult BuscarUsuario()
        {
            ViewBag.documento = contexto.TipoDocumentos.ToList();// buscar usuario

            return View();
        }

        [HttpPost]
        public IActionResult BuscarUsuario(Usuario usuario)
        {
            var us = contexto.Usuarios
                .Where(u => u.NumDoc == usuario.NumDoc
                && u.Id_Doc == usuario.Id_Doc).FirstOrDefault();

            if (us != null)
            {
                ViewBag.Genero = contexto.Generos.ToList();
                ViewBag.documento = contexto.TipoDocumentos.ToList();
                ViewBag.rol = contexto.Rols.ToList();
                ViewBag.programa = contexto.Programas.ToList();
                return View(us);
            }

            else
            {
                ViewBag.documento = contexto.TipoDocumentos.ToList();
                return View();
            }
        }

        public IActionResult ModificarUsuario(int? Id_Usuario)//modificar usuario

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
            else
            {
                Usuario user = contexto.Usuarios.Find(usuario.Id_Usuario);

                int idUser = usuario.Id_Usuario;

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
            }
            return RedirectToAction("BuscarUsuario", "Administrador");

        }


        public ActionResult Borrar(int Id_Usuario)
        {
            try
            {

                var usuario = contexto.Usuarios.Include(u => u.Homologacions).FirstOrDefault(u => u.Id_Usuario == Id_Usuario);

                if (usuario == null)
                {
                    ViewBag.mensaje = "Error al eliminar el Usuario";
                }
                else
                {
                    // Recuperar las homologaciones asociadas
                    var homologaciones = usuario.Homologacions.ToList();

                    // Eliminar las homologaciones
                    contexto.Homologacions.RemoveRange(homologaciones);

                    // Luego, eliminar el usuario
                    contexto.Usuarios.Remove(usuario);

                    // Guardar los cambios
                    contexto.SaveChanges();

                    ViewBag.mensaje = "Usuario y Homologaciones eliminados correctamente";
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = $"Error durante la eliminación: {ex.Message}";
            }

            return RedirectToAction("BuscarUsuario", "Administrador");
        }




        [HttpPost]
        public IActionResult Login(Usuario user)
        {

            var usuario = contexto.Usuarios//Login si el usuario es correcto entra
                .Where(consulta => consulta.NumDoc == user.NumDoc
                && consulta.Password == user.Password).FirstOrDefault();

            if (usuario != null)
            {
                if (usuario.Id_Rol == 1)
                {
                    return Redirect("Administrador/BuscarUsuario");//redirije a menu administrador
                }
                else if (usuario.Id_Rol == 2)
                {
                    return Redirect("Coordinador/Pagos");//redirige a menu coordinador
                }
                else if (usuario.Id_Rol == 3)
                {
                    return Redirect("Estudiante/Actualizar");//redirige a estudiante
                }
                else
                {
                }
            }
            else { }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

    }
}
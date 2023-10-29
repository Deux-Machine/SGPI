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
            int maxId = contexto.Usuarios.Max(u => u.Id_Usuario);

            // Asigna un valor único incrementado el mas alto encontrado
            usuario.Id_Usuario = maxId + 1;

            contexto.Add(usuario);
            contexto.SaveChanges();


            return View();
        }

        /// <summary>
        /// Consulta los Drop down para la vista de creación de usuarios
        /// </summary>
        /// <returns></returns>
        /*public IActionResult ModificarUsuario()
        {
            ViewBag.genero = contexto.Generos.ToList();
            ViewBag.rol = contexto.Rols.ToList();
            ViewBag.tipoDocumento = contexto.TipoDocumentos.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult BuscarUsuario(Usuario usuario)
        {
            var us = contexto.Usuarios
                .Where(u => u.NumDoc
                .Contains(usuario.NumDoc));

            return View();
        }
        */

        //---------------------------------------------------------------------//

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
                ViewBag.documento = contexto.TipoDocumentos.ToList();
                return View(us);
            }

            else
            {
                ViewBag.documento = contexto.TipoDocumentos.ToList();
                return View();
            }
        }

    }
}




























        /*

        [HttpPost]
        public IActionResult Login(Usuario user)
        {

            var usuario = contexto.Usuarios//Login si el usuario es correcto entra
                .Where(consulta => consulta.NumDoc == user.NumDoc
                && consulta.Password == user.Password).FirstOrDefault();

            if (usuario != null)
            {
                if (usuario.IdRol == 1)
                {
                    return Redirect("Administrador/AdminBuscar");//redirije a menu administrador
                }
                else if (usuario.IdRol == 2)
                {
                    return Redirect("Coordinador/MenuCoordinadorBuscar");//redirije a menu coordinador
                }
                else if (usuario.IdRol == 3)
                {
                    return Redirect("Estudiante/ActualizarEstudiante");//redirijhe a estudiante
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

        public IActionResult OlvidarContrasena()
        {
            return View();
        }

        public IActionResult MenuRegistro() //registro de usuarios
        {
            ViewBag.genero = contexto.Generos.ToList();
            ViewBag.rol = contexto.Rols.ToList();
            ViewBag.documento = contexto.TipoDocumentos.ToList(); //validar el Documentos
            ViewBag.programa = contexto.Programas.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult MenuRegistro(Usuario usuario)
        {
            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();
            ViewBag.genero = contexto.Generos.ToList();
            ViewBag.rol = contexto.Rols.ToList();
            ViewBag.documento = contexto.TipoDocumentos.ToList();
            ViewBag.programa = contexto.Programas.ToList();

            return View();
        }

 

        public IActionResult MenuAdmModificar(int? IdUsuario)//modificar usuario

        {
            Usuario usuario = contexto.Usuarios.Find(IdUsuario);
            if (usuario != null)
            {
                ViewBag.genero = contexto.Generos.ToList();
                ViewBag.documento = contexto.TipoDocumentos.ToList();
                ViewBag.rol = contexto.Rols.ToList();
                ViewBag.programa = contexto.Programas.ToList();
                return View(usuario);
            }
            else
                return Redirect("Administrador/AdminBuscar");
        }
        [HttpPost]

        public IActionResult MenuAdmModificar(Usuario user)
        {
            contexto.Update(user);
            contexto.SaveChanges();
            ViewBag.genero = contexto.Generos.ToList();
            ViewBag.documento = contexto.TipoDocumentos.ToList();
            ViewBag.rol = contexto.Rols.ToList();
            ViewBag.programa = contexto.Programas.ToList();
            return Redirect("Administrador/AdminBuscar");




        }
        public ActionResult Delete(int? IdUsuario)
        {

            Usuario usuario = contexto.Usuarios.Find(IdUsuario);

            if (usuario != null)
            {
                contexto.Remove(usuario);
                contexto.SaveChanges();
                return Redirect("/Administrador/AdminBuscar");
            }
            else

                return View();

        }

        public IActionResult Reportes()


        {
            return View();
        }*/
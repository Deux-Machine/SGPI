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

        public IActionResult CrearUsuario()
        {
            var generos = contexto.Generos.ToList();

            ViewBag.genero = new SelectList(generos, "IdGenero", "Descripcion");

            //ViewBag.Genero = contexto.Generos.ToList();

            //ViewBag.rol = context.Rols.ToList();

            return View();
        }
    }
}

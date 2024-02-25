using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGPI.Models;
using System.Linq;

namespace SGPI.Controllers
{
    public class CoordinadorController : Controller
    {
        SgpiContext contexto;

        public CoordinadorController(SgpiContext context)
        {
			contexto = new SgpiContext();
        }

		// GET: CoordinadorController
		public ActionResult MenuCoordinador()
		{
			return View();
		}

        public IActionResult Programacion()
        {
            return View();
        }

        public IActionResult Homologacion()
        {
            return View();
        }

        public IActionResult Entrevista()
        {
            return View();
        }

        public IActionResult Pagos()
        {
            ViewBag.documento = contexto.TipoDocumentos.ToList();// buscar usuario
            return View();
        }

        [HttpPost]
        public IActionResult Pagos(Usuario usuario)
        {
            var us = contexto.Usuarios
                .Where(u => u.NumDoc == usuario.NumDoc && u.Id_Doc == usuario.Id_Doc)
                .Include(u => u.IdPagosNavigation)
                .FirstOrDefault();

            if (us != null)
            {
                ViewBag.pago = us.IdPagosNavigation; 
                ViewBag.documento = contexto.TipoDocumentos.ToList();
                ViewBag.programa = contexto.Programas.ToList();
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

 
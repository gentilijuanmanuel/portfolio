using Project.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Helper;

namespace Project.Areas.Admin.Controllers
{
    [Autenticado]
    public class UsuarioController : Controller
    {
        private Usuario usuario = new Usuario();
        private TablaDato tablaDato = new TablaDato();


        // GET: Admin/Usuario
        public ActionResult Index()
        {
            ViewBag.Paises = tablaDato.getTablaDato("pais");
            return View(usuario.getUser( SessionHelper.GetUser(), false ));
        }

        public JsonResult Save(Usuario model, HttpPostedFileBase foto /* para validar la foto */)
        {
            var rm = new ResponseModel();

            //esta sentencia funciona para eliminar la validación de la propiedad password
            //en el controlador (recordar: EF también valida)
            //ModelState.Remove("password");
            if (ModelState.IsValid)
            {
                rm = model.Save(foto);
            }

            return Json(rm);
        }
    }
}
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
    public class HabilidadesController : Controller
    {
        private Habilidad habilidad = new Habilidad();

        // GET: Admin/Habilidad
        public ActionResult Index()
        {
            var usuario_id = SessionHelper.GetUser();
            return View(habilidad.getAll(usuario_id));
        }

        public ActionResult Crud(int id = 0)
        {
            if (id == 0)
            {
                habilidad.Usuario_id = SessionHelper.GetUser();
            }
            else
            {
                habilidad = habilidad.getHability(id);
            }


            return View(habilidad);
        }

        public JsonResult Save(Habilidad model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Save();

                if (rm.response)
                {
                    rm.href = Url.Content("~/admin/habilidades");
                }
            }

            return Json(rm);
        }


        public ActionResult Delete(int id = 0)
        {
            habilidad.Delete(id);

            return Redirect("~/admin/habilidades");
        }
    }
}
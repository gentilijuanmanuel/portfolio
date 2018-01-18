using Helper;
using Model;
using Project.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    [Autenticado]
    public class ExperienciaController : Controller
    {
        private Experiencia experiencia = new Experiencia();

        // GET: Admin/Experiencia
        public ActionResult Index(int tipo)
        {
            ViewBag.tipo = tipo;
            ViewBag.Title = tipo == 1 ? "Trabajos realizados" : "Estudios previos";
            var usuario_id = SessionHelper.GetUser();
            return View(experiencia.getAll(tipo, usuario_id));
        }

        public ActionResult Crud(byte tipo = 0, int id = 0)
        {
            if (id == 0)
            {
                if (tipo == 0)
                {
                    return Redirect("~/admin/experiencia/");
                }
                experiencia.Tipo = tipo;
                experiencia.Usuario_id = SessionHelper.GetUser();
            }
            else
            {
                experiencia = experiencia.getExperience(id);
            }


            return View(experiencia);
        }

        public JsonResult Save(Experiencia model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Save();

                if (rm.response)
                {
                    rm.href = Url.Content("~/admin/experiencia/?tipo=" + model.Tipo);
                }
            }

            return Json(rm);
        }

        //problema: no redirecciona a la tabla con las experiencias. PROBAR sin el self.
        //public JsonResult Delete(int id)
        //{
        //    var rm = experiencia.Delete(id);

        //    if (rm.response)
        //    {
        //        rm.href = "self";
        //    }

        //    return Json(rm, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Delete(byte tipo = 0, int id = 0)
        {
            experiencia.Delete(id, tipo);

            return Redirect("~/admin/experiencia?tipo=" + tipo);
        }
        
    }
}
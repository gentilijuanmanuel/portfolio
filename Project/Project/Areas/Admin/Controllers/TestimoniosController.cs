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
    public class TestimoniosController : Controller
    {
        
        private Testimonio testimonio = new Testimonio();

        // GET: Admin/Testimonio
        public ActionResult Index()
        {
            var usuario_id = SessionHelper.GetUser();
            return View(testimonio.getAll(usuario_id));
        }

        public ActionResult Crud(int id = 0)
        {
            testimonio = testimonio.getTestimony(id);

            return View(testimonio);
        }

        public JsonResult Save(Testimonio model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Save();

                if (rm.response)
                {
                    rm.href = Url.Content("~/admin/testimonios");
                }
            }

            return Json(rm);
        }


        public ActionResult Delete(int id = 0)
        {
            testimonio.Delete(id);

            return Redirect("~/admin/testimonios");
        }
    }
}
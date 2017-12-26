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
        // GET: Admin/Experiencia
        public ActionResult Index(int tipo)
        {
            ViewBag.Title = tipo == 1 ? "Trabajos realizados" : "Estudios previos";
            return View();
        }
    }
}
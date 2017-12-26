using Project.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class TestimoniosController : Controller
    {
        [Autenticado]
        // GET: Admin/Testimonios
        public ActionResult Index()
        {
            return View();
        }
    }
}
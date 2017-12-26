using Project.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class UsuarioController : Controller
    {
        [Autenticado]
        // GET: Admin/Usuario
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Helper;
using Project.Areas.Admin.Filters;

namespace Project.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private Usuario usuario = new Usuario();

        [NoLogin]
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string email, string password)
        {
            var rm = usuario.Acceder(email, password);

            if (rm.response)
            {
                rm.href = Url.Content("~/admin/usuario");
            }

            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }
    }
}
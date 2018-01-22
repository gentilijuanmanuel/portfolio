using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Project.App_Start;

namespace Project.Controllers
{
    public class DefaultController : Controller
    {
        private Usuario usuario = new Usuario();
        // GET: Default
        public ActionResult Index()
        {
            return View(usuario.getUser(FrontOfficeStartApp.UsuarioVisualizado(), true));
        }
    }
}
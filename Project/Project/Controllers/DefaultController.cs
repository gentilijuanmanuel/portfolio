using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace Project.Controllers
{
    public class DefaultController : Controller
    {
        private TablaDato tablaDato = new TablaDato();

        // GET: Default
        public int Index()
        {
            return tablaDato.Conexion();
        }
    }
}
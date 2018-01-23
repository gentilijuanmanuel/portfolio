using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Project.App_Start;
using Project.ViewModels;
using System.Net.Mail;

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

        //para pulirlo un poco, pero anda.
        public ActionResult EnviarCorreo(ContactoViewModel model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                try
                {
                    var _usuario = usuario.getUser(FrontOfficeStartApp.UsuarioVisualizado(), false);

                    var mail = new MailMessage();
                    mail.From = new MailAddress(model.Correo, model.Nombre);
                    mail.To.Add(_usuario.Email);
                    mail.Subject = "Correo desde contacto";
                    mail.IsBodyHtml = true;
                    mail.Body = model.Mensaje;

                    var smtpServer = new SmtpClient("smtp.gmail.com");
                    smtpServer.Port = 587;
                    smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpServer.UseDefaultCredentials = false;
                    smtpServer.Credentials = new System.Net.NetworkCredential("gentilijuanmanuel80974a@gmail.com", "contraseña");
                    smtpServer.EnableSsl = true;
                    smtpServer.Send(mail);
                }
                catch (Exception e)
                {
                    rm.SetResponse(false, e.Message);
                    return Json(rm);
                    throw;
                }

                rm.SetResponse(true);
                if (rm.response)
                {
                    ViewBag.Title = "Index";
                    return Redirect("~/");
                }
                //rm.function = "CerrarContacto();";
            }

            return Json(rm);
        }

        public ActionResult ExportarAPDF()
        {
            return new Rotativa.MVC.ActionAsPdf("PDF");
        }

        public ActionResult PDF()
        {
            return View(
                    usuario.getUser(FrontOfficeStartApp.UsuarioVisualizado(), true)
                );
        }
    }
}
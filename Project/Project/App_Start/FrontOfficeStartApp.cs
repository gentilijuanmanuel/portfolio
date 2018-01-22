using System;
using System.Web;

namespace Project.App_Start
{
    public class FrontOfficeStartApp
    {
        public static int UsuarioVisualizado()
        {
            int userIdDefault = 6;

            string userId = HttpContext.Current.Request.QueryString["id"];

            return userId != null ? Convert.ToInt32(userId) : userIdDefault;
        }

    }
}
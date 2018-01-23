using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class ContactoViewModel
    {
        private string nombre;

        [Required]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string correo;

        [Required]
        [EmailAddress]
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        private string mensaje;

        [Required]
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }



    }
}
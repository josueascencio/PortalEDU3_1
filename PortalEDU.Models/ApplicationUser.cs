using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortalEDU.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required (ErrorMessage =("El Nombre es requerido"))]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        [Required(ErrorMessage = ("La ciudad es requerida"))]
        public string Ciudad { get; set; }


        [Required(ErrorMessage = ("El Pais es Obligatorio"))]
        public string Pais { get; set; }


    }
}

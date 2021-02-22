﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortalEDU.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Ingrese un nombre para la categoria")]
        [Display (Name ="Nombre Categoria")]
        public  string Nombre { get; set; }


        [Required]
        [Display(Name = "Orden de Vizualizacion")]
        public string Orden { get; set; }

    }
}

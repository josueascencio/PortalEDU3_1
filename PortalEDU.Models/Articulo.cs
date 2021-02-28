using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PortalEDU.Models
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El Nombre es requerido")]
        [Display (Name ="Nombre del articulo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        
        public string Descripcion { get; set; }


        [Display(Name = "Fecha de creacion")]
        public string FechaCreacion { get; set; }

        [Display(Name = "Imagen")]
        [DataType(DataType.ImageUrl)]
        public string UrlImagen { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria{ get; set; }



    }
}


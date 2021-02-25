using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.Models.ViewModel
{
    public class ArticuloVM
    {

        public Articulo articulo { get; set; }

        public IEnumerable<SelectListItem> ListaCategorias { get; set; }

    }
}

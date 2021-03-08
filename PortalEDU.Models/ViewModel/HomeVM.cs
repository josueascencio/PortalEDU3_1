using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.Models.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Slider> slider { get; set; }

        public IEnumerable<Articulo> ListaArticulos { get; set; }
    }
}

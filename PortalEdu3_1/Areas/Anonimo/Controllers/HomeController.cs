using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalEDU.ADO.Data.Repository;
using PortalEDU.Models;
using PortalEDU.Models.ViewModel;
using PortalEdu3_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEdu3_1.Controllers
{
    [Area ("Anonimo")]
    public class HomeController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;


        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                slider = _contenedorTrabajo.Slider.GetAll(),
                ListaArticulos = _contenedorTrabajo.Articulo.GetAll()
            };
            return View(homeVM);
        
        }


        public IActionResult Details(int id) {


            var articuloDesdeDB = _contenedorTrabajo.Articulo.GetFirstOrDefault(a => a.Id == id);
            return View(articuloDesdeDB);
        }

        
    }
}

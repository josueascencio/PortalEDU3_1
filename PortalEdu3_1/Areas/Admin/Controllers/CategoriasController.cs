using Microsoft.AspNetCore.Mvc;
using PortalEDU.ADO.Data;
using PortalEDU.ADO.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEdu3_1.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }
           


        #region LLAMADAS A LAS API
        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new {data = _contenedorTrabajo.Categoria.GetAll()});
        }

        #endregion



    }
}

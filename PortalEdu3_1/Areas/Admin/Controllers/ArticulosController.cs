using Microsoft.AspNetCore.Mvc;
using PortalEDU.ADO.Data.Repository;
using PortalEDU.Models;
using PortalEDU.Models.ViewModel;

namespace PortalEdu3_1.Areas.Admin.Controllers
{

    [Area ("Admin")]
    public class ArticulosController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        
        public ArticulosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
                
        }

        [HttpGet]
        public IActionResult Index()
        {
           
            //ArticuloVM artivm = new ArticuloVM()
            //{
            //    articulo = new PortalEDU.Models.Articulo(),
            //    ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategoria()
            // // Articulo = new Models.
      
            //};

            return View();
        }

        [HttpGet]

        public IActionResult Create()
        {
            ArticuloVM artivm = new ArticuloVM()
            {
                articulo = new PortalEDU.Models.Articulo(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategoria()
                // Articulo = new Models.

            };

            return View(artivm);

        }




        #region LLAMADAS A LAS API
        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Articulo.GetAll(includeProperties: "Categoria") });
        
        }

        #endregion



    }
}

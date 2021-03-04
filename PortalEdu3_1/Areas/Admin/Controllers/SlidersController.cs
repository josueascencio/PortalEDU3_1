using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PortalEDU.ADO.Data.Repository;
using PortalEDU.Models;
using PortalEDU.Models.ViewModel;
using System;
using System.IO;
using System.Linq;

namespace PortalEdu3_1.Areas.Admin.Controllers
{

    [Area ("Admin")]
    public class SlidersController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostinEnvironment;
        
        public SlidersController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostinEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostinEnvironment = hostinEnvironment;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostinEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (slider.Id == 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\sliders");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    slider.UrlImagen = @"\imagenes\sliders\" + nombreArchivo + extension;
                    //artiVM.articulo.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.Slider.Add(slider);
                    _contenedorTrabajo.Save();


                    return RedirectToAction(nameof(Index));
                }
            }

            //artiVM.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategoria();
            return View(slider);
        }


        [HttpGet]

        public IActionResult Edit(int? id)
        {
           
            if (id != null)
            {
               var slider = _contenedorTrabajo.Slider.Get(id.GetValueOrDefault());
                return View(slider);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostinEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var sliderDesdeDb = _contenedorTrabajo.Slider.Get(slider.Id);

                if (archivos.Count() > 0)
                {
                    // Editamos Imagenes
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\sliders");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, sliderDesdeDb.UrlImagen.TrimStart('\\'));


                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    // Subimos nuevamente el archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    slider.UrlImagen = @"\imagenes\sliders\" + nombreArchivo + nuevaExtension;
                    //artiVM.articulo.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.Slider.Update(slider);
                    _contenedorTrabajo.Save();


                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    // Aqui es cuando la imagen ya existe y no se reeemplaza 
                    // debe conservar la que ya esta en la base de datos
                   slider.UrlImagen = sliderDesdeDb.UrlImagen;
                }

                _contenedorTrabajo.Slider.Update(slider);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }

            return View();
        }


        public IActionResult Delete(int id)
        {
            var sliderDesdeDb = _contenedorTrabajo.Slider.Get(id);
            string rutaDirectorioPrincipal = _hostinEnvironment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, sliderDesdeDb.UrlImagen.TrimStart('\\'));

            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }

            if (sliderDesdeDb == null)

            {
                return Json(new { success = false, message = "Error al intentar borrar articulo" });

            }

            _contenedorTrabajo.Slider.Remove(sliderDesdeDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Articulo borrado con exito" });
        }

        #region LLAMADAS A LAS API
        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Slider.GetAll() });
        
        }

        #endregion



    }
}

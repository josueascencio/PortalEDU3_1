using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.ADO.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.ADO.Data
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _db;

        public SliderRepository(ApplicationDbContext db):base (db)
        {
            _db = db;
        }

        public void Update(Slider slider)
        {

            var ObjDesdeDb = _db.Slider.FirstOrDefault(s => s.Id == slider.Id);
            ObjDesdeDb.Nombre = slider.Nombre;
            ObjDesdeDb.Estado = slider.Estado;
            ObjDesdeDb.UrlImagen = slider.UrlImagen;
            
           _db.SaveChanges();
        }
    }
}

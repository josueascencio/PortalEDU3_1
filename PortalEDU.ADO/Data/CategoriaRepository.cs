using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.ADO.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.ADO.Data
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepository(ApplicationDbContext db):base (db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaCategoria()
        {
            return _db.Categoria.Select(i => new SelectListItem()
            {
                Text= i.Nombre,
                Value= i.Id.ToString()
            });
        }

        public void Update(Categoria categoria)
        {

            var ObjDesdeDb = _db.Categoria.FirstOrDefault(s => s.Id == categoria.Id);
            ObjDesdeDb.Nombre = categoria.Nombre;
            ObjDesdeDb.Orden = categoria.Orden;
            _db.SaveChanges();
        }
    }
}

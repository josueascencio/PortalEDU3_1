using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.ADO.Data.Repository;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.ADO.Data
{
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {
        private readonly ApplicationDbContext _db;

        public ArticuloRepository(ApplicationDbContext db):base (db)
        {
            _db = db;
        }

        public void Update(Articulo articulo)
        {

            var ObjDesdeDb = _db.Articulo.FirstOrDefault(s => s.Id == articulo.Id);
            ObjDesdeDb.Nombre = articulo.Nombre;
            ObjDesdeDb.Descripcion = articulo.Descripcion;
            ObjDesdeDb.FechaCreacion = articulo.FechaCreacion;
            ObjDesdeDb.UrlImagen = articulo.UrlImagen;
            ObjDesdeDb.CategoriaId = articulo.CategoriaId;
           // _db.SaveChanges();
        }
    }
}

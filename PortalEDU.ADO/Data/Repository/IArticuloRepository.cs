using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.ADO.Data.Repository
{
    public interface IArticuloRepository : IRepository<Articulo>
    {
               

                void Update(Articulo articulo);
    }
}

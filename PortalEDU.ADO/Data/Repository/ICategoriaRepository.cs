using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.ADO.Data.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {

        IEnumerable<SelectListItem> GetListaCategoria();

        void Update(Categoria categoria);
    }
}

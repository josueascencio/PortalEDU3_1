using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEDU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.ADO.Data.Repository
{
    public interface IUsuarioRepository : IRepository<ApplicationUser>
    {

        void BloquearUsuario(string IdUsuario);
        void DesbloquearUsuario(string IdUsuario);

    }
}

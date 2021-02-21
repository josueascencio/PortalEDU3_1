using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.ADO.Data.Repository
{
    interface IContenedorTrabajo : IDisposable
    {
        ICategoriaRepository Categoria { get; }

        void Save();
    }
}

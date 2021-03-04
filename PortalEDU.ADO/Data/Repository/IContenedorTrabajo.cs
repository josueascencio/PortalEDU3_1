using System;
using System.Collections.Generic;
using System.Text;

namespace PortalEDU.ADO.Data.Repository
{
    public interface IContenedorTrabajo : IDisposable
    {
        ICategoriaRepository Categoria { get; }

        IArticuloRepository Articulo { get; }

        ISliderRepository Slider { get; }

        void Save();
    }
}

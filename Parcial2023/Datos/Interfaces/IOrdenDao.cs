using Produccion.Domino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produccion.Datos
{
    public interface IOrdenDao
    {
        int CrearOrden(OrdenProduccion orden);
    }
}

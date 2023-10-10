using Produccion.Datos;
using Produccion.Domino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2023.Datos.Implementaciones
{
    public class DaoOrden : IOrdenDao
    {
        public int CrearOrden(OrdenProduccion orden)
        {
            return DBHelper.GetInstancia().ConfirmarOrden(orden);
        }
    }
}

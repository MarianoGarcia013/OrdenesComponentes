using Parcial2023.Datos;
using Produccion.Datos;
using Produccion.Domino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2023.Servicio
{
    public class GestorOrden
    {
        public IOrdenDao dao;
        public GestorOrden(IOrdenDao dao)
        {
            this.dao = dao;
        }
        public int Crear(OrdenProduccion orden)
        {
            return dao.CrearOrden(orden);
        }
    }
}

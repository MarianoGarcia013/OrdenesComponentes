using Parcial2023.Datos;
using Produccion.Domino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2023.Servicio
{
    public class GestorComponente
    {
        public IDaoComponente dao;
        public GestorComponente(IDaoComponente dao)
        {
            this.dao = dao;
        }
        public List<Componente> ObtenerComponentes()
        {
            return dao.GetComponentes();
        }
    }
}

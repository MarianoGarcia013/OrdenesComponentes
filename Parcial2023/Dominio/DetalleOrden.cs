using Produccion.Domino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2023.Dominio
{
    public class DetalleOrden
    {
        public Componente Componente { get; set; }
        public int Cantidad { get; set; }
        public DetalleOrden(Componente p, int cant)
        {
            Componente = p;
            Cantidad = cant;
        }
    }
}

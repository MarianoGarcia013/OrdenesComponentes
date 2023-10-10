using Parcial2023.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produccion.Domino
{
    public class OrdenProduccion
    {
        public DateTime Fecha { get; set; }
        public string Modelo { get; set; }
        public string Estado { get; set; }
        public int Cantidad { get; set; }
        public int NroOrden { get; set; }

        public List<DetalleOrden> lDetalles = new List<DetalleOrden>();
        public void AgregarDetalle(DetalleOrden detalle)
        {
            lDetalles.Add(detalle);
        }

        public void QuitarDetalle(int indice)
        {
            lDetalles.RemoveAt(indice);
        }

    }
}

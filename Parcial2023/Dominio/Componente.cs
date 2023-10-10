using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produccion.Domino
{
    public class Componente
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public Componente()
        {
        }
        public Componente(int codigo, string nombre) 
        {
            Codigo = codigo;
            Nombre = nombre;
        }
    }
}

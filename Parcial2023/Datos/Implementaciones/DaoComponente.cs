using Produccion.Domino;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2023.Datos.Implementaciones
{
    public class DaoComponente : IDaoComponente
    {
        public List<Componente> GetComponentes()
        {
            List<Componente> componentes= new List<Componente>();
            DataTable dt = DBHelper.GetInstancia().Consultar("SP_CONSULTAR_COMPONENTES");
            foreach (DataRow row in dt.Rows)
            {
                Componente aux = new Componente();
                aux.Codigo = Convert.ToInt32(row["codigo"].ToString());
                aux.Nombre = row["nombre"].ToString();
                componentes.Add(aux);
            }
            return componentes;
        }
    }
}

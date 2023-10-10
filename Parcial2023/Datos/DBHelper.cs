using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Produccion.Domino;
using Parcial2023.Dominio;

namespace Parcial2023.Datos
{
    public class DBHelper
    {
        private static DBHelper instancia = null;
        private SqlConnection conexion;
        private DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=172.16.10.196;Initial Catalog=Produccion;User ID=alumno1w1;Password=alumno1w1");
        }     
        public static DBHelper GetInstancia()
        {
            if (instancia == null)
                instancia = new DBHelper();
            return instancia;
        }
        public DataTable Consultar(string nombreSP)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;   
        }
        public int ConfirmarOrden(OrdenProduccion orden)
        {
            int resultado = 0;
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.Transaction = t;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERTAR_MAESTRO";
                cmd.Parameters.AddWithValue("@fecha", orden.Fecha);
                cmd.Parameters.AddWithValue("@modelo", orden.Modelo);
                cmd.Parameters.AddWithValue("@cantidad", orden.Cantidad);
                cmd.Parameters.AddWithValue("@estado", orden.Estado);


            SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@nro_orden";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parametro);
                cmd.ExecuteNonQuery();
                int numero_de_orden = (int)parametro.Value;
                resultado = numero_de_orden;
                int detalleOrden = 1;
                SqlCommand cmdDetalle;
                foreach (DetalleOrden x in orden.lDetalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@nro_orden", numero_de_orden);
                    cmdDetalle.Parameters.AddWithValue("@id", detalleOrden);
                    cmdDetalle.Parameters.AddWithValue("@componente", x.Componente.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", "Creado");
                    cmdDetalle.ExecuteNonQuery();
                    detalleOrden++;
                }
                t.Commit();
        }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
                return resultado;
        }
    }
}

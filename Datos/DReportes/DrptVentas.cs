using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos.DReportes
{
    public class DrptVentas : Conexion
    {
        public DataTable Beneficio(DateTime desde, DateTime hasta)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "reporte_ventas_beneficio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value = desde;
                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value = hasta;
                    try
                    {
                        SqlDataReader leer = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(leer);
                        return table;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public DataTable Ventas(DateTime desde, DateTime hasta)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "reporte_ventas";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value = desde;
                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value = hasta;
                    try
                    {
                        SqlDataReader leer = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(leer);
                        return table;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public DataTable Devoluciones(DateTime desde, DateTime hasta)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "reporte_ventas_devoluciones";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value = desde;
                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value = hasta;
                    try
                    {
                        SqlDataReader leer = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(leer);
                        return table;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
    }
}

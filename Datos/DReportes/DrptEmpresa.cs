using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos.DReportes
{
    public class DrptEmpresa : Conexion
    {
        public void FachaActualiza()
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Empresa set fecha_actualizacion = GETDATE()";
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        _ = cmd.ExecuteScalar();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public DataTable Empresa()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Empresa";
                    cmd.CommandType = CommandType.Text;
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

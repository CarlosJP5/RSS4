using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos.DReportes
{
    public class DrptEmpresa : Conexion
    {
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

        public DateTime Licensia()
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select lisencia_empresa from Empresa";
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        DateTime lisencia = DateTime.Parse(cmd.ExecuteScalar().ToString());
                        return lisencia;
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

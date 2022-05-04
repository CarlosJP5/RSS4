using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DReciboIngreso : Conexion
    {
        public int Insertar(int IdCliente, DateTime Fecha, DataTable Detalle)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "reciboIngreso_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = IdCliente;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = Fecha;
                    cmd.Parameters.Add("@detalle", SqlDbType.Structured).Value = Detalle;
                    try
                    {
                        int idRecibo = (int)cmd.ExecuteScalar();
                        return idRecibo;
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

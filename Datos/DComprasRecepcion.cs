using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DComprasRecepcion : Conexion
    {
        public void Insertar (string idCompra, DataTable detalle)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "compra_recpcion_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_compra", SqlDbType.Int).Value = idCompra;
                    cmd.Parameters.Add("@detalle", SqlDbType.Structured).Value = detalle;
                    try
                    {
                        _ = cmd.ExecuteNonQuery();
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

using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DComprasRecepcion : Conexion
    {
        public DataTable Insertada (string idCompra)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "compra_recpcion_insertada";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idCompra", SqlDbType.Int).Value = idCompra;
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
                        foreach (DataRow row in detalle.Rows)
                        {
                            string query = string.Format(@"update Articulo set 
                                                  cantidad_articulo  += 1,
                                                  costo_articulo = '{0}',
                                                  precio_articulo = '{1}',
                                                  beneficio_articulo = '{2}'
                                                  where id_articulo = '{3}'",
                                                  row["[costo_final]"], row["[precio]"],
                                                  row["[beneficio]"], row["[id_articulo]"]);
                            Articulo(query);
                            if (!string.IsNullOrWhiteSpace(row["[Imei]"].ToString()))
                            {
                                query = string.Format("insert into ArticuloImei values({0}, '{1}')", row["[id_articulo]"], row["[Imei]"]);
                                Articulo(query);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        private void Articulo (string query)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
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

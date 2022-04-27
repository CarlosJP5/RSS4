using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DCompras : Conexion
    {
        public void Insertar(ECompra Compra, DataTable Detalle)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "compra_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idSuplidor", SqlDbType.Int).Value = Compra.IdSuplidor;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = Compra.Fecha;
                    cmd.Parameters.Add("@tipoCompra", SqlDbType.VarChar).Value = Compra.TipoCompra;
                    cmd.Parameters.Add("@facturaNumero", SqlDbType.VarChar).Value = Compra.FacturaNumero;
                    cmd.Parameters.Add("@ncf", SqlDbType.VarChar).Value = Compra.NCF;
                    cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = Compra.Importe;
                    cmd.Parameters.Add("@descuento", SqlDbType.Decimal).Value = Compra.Descuento;
                    cmd.Parameters.Add("@itbis", SqlDbType.Decimal).Value = Compra.Itbis;
                    cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = Compra.Total;
                    cmd.Parameters.Add("@detalle", SqlDbType.Structured).Value = Detalle;
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

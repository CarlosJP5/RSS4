using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DArticulos : Conexion
    {
        public void Insertar(EArticulo articulo)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "articulo_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idMarca", SqlDbType.Int).Value = articulo.IdMarca;
                    cmd.Parameters.Add("@idItbis", SqlDbType.Int).Value = articulo.IdItbis;
                    cmd.Parameters.Add("@idSuplidor", SqlDbType.Int).Value = articulo.IdSuplidor;
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = articulo.Codigo;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = articulo.Nombre;
                    cmd.Parameters.Add("@referencia", SqlDbType.VarChar).Value = articulo.Referencia;
                    cmd.Parameters.Add("@puntoReorden", SqlDbType.Int).Value = articulo.PuntoReorden;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = articulo.Cantidad;
                    cmd.Parameters.Add("@costo", SqlDbType.Decimal).Value = articulo.Costo;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = articulo.Precio;
                    cmd.Parameters.Add("@beneficio", SqlDbType.Decimal).Value = articulo.Beneficio;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = articulo.Estado;
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

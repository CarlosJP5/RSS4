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
    public class DSuplidores : Conexion
    {
        public void Insertar(ESuplidor suplidor)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "suplidor_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = suplidor.Nombre;
                    cmd.Parameters.Add("@rnc", SqlDbType.VarChar).Value = suplidor.RNC;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = suplidor.Direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = suplidor.Telefono;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = suplidor.Correo;
                    cmd.Parameters.Add("@vendedor", SqlDbType.VarChar).Value = suplidor.Vendedor;
                    cmd.Parameters.Add("@cell", SqlDbType.VarChar).Value = suplidor.Cell;
                    cmd.Parameters.Add("@tipoCompra", SqlDbType.VarChar).Value = suplidor.TipoCompra;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = suplidor.Estado;
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

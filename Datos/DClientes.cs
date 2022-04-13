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
    public class DClientes : Conexion
    {
        public int MaxId()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "cliente_maxId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        SqlDataReader leer = cmd.ExecuteReader();
                        if (leer.Read())
                        {
                            return leer.GetInt32(0) + 1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public void Insertar(ECliente cliente)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "cliente_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idComprobante", SqlDbType.VarChar).Value = cliente.IdComprobante;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.Nombre;
                    cmd.Parameters.Add("@cedula", SqlDbType.VarChar).Value = cliente.Cedula;
                    cmd.Parameters.Add("@rnc", SqlDbType.VarChar).Value = cliente.RNC;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.Direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = cliente.Telefono;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = cliente.Correo;
                    cmd.Parameters.Add("@tipoCompra", SqlDbType.VarChar).Value = cliente.TipoCompra;
                    cmd.Parameters.Add("@limiteCredito", SqlDbType.Decimal).Value = cliente.LimiteCredito;
                    cmd.Parameters.Add("@descuento", SqlDbType.Decimal).Value = cliente.Descuento;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = cliente.Estado;
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

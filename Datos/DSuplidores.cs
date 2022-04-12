using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DSuplidores : Conexion
    {
        public DataTable Buscar(string Query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = Query;
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
        public DataTable BuscarId(int Id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "suplidor_buscarId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;
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
        public DataTable Listar()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "suplidor_listar";
                    cmd.CommandType = CommandType.StoredProcedure;
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
        public int MaxId()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "suplidor_maxId";
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
        public void Editar(ESuplidor suplidor)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "suplidor_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = suplidor.IdSuplidor;
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

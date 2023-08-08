using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DUsuario : Conexion
    {
        public DataTable Buscar(string query, string buscar)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@buscar", SqlDbType.VarChar, 50).Value = buscar;
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
        public DataTable Login(string usuario)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "usuario_login";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
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
        public DataTable ListaPermisos(int idUsuario)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "usuario_listar_permisos";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
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
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usuario_maxId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        SqlDataReader leer = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(leer);
                        if (table.Rows[0][0].ToString() != "")
                        {
                            return Convert.ToInt32(table.Rows[0][0].ToString()) + 1;
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
        public async void Editar(EUsuario usuario)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "usuario_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                    cmd.Parameters.Add("@cedula", SqlDbType.VarChar).Value = usuario.Cedula;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = usuario.Direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = usuario.Telefono;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.Correo;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = usuario.Estado;
                    try
                    {
                        await cmd.ExecuteNonQueryAsync();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public async void Insertar(EUsuario usuario)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "usuario_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.Usuario;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                    cmd.Parameters.Add("@cedula", SqlDbType.VarChar).Value = usuario.Cedula;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = usuario.Direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = usuario.Telefono;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.Correo;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = usuario.FechaIngreso;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = usuario.Estado;
                    try
                    {
                        await cmd.ExecuteNonQueryAsync();
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

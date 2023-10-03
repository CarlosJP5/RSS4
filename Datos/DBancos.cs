using System;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DBancos : Conexion
    {
        public DataTable BuscarNombre(string Nombre)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[banco_buscar]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = Nombre;
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
        public DataTable BuscarCuentaNombre(string Nombre)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "bancoCuenta_buscar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = Nombre;
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
        public DataTable BuscarId(string id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "banco_buscar_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
        public DataTable BuscarCuentaId(string id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "bancoCuenta_buscar_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
        public void Editar(int Id, string Nombre)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "banco_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = Nombre;
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
        public void EditarCuenta(string id, string idBanco, string nombre, string numero)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "bancoCuenta_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@idBanco", SqlDbType.Int).Value = idBanco;
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = nombre;
                    cmd.Parameters.Add("@numero", SqlDbType.NVarChar, 50).Value = numero;
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
        public void Insertar(string Nombre)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "banco_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = Nombre;
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
        public void InsertarCuenta(string idBanco, string nombre, string numero)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "bancoCuenta_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idBanco", SqlDbType.Int).Value = idBanco;
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = nombre;
                    cmd.Parameters.Add("@numero", SqlDbType.NVarChar, 50).Value = numero;
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
        public void InsertarMovimiento(string idBanco, string idCtnBanco, DateTime fecha, string descripcion, double debito, double credito, double total)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "bancoMovimiento_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idBanco", SqlDbType.Int).Value = idBanco;
                    cmd.Parameters.Add("@idCtnBanco", SqlDbType.Int).Value = idCtnBanco;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                    cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 50).Value = descripcion;
                    cmd.Parameters.Add("@debito", SqlDbType.Float).Value = debito;
                    cmd.Parameters.Add("@credito", SqlDbType.Float).Value = credito;
                    cmd.Parameters.Add("@total", SqlDbType.Float).Value = total;
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

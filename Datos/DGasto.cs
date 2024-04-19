using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DGasto : Conexion
    {
        public DataTable Buscar(int id)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "gasto_buscar_id";
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
        public DataTable Buscar(string nombre)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "gasto_buscar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
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
        public DataTable BuscarDetalle(int idRegistro)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "gastoDetalle_buscar_idRegistro";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@registro", SqlDbType.Int).Value = idRegistro;
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
        public DataTable BuscarDetalle(DateTime desde, DateTime hasta)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "gastoDetalle_buscar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value = desde;
                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value = hasta;
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
        public DataTable BuscarDetalle(DateTime desde, DateTime hasta, int idTipo)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "gastoDetalle_buscar_tipoGasto";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value = desde;
                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value = hasta;
                    cmd.Parameters.Add("@idGasto", SqlDbType.Int).Value = idTipo;
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
        public void Editar(int id, string nombre)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "gasto_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
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
        public void EditarDetalle(int idRegistro, int idGasto, DateTime fecha, string nota, decimal monto)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "gastoDetalle_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@registro", SqlDbType.Int).Value = idRegistro;
                    cmd.Parameters.Add("@idGasto", SqlDbType.Int).Value = idGasto;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                    cmd.Parameters.Add("@nota", SqlDbType.VarChar, 150).Value = nota;
                    cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
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
        public void Insertar(string nombre)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "gasto_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
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
        public void InsertarDetalle(int idGasto, DateTime fecha, string nota, decimal monto)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "gastoDetalle_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idGasto", SqlDbType.VarChar, 50).Value = idGasto;
                    cmd.Parameters.Add("@fecha", SqlDbType.VarChar, 50).Value = fecha;
                    cmd.Parameters.Add("@nota", SqlDbType.VarChar, 50).Value = nota;
                    cmd.Parameters.Add("@monto", SqlDbType.VarChar, 50).Value = monto;
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

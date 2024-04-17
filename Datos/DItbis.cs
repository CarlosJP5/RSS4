using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DItbis : Conexion
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
                        DataTable dt = new DataTable();
                        dt.Load(leer);
                        return dt;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public DataTable BuscarId(int IdItbis)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "itbis_buscarId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = IdItbis;
                    try
                    {
                        SqlDataReader leer = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(leer);
                        return dt;
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
                    cmd.CommandText = "itbis_listar";
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
                    cmd.CommandText = "itbis_maxId";
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
        public void Editar(int IdItbis, string Nombre, decimal Porciento)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "itbis_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = IdItbis;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = Nombre;
                    cmd.Parameters.Add("@porciento", SqlDbType.Decimal).Value = Porciento;
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
        public void Insertar(string Nombre, decimal Porciento)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "itbis_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = Nombre;
                    cmd.Parameters.Add("@porciento", SqlDbType.Decimal).Value = Porciento;
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

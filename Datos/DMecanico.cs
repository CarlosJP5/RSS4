using System;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DMecanico : Conexion
    {
        public DataTable Comision(int idMecanico, DateTime desde, DateTime hasta)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "mecanico_comision";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idMecanico", SqlDbType.Int).Value = idMecanico;
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
        public DataTable Buscar(int Id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "mecanico_buscar_id";
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
        public DataTable Buscar(string nombre)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "mecanico_buscar";
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
        public void Editar(int id, string nombre, double comision)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "mecanico_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    cmd.Parameters.Add("@comision", SqlDbType.Float).Value = comision;
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
        public void Insertar(string nombre, double comision)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "mecanico_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    cmd.Parameters.Add("@comision", SqlDbType.Float).Value = comision;
                    try
                    {
                        _ = cmd.ExecuteScalar();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public void PagoComision(DataTable detalle)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "mecanico_comision_paga";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@detalle", SqlDbType.Structured).Value = detalle;
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

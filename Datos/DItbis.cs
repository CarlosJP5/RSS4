using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        DataTable table= new DataTable();
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

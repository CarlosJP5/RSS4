using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DArticulos : Conexion
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
        public DataTable BuscarCodigo(string Codigo)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "articulo_BuscarCodigo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 50).Value = Codigo;
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
                    cmd.CommandText = "articulo_BuscarId";
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
        public DataTable BuscarImei(string imei)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[articulo_imei_buscar]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@imei", SqlDbType.NVarChar).Value = imei;
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
                    cmd.CommandText = "articulo_listar";
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
        public DataTable ListarImei(string idArticulo)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "articulo_imei_listar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
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
        public DataTable ListaDeCompras()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "articulo_listaDeCompras";
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
        public DataTable ListaDeCompras(int IdSup)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "articulo_listaDeComprasIdSup";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdSup", SqlDbType.Int).Value = IdSup;
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
        public void CambiarCodigo(int IdArticulo, string Codigo)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "articulo_cambiarCodigo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idArticulo", SqlDbType.Int).Value = IdArticulo;
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 50).Value = Codigo;
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
        public void Editar(EArticulo articulo)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "articulo_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = articulo.Id;
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
                    cmd.Parameters.Add("@minimo", SqlDbType.Decimal).Value = articulo.BeneficioMinimo;
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
                    cmd.Parameters.Add("@minimo", SqlDbType.Decimal).Value = articulo.BeneficioMinimo;
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
        public void InsertarAjuste(DateTime Fecha, string Nota, DataTable Detalle)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "articulo_ajusteInventario_insert";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = Fecha;
                    cmd.Parameters.Add("@nota", SqlDbType.VarChar, 50).Value = Nota;
                    cmd.Parameters.Add("@detalle", SqlDbType.Structured).Value = Detalle;
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

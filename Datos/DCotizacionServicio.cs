using Entidades;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DCotizacionServicio : Conexion
    {
        public DataTable Buscar(DateTime desde, DateTime hasta)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[cotizacionServicio_buscar_fecha]";
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
        public DataTable Buscar_cliente(DateTime desde, DateTime hasta, int idCliente)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[cotizacionServicio_buscar_cliente]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value = desde;
                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value = hasta;
                    cmd.Parameters.Add("@cliente", SqlDbType.Int).Value = idCliente;
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
        public DataTable Buscar_idFactura(string idfactura)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[cotizacionServicio_buscar_idFactura]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idfact", SqlDbType.NVarChar).Value = idfactura;
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
        public DataTable Listar(string idfactura)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[cotizacionServicio_listar]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idfact", SqlDbType.NVarChar).Value = idfactura;
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
        public async void Editar(EServicio Factura, DataTable Detalle)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[cotizacionServicio_editar]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idFact", SqlDbType.Int).Value = Factura.IdFactura;
                    cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = Factura.IdCliente;
                    cmd.Parameters.Add("@nombre_cliente", SqlDbType.NVarChar).Value = Factura.NombreCliente;
                    cmd.Parameters.Add("@cedula", SqlDbType.NVarChar).Value = Factura.Cedula;
                    cmd.Parameters.Add("@rnc", SqlDbType.NVarChar).Value = Factura.Rnc;
                    cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = Factura.Importe;
                    cmd.Parameters.Add("@itbis", SqlDbType.Decimal).Value = Factura.Itbis;
                    cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = Factura.Total;
                    cmd.Parameters.Add("@detalle", SqlDbType.Structured).Value = Detalle;
                    try
                    {
                        _ = await cmd.ExecuteScalarAsync();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public string Insertar(EServicio Factura, DataTable Detalle)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[cotizacionServicio_insertar]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Factura.Fecha;
                    cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = Factura.IdCliente;
                    cmd.Parameters.Add("@nombre_cliente", SqlDbType.NVarChar).Value = Factura.NombreCliente;
                    cmd.Parameters.Add("@cedula", SqlDbType.NVarChar).Value = Factura.Cedula;
                    cmd.Parameters.Add("@rnc", SqlDbType.NVarChar).Value = Factura.Rnc;
                    cmd.Parameters.Add("@id_comprobante", SqlDbType.NVarChar).Value = Factura.IdComprobante;
                    cmd.Parameters.Add("@nombre_comprobante", SqlDbType.NVarChar).Value = Factura.NombreComprobante;
                    cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = Factura.Importe;
                    cmd.Parameters.Add("@itbis", SqlDbType.Decimal).Value = Factura.Itbis;
                    cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = Factura.Total;
                    cmd.Parameters.Add("@ncf", SqlDbType.NVarChar).Value = Factura.Ncf;
                    cmd.Parameters.Add("@fechaVencimiento", SqlDbType.Date).Value = Factura.FechaVencimiento;
                    cmd.Parameters.Add("@detalle", SqlDbType.Structured).Value = Detalle;
                    try
                    {
                        return (string)cmd.ExecuteScalar();
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

using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DFacturacion : Conexion
    {
        public bool TieneMovimientos(int IdFactura)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = string.Format(@"SELECT FD.id_devolucion, RI.id_ri FROM Factura F LEFT JOIN FacturaDevolucion FD
                                                      ON F.id_factura = FD.id_factura LEFT JOIN ReciboIngreso
                                                      RI ON F.id_factura = RI.id_factura WHERE 
                                                      F.id_factura = {0}", IdFactura);
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        SqlDataReader leer = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(leer);
                        string devolucion = table.Rows[0][0].ToString();
                        string recibo = table.Rows[0][1].ToString();
                        if (string.IsNullOrEmpty(devolucion) && string.IsNullOrEmpty(recibo))
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
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
        public DataTable BuscarId(int IdFactura)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "factura_buscarId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idFactura", SqlDbType.Int).Value = IdFactura;
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
        public DataTable BuscarDevoluionId(int IdDevolucion)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "facturaDevolucion_buscarId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idDevolucion", SqlDbType.Int).Value = IdDevolucion;
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
        public DataTable DevolucionCargar(int IdFactura)
        {
            //Carga las devoluciones que tenga una Factura para determinas
            //Las cantidades disponibles para devolver
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "facturaDevolucion_cargar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idFactura", SqlDbType.Int).Value = IdFactura;
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
        public DataTable Listar(DateTime Desde, DateTime Hasta)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "factura_listar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value = Desde;
                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value= Hasta;
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
        public DataTable ListarDevolucion(DateTime Desde, DateTime Hasta)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "facturaDevolucion_listar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desde", SqlDbType.Date).Value = Desde;
                    cmd.Parameters.Add("@hasta", SqlDbType.Date).Value = Hasta;
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
        public DataTable ReporteDevolucion(int idDevolucion)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "facturaDevolucion_rpt_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idDevolucion", SqlDbType.Int).Value = idDevolucion;
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
        public DataTable ReporteDevolucion(DateTime Desde, DateTime Hasta)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "facturaDevolucion_rpt_listar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desde", SqlDbType.Date).Value = Desde;
                    cmd.Parameters.Add("@hasta", SqlDbType.Date).Value = Hasta;
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
        public int Insertar(EFactura Factura, DataTable Detalle)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "factura_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = Factura.IdCliente;
                    cmd.Parameters.Add("@idComprobante", SqlDbType.VarChar).Value = Factura.IdComprobante;
                    cmd.Parameters.Add("@ncf", SqlDbType.VarChar).Value = Factura.Ncf;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Factura.Fecha;
                    cmd.Parameters.Add("@fechaVencimiento", SqlDbType.Date).Value = Factura.FechaVencimiento;
                    cmd.Parameters.Add("@tipoCompra", SqlDbType.VarChar).Value = Factura.TipoCompra;
                    cmd.Parameters.Add("@nota", SqlDbType.VarChar).Value = Factura.Nota;
                    cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = Factura.Importe;
                    cmd.Parameters.Add("@descuento", SqlDbType.Decimal).Value = Factura.Descuento;
                    cmd.Parameters.Add("@itbis", SqlDbType.Decimal).Value = Factura.Itbis;
                    cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = Factura.Total;
                    cmd.Parameters.Add("@detalle", SqlDbType.Structured).Value = Detalle;
                    cmd.Parameters.Add("@nombreCliente", SqlDbType.VarChar).Value = Factura.Nombre;
                    try
                    {
                        return (int)cmd.ExecuteScalar();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public int InsertarDevolucion(EFactura Factura, DataTable Detalle)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "facturaDevolucion_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idFactura", SqlDbType.Int).Value = Factura.IdFactura;
                    cmd.Parameters.Add("@idcliente", SqlDbType.Int).Value = Factura.IdCliente;
                    cmd.Parameters.Add("@idComprobante", SqlDbType.VarChar).Value = Factura.IdComprobante;
                    cmd.Parameters.Add("@ncf", SqlDbType.VarChar).Value = Factura.Ncf;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = Factura.Fecha;
                    cmd.Parameters.Add("@fechaVencimiento", SqlDbType.Date).Value = Factura.FechaVencimiento;
                    cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = Factura.Importe;
                    cmd.Parameters.Add("@descuento", SqlDbType.Decimal).Value = Factura.Descuento;
                    cmd.Parameters.Add("@itbis", SqlDbType.Decimal).Value = Factura.Itbis;
                    cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = Factura.Total;
                    cmd.Parameters.Add("@detalle", SqlDbType.Structured).Value = Detalle;
                    cmd.Parameters.Add("@tipoFactura", SqlDbType.NVarChar).Value = Factura.TipoCompra;
                    try
                    {
                        return (int)cmd.ExecuteScalar();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public void Editar(EFactura Factura, DataTable Detalle)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "factura_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idFact", SqlDbType.Int).Value = Factura.IdFactura;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = Factura.IdCliente;
                    cmd.Parameters.Add("@tipoCompra", SqlDbType.VarChar).Value = Factura.TipoCompra;
                    cmd.Parameters.Add("@nota", SqlDbType.VarChar).Value = Factura.Nota;
                    cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = Factura.Importe;
                    cmd.Parameters.Add("@descuento", SqlDbType.Decimal).Value = Factura.Descuento;
                    cmd.Parameters.Add("@itbis", SqlDbType.Decimal).Value = Factura.Itbis;
                    cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = Factura.Total;
                    cmd.Parameters.Add("@detalle", SqlDbType.Structured).Value = Detalle;
                    cmd.Parameters.Add("@nombreCliente", SqlDbType.VarChar).Value = Factura.Nombre;
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

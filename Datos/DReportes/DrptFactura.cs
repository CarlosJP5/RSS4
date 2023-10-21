using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos.DReportes
{
    public class DrptFactura : Conexion
    {
        public DataTable Factura(int IdFactura)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd= new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = string.Format(@"SELECT F.id_factura, F.id_cliente, F.id_comprobante, F.fecha_factura,
                                        F.tipoCompra_factura, F.nota_factura, F.importe_factura, F.descuento_factura,
                                        F.itbis_factura, F.total_factura, C.nombre_cliente, C.cedula_cliente, C.rnc_cliente,
                                        C.direccion_cliente, C.telefono_cliente, C.correo_cliente, CD.ncf_comprobante,
                                        CD.fechaVencimiento_comprobante, CC.nombre_comprobante, F.pago_factura, F.devuelta_factura
                                        FROM Factura F
                                        LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente
                                        LEFT JOIN ComprobantesDetalle CD ON cast(F.id_factura as varchar(50)) = CD.id_documento AND F.id_comprobante = CD.id_comprobante
                                        LEFT JOIN Comprobantes CC ON F.id_comprobante = CC.id_comprobante
                                        WHERE F.id_factura = {0}", IdFactura);
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
        public DataTable FacturaDetalle(int IdFactura)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = string.Format(@"SELECT A.codigo_articulo, A.nombre_articulo, A.referencia_articulo,
                                                        FD.cantidad_factura, FD.descuento_factura, FD.precio_factura,
                                                        FD.importe_factura, FD.totalImporte_factura, FD.totalDescuento_factura,
                                                        FD.totalItbis_factura
                                                        FROM FacturaDetalle FD
                                                        LEFT JOIN Articulo A ON FD.id_articulo = A.id_articulo
                                                        WHERE FD.id_factura = {0}", IdFactura);
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
        public DataTable Cotizacion(int IdCotizacion)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "citizacion_reporte";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = IdCotizacion;
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
        public DataTable CotizacionDetalle(int IdCotizacion)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "citizacion_reporte_detalle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = IdCotizacion;
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
        public DataTable ReporteVentas(DateTime desde, DateTime hasta)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "reporte_de_ventas";
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
        public DataTable ReporteVentasDevoluciones(DateTime desde, DateTime hasta)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "reporte_de_ventas_devolucion";
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
        public DataTable ReporteVentasReciboIngreso(DateTime desde, DateTime hasta)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "reporte_de_ventas_reciboIngreso";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value = desde;
                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value = hasta;
                    try
                    {
                        DataTable output = new DataTable();
                        output.Columns.Add("pago", typeof(double));
                        output.Columns.Add("costoPago", typeof(double));
                        output.Columns.Add("gananciaPaga", typeof(double));
                        SqlDataReader leer = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(leer);
                        foreach (DataRow dr in table.Rows)
                        {
                            DataTable detalle = new DataTable();
                            detalle = BuscarFacturaDetalle(dr[0].ToString());
                            if (detalle.Rows.Count > 0)
                            {
                                double precio = Convert.ToDouble(detalle.Rows[0][0]);
                                double costo = Convert.ToDouble(detalle.Rows[0][1]);
                                double ganancia = precio - costo;
                                double porciento = precio / ganancia;
                                double pago = Convert.ToDouble(dr[1]);
                                double gananciaPaga = pago / porciento;
                                double costoPago = pago - gananciaPaga;
                                DataRow rowOutput = output.NewRow();
                                rowOutput[0] = pago;
                                rowOutput[1] = costoPago;
                                rowOutput[2] = gananciaPaga;
                                output.Rows.Add(rowOutput);
                            }
                        }
                        return output;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        private DataTable BuscarFacturaDetalle(string idFact)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "reporte_de_ventas_facturaDetalle";
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idFact", SqlDbType.Int).Value = idFact;
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
    }
}

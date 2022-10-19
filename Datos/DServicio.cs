using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public  class DServicio : Conexion
    {
        public int Insertar(EServicio Factura, DataTable Detalle)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[facturaServicio_insertar]";
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
                        return (int)cmd.ExecuteScalar();
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

﻿using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DFacturacion : Conexion
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
                    cmd.Parameters.Add("@tipoCompra", SqlDbType.VarChar).Value = Factura.TipoCompra;
                    cmd.Parameters.Add("@nota", SqlDbType.VarChar).Value = Factura.Nota;
                    cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = Factura.Importe;
                    cmd.Parameters.Add("@descuento", SqlDbType.Decimal).Value = Factura.Descuento;
                    cmd.Parameters.Add("@itbis", SqlDbType.Decimal).Value = Factura.Itbis;
                    cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = Factura.Total;
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

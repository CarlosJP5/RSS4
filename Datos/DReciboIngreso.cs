﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DReciboIngreso : Conexion
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
        public DataTable Listar(DateTime Desde, DateTime Hasta)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "reciboIngreso_listar";
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
        public int Insertar(int IdCliente, DateTime Fecha, DataTable Detalle)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "reciboIngreso_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = IdCliente;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = Fecha;
                    cmd.Parameters.Add("@detalle", SqlDbType.Structured).Value = Detalle;
                    try
                    {
                        int idRecibo = (int)cmd.ExecuteScalar();
                        return idRecibo;
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

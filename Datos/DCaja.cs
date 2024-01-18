﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCaja : Conexion
    {
        public void Cierre(ECaja caja)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "caja_cierre";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idCaja", SqlDbType.Int).Value = caja.id_caja;
                    cmd.Parameters.Add("@nombre_cierre", SqlDbType.VarChar, 50).Value = caja.cierre_nombre;
                    cmd.Parameters.Add("@fecha_cierre", SqlDbType.DateTime).Value = DateTime.Now;
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
        public void Apertura(string nombre, double fondo)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "caja_apertura";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    cmd.Parameters.Add("@fondo", SqlDbType.Float).Value = fondo;
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

using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DUsuario : Conexion
    {
        public DataTable Buscar(string query, string buscar)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@buscar", SqlDbType.VarChar, 50).Value = buscar;
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
        public DataTable Login(string usuario)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "usuario_login";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
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
        public DataTable ListaPermisos(int idUsuario)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "usuario_listar_permisos";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
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
        public int MaxId()
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usuario_maxId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        SqlDataReader leer = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(leer);
                        if (table.Rows[0][0].ToString() != "")
                        {
                            return Convert.ToInt32(table.Rows[0][0].ToString()) + 1;
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
        public async void Editar(EUsuario usuario)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "usuario_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                    cmd.Parameters.Add("@cedula", SqlDbType.VarChar).Value = usuario.Cedula;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = usuario.Direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = usuario.Telefono;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.Correo;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = usuario.Estado;
                    try
                    {
                        await cmd.ExecuteNonQueryAsync();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public async void EditarPermisos(EUsuario usuario)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "usuario_permisos_editar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                    cmd.Parameters.Add("@datos_", SqlDbType.Bit).Value = usuario.datos_;
                    cmd.Parameters.Add("@datos_articulos_", SqlDbType.Bit).Value = usuario.datos_articulos_;
                    cmd.Parameters.Add("@datos_articulos_detalle", SqlDbType.Bit).Value = usuario.datos_articulos_detalle;
                    cmd.Parameters.Add("@datos_articulos_marcas", SqlDbType.Bit).Value = usuario.datos_articulos_marcas;
                    cmd.Parameters.Add("@datos_articulos_ajusteInventario", SqlDbType.Bit).Value = usuario.datos_articulos_ajusteInventario;
                    cmd.Parameters.Add("@datos_articulos_cambiar_codigo", SqlDbType.Bit).Value = usuario.datos_articulos_cambiar_codigo;
                    cmd.Parameters.Add("@datos_articulos_itbis", SqlDbType.Bit).Value = usuario.datos_articulos_itbis;
                    cmd.Parameters.Add("@datos_articulos_reporteInventario", SqlDbType.Bit).Value = usuario.datos_articulos_reporteInventario;
                    cmd.Parameters.Add("@datos_clientes_", SqlDbType.Bit).Value = usuario.datos_clientes_;
                    cmd.Parameters.Add("@datos_clientes_detalle", SqlDbType.Bit).Value = usuario.datos_clientes_detalle;
                    cmd.Parameters.Add("@datos_suplidores", SqlDbType.Bit).Value = usuario.datos_suplidores;
                    cmd.Parameters.Add("@datos_usuario_", SqlDbType.Bit).Value = usuario.datos_usuario_;
                    cmd.Parameters.Add("@datos_usuario_detalle", SqlDbType.Bit).Value = usuario.datos_usuario_detalle;
                    cmd.Parameters.Add("@datos_usuario_permisos", SqlDbType.Bit).Value = usuario.datos_usuario_permisos;
                    cmd.Parameters.Add("@datos_ncf", SqlDbType.Bit).Value = usuario.datos_ncf;
                    cmd.Parameters.Add("@datos_registro_comprobante", SqlDbType.Bit).Value = usuario.datos_registro_comprobante;
                    cmd.Parameters.Add("@datos_reporte_607", SqlDbType.Bit).Value = usuario.datos_reporte_607;
                    cmd.Parameters.Add("@facturacion_", SqlDbType.Bit).Value = usuario.facturacion_;
                    cmd.Parameters.Add("@facturacion_normal", SqlDbType.Bit).Value = usuario.facturacion_normal;
                    cmd.Parameters.Add("@facturacion_devolucion", SqlDbType.Bit).Value = usuario.facturacion_devolucion;
                    cmd.Parameters.Add("@facturacion_cotizacion", SqlDbType.Bit).Value = usuario.facturacion_cotizacion;
                    cmd.Parameters.Add("@facturacion_cuadre_caja", SqlDbType.Bit).Value = usuario.facturacion_cuadre_caja;
                    cmd.Parameters.Add("@cxc_", SqlDbType.Bit).Value = usuario.cxc_;
                    cmd.Parameters.Add("@cxc_reciboIngreso", SqlDbType.Bit).Value = usuario.cxc_reciboIngreso;
                    cmd.Parameters.Add("@cxp_", SqlDbType.Bit).Value = usuario.cxp_;
                    cmd.Parameters.Add("@cxp_compra", SqlDbType.Bit).Value = usuario.cxp_compra;
                    cmd.Parameters.Add("@cxp_devolucion", SqlDbType.Bit).Value = usuario.cxp_devolucion;
                    cmd.Parameters.Add("@cxp_pago", SqlDbType.Bit).Value = usuario.cxp_pago;
                    try
                    {
                        await cmd.ExecuteNonQueryAsync();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public async void Insertar(EUsuario usuario)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "usuario_insertar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.Usuario;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                    cmd.Parameters.Add("@cedula", SqlDbType.VarChar).Value = usuario.Cedula;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = usuario.Direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = usuario.Telefono;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.Correo;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = usuario.FechaIngreso;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = usuario.Estado;
                    try
                    {
                        await cmd.ExecuteNonQueryAsync();
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

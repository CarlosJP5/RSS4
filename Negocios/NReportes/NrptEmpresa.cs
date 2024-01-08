using Datos.DReportes;
using Entidades;
using Entidades.EReportes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocios.NReportes
{
    public class NrptEmpresa
    {
        public string Nombre { get; private set; }
        public List<ErptEmpresa> Empresa { get; private set; }
        public List<ErptEstadoCuenta> EstadoCuentas { get; private set; }
        public List<ECliente> Clientes { get; private set; }

        public string LlenaEmpresa()
        {
            DrptEmpresa _empresa = new DrptEmpresa();
            DataTable tableEmpresa = _empresa.Empresa();
            Empresa = new List<ErptEmpresa>();
            ErptEmpresa empresaModel = new ErptEmpresa()
            {
                IdEmpresa = (int)tableEmpresa.Rows[0][0],
                NombreEmpresa = tableEmpresa.Rows[0][1].ToString(),
                DireccionEmpresa = tableEmpresa.Rows[0][2].ToString(),
                RncEmpresa = tableEmpresa.Rows[0][3].ToString(),
                TelefonoEmpresa = tableEmpresa.Rows[0][4].ToString(),
                CellEmpresa = tableEmpresa.Rows[0][5].ToString(),
                CorreoEmpresa = tableEmpresa.Rows[0][6].ToString()
            };
            Empresa.Add(empresaModel);
            return tableEmpresa.Rows[0][1].ToString();
        }

        public void EstadoCuenta(DataTable detalle)
        {
            EstadoCuentas = new List<ErptEstadoCuenta>();
            foreach (DataRow row in detalle.Rows)
            {
                ErptEstadoCuenta modeloEstadoCuenta = new ErptEstadoCuenta()
                {
                    IdFactura = row[0].ToString(),
                    NCF = row[1].ToString(),
                    Fecha = DateTime.Parse(row[2].ToString()),
                    Dias = row[3].ToString(),
                    Balance = Convert.ToDecimal(row[4].ToString()),
                    Total = Convert.ToDecimal(row[5].ToString()),
                };
                EstadoCuentas.Add(modeloEstadoCuenta);
            }
        }

        public void Cliente(string idCliente)
        {
            NClientes nClientes = new NClientes();
            DataTable Cliente = nClientes.BuscarId(idCliente);
            Clientes = new List<ECliente>();
            foreach (DataRow row in Cliente.Rows)
            {
                ECliente modeloCliente = new ECliente()
                {
                    Id = Convert.ToInt16(row[0].ToString()),
                    IdComprobante = row[1].ToString(),
                    Nombre = row[2].ToString(),
                    Cedula = row[3].ToString(),
                    RNC = row[4].ToString(),
                    Direccion = row[5].ToString(),
                    Telefono = row[6].ToString(),
                    Correo = row[7].ToString(),
                    TipoCompra = row[8].ToString(),
                    LimiteCredito = Convert.ToDecimal(row[9].ToString()),
                    Descuento = Convert.ToDecimal(row[10].ToString()),
                    Estado = Convert.ToBoolean(row[11].ToString()),
                };
                Clientes.Add(modeloCliente);
            }
        }

        public DateTime Licensia()
        {
            DrptEmpresa empresa = new DrptEmpresa();
            return empresa.Licensia();
        }
    }
}

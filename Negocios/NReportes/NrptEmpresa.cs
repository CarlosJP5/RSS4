using Datos.DReportes;
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
        public List<ErptFacturaDetalle> ArticuloLista { get; private set; }

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
        public void ArticulosReporte(string query)
        {
            NReciboPago nReporte = new NReciboPago();
            DataTable articulosData = nReporte.Buscar(query);
            ArticuloLista = new List<ErptFacturaDetalle>();
            foreach (DataRow row in articulosData.Rows)
            {
                ErptFacturaDetalle modeloArticulo = new ErptFacturaDetalle
                {
                    CodigoArticulo = row[0].ToString(),
                    NombreArticulo = row[1].ToString(),
                    CantidadFacturado = Convert.ToDecimal(row[2]),
                    CostoArticulo = Convert.ToDecimal(row[3]),
                    ImporteFacturado = Convert.ToDecimal(row[4]),
                };
                ArticuloLista.Add(modeloArticulo);
            }
        }
    }
}

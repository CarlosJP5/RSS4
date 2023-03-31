using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.NReportes
{
    public class NrptArticulos
    {
        public List<EArticulo> Articulos {  get; private set; }

        public void CapitalInventario()
        {
            NArticulos nArticulos = new NArticulos();
            DataTable articulos = nArticulos.Buscar("select codigo_articulo, referencia_articulo, nombre_articulo, cantidad_articulo, costo_articulo from Articulo\r\nwhere cantidad_articulo > 0");
            Articulos = new List<EArticulo>();
            foreach (DataRow row in articulos.Rows)
            {
                EArticulo modeloArticulo = new EArticulo()
                {
                    Codigo = row[0].ToString(),
                    Referencia = row[1].ToString(),
                    Nombre = row[2].ToString(),
                    Cantidad = (decimal)row[3],
                    Costo = (decimal)row[4],
                    Precio = (decimal)row[3] * (decimal)row[4],
                };
                Articulos.Add(modeloArticulo);
            }

        }
    }
}

using Datos.DReportes;
using Entidades.EReportes;
using System.Collections.Generic;
using System.Data;

namespace Negocios.NReportes
{
    public class NrptEmpresa
    {
        public List<ErptEmpresa> Empresa { get; set; }

        public void LlenaEmpresa()
        {
            DrptEmpresa _empresa = new DrptEmpresa();
            DataTable tableEmpresa = _empresa.Empresa();
            Empresa = new List<ErptEmpresa>();
            foreach (DataRow row in tableEmpresa.Rows)
            {
                ErptEmpresa empresaModel = new ErptEmpresa()
                {
                    IdEmpresa = (int)tableEmpresa.Rows[0][0],
                    NombreEmpresa = tableEmpresa.Rows[0][1].ToString(),

                };
                Empresa.Add(empresaModel);
            }
        }
    }
}

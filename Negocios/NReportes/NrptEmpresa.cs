using Datos.DReportes;
using Entidades.EReportes;
using System.Collections.Generic;
using System.Data;

namespace Negocios.NReportes
{
    public class NrptEmpresa
    {
        public string Nombre { get; private set; }
        public List<ErptEmpresa> Empresa { get; private set; }

        private readonly DrptEmpresa _empresa = new DrptEmpresa();

        public string LlenaEmpresa()
        {            
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

        public DataTable EmpresaDatos()
        {
            return _empresa.Empresa();
        }

        public void FachaActualiza()
        {
            _empresa.FachaActualiza();
        }
    }
}

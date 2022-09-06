using Datos;
using Entidades;
using Entidades.EClases;
using System.Data;

namespace Negocios
{
    public class NUsuario
    {
        private readonly DUsuario dUsuario = new DUsuario();
        private readonly EAutenticacion autenticacion = new EAutenticacion();

        public DataTable Buscar(string query, string buscar)
        {
            DataTable table = dUsuario.Buscar(query, buscar);
            string clave = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                clave = row[8].ToString();
                clave = autenticacion.Desencriptar(clave);
                row[8] = clave;
            }
            //if (table.Rows.Count > 0)
            //{
            //    string clave = table.Rows[0][8].ToString();
            //    clave = autenticacion.Desencriptar(clave);
            //    table.Rows[0][8] = clave;
            //}
            return table;
        }
        public DataTable Login(string usuario)
        {
            DataTable table = dUsuario.Login(usuario);
            if (table.Rows.Count > 0)
            {
                string clave = table.Rows[0][8].ToString();
                clave = autenticacion.Desencriptar(clave);
                table.Rows[0][8] = clave;
            }
            return table;
        }
        public string MaxId()
        {
            return dUsuario.MaxId().ToString();
        }
        public void Editar(EUsuario usuario)
        {
            string pwd = autenticacion.Encriptar(usuario.Clave);
            usuario.Clave = pwd;
            dUsuario.Editar(usuario);
        }
        public void Insertar(EUsuario usuario)
        {
            string pwd = autenticacion.Encriptar(usuario.Clave);
            usuario.Clave = pwd;
            dUsuario.Insertar(usuario);
        }
    }
}

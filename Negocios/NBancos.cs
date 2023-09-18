using Datos;
using System.Data;

namespace Negocios
{
    public class NBancos
    {
        private readonly DBancos dBancos = new DBancos();

        public DataTable BuscarNombre(string Nombre)
        {
            return dBancos.BuscarNombre(Nombre);
        }
        public void Editar(int Id, string Nombre)
        {
            dBancos.Editar(Id, Nombre);
        }
        public void Insertar(string Nombre)
        {
            dBancos.Insertar(Nombre);
        }
    }
}

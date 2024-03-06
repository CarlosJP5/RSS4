using Datos;
using System.Data;

namespace Negocios
{
    public class NMecanico
    {
        private readonly DMecanico dMecanico = new DMecanico();

        public DataTable Buscar(int Id)
        {
            return dMecanico.Buscar(Id);
        }
        public DataTable Buscar(string nombre)
        {
            return dMecanico.Buscar(nombre);
        }
        public void Editar(int id, string nombre, double comision)
        {
            dMecanico.Editar(id, nombre, comision);
        }
        public void Insertar(string nombre, double comision)
        {
            dMecanico.Insertar(nombre, comision);
        }
    }
}

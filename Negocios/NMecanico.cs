using Datos;
using System;
using System.Data;

namespace Negocios
{
    public class NMecanico
    {
        private readonly DMecanico dMecanico = new DMecanico();

        public DataTable Comision(int idMecanico, DateTime desde, DateTime hasta)
        {
            return dMecanico.Comision(idMecanico, desde, hasta);
        }
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
        public void PagoComision(DataTable detalle)
        {
            dMecanico.PagoComision(detalle);
        }
    }
}

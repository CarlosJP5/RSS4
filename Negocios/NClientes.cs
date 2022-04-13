using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocios
{
    public class NClientes
    {
        private readonly DClientes _cliente = new DClientes();

        public DataTable Buscar(string Query)
        {
            return _cliente.Buscar(Query);
        }
        public DataTable BuscarId(string IdCliente)
        {
            int Id = Convert.ToInt32(IdCliente);
            return _cliente.BuscarId(Id);
        }
        public DataTable Listar()
        {
            return _cliente.Listar();
        }
        public int MaxId()
        {
            return _cliente.MaxId();
        }
        public void Editar(ECliente cliente)
        {
            _cliente.Editar(cliente);
        }
        public void Insertar(ECliente cliente)
        {
            _cliente.Insertar(cliente);
        }
    }
}

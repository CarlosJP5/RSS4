using Datos;
using System;
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
        public DataTable BuscarCuentaNombre(string Nombre)
        {
            return dBancos.BuscarCuentaNombre(Nombre);
        }
        public DataTable BuscarCuentaId(string id)
        {
            return dBancos.BuscarCuentaId(id);
        }
        public DataTable BuscarId(string id)
        {
            return dBancos.BuscarId(id);
        }
        public void EditarCuenta(string id, string idBanco, string nombre, string numero)
        {
            dBancos.EditarCuenta(id, idBanco, nombre, numero);
        }
        public void InsertarCuenta(string idBanco, string nombre, string numero)
        {
            dBancos.InsertarCuenta(idBanco, nombre, numero);
        }
        public void InsertarMovimiento(string idBanco, string idCtnBanco, DateTime fecha, string descripcion, double debito, double credito, double total)
        {
            dBancos.InsertarMovimiento(idBanco, idCtnBanco, fecha, descripcion, debito, credito, total);
        }
    }
}

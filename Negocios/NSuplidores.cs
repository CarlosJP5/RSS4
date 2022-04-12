﻿using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocios
{
    public class NSuplidores
    {
        private readonly DSuplidores _suplidor = new DSuplidores();

        public DataTable Buscar(string Query)
        {
            return _suplidor.Buscar(Query);
        }
        public DataTable BuscarId(string IdSuplidor)
        {
            int Id = Convert.ToInt32(IdSuplidor);
            return _suplidor.BuscarId(Id);
        }
        public DataTable Listar()
        {
            return _suplidor.Listar();
        }
        public int MaxId()
        {
            return _suplidor.MaxId();
        }
        public void Editar(ESuplidor suplidor)
        {
            _suplidor.Editar(suplidor);
        }
        public void Insertar(ESuplidor suplidor)
        {
            _suplidor.Insertar(suplidor);
        }
    }
}

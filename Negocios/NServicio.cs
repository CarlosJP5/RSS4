﻿using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocios
{
    public class NServicio
    {
        private readonly DServicio dservicio = new DServicio();

        public DataTable Buscar(DateTime desde, DateTime hasta)
        {
            return dservicio.Buscar(desde, hasta);
        }

        public DataTable Buscar_cliente(DateTime desde, DateTime hasta, string idCliente)
        {
            int id = int.Parse(idCliente);
            return dservicio.Buscar_cliente(desde, hasta, id);
        }

        public DataTable Buscar_idFactura(string idfactura)
        {
            return dservicio.Buscar_idFactura(idfactura);
        }

        public int Insertar(EServicio Factura, DataTable Detalle)
        {
            return dservicio.Insertar(Factura, Detalle);
        }
    }
}

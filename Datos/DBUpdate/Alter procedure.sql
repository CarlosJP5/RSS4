create proc reporte_ventas
@desde datetime,
@hasta datetime
as
begin
set nocount on
select id_factura, nombre_cliente, fecha_factura, importe_factura, descuento_factura, itbis_factura, total_factura, tipoCompra_factura from Factura
where fecha_factura between @desde and @hasta
order by fecha_factura asc
end
go
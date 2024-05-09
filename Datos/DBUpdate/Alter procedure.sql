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

create proc reporte_ventas_beneficio
@desde datetime,
@hasta datetime
as
begin
set nocount on
select fd.importe_factura, fd.descuento_factura, fd.cantidad_factura * fd.costo_factura as costoTotal
from Factura f
left join FacturaDetalle fd on f.id_factura = fd.id_factura
where f.fecha_factura between @desde and @hasta and f.tipoCompra_factura = 'CONTADO'
order by f.fecha_factura asc
end
go
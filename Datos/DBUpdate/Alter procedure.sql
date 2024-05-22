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

create proc reporte_ventas_devoluciones
@desde datetime,
@hasta datetime
as
begin
set nocount on
select dv.id_devolucion, cl.nombre_cliente, dv.fecha_devolucion, dv.importe_devolucion, dv.descuento_devolucion, dv.itbis_devolucion, dv.total_devolucion, dv.tipo_devolucion
from FacturaDevolucion dv
left join Clientes cl on dv.id_cliente = cl.id_cliente
where dv.fecha_devolucion between @desde and @hasta
order by dv.id_devolucion asc
end
go

create proc reporte_ventas_beneficio_devolucion
@desde datetime,
@hasta datetime
as
begin
set nocount on
select dt.precio_devolucion * dt.cantidad_devolucion as importe,
       fd.descuento_factura,
	   fd.costo_factura * dt.cantidad_devolucion as costo
from FacturaDevolucion dv
left join FacturaDevolucionDetalle dt on dv.id_devolucion = dt.id_devolucion
left join FacturaDetalle fd on dv.id_factura = fd.id_factura and dt.id_articulo = fd.id_articulo
where dv.fecha_devolucion between @desde and @hasta
end
go

create proc reporte_ventas_reciboIngreso
@desde datetime,
@hasta datetime
as
begin
	set nocount on
	select ri.id_ri, ri.fecha_ri, cl.nombre_cliente, ri.pago_ri 
	from ReciboIngreso ri
	left join Clientes cl on ri.id_cliente = cl.id_cliente
	where ri.fecha_ri between @desde and @hasta
	order by ri.id_ri asc
end
go

ALTER PROC [dbo].[reciboIngreso_buscarId]
@idRecibo int
AS
BEGIN
	SET NOCOUNT ON
	SELECT CL.id_cliente, CL.nombre_cliente, RI.fecha_ri,
	RI.id_ri, RI.id_factura, F.fecha_factura, RI.pago_ri,
	RI.estado_ri, F.total_factura
	FROM ReciboIngreso RI
	LEFT JOIN Clientes CL ON RI.id_cliente = CL.id_cliente
	LEFT JOIN Factura F ON RI.id_factura = F.id_factura
	WHERE RI.id_ri = @idRecibo
END
go

ALTER proc [dbo].[reporte_ventas_reciboIngreso]
@desde datetime,
@hasta datetime
as
begin
	set nocount on
	select ri.id_ri, ri.fecha_ri, cl.nombre_cliente, sum( ri.pago_ri) as pago 
	from ReciboIngreso ri
	left join Clientes cl on ri.id_cliente = cl.id_cliente
	where ri.fecha_ri between @desde and @hasta
	group by ri.id_ri, ri.fecha_ri, cl.nombre_cliente
	order by ri.id_ri asc
end
go

create proc reporte_ventas_beneficio_factura
@idFactura int
as
begin
set nocount on
select fd.importe_factura, fd.descuento_factura, fd.cantidad_factura * fd.costo_factura as costoTotal
from Factura f
left join FacturaDetalle fd on f.id_factura = fd.id_factura
where f.id_factura = @idFactura
order by f.fecha_factura asc
end
go
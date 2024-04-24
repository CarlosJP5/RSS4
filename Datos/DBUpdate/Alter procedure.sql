create proc articulo_inventario
as
begin
set nocount on
select codigo_articulo, nombre_articulo, cantidad_articulo, costo_articulo, precio_articulo,
(cantidad_articulo * costo_articulo) as costo, (cantidad_articulo * precio_articulo) as precio
from Articulo
where cantidad_articulo > 0
order by nombre_articulo asc
end
go

create proc cxc_estadoCuenta
as
begin
set nocount on
SELECT cc.id_cliente, cl.nombre_cliente, f.id_factura, f.fecha_factura,
f.total_factura, cc.balance_cxc
FROM CuentaCobrar cc
INNER JOIN Clientes cl ON cc.id_cliente = cl.id_cliente
INNER JOIN Factura f on cc.id_factura = f.id_factura
WHERE cc.balance_cxc > 0
order by cl.nombre_cliente
end
go
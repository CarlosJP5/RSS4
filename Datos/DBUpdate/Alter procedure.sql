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
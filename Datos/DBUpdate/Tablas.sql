USE [Link]
GO
/****** Object:  StoredProcedure [dbo].[compra_listar]    Script Date: 10/16/2023 5:55:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[compra_listar]
@desde date,
@hasta date
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_compra, facturaNumero_compra, fecha_compra, ncf_compra,
	S.nombre_suplidor, total_compra, tipoCompra_compra
	FROM Compra C
	LEFT JOIN Suplidores S ON C.id_suplidor = S.id_suplidor
	WHERE fecha_compra BETWEEN @desde AND @hasta
	ORDER BY id_compra DESC
END
GO

ALTER PROC [dbo].[compra_insertar]
@idSuplidor int,
@fecha date,
@tipoCompra varchar(10),
@facturaNumero varchar(50),
@ncf varchar(15),
@importe decimal(18,2),
@descuento decimal(18,2),
@itbis decimal(18,2),
@total decimal(18,2),
@taza float,
@detalle type_compra_detalle readonly
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @idCompra int = 1
	IF EXISTS (SELECT id_compra FROM Compra)
		SET @idCompra = 1 + (SELECT MAX(id_compra) FROM Compra)

	INSERT INTO Compra VALUES (@idCompra, @idSuplidor, @fecha, @tipoCompra,
	@facturaNumero, @ncf, @importe, @descuento, @itbis, @total * @taza, @taza)

	INSERT INTO CompraDetalle (id_compra, id_suplidor, id_articulo, tipoItbis_compra,
	cantidad_compra, descuento_compra, costo_compra, importe_compra, precio_compra,
	beneficio_compra, costoFinal_compra, totalImporte_compra, totalDescuento_compra,
	totalItbis_compra)
	SELECT @idCompra, @idSuplidor, D.idArticulo, D.tipoItbis, D.cantidad, D.descuento,
	D.costo, D.importe, D.precio, D.beneficio, D.costoFinal, D.totalImporte, 
	D.totalDescuento, D.totalItbis
	FROM @detalle D

	IF @tipoCompra = 'CREDITO'
		BEGIN
			DECLARE @idCxp int  = 1
			IF EXISTS (SELECT id_cxp FROM CuentaPagar)
				SET @idCxp = 1 + (SELECT MAX(id_cxp) FROM CuentaPagar)

			INSERT INTO CuentaPagar VALUES (@idCxp, @idCompra, @idSuplidor, @total * @taza, 'PENDIENTE')
		END
	select @idCompra
END
GO

create proc [dbo].[reporte_de_ventas]
@desde datetime,
@hasta datetime
as
begin
set nocount on
select f.id_factura,
	   f.fecha_factura,
	    
	   articulos = stuff((select ' ~ ' + 'x' + convert(varchar(10), fd2.cantidad_factura) + '' + a2.nombre_articulo
	       from FacturaDetalle fd2
		       inner join Articulo a2 on a2.id_articulo = fd2.id_articulo
			   where fd2.id_factura = fd.id_factura
			   for xml path('')), 1, 2, ''),
	   sum(fd.cantidad_factura * fd.precio_factura) as total_venta,
	   sum(fd.cantidad_factura * fd.costo_factura) as total_costo
from Factura f
inner join FacturaDetalle fd on f.id_factura = fd.id_factura
inner join Articulo a on fd.id_articulo = a.id_articulo
where f.fecha_factura between @desde and @hasta and f.tipoCompra_factura = 'CONTADO'
group by f.id_factura, f.fecha_factura, fd.id_factura
order by f.id_factura desc
end
go

create proc [dbo].[reporte_de_ventas_devolucion]
@desde datetime,
@hasta datetime
as
begin
set nocount on
select sum(fd.cantidad_devolucion * fd.precio_devolucion) as total_precio,
	   sum(fd.cantidad_devolucion * fd.costo_devolucion) as total_costo
from FacturaDevolucion f
left join FacturaDevolucionDetalle fd on f.id_devolucion = fd.id_devolucion
where f.fecha_devolucion between @desde and @hasta and f.tipo_devolucion = 'CONTADO'
end
GO
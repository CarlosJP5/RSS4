USE [AlvaroTruck]
GO
/****** Object:  StoredProcedure [dbo].[factura_editar]    Script Date: 4/30/2024 3:12:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[factura_editar]
@idFact int,
@idCliente int,
@tipoCompra varchar(10),
@nota varchar(50),
@importe decimal(18,2),
@descuento decimal(18,2),
@itbis decimal(18,2),
@total decimal(18,2),
@detalle type_factura_detalle readonly,
@nombreCliente nvarchar(50),
@idCaja int
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @tipoFactura VARCHAR(50) = (Select tipoCompra_factura from Factura WHERE id_factura = @idFact)
	IF @tipoCompra = 'CONTADO'
		BEGIN
			DECLARE @totalViejo decimal(18,2) = (Select total_factura from Factura WHERE id_factura = @idFact)
			UPDATE Caja SET total_caja = total_caja - @totalViejo WHERE id_caja = @idCaja
		END
	
	DELETE FacturaDetalle WHERE id_factura  = @idFact

	UPDATE Factura SET id_cliente = @idCliente, nota_factura = @nota,
	importe_factura = @importe, descuento_factura = @descuento,
	itbis_factura = @itbis, total_factura = @total, nombre_cliente = @nombreCliente,
	tipoCompra_factura = @tipoCompra
	WHERE id_factura = @idFact

	INSERT INTO FacturaDetalle (id_factura, id_articulo, cantidad_factura, descuento_factura,
	precio_factura, importe_factura, costo_factura, totalImporte_factura, 
	totalDescuento_factura, totalItbis_factura)
	SELECT @idFact, D.idArticulo, D.cantidad, D.descuento, D.precio, D.importe,
	D.costo, D.totalimporte, D.totaldescuento, D.totalitbis
	FROM @detalle D

	IF @tipoCompra = 'CREDITO'
		BEGIN
			IF exists(select id_factura from CuentaCobrar where id_factura = @idFact)
				BEGIN
					UPDATE CuentaCobrar SET id_cliente = @idCliente, balance_cxc = @total WHERE id_factura = @idFact
				END
			ELSE
				BEGIN
					DECLARE @idCxc int  = 1
					IF EXISTS (SELECT id_cxc FROM CuentaCobrar)
						SET @idCxc = 1 + (SELECT MAX(id_cxc) FROM CuentaCobrar)

					INSERT INTO CuentaCobrar VALUES (@idCxc, @idFact, @idCliente, @total, 'PENDIENTE')
					UPDATE Caja SET total_caja = total_caja - @total WHERE id_caja = @idCaja
				END
		END
	ELSE
		BEGIN
			UPDATE Caja SET total_caja = total_caja + @total WHERE id_caja = @idCaja
		END
END
go

ALTER PROC [dbo].[facturaServicio_editar]
@idFact int,
@id_cliente int,
@nombre_cliente nvarchar(50),
@cedula nvarchar(20),
@rnc nvarchar(20),
@tipoCompra nvarchar(10),
@importe decimal(18,2),
@itbis decimal(18,2),
@total decimal(18,2),
@detalle type_fservicio_detalle readonly,
@idCaja int
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @tipoFactura VARCHAR(50) = (Select tipoCompra_fservicio from FacturaServicio WHERE id_fservicio = @idFact)
	IF @tipoCompra = 'CONTADO'
		BEGIN
			DECLARE @totalViejo decimal(18,2) = (Select total_fservicio from FacturaServicio WHERE id_fservicio = @idFact)
			UPDATE Caja SET total_caja = total_caja - @totalViejo WHERE id_caja = @idCaja
		END

	UPDATE FacturaServicio SET id_cliente = @id_cliente, nombre_cliente = @nombre_cliente,
	cedula_cliente = @cedula, rnc_cliente = @rnc, importe_fservicio = @importe,
	itbis_fservicio = @itbis, total_fservicio = @total, tipoCompra_fservicio = @tipoCompra
	WHERE id_fservicio = @idFact

	DECLARE @idFact_fs nvarchar(50) = (SELECT id_fservicio_st FROM FacturaServicio WHERE id_fservicio = @idFact)

	Delete FacturaServicioDetalle where id_fservicio = @idFact

	INSERT INTO FacturaServicioDetalle(id_fservicio, descripcion_fservicio, precio_fservicio)
	SELECT @idFact, D.descripcion, D.precio
	FROM @detalle D

	IF @tipoCompra = 'CREDITO'
		BEGIN
			IF EXISTS (SELECT id_factura FROM CuentaCobrarServicio WHERE id_factura = @idFact_fs)
				UPDATE CuentaCobrarServicio SET balance_cxc = @total WHERE id_factura = @idFact_fs
			ELSE
				BEGIN
					DECLARE @idCxc int  = 1
					IF EXISTS (SELECT id_cxc FROM CuentaCobrarServicio)
						SET @idCxc = 1 + (SELECT MAX(id_cxc) FROM CuentaCobrarServicio)

					INSERT INTO CuentaCobrarServicio VALUES (@idCxc, @idFact_fs, @id_cliente, @total, 'PENDIENTE')
					UPDATE Caja SET total_caja = total_caja - @total WHERE id_caja = @idCaja
				END
		END
	ELSE
		BEGIN
			UPDATE Caja SET total_caja = total_caja + @total WHERE id_caja = @idCaja
		END
END
go
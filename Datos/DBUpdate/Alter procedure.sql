CREATE TABLE Caja
(
	id_caja int primary key,
	apertura_caja datetime,
	apertura_nombre varchar(50),
	cierre_caja datetime,
	cierre_nombre varchar(50),
	total_caja float,
	fondo_caja float,
	estado_caja varchar(15)
)
GO

create proc caja_apertura
@nombre varchar(50),
@fondo float
as
begin
	set nocount on
	declare @id int = 1
	if exists (select id_caja from Caja)
		set @id = 1 + (select max(id_caja) from Caja)

	insert into Caja (id_caja, apertura_caja, apertura_nombre, total_caja, fondo_caja, estado_caja)
	values(@id, GETDATE(), @nombre, 0, @fondo, 'ABIERTA')
end
GO

ALTER PROC [dbo].[facturaDevolucion_insertar]
@idFactura int,
@idcliente int,
@idComprobante varchar(3),
@ncf varchar(15),
@fecha date,
@fechaVencimiento date,
@importe decimal(18,2),
@descuento decimal(18,2),
@itbis decimal(18,2),
@total decimal(18,2),
@detalle type_devolucion_detalle readonly,
@tipoFactura nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @idDevolcion int  = 1
	IF EXISTS (SELECT id_devolucion FROM FacturaDevolucion)
		SET @idDevolcion = 1 + (SELECT MAX(id_devolucion) FROM FacturaDevolucion)

	INSERT INTO FacturaDevolucion VALUES (@idDevolcion, @idFactura, @idcliente, @idComprobante,
	@fecha, @importe, @descuento, @itbis, @total, @tipoFactura)

	INSERT INTO FacturaDevolucionDetalle (id_devolucion, id_articulo, cantidad_devolucion,
	totalImporte_devolucion, totalDescuento_devolucion, totalItbis_devolucion, precio_devolucion)
	SELECT @idDevolcion, D.idArticulo, D.cantidad, D.totalimporte, D.totaldescuento, D.totalitbis, D.precio
	FROM @detalle D

	INSERT INTO ComprobantesDetalle VALUES (@idComprobante, @idDevolcion, @ncf, @fechaVencimiento)
	SELECT MAX(id_devolucion) FROM FacturaDevolucion

	IF @tipoFactura = 'CREDITO'
		BEGIN
			UPDATE CuentaCobrar SET balance_cxc = balance_cxc - @total WHERE id_factura = @idFactura
		END
	RETURN SELECT @idDevolcion
END
GO
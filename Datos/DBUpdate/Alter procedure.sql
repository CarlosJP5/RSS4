create proc caja_cierre
@idCaja int,
@nombre_cierre varchar(50),
@fecha_cierre datetime
as
begin
	set nocount on
	update Caja set cierre_caja = @fecha_cierre, cierre_nombre = @nombre_cierre,
	       estado_caja = 'CERRADA'
	where id_caja = @idCaja
end
go

SELECT * INTO TEMP FROM Factura
GO

/****** Object:  Table [dbo].[Factura]    Script Date: 1/18/2024 3:55:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Factura]') AND type in (N'U'))
DROP TABLE [dbo].[Factura]
GO

/****** Object:  Table [dbo].[Factura]    Script Date: 1/18/2024 3:55:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Factura](
	[id_factura] [int] NOT NULL,
	[id_cliente] [int] NULL,
	[id_comprobante] [varchar](3) NULL,
	[fecha_factura] [datetime] NULL,
	[tipoCompra_factura] [varchar](10) NULL,
	[nota_factura] [varchar](50) NULL,
	[importe_factura] [decimal](18, 2) NULL,
	[descuento_factura] [decimal](18, 2) NULL,
	[itbis_factura] [decimal](18, 2) NULL,
	[total_factura] [decimal](18, 2) NULL,
	[nombre_cliente] [varchar](50) NULL,
	[id_caja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO Factura SELECT *, 0 FROM TEMP
GO

SELECT * INTO TEMP2 FROM FacturaServicio
GO

/****** Object:  Table [dbo].[FacturaServicio]    Script Date: 1/18/2024 4:00:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FacturaServicio]') AND type in (N'U'))
DROP TABLE [dbo].[FacturaServicio]
GO

/****** Object:  Table [dbo].[FacturaServicio]    Script Date: 1/18/2024 4:00:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FacturaServicio](
	[id_fservicio] [int] NOT NULL,
	[fecha_fservicio] [datetime] NULL,
	[id_cliente] [int] NULL,
	[nombre_cliente] [nvarchar](50) NULL,
	[cedula_cliente] [nvarchar](20) NULL,
	[rnc_cliente] [nvarchar](20) NULL,
	[id_comprobante] [nvarchar](5) NULL,
	[nombre_comprobante] [nvarchar](25) NULL,
	[importe_fservicio] [decimal](18, 2) NULL,
	[itbis_fservicio] [decimal](18, 2) NULL,
	[total_fservicio] [decimal](18, 2) NULL,
	[id_fservicio_st] [nvarchar](50) NOT NULL,
	[tipoCompra_fservicio] [nvarchar](50) NOT NULL,
	[id_caja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_fservicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO FacturaServicio SELECT *, 0 FROM TEMP2
GO

DROP TABLE TEMP2
GO

DROP TABLE TEMP
GO

ALTER PROC [dbo].[factura_insertar]
@idCliente int,
@idComprobante varchar(3),
@ncf varchar(15),
@fecha datetime,
@fechaVencimiento date,
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
	
	DECLARE @idFact int = 1
	IF EXISTS (SELECT id_factura FROM Factura)
		SET @idFact = 1 + (SELECT MAX(id_factura) FROM Factura)

	INSERT INTO ComprobantesDetalle VALUES (@idComprobante, @idFact, @ncf, @fechaVencimiento)

	INSERT INTO Factura VALUES (@idFact, @idCliente, @idComprobante, @fecha,
	@tipoCompra, @nota, @importe, @descuento, @itbis, @total, @nombreCliente, @idCaja)

	INSERT INTO FacturaDetalle (id_factura, id_articulo, cantidad_factura, descuento_factura,
	precio_factura, importe_factura, costo_factura, totalImporte_factura, 
	totalDescuento_factura, totalItbis_factura)
	SELECT @idFact, D.idArticulo, D.cantidad, D.descuento, D.precio, D.importe,
	D.costo, D.totalimporte, D.totaldescuento, D.totalitbis
	FROM @detalle D

	IF @tipoCompra = 'CREDITO'
		BEGIN
			DECLARE @idCxc int  = 1
			IF EXISTS (SELECT id_cxc FROM CuentaCobrar)
				SET @idCxc = 1 + (SELECT MAX(id_cxc) FROM CuentaCobrar)

			INSERT INTO CuentaCobrar VALUES (@idCxc, @idFact, @idCliente, @total, 'PENDIENTE')
		END
	ELSE
		BEGIN
			UPDATE Caja SET total_caja = total_caja + @total WHERE id_caja = @idCaja
		END

	SELECT MAX(id_factura) FROM Factura
END
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

	UPDATE Factura SET @idCliente = @idCliente, nota_factura = @nota,
	importe_factura = @importe, descuento_factura = @descuento,
	itbis_factura = @itbis, total_factura = @total, nombre_cliente = @nombreCliente
	WHERE id_factura = @idFact

	INSERT INTO FacturaDetalle (id_factura, id_articulo, cantidad_factura, descuento_factura,
	precio_factura, importe_factura, costo_factura, totalImporte_factura, 
	totalDescuento_factura, totalItbis_factura)
	SELECT @idFact, D.idArticulo, D.cantidad, D.descuento, D.precio, D.importe,
	D.costo, D.totalimporte, D.totaldescuento, D.totalitbis
	FROM @detalle D

	IF @tipoCompra = 'CREDITO'
		BEGIN
			UPDATE CuentaCobrar SET id_cliente = @idCliente, balance_cxc = @total WHERE id_factura = @idFact
		END
	ELSE
		BEGIN
			UPDATE Caja SET total_caja = total_caja + @total WHERE id_caja = @idCaja
		END
END
GO

ALTER PROC [dbo].[facturaServicio_insertar]
@fecha datetime,
@id_cliente int,
@nombre_cliente nvarchar(50),
@cedula nvarchar(20),
@rnc nvarchar(20),
@id_comprobante nvarchar(5),
@nombre_comprobante nvarchar(25),
@importe decimal(18,2),
@itbis decimal(18,2),
@total decimal(18,2),
@ncf varchar(15),
@fechaVencimiento date,
@idCotizacion nvarchar(50),
@tipoCompra varchar(10),
@detalle type_fservicio_detalle readonly,
@idCaja int
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @idFact int = 1
	IF EXISTS (SELECT id_fservicio FROM FacturaServicio)
		SET @idFact = 1 + (SELECT MAX(id_fservicio) FROM FacturaServicio)

	DECLARE @idFact_fs nvarchar(50) = 'FS-' + (SELECT CAST(@idFact as nvarchar(50)) as Num1)
	
	INSERT INTO ComprobantesDetalle VALUES (@id_comprobante, @idFact_fs, @ncf, @fechaVencimiento)

	INSERT INTO FacturaServicio VALUES (@idFact, @fecha, @id_cliente, @nombre_cliente,
	@cedula, @rnc, @id_comprobante, @nombre_comprobante, @importe, @itbis, @total, @idFact_fs, @tipoCompra, @idCaja)

	INSERT INTO FacturaServicioDetalle(id_fservicio, descripcion_fservicio, precio_fservicio)
	SELECT @idFact, D.descripcion, D.precio
	FROM @detalle D

	update CotizacionServicio set estado_cotizacion = 'Facturado'
	where id_fservicio_st = @idCotizacion

	IF @tipoCompra = 'CREDITO'
		BEGIN
			DECLARE @idCxc int  = 1
			IF EXISTS (SELECT id_cxc FROM CuentaCobrarServicio)
				SET @idCxc = 1 + (SELECT MAX(id_cxc) FROM CuentaCobrarServicio)

			INSERT INTO CuentaCobrarServicio VALUES (@idCxc, @idFact_fs, @id_cliente, @total, 'PENDIENTE')
		END
	ELSE
		BEGIN
			UPDATE Caja SET total_caja = total_caja + @total WHERE id_caja = @idCaja
		END

	SELECT id_fservicio_st FROM FacturaServicio
	where id_fservicio_st = @idFact_fs
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
	itbis_fservicio = @itbis, total_fservicio = @total
	WHERE id_fservicio = @idFact

	Delete FacturaServicioDetalle where id_fservicio = @idFact

	INSERT INTO FacturaServicioDetalle(id_fservicio, descripcion_fservicio, precio_fservicio)
	SELECT @idFact, D.descripcion, D.precio
	FROM @detalle D

	IF @tipoCompra = 'CREDITO'
		BEGIN
			UPDATE CuentaCobrarServicio SET balance_cxc = @total WHERE id_factura = (select top 1 id_fservicio_st from FacturaServicio where id_fservicio = @idFact)
		END
	ELSE
		BEGIN
			UPDATE Caja SET total_caja = total_caja + @total WHERE id_caja = @idCaja
		END
END
go

SELECT * INTO TEMP3 FROM ReciboIngreso
GO

/****** Object:  Table [dbo].[ReciboIngreso]    Script Date: 1/20/2024 4:14:07 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReciboIngreso]') AND type in (N'U'))
DROP TABLE [dbo].[ReciboIngreso]
GO

/****** Object:  Table [dbo].[ReciboIngreso]    Script Date: 1/20/2024 4:14:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReciboIngreso](
	[id_ri] [int] NULL,
	[id_factura] [int] NULL,
	[id_cliente] [int] NULL,
	[fecha_ri] [date] NULL,
	[pago_ri] [decimal](18, 2) NULL,
	[estado_ri] [varchar](20) NULL,
	[id_caja] [int] NULL
) ON [PRIMARY]
GO

INSERT INTO ReciboIngreso SELECT *, 0 FROM TEMP3
GO

DROP TABLE TEMP3
GO

ALTER PROC [dbo].[reciboIngreso_insertar]
@idCliente int,
@fecha date,
@detalle type_recibo_ingreso readonly,
@idCaja int
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @idRecibo int = 1
	IF EXISTS (SELECT id_ri FROM ReciboIngreso)
		SET @idRecibo = 1 + (SELECT MAX(id_ri) FROM ReciboIngreso)

	INSERT INTO ReciboIngreso (id_ri, id_factura, id_cliente,
	fecha_ri, pago_ri, estado_ri, id_caja)
	SELECT @idRecibo, D.idFactura, @idCliente, @fecha, D.pago, D.estado, @idCaja
	FROM @detalle D

	DECLARE @total decimal(18,2) = (SELECT SUM(RI.pago_ri) Monto FROM ReciboIngreso RI WHERE RI.id_ri = @idRecibo)
	UPDATE Caja SET total_caja = total_caja + @total WHERE id_caja = @idCaja

	SELECT MAX(id_ri) FROM ReciboIngreso
END
GO

SELECT * INTO TEMP4 FROM ReciboIngresoServicio
GO

/****** Object:  Table [dbo].[ReciboIngresoServicio]    Script Date: 1/20/2024 4:20:39 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReciboIngresoServicio]') AND type in (N'U'))
DROP TABLE [dbo].[ReciboIngresoServicio]
GO

/****** Object:  Table [dbo].[ReciboIngresoServicio]    Script Date: 1/20/2024 4:20:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReciboIngresoServicio](
	[id_ri] [int] NULL,
	[id_factura] [nvarchar](50) NULL,
	[id_cliente] [int] NULL,
	[fecha_ri] [date] NULL,
	[pago_ri] [decimal](18, 2) NULL,
	[estado_ri] [varchar](20) NULL,
	[id_caja] [int] NULL
) ON [PRIMARY]
GO

INSERT INTO ReciboIngresoServicio SELECT *, 0 FROM TEMP4
GO

DROP TABLE TEMP4
GO

ALTER PROC [dbo].[reciboIngreso_insertar_servicio]
@idCliente int,
@fecha date,
@detalle type_recibo_ingreso_servicio readonly,
@idCaja int
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @idRecibo int = 1
	IF EXISTS (SELECT id_ri FROM ReciboIngresoServicio)
		SET @idRecibo = 1 + (SELECT MAX(id_ri) FROM ReciboIngresoServicio)

	INSERT INTO ReciboIngresoServicio (id_ri, id_factura, id_cliente,
	fecha_ri, pago_ri, estado_ri, id_caja)
	SELECT @idRecibo, D.idFactura, @idCliente, @fecha, D.pago, D.estado, @idCaja
	FROM @detalle D

	DECLARE @total decimal(18,2) = (SELECT SUM(RI.pago_ri) Monto FROM ReciboIngresoServicio RI WHERE RI.id_ri = @idRecibo)
	UPDATE Caja SET total_caja = total_caja + @total WHERE id_caja = @idCaja

	SELECT MAX(id_ri) FROM ReciboIngresoServicio
END
GO

ALTER PROC [dbo].[reciboIngreso_anular]
@IdRecibo int
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @idCaja INT = (SELECT id_caja FROM ReciboIngreso RI WHERE RI.id_ri = @idRecibo)
	DECLARE @total decimal(18,2) = (SELECT SUM(RI.pago_ri) Monto FROM ReciboIngreso RI WHERE RI.id_ri = @idRecibo)
	UPDATE Caja SET total_caja = total_caja - @total WHERE id_caja = @idCaja

	DELETE ReciboIngreso
	WHERE id_ri = @IdRecibo
END
go

ALTER PROC [dbo].[reciboIngreso_anular_servicio]
@IdRecibo int
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @idCaja INT = (SELECT id_caja FROM ReciboIngresoServicio RI WHERE RI.id_ri = @idRecibo)
	DECLARE @total decimal(18,2) = (SELECT SUM(RI.pago_ri) Monto FROM ReciboIngresoServicio RI WHERE RI.id_ri = @idRecibo)
	UPDATE Caja SET total_caja = total_caja - @total WHERE id_caja = @idCaja

	DELETE ReciboIngresoServicio
	WHERE id_ri = @IdRecibo
END
go

SELECT * INTO TEMP5 FROM FacturaDevolucion
GO

/****** Object:  Table [dbo].[FacturaDevolucion]    Script Date: 1/23/2024 10:37:56 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FacturaDevolucion]') AND type in (N'U'))
DROP TABLE [dbo].[FacturaDevolucion]
GO

/****** Object:  Table [dbo].[FacturaDevolucion]    Script Date: 1/23/2024 10:37:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FacturaDevolucion](
	[id_devolucion] [int] NOT NULL,
	[id_factura] [int] NULL,
	[id_cliente] [int] NULL,
	[id_comprobante] [varchar](3) NULL,
	[fecha_devolucion] [date] NULL,
	[importe_devolucion] [decimal](18, 2) NULL,
	[descuento_devolucion] [decimal](18, 2) NULL,
	[itbis_devolucion] [decimal](18, 2) NULL,
	[total_devolucion] [decimal](18, 2) NULL,
	[tipo_devolucion] [nvarchar](20) NULL,
	[id_caja] [int] NULL
PRIMARY KEY CLUSTERED 
(
	[id_devolucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO FacturaDevolucion SELECT *, 0 FROM TEMP5
GO

DROP TABLE TEMP5
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
@tipoFactura nvarchar(50),
@idCaja int
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @idDevolcion int  = 1
	IF EXISTS (SELECT id_devolucion FROM FacturaDevolucion)
		SET @idDevolcion = 1 + (SELECT MAX(id_devolucion) FROM FacturaDevolucion)

	INSERT INTO FacturaDevolucion VALUES (@idDevolcion, @idFactura, @idcliente, @idComprobante,
	@fecha, @importe, @descuento, @itbis, @total, @tipoFactura, @idCaja)

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
	ELSE
		BEGIN
			UPDATE Caja SET total_caja = total_caja - @total WHERE id_caja = @idCaja
		END
END
go

create PROC [dbo].[factura_listar_cajero]
@idcaja int
AS
BEGIN
	SET NOCOUNT ON
	SELECT F.id_factura, F.fecha_factura, CD.ncf_comprobante,
	C.nombre_cliente, F.total_factura, F.tipoCompra_factura
	FROM Factura F
	LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente
	LEFT JOIN ComprobantesDetalle CD ON F.id_comprobante = F.id_comprobante AND cast(F.id_factura as varchar(50)) = CD.id_documento
	WHERE F.id_caja = @idcaja
	ORDER BY F.id_factura DESC
END
go

create PROC [dbo].[facturaServicio_listar2_caja]
@idCaja int
AS
BEGIN
	SET NOCOUNT ON
	SELECT F.id_fservicio_st, F.fecha_fservicio, CD.ncf_comprobante,
	C.nombre_cliente, F.total_fservicio, F.tipoCompra_fservicio
	FROM FacturaServicio F
	LEFT JOIN ComprobantesDetalle CD ON F.id_fservicio_st = CD.id_documento AND F.id_comprobante = CD.id_comprobante
	LEFT JOIN Clientes C on F.id_cliente = C.id_cliente
	WHERE F.id_caja = @idCaja
	ORDER BY F.id_fservicio DESC
END
go

create PROC [dbo].[facturaDevolucion_listar_caja]
@idcaja int
AS
BEGIN
	SET NOCOUNT ON
	SELECT DV.id_devolucion, CD.ncf_comprobante,
	DV.fecha_devolucion, CL.nombre_cliente, DV.total_devolucion
	FROM FacturaDevolucion DV
	LEFT JOIN ComprobantesDetalle CD ON CD.id_documento = DV.id_devolucion AND CD.id_comprobante = DV.id_comprobante
	LEFT JOIN Clientes CL ON DV.id_cliente = CL.id_cliente
	WHERE DV.id_caja = @idcaja
	ORDER BY DV.id_devolucion DESC
END
go

create proc [dbo].[facturaDevolucion_rpt_listar_caja]
@idcaja int
as
begin
set nocount on
SELECT d.id_devolucion, d.id_cliente, d.id_comprobante, d.fecha_devolucion,
d.tipo_devolucion, d.importe_devolucion, d.descuento_devolucion, d.itbis_devolucion,
d.total_devolucion, cl.nombre_cliente, cl.cedula_cliente, cl.rnc_cliente,
cl.direccion_cliente, cl.telefono_cliente, cd.ncf_comprobante,
cd.fechaVencimiento_comprobante, cdd.nombre_comprobante
FROM FacturaDevolucion d
left join Clientes cl on d.id_cliente = cl.id_cliente
left join Comprobantes cdd on d.id_comprobante = cdd.id_comprobante
left join ComprobantesDetalle cd on d.id_comprobante = cd.id_comprobante and CONVERT(nvarchar, d.id_devolucion) = cd.id_documento
WHERE d.id_caja = @idcaja
end
go

create PROC [dbo].[reciboIngreso_listar_caja]
@idCaja int
AS
BEGIN
	SET NOCOUNT ON
	SELECT RI.id_ri, RI.fecha_ri, CL.nombre_cliente, SUM(RI.pago_ri) Monto
	FROM ReciboIngreso RI
	LEFT JOIN Clientes CL ON RI.id_cliente = CL.id_cliente
	WHERE RI.id_caja = @idCaja
	GROUP BY RI.id_ri, RI.fecha_ri, CL.nombre_cliente
	ORDER BY RI.id_ri DESC
END
go

create PROC [dbo].[reciboIngreso_listar_servicio_caja]
@idCaja int
AS
BEGIN
	SET NOCOUNT ON
	SELECT RI.id_ri, RI.fecha_ri, CL.nombre_cliente, SUM(RI.pago_ri) Monto
	FROM ReciboIngresoServicio RI
	LEFT JOIN Clientes CL ON RI.id_cliente = CL.id_cliente
	WHERE RI.id_caja = @idCaja
	GROUP BY RI.id_ri, RI.fecha_ri, CL.nombre_cliente
	ORDER BY RI.id_ri DESC
END
go
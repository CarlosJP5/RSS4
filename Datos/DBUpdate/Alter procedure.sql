--USE [JuanGomas]
--GO


--SELECT * into temp from Factura
--GO

--/****** Object:  Table [dbo].[Factura]    Script Date: 08/04/2024 8:48:37 pm ******/
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Factura]') AND type in (N'U'))
--DROP TABLE [dbo].[Factura]
--GO

--/****** Object:  Table [dbo].[Factura]    Script Date: 08/04/2024 8:48:37 pm ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO

--CREATE TABLE [dbo].[Factura](
--	[id_factura] [int] NOT NULL,
--	[id_cliente] [int] NULL,
--	[id_comprobante] [varchar](3) NULL,
--	[fecha_factura] [datetime] NULL,
--	[tipoCompra_factura] [varchar](10) NULL,
--	[nota_factura] [varchar](50) NULL,
--	[importe_factura] [decimal](18, 2) NULL,
--	[descuento_factura] [decimal](18, 2) NULL,
--	[itbis_factura] [decimal](18, 2) NULL,
--	[total_factura] [decimal](18, 2) NULL,
--	[nombre_cliente] [varchar](50) NULL,
--	[id_mecanico] [int] NULL,
--	[comision_paga] [bit] NULL,
--PRIMARY KEY CLUSTERED 
--(
--	[id_factura] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]
--GO

--insert into Factura select *,0 from temp
--go

--drop table temp
--go

--ALTER PROC [dbo].[mecanico_comision]
--@idMecanico int,
--@desde datetime,
--@hasta datetime
--AS
--BEGIN
--	SET NOCOUNT ON

--	SELECT F.id_factura, F.fecha_factura, F.nombre_cliente,
--	       F.total_factura, M.comision_mecanico, F.comision_paga
--    FROM Factura F
--	RIGHT JOIN Mecanico M ON F.id_mecanico = M.id_mecanico
--	WHERE F.id_mecanico = @idMecanico AND F.fecha_factura BETWEEN @desde AND @hasta
--	      AND F.comision_paga = 0
--	ORDER BY F.id_factura
--END
--GO

--CREATE TYPE comisionAplicarPago AS TABLE 
--(
--	idFactura int,
--	pago bit
--)
--GO

--CREATE PROC [dbo].[mecanico_comision_paga]
--@detalle comisionAplicarPago readonly
--AS
--BEGIN
--	SET NOCOUNT ON
	
--	UPDATE Factura SET comision_paga = D.pago
--	FROM @detalle D
--	WHERE id_factura = D.idFactura
--END
--GO

--ALTER PROC [dbo].[factura_insertar]
--@idCliente int,
--@idComprobante varchar(3),
--@ncf varchar(15),
--@fecha datetime,
--@fechaVencimiento date,
--@tipoCompra varchar(10),
--@nota varchar(50),
--@importe decimal(18,2),
--@descuento decimal(18,2),
--@itbis decimal(18,2),
--@total decimal(18,2),
--@detalle type_factura_detalle readonly,
--@nombreCliente nvarchar(50),
--@idMecanico int
--AS
--BEGIN
--	SET NOCOUNT ON
	
--	DECLARE @idFact int = 1
--	IF EXISTS (SELECT id_factura FROM Factura)
--		SET @idFact = 1 + (SELECT MAX(id_factura) FROM Factura)

--	INSERT INTO ComprobantesDetalle VALUES (@idComprobante, @idFact, @ncf, @fechaVencimiento)

--	INSERT INTO Factura VALUES (@idFact, @idCliente, @idComprobante, @fecha,
--	@tipoCompra, @nota, @importe, @descuento, @itbis, @total, @nombreCliente, @idMecanico, 0)

--	INSERT INTO FacturaDetalle (id_factura, id_articulo, cantidad_factura, descuento_factura,
--	precio_factura, importe_factura, costo_factura, totalImporte_factura, 
--	totalDescuento_factura, totalItbis_factura)
--	SELECT @idFact, D.idArticulo, D.cantidad, D.descuento, D.precio, D.importe,
--	D.costo, D.totalimporte, D.totaldescuento, D.totalitbis
--	FROM @detalle D

--	IF @tipoCompra = 'CREDITO'
--		BEGIN
--			DECLARE @idCxc int  = 1
--			IF EXISTS (SELECT id_cxc FROM CuentaCobrar)
--				SET @idCxc = 1 + (SELECT MAX(id_cxc) FROM CuentaCobrar)

--			INSERT INTO CuentaCobrar VALUES (@idCxc, @idFact, @idCliente, @total, 'PENDIENTE')
--		END

--	SELECT MAX(id_factura) FROM Factura
--END
--go

--CREATE TABLE Gasto
--(
--	id_gasto int primary key not null,
--	nombre_gasto varchar(50)  not null
--)
--go

--create proc gasto_insertar
--@nombre varchar(50)
--as
--begin
--	set nocount on
--	declare @id int = 1
--	if exists (select id_gasto from Gasto)
--		set @id = 1 + (select max(id_gasto) from Gasto)
--	insert into Gasto (id_gasto,
--					   nombre_gasto
--					   )
--			values    (@id,
--			           @nombre
--					   )
--end
--go

--create proc gasto_editar
--@id int,
--@nombre varchar(50)
--as
--begin
--	set nocount on
--	update Gasto set nombre_gasto = @nombre
--	where id_gasto = @id
--end
--go

--create proc gasto_buscar
--@nombre varchar(50)
--as
--begin
--	set nocount on
--	select id_gasto, nombre_gasto from Gasto
--	where nombre_gasto like '%' + @nombre + '%'
--end
--go

--create proc gasto_buscar_id
--@id int
--as
--begin
--	set nocount on
--	select id_gasto, nombre_gasto from Gasto
--	where id_gasto = @id
--end
--go

--create table GastoDetalle
--(
--	registro_gasto int primary key,
--	id_gasto int,
--	fecha_gasto datetime,
--	nota_gatos varchar(150),
--	monto_gasto decimal(12,2)
--)
--go

--create proc gastoDetalle_insertar
--@idGasto int,
--@fecha datetime,
--@nota varchar(150),
--@monto decimal(12,2)
--as
--begin
--	set nocount on
--	declare @id int = 1
--	if exists (select registro_gasto from GastoDetalle)
--		set @id = 1 + (select max(registro_gasto) from GastoDetalle)
--	insert into GastoDetalle (registro_gasto,
--							  id_gasto,
--							  fecha_gasto,
--							  nota_gatos,
--							  monto_gasto
--							  )
--	values                   (@id,
--	                          @idGasto,
--							  @fecha,
--							  @nota,
--							  @monto
--							  )
--end
--go

--create proc gastoDetalle_editar
--@registro int,
--@idGasto int,
--@fecha datetime,
--@nota varchar(150),
--@monto decimal(12,2)
--as
--begin
--	set nocount on
--	update GastoDetalle set   id_gasto = @idGasto,
--							  fecha_gasto = @fecha,
--							  nota_gatos = @nota,
--							  monto_gasto = @monto
--	where registro_gasto = @registro
--end
--go

--create proc gastoDetalle_buscar
--@desde datetime,
--@hasta datetime
--as
--begin
--	set nocount on
--	select gd.registro_gasto,
--	       gd.id_gasto,
--		   g.nombre_gasto,
--		   gd.fecha_gasto,
--		   gd.nota_gatos,
--		   gd.monto_gasto
--	from GastoDetalle gd
--	left join Gasto g on gd.id_gasto = g.id_gasto
--	where gd.fecha_gasto between @desde and @hasta
--	order by gd.registro_gasto
--end
--go

--create proc gastoDetalle_buscar_tipoGasto
--@desde datetime,
--@hasta datetime,
--@idGasto int
--as
--begin
--	set nocount on
--	select gd.registro_gasto,
--	       gd.id_gasto,
--		   g.nombre_gasto,
--		   gd.fecha_gasto,
--		   gd.nota_gatos,
--		   gd.monto_gasto
--	from GastoDetalle gd
--	left join Gasto g on gd.id_gasto = g.id_gasto
--	where gd.fecha_gasto between @desde and @hasta
--	and   gd.id_gasto = @idGasto
--	order by gd.registro_gasto
--end
--go

--create proc gastoDetalle_buscar_idRegistro
--@registro int
--as
--begin
--	set nocount on
--	select gd.registro_gasto,
--	       gd.id_gasto,
--		   g.nombre_gasto,
--		   gd.fecha_gasto,
--		   gd.nota_gatos,
--		   gd.monto_gasto
--	from GastoDetalle gd
--	left join Gasto g on gd.id_gasto = g.id_gasto
--	and   gd.id_gasto = @registro
--	order by gd.registro_gasto
--end
--go

ALTER proc [dbo].[gasto_buscar]
@nombre varchar(50)
as
begin
	set nocount on
	select id_gasto, nombre_gasto from Gasto
	where nombre_gasto like '%' + @nombre + '%'
	order by nombre_gasto
end
go

ALTER proc [dbo].[gastoDetalle_buscar_tipoGasto]
@desde datetime,
@hasta datetime,
@idGasto int
as
begin
	set nocount on
	select gd.registro_gasto,
	       gd.id_gasto,
		   g.nombre_gasto,
		   gd.fecha_gasto,
		   gd.nota_gatos,
		   gd.monto_gasto
	from GastoDetalle gd
	left join Gasto g on gd.id_gasto = g.id_gasto
	where gd.fecha_gasto between @desde and @hasta
	and   gd.id_gasto = @idGasto
	order by gd.registro_gasto desc
end
go

ALTER proc [dbo].[gastoDetalle_buscar_idRegistro]
@registro int
as
begin
	set nocount on
	select gd.registro_gasto,
	       gd.id_gasto,
		   g.nombre_gasto,
		   gd.fecha_gasto,
		   gd.nota_gatos,
		   gd.monto_gasto
	from GastoDetalle gd
	left join Gasto g on gd.id_gasto = g.id_gasto
	and   gd.id_gasto = @registro
	order by gd.registro_gasto desc
end
go

ALTER proc [dbo].[gastoDetalle_buscar]
@desde datetime,
@hasta datetime
as
begin
	set nocount on
	select gd.registro_gasto,
	       gd.id_gasto,
		   g.nombre_gasto,
		   gd.fecha_gasto,
		   gd.nota_gatos,
		   gd.monto_gasto
	from GastoDetalle gd
	left join Gasto g on gd.id_gasto = g.id_gasto
	where gd.fecha_gasto between @desde and @hasta
	order by gd.registro_gasto desc
end
go
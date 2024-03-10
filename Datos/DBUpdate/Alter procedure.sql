CREATE TABLE Mecanico
(
	id_mecanico int primary key,
	nombre_mecanico varchar(50),
	comision_mecanico float
)
go

create proc mecanico_insertar
@nombre varchar(50),
@comision float
as
begin
	set nocount on
	declare @id int  = 1
	if exists (select id_mecanico from Mecanico)
		set @id = 1 + (select max(id_mecanico) from Mecanico)
	insert into Mecanico (id_mecanico, nombre_mecanico, comision_mecanico)
	values (@id, @nombre, @comision)
end
go

create proc mecanico_editar
@id int,
@nombre varchar(50),
@comision float
as
begin
	set nocount on
	update Mecanico set nombre_mecanico = @nombre, comision_mecanico = @comision
	where id_mecanico = @id
end
go

create proc mecanico_buscar
@nombre varchar(50)
as
begin
	set nocount on
	select id_mecanico, nombre_mecanico, comision_mecanico from Mecanico
	where nombre_mecanico like '%' + @nombre + '%'
	order by nombre_mecanico
end
go

create proc mecanico_buscar_id
@id int
as
begin
	set nocount on
	select id_mecanico, nombre_mecanico, comision_mecanico from Mecanico
	where id_mecanico = @id
	order by nombre_mecanico
end
go

SELECT * INTO TEMP1 FROM Factura
GO

/****** Object:  Table [dbo].[Factura]    Script Date: 3/9/2024 3:43:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Factura]') AND type in (N'U'))
DROP TABLE [dbo].[Factura]
GO

/****** Object:  Table [dbo].[Factura]    Script Date: 3/9/2024 3:43:36 PM ******/
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
	[id_mecanico] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO Factura SELECT *, 0 FROM TEMP1
GO

DROP TABLE TEMP1
GO
DROP TABLE TEMP2
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
@idMecanico int
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @idFact int = 1
	IF EXISTS (SELECT id_factura FROM Factura)
		SET @idFact = 1 + (SELECT MAX(id_factura) FROM Factura)

	INSERT INTO ComprobantesDetalle VALUES (@idComprobante, @idFact, @ncf, @fechaVencimiento)

	INSERT INTO Factura VALUES (@idFact, @idCliente, @idComprobante, @fecha,
	@tipoCompra, @nota, @importe, @descuento, @itbis, @total, @nombreCliente, @idMecanico)

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

	SELECT MAX(id_factura) FROM Factura
END
GO

CREATE PROC mecanico_comision
@idMecanico int,
@desde datetime,
@hasta datetime
AS
BEGIN
	SET NOCOUNT ON

	SELECT F.id_factura, F.fecha_factura, F.nombre_cliente,
	       F.total_factura, M.comision_mecanico
    FROM Factura F
	RIGHT JOIN Mecanico M ON F.id_mecanico = M.id_mecanico
	WHERE F.id_mecanico = @idMecanico AND F.fecha_factura BETWEEN @desde AND @hasta
	ORDER BY F.id_factura
END
GO
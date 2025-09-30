USE [RepMyC]
GO

SELECT * INTO newtable FROM Articulo
go

ALTER TABLE [dbo].[Articulo] DROP CONSTRAINT [DF__Articulo__puntoR__34C8D9D1]
GO

/****** Object:  Table [dbo].[Articulo]    Script Date: 3/24/2025 9:52:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Articulo]') AND type in (N'U'))
DROP TABLE [dbo].[Articulo]
GO

/****** Object:  Table [dbo].[Articulo]    Script Date: 3/24/2025 9:52:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articulo](
	[id_articulo] [int] NOT NULL,
	[id_marca] [int] NULL,
	[id_suplidor] [int] NULL,
	[id_itbis] [int] NULL,
	[codigo_articulo] [varchar](50) NULL,
	[nombre_articulo] [varchar](50) NULL,
	[referencia_articulo] [varchar](50) NULL,
	[puntoReorden_articulo] [int] NULL,
	[cantidad_articulo] [decimal](18, 2) NULL,
	[costo_articulo] [decimal](18, 2) NULL,
	[precio_articulo] [decimal](18, 2) NULL,
	[beneficio_articulo] [decimal](18, 2) NULL,
	[estado_articulo] [bit] NULL,
	[beneficio_minimo] [decimal](18, 2) NULL,
	[ubicacion_articulo] [varchar](50) NULL,
 CONSTRAINT [PK__Articulo__3F6E8288AF52858D] PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Articulo__014352623BD6DE5F] UNIQUE NONCLUSTERED 
(
	[codigo_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Articulo] ADD  CONSTRAINT [DF__Articulo__puntoR__34C8D9D1]  DEFAULT ((0)) FOR [puntoReorden_articulo]
GO

insert into Articulo select *, '' from newtable
go

drop table newtable
go

ALTER PROC [dbo].[articulo_insertar]
@idMarca int,
@idItbis int,
@idSuplidor int,
@codigo varchar(50),
@nombre varchar(50),
@referencia varchar(50),
@puntoReorden int,
@cantidad decimal(18,2),
@costo decimal(18,2),
@precio decimal(18,2),
@beneficio decimal(18,2),
@estado bit,
@minimo decimal(18,2),
@ubicacion varchar(50)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @id int = 1
	IF EXISTS(SELECT id_articulo FROM Articulo)
		SET @id = 1 + (SELECT MAX(id_articulo) FROM Articulo)

	INSERT INTO Articulo VALUES (@id, @idMarca, @idSuplidor, @idItbis, 
	@codigo, @nombre, @referencia, @puntoReorden, @cantidad, @costo,
	@precio, @beneficio, @estado, @minimo, @ubicacion)
END
go

ALTER PROC [dbo].[articulo_editar]
@id int,
@idMarca int,
@idItbis int,
@idSuplidor int,
@codigo varchar(50),
@nombre varchar(50),
@referencia varchar(50),
@puntoReorden int,
@cantidad decimal(18,2),
@costo decimal(18,2),
@precio decimal(18,2),
@beneficio decimal(18,2),
@estado bit,
@minimo decimal(18,2),
@ubicacion varchar(50)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE Articulo SET id_marca = @idMarca, id_itbis = @idItbis,
	id_suplidor = @idSuplidor, codigo_articulo = @codigo,
	nombre_articulo = @nombre, referencia_articulo = @referencia,
	puntoReorden_articulo = @puntoReorden, cantidad_articulo = @cantidad,
	costo_articulo = @costo, precio_articulo = @precio,
	beneficio_articulo = @beneficio, estado_articulo = @estado,
	beneficio_minimo = @minimo, ubicacion_articulo = @ubicacion
	WHERE id_articulo = @id
END
go

ALTER PROC [dbo].[articulo_listar]
AS
BEGIN
	SET NOCOUNT ON

	SELECT A.id_articulo, codigo_articulo, referencia_articulo, nombre_articulo,
	nombre_marca, cantidad_articulo, precio_articulo, estado_articulo, porciento_itbis,
	A.costo_articulo, A.beneficio_minimo, A.puntoReorden_articulo, A.ubicacion_articulo
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis
	ORDER BY nombre_articulo
END
go

ALTER PROC [dbo].[articulo_BuscarId]
@id int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT A.id_articulo, A.id_marca, A.id_itbis, A.id_suplidor,
	codigo_articulo, nombre_articulo, referencia_articulo, puntoReorden_articulo,
	cantidad_articulo, costo_articulo, precio_articulo, beneficio_articulo, 
	estado_articulo, nombre_marca, nombre_itbis, porciento_itbis,
	nombre_suplidor, beneficio_minimo, A.ubicacion_articulo
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	LEFT JOIN Suplidores S ON A.id_suplidor = S.id_suplidor
	LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis
	WHERE A.id_articulo = @id
END
go

ALTER PROC [dbo].[articulo_BuscarCodigo]
@codigo varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT A.id_articulo, A.id_marca, A.id_itbis, A.id_suplidor,
	codigo_articulo, nombre_articulo, referencia_articulo, puntoReorden_articulo,
	cantidad_articulo, costo_articulo, precio_articulo, beneficio_articulo, 
	estado_articulo, nombre_marca, nombre_itbis, porciento_itbis,
	nombre_suplidor, beneficio_minimo, A.ubicacion_articulo
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	LEFT JOIN Suplidores S ON A.id_suplidor = S.id_suplidor
	LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis
	WHERE A.codigo_articulo = @codigo
END
go


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


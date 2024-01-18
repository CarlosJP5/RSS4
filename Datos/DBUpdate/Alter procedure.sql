DROP TABLE TEMP2
GO

DROP TABLE TEMP
GO

create proc caja_cierre
@idCaja int,
@nombre_cierre varchar(50),
@fecha_cierre datetime
as
begin
	set nocount on
	update Caja set cierre_caja = @fecha_cierre, cierre_nombre = @nombre_cierre,
	       estado_caja = 'CERRADO'
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
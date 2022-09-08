USE [AlvaroTruck]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 9/7/2022 11:14:19 AM ******/
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
/****** Object:  Table [dbo].[ArticuloAjuste]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticuloAjuste](
	[id_ajuste] [int] NULL,
	[id_articulo] [int] NULL,
	[fecha_ajuste] [date] NULL,
	[nota_ajuste] [varchar](50) NULL,
	[cantidad_ajuste] [decimal](10, 2) NULL,
	[tipo_ajuste] [char](1) NULL,
	[costo_ajuste] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticuloItbis]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticuloItbis](
	[id_itbis] [int] NOT NULL,
	[nombre_itbis] [varchar](40) NULL,
	[porciento_itbis] [decimal](6, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_itbis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticuloMarca]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticuloMarca](
	[id_marca] [int] NOT NULL,
	[nombre_marca] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_cliente] [int] NOT NULL,
	[id_comprobante] [varchar](3) NOT NULL,
	[nombre_cliente] [varchar](50) NULL,
	[cedula_cliente] [varchar](15) NULL,
	[rnc_cliente] [varchar](15) NULL,
	[direccion_cliente] [varchar](150) NULL,
	[telefono_cliente] [varchar](15) NULL,
	[correo_cliente] [varchar](50) NULL,
	[tipoCompra_cliente] [varchar](10) NULL,
	[limiteCredito_cliente] [decimal](18, 2) NULL,
	[descuento_cliente] [decimal](6, 2) NULL,
	[estado_cliente] [bit] NULL,
 CONSTRAINT [PK__Clientes__677F38F5D8756075] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[id_compra] [int] NOT NULL,
	[id_suplidor] [int] NULL,
	[fecha_compra] [date] NULL,
	[tipoCompra_compra] [varchar](10) NULL,
	[facturaNumero_compra] [varchar](50) NULL,
	[ncf_compra] [varchar](15) NULL,
	[importe_compra] [decimal](18, 2) NULL,
	[descuento_compra] [decimal](18, 2) NULL,
	[itbis_compra] [decimal](18, 2) NULL,
	[total_compra] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraDetalle]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraDetalle](
	[id_compra] [int] NULL,
	[id_suplidor] [int] NULL,
	[id_articulo] [int] NULL,
	[tipoItbis_compra] [char](1) NULL,
	[cantidad_compra] [decimal](18, 2) NULL,
	[descuento_compra] [decimal](18, 2) NULL,
	[costo_compra] [decimal](18, 2) NULL,
	[importe_compra] [decimal](18, 2) NULL,
	[precio_compra] [decimal](18, 2) NULL,
	[beneficio_compra] [decimal](18, 2) NULL,
	[costoFinal_compra] [decimal](18, 2) NULL,
	[totalImporte_compra] [decimal](18, 2) NULL,
	[totalDescuento_compra] [decimal](18, 2) NULL,
	[totalItbis_compra] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraDevolucion]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraDevolucion](
	[id_devolucionCompra] [int] NULL,
	[id_compra] [int] NULL,
	[id_suplidor] [int] NULL,
	[fecha_devolucionCompra] [date] NULL,
	[importe_devolucionCompra] [decimal](18, 2) NULL,
	[descuento_devolucionCompra] [decimal](18, 2) NULL,
	[itbis_devolucionCompra] [decimal](18, 2) NULL,
	[total_devolucionCompra] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraDevolucionDetalle]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraDevolucionDetalle](
	[id_devolucionCompra] [int] NULL,
	[id_articulo] [int] NULL,
	[cantidad_devolucionCompra] [decimal](16, 2) NULL,
	[importeUnitario_devolucionCompra] [decimal](16, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comprobantes]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comprobantes](
	[id_comprobante] [varchar](3) NOT NULL,
	[nombre_comprobante] [varchar](25) NULL,
 CONSTRAINT [PK__Comproba__55E5E240CBF34299] PRIMARY KEY CLUSTERED 
(
	[id_comprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComprobantesCantidad]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprobantesCantidad](
	[id_registro] [int] NOT NULL,
	[id_comprobante] [varchar](3) NOT NULL,
	[desde_comprobante] [int] NULL,
	[hasta_comprobante] [int] NULL,
	[secuencia_comprobante] [int] NULL,
	[fechaVencimiento_comprobante] [date] NULL,
	[estado_comprobante] [bit] NULL,
 CONSTRAINT [PK_ComprobantesCantidad] PRIMARY KEY CLUSTERED 
(
	[id_registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComprobantesDetalle]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprobantesDetalle](
	[id_comprobante] [varchar](3) NOT NULL,
	[id_documento] [varchar](30) NULL,
	[ncf_comprobante] [varchar](15) NULL,
	[fechaVencimiento_comprobante] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotizacion](
	[id_cotizacion] [int] NOT NULL,
	[id_cliente] [int] NULL,
	[id_comprobante] [varchar](3) NULL,
	[fecha_cotizacion] [datetime] NULL,
	[tipoCompra_cotizacion] [varchar](10) NULL,
	[nota_cotizacion] [varchar](50) NULL,
	[importe_cotizacion] [decimal](18, 2) NULL,
	[descuento_cotizacion] [decimal](18, 2) NULL,
	[itbis_cotizacion] [decimal](18, 2) NULL,
	[total_cotizacion] [decimal](18, 2) NULL,
	[estado_cotizacion] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cotizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CotizacionDetalle]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CotizacionDetalle](
	[id_cotizacion] [int] NULL,
	[id_articulo] [int] NULL,
	[cantidad_cotizacion] [decimal](18, 2) NULL,
	[descuento_cotizacion] [decimal](18, 2) NULL,
	[precio_cotizacion] [decimal](18, 2) NULL,
	[importe_cotizacion] [decimal](18, 2) NULL,
	[totalImporte_cotizacion] [decimal](18, 2) NULL,
	[totalDescuento_cotizacion] [decimal](18, 2) NULL,
	[totalItbis_cotizacion] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentaCobrar]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaCobrar](
	[id_cxc] [int] NOT NULL,
	[id_factura] [int] NULL,
	[id_cliente] [int] NULL,
	[balance_cxc] [decimal](18, 2) NULL,
	[estado_cxc] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cxc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentaPagar]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaPagar](
	[id_cxp] [int] NOT NULL,
	[id_compra] [int] NULL,
	[id_suplidor] [int] NULL,
	[balance_cxp] [decimal](18, 2) NULL,
	[estado_cxp] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cxp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[id_empresa] [int] NOT NULL,
	[nombre_empresa] [varchar](50) NULL,
	[direccion_empresa] [varchar](150) NULL,
	[rnc_empresa] [varchar](15) NULL,
	[telefono] [varchar](20) NULL,
	[cell_empresa] [varchar](20) NULL,
	[correo_empresa] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 9/7/2022 11:14:19 AM ******/
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
PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaDetalle](
	[id_factura] [int] NULL,
	[id_articulo] [int] NULL,
	[cantidad_factura] [decimal](18, 2) NULL,
	[descuento_factura] [decimal](18, 2) NULL,
	[precio_factura] [decimal](18, 2) NULL,
	[importe_factura] [decimal](18, 2) NULL,
	[costo_factura] [decimal](18, 2) NULL,
	[totalImporte_factura] [decimal](18, 2) NULL,
	[totalDescuento_factura] [decimal](18, 2) NULL,
	[totalItbis_factura] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaDevolucion]    Script Date: 9/7/2022 11:14:19 AM ******/
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
PRIMARY KEY CLUSTERED 
(
	[id_devolucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaDevolucionDetalle]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaDevolucionDetalle](
	[id_devolucion] [int] NULL,
	[id_articulo] [int] NULL,
	[cantidad_devolucion] [decimal](18, 2) NULL,
	[precio_devolucion] [decimal](18, 2) NULL,
	[totalImporte_devolucion] [decimal](18, 2) NULL,
	[totalDescuento_devolucion] [decimal](18, 2) NULL,
	[totalItbis_devolucion] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReciboIngreso]    Script Date: 9/7/2022 11:14:19 AM ******/
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
	[estado_ri] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReciboPago]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReciboPago](
	[id_rp] [int] NULL,
	[id_compra] [int] NULL,
	[id_suplidor] [int] NULL,
	[fecha_rp] [date] NULL,
	[pago_rp] [decimal](18, 2) NULL,
	[estado_rp] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suplidores]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suplidores](
	[id_suplidor] [int] NOT NULL,
	[nombre_suplidor] [varchar](50) NULL,
	[rnc_suplidor] [varchar](15) NULL,
	[direccion_suplidor] [varchar](150) NULL,
	[telefono_suplidor] [varchar](15) NULL,
	[correo_suplidor] [varchar](50) NULL,
	[vendedor_suplidor] [varchar](50) NULL,
	[cell_suplidor] [varchar](15) NULL,
	[tipoCompra_suplidor] [varchar](10) NULL,
	[estado_suplidor] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_suplidor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/7/2022 11:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_usuario] [int] NOT NULL,
	[usuario_usuario] [varchar](50) NULL,
	[nombre_usuario] [varchar](50) NULL,
	[cedula_usuario] [varchar](15) NULL,
	[direccion_usuario] [varchar](155) NULL,
	[telefono_usuario] [varchar](15) NULL,
	[correo_usuario] [varchar](50) NULL,
	[fechaIngreso_usuario] [date] NULL,
	[clave_usuario] [varchar](max) NULL,
	[estado_usuario] [bit] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articulo] ADD  CONSTRAINT [DF__Articulo__puntoR__34C8D9D1]  DEFAULT ((0)) FOR [puntoReorden_articulo]
GO

GO
/****** Object:  UserDefinedTableType [dbo].[type_ajuste_inventario]    Script Date: 9/7/2022 11:14:45 AM ******/
CREATE TYPE [dbo].[type_ajuste_inventario] AS TABLE(
	[idArticulo] [int] NULL,
	[cantidad] [decimal](10, 2) NULL,
	[tipoAjuste] [char](1) NULL,
	[costo] [decimal](18, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[type_compra_detalle]    Script Date: 9/7/2022 11:14:45 AM ******/
CREATE TYPE [dbo].[type_compra_detalle] AS TABLE(
	[idArticulo] [int] NULL,
	[tipoItbis] [char](1) NULL,
	[cantidad] [decimal](18, 2) NULL,
	[descuento] [decimal](18, 2) NULL,
	[costo] [decimal](18, 2) NULL,
	[importe] [decimal](18, 2) NULL,
	[precio] [decimal](18, 2) NULL,
	[beneficio] [decimal](18, 2) NULL,
	[costoFinal] [decimal](18, 2) NULL,
	[totalImporte] [decimal](18, 2) NULL,
	[totalDescuento] [decimal](18, 2) NULL,
	[totalItbis] [decimal](18, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[type_detalle_devolucion]    Script Date: 9/7/2022 11:14:45 AM ******/
CREATE TYPE [dbo].[type_detalle_devolucion] AS TABLE(
	[id_articulo] [int] NULL,
	[cantidad] [decimal](16, 2) NULL,
	[importe] [decimal](16, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[type_devolucion_detalle]    Script Date: 9/7/2022 11:14:45 AM ******/
CREATE TYPE [dbo].[type_devolucion_detalle] AS TABLE(
	[idArticulo] [int] NULL,
	[cantidad] [decimal](18, 2) NULL,
	[precio] [decimal](18, 2) NULL,
	[totalimporte] [decimal](18, 2) NULL,
	[totaldescuento] [decimal](18, 2) NULL,
	[totalitbis] [decimal](18, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[type_factura_detalle]    Script Date: 9/7/2022 11:14:45 AM ******/
CREATE TYPE [dbo].[type_factura_detalle] AS TABLE(
	[idArticulo] [int] NULL,
	[cantidad] [decimal](18, 2) NULL,
	[descuento] [decimal](18, 2) NULL,
	[precio] [decimal](18, 2) NULL,
	[importe] [decimal](18, 2) NULL,
	[costo] [decimal](18, 2) NULL,
	[totalimporte] [decimal](18, 2) NULL,
	[totaldescuento] [decimal](18, 2) NULL,
	[totalitbis] [decimal](18, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[type_recibo_ingreso]    Script Date: 9/7/2022 11:14:45 AM ******/
CREATE TYPE [dbo].[type_recibo_ingreso] AS TABLE(
	[idFactura] [int] NULL,
	[pago] [decimal](18, 2) NULL,
	[estado] [varchar](20) NULL
)
GO

GO
/****** Object:  StoredProcedure [dbo].[articulo_ajusteInventario_insert]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[articulo_ajusteInventario_insert]
@fecha date,
@nota varchar(50),
@detalle type_ajuste_inventario readonly
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Id int = 1
	IF EXISTS (SELECT id_ajuste FROM ArticuloAjuste)
		SET @Id = 1 + (SELECT MAX(id_ajuste) FROM ArticuloAjuste)

	INSERT INTO ArticuloAjuste (id_ajuste, id_articulo, fecha_ajuste,
	nota_ajuste, cantidad_ajuste, tipo_ajuste, costo_ajuste)
	SELECT  @Id, D.idArticulo, @fecha, @nota, D.cantidad, D.tipoAjuste, D.costo
	FROM @detalle D

	SELECT MAX(id_ajuste) FROM ArticuloAjuste
END
GO
/****** Object:  StoredProcedure [dbo].[articulo_BuscarCodigo]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[articulo_BuscarCodigo]
@codigo varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT A.id_articulo, A.id_marca, A.id_itbis, A.id_suplidor,
	codigo_articulo, nombre_articulo, referencia_articulo, puntoReorden_articulo,
	cantidad_articulo, costo_articulo, precio_articulo, beneficio_articulo, 
	estado_articulo, nombre_marca, nombre_itbis, porciento_itbis,
	nombre_suplidor
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	LEFT JOIN Suplidores S ON A.id_suplidor = S.id_suplidor
	LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis
	WHERE A.codigo_articulo = @codigo
END
GO
/****** Object:  StoredProcedure [dbo].[articulo_BuscarId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[articulo_BuscarId]
@id int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT A.id_articulo, A.id_marca, A.id_itbis, A.id_suplidor,
	codigo_articulo, nombre_articulo, referencia_articulo, puntoReorden_articulo,
	cantidad_articulo, costo_articulo, precio_articulo, beneficio_articulo, 
	estado_articulo, nombre_marca, nombre_itbis, porciento_itbis,
	nombre_suplidor
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	LEFT JOIN Suplidores S ON A.id_suplidor = S.id_suplidor
	LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis
	WHERE A.id_articulo = @id
END
GO
/****** Object:  StoredProcedure [dbo].[articulo_cambiarCodigo]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[articulo_cambiarCodigo]
@idArticulo int,
@codigo varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Articulo SET codigo_articulo = @codigo
	WHERE id_articulo = @idArticulo
END
GO
/****** Object:  StoredProcedure [dbo].[articulo_editar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[articulo_editar]
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
@estado bit
AS
BEGIN
	SET NOCOUNT ON

	UPDATE Articulo SET id_marca = @idMarca, id_itbis = @idItbis,
	id_suplidor = @idSuplidor, codigo_articulo = @codigo,
	nombre_articulo = @nombre, referencia_articulo = @referencia,
	puntoReorden_articulo = @puntoReorden, cantidad_articulo = @cantidad,
	costo_articulo = @costo, precio_articulo = @precio,
	beneficio_articulo = @beneficio, estado_articulo = @estado
	WHERE id_articulo = @id
END
GO
/****** Object:  StoredProcedure [dbo].[articulo_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[articulo_insertar]
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
@estado bit
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @id int = 1
	IF EXISTS(SELECT id_articulo FROM Articulo)
		SET @id = 1 + (SELECT MAX(id_articulo) FROM Articulo)

	INSERT INTO Articulo VALUES (@id, @idMarca, @idSuplidor, @idItbis, 
	@codigo, @nombre, @referencia, @puntoReorden, @cantidad, @costo,
	@precio, @beneficio, @estado)
END
GO
/****** Object:  StoredProcedure [dbo].[articulo_listaDeCompras]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[articulo_listaDeCompras]
AS
BEGIN
	SET NOCOUNT ON
	SELECT A.id_articulo, A.codigo_articulo, A.referencia_articulo, A.nombre_articulo,
	M.nombre_marca, A.cantidad_articulo, A.costo_articulo
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	WHERE puntoReorden_articulo >= cantidad_articulo
END
GO
/****** Object:  StoredProcedure [dbo].[articulo_listaDeComprasIdSup]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[articulo_listaDeComprasIdSup]
@IdSup int
AS
BEGIN
	SET NOCOUNT ON
	SELECT A.id_articulo, A.codigo_articulo, A.referencia_articulo, A.nombre_articulo,
	M.nombre_marca, A.cantidad_articulo, A.costo_articulo
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	WHERE puntoReorden_articulo >= cantidad_articulo AND A.id_suplidor = @IdSup
END
GO
/****** Object:  StoredProcedure [dbo].[articulo_listar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[articulo_listar]
AS
BEGIN
	SET NOCOUNT ON

	SELECT A.id_articulo, codigo_articulo, referencia_articulo, nombre_articulo,
	nombre_marca, cantidad_articulo, precio_articulo, estado_articulo, porciento_itbis, A.costo_articulo
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis
	ORDER BY nombre_articulo
END
GO
/****** Object:  StoredProcedure [dbo].[cliente_balancePendiente]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[cliente_balancePendiente]
@idCliente int
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM CuentaCobrar CC
	LEFT JOIN Factura F ON CC.id_factura = F.id_factura
	LEFT JOIN ComprobantesDetalle CD ON F.id_factura = CD.id_documento AND F.id_comprobante = CD.id_comprobante
	WHERE CC.id_cliente = @idCliente AND CC.balance_cxc > 0
END
GO
/****** Object:  StoredProcedure [dbo].[cliente_buscarId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[cliente_buscarId]
@id int
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_cliente, id_comprobante, nombre_cliente, cedula_cliente, rnc_cliente, direccion_cliente,
	telefono_cliente, correo_cliente, tipoCompra_cliente, limiteCredito_cliente, descuento_cliente,
	estado_cliente FROM Clientes
	WHERE id_cliente =  @id
	ORDER BY nombre_cliente
END
GO
/****** Object:  StoredProcedure [dbo].[cliente_editar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[cliente_editar]
@id int,
@idComprobante varchar(3),
@nombre varchar(50),
@cedula varchar(15),
@rnc varchar(15),
@direccion varchar(150),
@telefono varchar(15),
@correo varchar(50),
@tipoCompra varchar(10),
@limiteCredito decimal(18,2),
@descuento decimal(6,2),
@estado bit
AS
BEGIN
	SET NOCOUNT ON

	UPDATE Clientes SET id_comprobante = @idComprobante, nombre_cliente = @nombre, cedula_cliente = @cedula,
	rnc_cliente = @rnc, direccion_cliente = @direccion, telefono_cliente = @telefono, correo_cliente = @correo,
	tipoCompra_cliente = @tipoCompra, limiteCredito_cliente = @limiteCredito,
	descuento_cliente = @descuento, estado_cliente = @estado
	WHERE id_cliente = @id
END
GO
/****** Object:  StoredProcedure [dbo].[cliente_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[cliente_insertar]
@idComprobante varchar(3),
@nombre varchar(50),
@cedula varchar(15),
@rnc varchar(15),
@direccion varchar(150),
@telefono varchar(15),
@correo varchar(50),
@tipoCompra varchar(10),
@limiteCredito decimal(18,2),
@descuento decimal(6,2),
@estado bit
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @id int = 1
	IF EXISTS(SELECT id_cliente FROM Clientes)
		SET @id = 1 + (SELECT MAX(id_cliente) FROM Clientes)

	INSERT INTO Clientes VALUES(@id, @idComprobante, @nombre, @cedula, @rnc, @direccion, @telefono,
	@correo, @tipoCompra, @limiteCredito, @descuento, @estado)
END
GO
/****** Object:  StoredProcedure [dbo].[cliente_listar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[cliente_listar]
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_cliente, id_comprobante, nombre_cliente, cedula_cliente, rnc_cliente, direccion_cliente,
	telefono_cliente, correo_cliente, tipoCompra_cliente, limiteCredito_cliente, descuento_cliente,
	estado_cliente FROM Clientes
	ORDER BY nombre_cliente
END
GO
/****** Object:  StoredProcedure [dbo].[cliente_maxId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[cliente_maxId]
AS
BEGIN
SET NOCOUNT ON
IF EXISTS(SELECT id_cliente FROM Clientes)
	SELECT MAX(id_cliente) as ID FROM Clientes
END
GO
/****** Object:  StoredProcedure [dbo].[compra_buscarId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[compra_buscarId]
@idCompra int
AS
BEGIN
	SET NOCOUNT ON
	SELECT C.id_compra, C.id_suplidor, S.nombre_suplidor, C.tipoCompra_compra,
	C.fecha_compra, C.facturaNumero_compra, C.ncf_compra, C.importe_compra, C.descuento_compra,
	C.itbis_compra, C.total_compra, CD.id_articulo, A.codigo_articulo, A.nombre_articulo,
	CD.tipoItbis_compra, CD.cantidad_compra, CD.descuento_compra, CD.costo_compra, CD.importe_compra,
	I.porciento_itbis, CD.costoFinal_compra, CD.precio_compra, CD.beneficio_compra,
	CD.totalImporte_compra, CD.totalDescuento_compra, CD.totalItbis_compra
	FROM Compra C
	LEFT JOIN CompraDetalle CD ON C.id_compra = CD.id_compra
	LEFT JOIN Articulo A ON CD.id_articulo = A.id_articulo
	LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis
	LEFT JOIN Suplidores S ON C.id_suplidor = S.id_suplidor
	WHERE C.id_compra = @idCompra
END
GO
/****** Object:  StoredProcedure [dbo].[compra_detalleArticulo]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[compra_detalleArticulo]
@idArticulo int
AS
BEGIN
	SET NOCOUNT ON
	SELECT TOP 5 CC.fecha_compra AS Fecha, S.nombre_suplidor AS Nombre, C.costo_compra AS Precio
	FROM CompraDetalle C
	LEFT JOIN Suplidores S ON C.id_suplidor = S.id_suplidor
	LEFT JOIN Compra CC ON C.id_compra = CC.id_compra
	WHERE C.id_articulo = @idArticulo
END

SELECT * FROM CompraDetalle
GO
/****** Object:  StoredProcedure [dbo].[compra_editar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[compra_editar]
@idCompra int,
@idSuplidor int,
@tipoCompra varchar(10),
@importe decimal(18,2),
@descuento decimal(18,2),
@itbis decimal(18,2),
@total decimal(18,2),
@detalle type_compra_detalle readonly
AS
BEGIN
	SET NOCOUNT ON

	DELETE CompraDetalle WHERE id_compra = @idCompra
	
	UPDATE Compra SET id_suplidor = @idSuplidor, importe_compra = @importe,
	descuento_compra = @descuento, itbis_compra = @itbis, total_compra = @total
	WHERE id_compra = @idCompra

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
			UPDATE CuentaPagar SET balance_cxp = @total WHERE id_compra = @idCompra
		END 
END
GO
/****** Object:  StoredProcedure [dbo].[compra_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[compra_insertar]
@idSuplidor int,
@fecha date,
@tipoCompra varchar(10),
@facturaNumero varchar(50),
@ncf varchar(15),
@importe decimal(18,2),
@descuento decimal(18,2),
@itbis decimal(18,2),
@total decimal(18,2),
@detalle type_compra_detalle readonly
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @idCompra int = 1
	IF EXISTS (SELECT id_compra FROM Compra)
		SET @idCompra = 1 + (SELECT MAX(id_compra) FROM Compra)

	INSERT INTO Compra VALUES (@idCompra, @idSuplidor, @fecha, @tipoCompra,
	@facturaNumero, @ncf, @importe, @descuento, @itbis, @total)

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

			INSERT INTO CuentaPagar VALUES (@idCxp, @idCompra, @idSuplidor, @total, 'PENDIENTE')
		END 
END
GO
/****** Object:  StoredProcedure [dbo].[compra_listar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[compra_listar]
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
	ORDER BY nombre_suplidor

END
GO
/****** Object:  StoredProcedure [dbo].[compraDevolucion_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[compraDevolucion_insertar]
@id_compra int,
@id_suplidor int,
@fecha date,
@importe decimal(18,2),
@descuento decimal(18,2),
@itbis decimal(18,2),
@total decimal(18,2),
@detalle type_detalle_devolucion readonly
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @Id int = 1
	IF EXISTS (SELECT id_devolucionCompra FROM CompraDevolucion)
		SET @Id = 1 + (SELECT MAX(id_devolucionCompra) FROM CompraDevolucion)

	INSERT INTO CompraDevolucion VALUES(@Id, @id_compra, @id_suplidor,
	@fecha,	@importe, @descuento, @itbis, @total)

	INSERT INTO CompraDevolucionDetalle (id_devolucionCompra, id_articulo,
	cantidad_devolucionCompra, importeUnitario_devolucionCompra)
	SELECT @Id, D.id_articulo, D.cantidad, D.importe
	FROM @detalle D

	IF (SELECT balance_cxp FROM CuentaPagar WHERE id_compra = @id_compra) = @total
		UPDATE CuentaPagar SET estado_cxp = 'SALDO' WHERE id_compra = @id_compra

	UPDATE CuentaPagar SET balance_cxp = balance_cxp - @total WHERE id_compra = @id_compra

	SELECT MAX(id_devolucionCompra) FROM CompraDevolucion
END
GO
/****** Object:  StoredProcedure [dbo].[compraDevolucion_select]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[compraDevolucion_select]
@idCompra int
AS
BEGIN
	SET NOCOUNT ON
	SELECT CD.id_articulo, CD.cantidad_devolucionCompra FROM CompraDevolucion C
	LEFT JOIN CompraDevolucionDetalle CD ON C.id_devolucionCompra = CD.id_devolucionCompra
	WHERE C.id_compra = @idCompra
END
GO
/****** Object:  StoredProcedure [dbo].[comprobante_borrar_cantidad]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[comprobante_borrar_cantidad]
@idRegistro int
AS
BEGIN
	SET NOCOUNT ON
	DELETE ComprobantesCantidad WHERE id_registro = @idRegistro 
END
GO
/****** Object:  StoredProcedure [dbo].[comprobante_insertar_cantidad]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[comprobante_insertar_cantidad]
@idComprobante varchar(3),
@desde int,
@hasta int,
@fecha date
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @id int = 1
	IF EXISTS(SELECT id_registro FROM ComprobantesCantidad)
		SET @id = 1 + (SELECT MAX(id_registro) FROM ComprobantesCantidad)

	INSERT INTO ComprobantesCantidad VALUES(@id, @idComprobante, @desde, @hasta, 0, @fecha, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[comprobante_listar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[comprobante_listar]
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_comprobante, nombre_comprobante FROM Comprobantes
	ORDER BY nombre_comprobante
END
GO
/****** Object:  StoredProcedure [dbo].[comprobante_listar_cantidad]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[comprobante_listar_cantidad]
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_registro, CC.id_comprobante, nombre_comprobante, desde_comprobante,
	hasta_comprobante, secuencia_comprobante,
	fechaVencimiento_comprobante, estado_comprobante
	FROM ComprobantesCantidad CC
	LEFT JOIN Comprobantes C ON CC.id_comprobante = C.id_comprobante
	ORDER BY id_comprobante
END
GO
/****** Object:  StoredProcedure [dbo].[comprobante_sumar_cantidad]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[comprobante_sumar_cantidad]
@idComprobante varchar(3)
AS
BEGIN
SET NOCOUNT ON

DECLARE @id int = (SELECT TOP 1 id_registro FROM ComprobantesCantidad WHERE id_comprobante = @idComprobante AND estado_comprobante = 1)
DECLARE @numero int = (SELECT secuencia_comprobante FROM ComprobantesCantidad WHERE id_registro = @id)

IF @numero = 0
	SET @numero = (SELECT desde_comprobante FROM ComprobantesCantidad WHERE id_registro = @id) - 1
SET @numero = 1 + @numero

UPDATE ComprobantesCantidad SET secuencia_comprobante = @numero WHERE id_registro = @id

IF @numero = (SELECT hasta_comprobante FROM ComprobantesCantidad WHERE id_registro = @id)
	UPDATE ComprobantesCantidad SET estado_comprobante = 0 WHERE id_registro = @id

SELECT * FROM ComprobantesCantidad WHERE id_registro = @id

END
GO
/****** Object:  StoredProcedure [dbo].[comprobante_ventas]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[comprobante_ventas]
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT id_comprobante, nombre_comprobante FROM Comprobantes 
	WHERE id_comprobante = 'B01' OR id_comprobante = 'B02'
	ORDER BY nombre_comprobante
END
GO
/****** Object:  StoredProcedure [dbo].[factura_buscarId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[factura_buscarId]
@idFactura int
AS
BEGIN
	SET NOCOUNT ON
	SELECT F.id_factura, CD.ncf_comprobante, F.fecha_factura, CL.id_cliente,
	CL.nombre_cliente, CL.direccion_cliente, CL.cedula_cliente,	CL.rnc_cliente,
	F.tipoCompra_factura, F.id_comprobante, CL.descuento_cliente, F.importe_factura,
	F.descuento_factura, F.itbis_factura, F.total_factura, F.nota_factura,
	A.id_articulo, A.codigo_articulo, A.nombre_articulo, M.nombre_marca,
	FD.cantidad_factura, FD.descuento_factura, FD.precio_factura, FD.importe_factura,
	FD.costo_factura, I.porciento_itbis, FD.totalImporte_factura,
	FD.totalDescuento_factura, FD.totalItbis_factura	
	FROM Factura F
	INNER JOIN ComprobantesDetalle CD ON F.id_factura = CD.id_documento AND F.id_comprobante = CD.id_comprobante
	INNER JOIN Clientes CL ON F.id_cliente = CL.id_cliente
	INNER JOIN FacturaDetalle FD ON F.id_factura = FD.id_factura
	LEFT JOIN Articulo A ON FD.id_articulo = A.id_articulo
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis
	WHERE F.id_factura = @idFactura
END
GO
/****** Object:  StoredProcedure [dbo].[factura_editar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[factura_editar]
@idFact int,
@idCliente int,
@tipoCompra varchar(10),
@nota varchar(50),
@importe decimal(18,2),
@descuento decimal(18,2),
@itbis decimal(18,2),
@total decimal(18,2),
@detalle type_factura_detalle readonly
AS
BEGIN
	SET NOCOUNT ON
	
	DELETE FacturaDetalle WHERE id_factura  = @idFact

	UPDATE Factura SET @idCliente = @idCliente, nota_factura = @nota,
	importe_factura = @importe, descuento_factura = @descuento,
	itbis_factura = @itbis, total_factura = @total
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
END
GO
/****** Object:  StoredProcedure [dbo].[factura_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[factura_insertar]
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
@detalle type_factura_detalle readonly
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @idFact int = 1
	IF EXISTS (SELECT id_factura FROM Factura)
		SET @idFact = 1 + (SELECT MAX(id_factura) FROM Factura)

	INSERT INTO ComprobantesDetalle VALUES (@idComprobante, @idFact, @ncf, @fechaVencimiento)

	INSERT INTO Factura VALUES (@idFact, @idCliente, @idComprobante, @fecha,
	@tipoCompra, @nota, @importe, @descuento, @itbis, @total)

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
/****** Object:  StoredProcedure [dbo].[factura_listar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[factura_listar]
@desde datetime,
@hasta datetime
AS
BEGIN
	SET NOCOUNT ON
	SELECT F.id_factura, F.fecha_factura, CD.ncf_comprobante,
	C.nombre_cliente, F.total_factura, F.tipoCompra_factura
	FROM Factura F
	LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente
	LEFT JOIN ComprobantesDetalle CD ON F.id_comprobante = F.id_comprobante AND F.id_factura = CD.id_documento
	WHERE F.fecha_factura BETWEEN @desde AND @hasta
	ORDER BY F.id_factura DESC
END
GO
/****** Object:  StoredProcedure [dbo].[facturaDevolucion_buscarId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[facturaDevolucion_buscarId]
@idDevolucion int
AS
BEGIN
	SET NOCOUNT ON
	SELECT F.id_factura, FD.id_articulo, FD.cantidad_devolucion FROM FacturaDevolucion F
	LEFT JOIN FacturaDevolucionDetalle FD ON F.id_devolucion = FD.id_devolucion
	WHERE F.id_devolucion = @idDevolucion
END
GO
/****** Object:  StoredProcedure [dbo].[facturaDevolucion_cargar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[facturaDevolucion_cargar]
@idFactura int
AS
BEGIN
	SET NOCOUNT ON
	SELECT FD.id_articulo, FD.cantidad_devolucion FROM FacturaDevolucion F
	LEFT JOIN FacturaDevolucionDetalle FD ON F.id_devolucion = FD.id_devolucion
	WHERE F.id_factura = @idFactura
END
GO
/****** Object:  StoredProcedure [dbo].[facturaDevolucion_editar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[facturaDevolucion_editar]
@idDevolcion int,
@importe decimal(18,2),
@descuento decimal(18,2),
@itbis decimal(18,2),
@total decimal(18,2),
@detalle type_devolucion_detalle readonly
AS
BEGIN
	SET NOCOUNT ON

	DELETE FacturaDevolucionDetalle WHERE id_devolucion = @idDevolcion

	UPDATE FacturaDevolucion SET importe_devolucion = @importe,
	descuento_devolucion = @descuento, itbis_devolucion = @itbis,
	total_devolucion = @total
	WHERE id_devolucion = @idDevolcion

	INSERT INTO FacturaDevolucionDetalle (id_devolucion, id_articulo, cantidad_devolucion,
	totalImporte_devolucion, totalDescuento_devolucion, totalItbis_devolucion, precio_devolucion)
	SELECT @idDevolcion, D.idArticulo, D.cantidad, D.totalimporte, D.totaldescuento, D.totalitbis, D.precio
	FROM @detalle D

END
GO
/****** Object:  StoredProcedure [dbo].[facturaDevolucion_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[facturaDevolucion_insertar]
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
@detalle type_devolucion_detalle readonly
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @idDevolcion int  = 1
	IF EXISTS (SELECT id_devolucion FROM FacturaDevolucion)
		SET @idDevolcion = 1 + (SELECT MAX(id_devolucion) FROM FacturaDevolucion)

	INSERT INTO FacturaDevolucion VALUES (@idDevolcion, @idFactura, @idcliente, @idComprobante,
	@fecha, @importe, @descuento, @itbis, @total)

	INSERT INTO FacturaDevolucionDetalle (id_devolucion, id_articulo, cantidad_devolucion,
	totalImporte_devolucion, totalDescuento_devolucion, totalItbis_devolucion, precio_devolucion)
	SELECT @idDevolcion, D.idArticulo, D.cantidad, D.totalimporte, D.totaldescuento, D.totalitbis, D.precio
	FROM @detalle D

	INSERT INTO ComprobantesDetalle VALUES (@idComprobante, @idDevolcion, @ncf, @fechaVencimiento)
	SELECT MAX(id_devolucion) FROM FacturaDevolucion
END
GO
/****** Object:  StoredProcedure [dbo].[facturaDevolucion_listar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[facturaDevolucion_listar]
@desde date,
@hasta date
AS
BEGIN
	SET NOCOUNT ON
	SELECT DV.id_devolucion, CD.ncf_comprobante,
	DV.fecha_devolucion, CL.nombre_cliente, DV.total_devolucion
	FROM FacturaDevolucion DV
	LEFT JOIN ComprobantesDetalle CD ON CD.id_documento = DV.id_devolucion AND CD.id_comprobante = DV.id_comprobante
	LEFT JOIN Clientes CL ON DV.id_cliente = CL.id_cliente
	WHERE DV.fecha_devolucion BETWEEN @desde AND @hasta
	ORDER BY DV.id_devolucion DESC
END
GO
/****** Object:  StoredProcedure [dbo].[itbis_buscarId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[itbis_buscarId]
@id int
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_itbis, nombre_itbis, porciento_itbis FROM ArticuloItbis
	WHERE id_itbis = @id
	ORDER BY nombre_itbis
END
GO
/****** Object:  StoredProcedure [dbo].[itbis_editar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[itbis_editar]
@id int,
@nombre varchar(50),
@porciento decimal(6,2)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE ArticuloItbis SET nombre_itbis= @nombre, porciento_itbis = @porciento
	WHERE id_itbis = @id
END
GO
/****** Object:  StoredProcedure [dbo].[itbis_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[itbis_insertar]
@nombre varchar(50),
@porciento decimal(6,2)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @id int = 1
	IF EXISTS(SELECT id_itbis FROM ArticuloItbis)
		SET @id = (SELECT MAX(id_itbis) FROM ArticuloItbis) + 1

	INSERT INTO ArticuloItbis VALUES(@id, @nombre, @porciento)
END
GO
/****** Object:  StoredProcedure [dbo].[itbis_listar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[itbis_listar]
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_itbis, nombre_itbis, porciento_itbis FROM ArticuloItbis
	ORDER BY nombre_itbis
END
GO
/****** Object:  StoredProcedure [dbo].[itbis_maxId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[itbis_maxId]
AS
BEGIN
SET NOCOUNT ON
IF EXISTS(SELECT id_itbis FROM ArticuloItbis)
	SELECT MAX(id_itbis) as ID FROM ArticuloItbis
END
GO
/****** Object:  StoredProcedure [dbo].[marca_buscarId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[marca_buscarId]
@id int
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_marca, nombre_marca FROM ArticuloMarca
	WHERE id_marca = @id
END
GO
/****** Object:  StoredProcedure [dbo].[marca_buscarNombre]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[marca_buscarNombre]
@nombre varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_marca, nombre_marca FROM ArticuloMarca
	WHERE nombre_marca = @nombre
END
GO
/****** Object:  StoredProcedure [dbo].[marca_editar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[marca_editar]
@id int,
@nombre varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE ArticuloMarca SET nombre_marca = @nombre
	WHERE id_marca = @id
END
GO
/****** Object:  StoredProcedure [dbo].[marca_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[marca_insertar]
@nombre varchar(50)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @id int = 1
	IF EXISTS(SELECT id_marca FROM ArticuloMarca)
		SET @id = (SELECT MAX(id_marca) FROM ArticuloMarca) + 1

	INSERT INTO ArticuloMarca VALUES(@id, @nombre)
	SELECT MAX(id_marca) FROM ArticuloMarca
END
GO
/****** Object:  StoredProcedure [dbo].[marca_listar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[marca_listar]
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_marca, nombre_marca FROM ArticuloMarca
	ORDER BY nombre_marca
END
GO
/****** Object:  StoredProcedure [dbo].[marca_maxId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[marca_maxId]
AS
BEGIN
SET NOCOUNT ON
IF EXISTS(SELECT id_marca FROM ArticuloMarca)
	SELECT MAX(id_marca) as ID FROM ArticuloMarca
END
GO
/****** Object:  StoredProcedure [dbo].[reciboIngreso_anular]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[reciboIngreso_anular]
@IdRecibo int
AS
BEGIN
	SET NOCOUNT ON
	DELETE ReciboIngreso
	WHERE id_ri = @IdRecibo
END
GO
/****** Object:  StoredProcedure [dbo].[reciboIngreso_buscarId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[reciboIngreso_buscarId]
@idRecibo int
AS
BEGIN
	SET NOCOUNT ON
	SELECT CL.id_cliente, CL.nombre_cliente, RI.fecha_ri,
	RI.id_ri, RI.id_factura, F.fecha_factura, RI.pago_ri,
	RI.estado_ri
	FROM ReciboIngreso RI
	LEFT JOIN Clientes CL ON RI.id_cliente = CL.id_cliente
	LEFT JOIN Factura F ON RI.id_factura = F.id_factura
	WHERE RI.id_ri = @idRecibo
END
GO
/****** Object:  StoredProcedure [dbo].[reciboIngreso_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[reciboIngreso_insertar]
@idCliente int,
@fecha date,
@detalle type_recibo_ingreso readonly
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @idRecibo int = 1
	IF EXISTS (SELECT id_ri FROM ReciboIngreso)
		SET @idRecibo = 1 + (SELECT MAX(id_ri) FROM ReciboIngreso)

	INSERT INTO ReciboIngreso (id_ri, id_factura, id_cliente,
	fecha_ri, pago_ri, estado_ri)
	SELECT @idRecibo, D.idFactura, @idCliente, @fecha, D.pago, D.estado
	FROM @detalle D

	SELECT MAX(id_ri) FROM ReciboIngreso
END
GO
/****** Object:  StoredProcedure [dbo].[reciboIngreso_listar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[reciboIngreso_listar]
@desde date,
@hasta date
AS
BEGIN
	SET NOCOUNT ON
	SELECT RI.id_ri, RI.fecha_ri, CL.nombre_cliente, SUM(RI.pago_ri) Monto
	FROM ReciboIngreso RI
	LEFT JOIN Clientes CL ON RI.id_cliente = CL.id_cliente
	WHERE RI.fecha_ri BETWEEN @desde AND @hasta
	GROUP BY RI.id_ri, RI.fecha_ri, CL.nombre_cliente
	ORDER BY RI.id_ri DESC
END
GO
/****** Object:  StoredProcedure [dbo].[reciboPago_anular]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[reciboPago_anular]
@IdRecibo int
AS
BEGIN
	SET NOCOUNT ON
	DELETE ReciboPago
	WHERE id_rp = @IdRecibo
END
GO
/****** Object:  StoredProcedure [dbo].[reciboPago_buscarId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[reciboPago_buscarId]
@idRecibo int
AS
BEGIN
	SET NOCOUNT ON
	SELECT S.id_suplidor, S.nombre_suplidor, RP.fecha_rp,
	RP.id_rp, RP.id_compra, C.fecha_compra, RP.pago_rp,
	RP.estado_rp
	FROM ReciboPago RP
	LEFT JOIN Suplidores S ON RP.id_suplidor = S.id_suplidor
	LEFT JOIN Compra C ON RP.id_compra = C.id_compra
	WHERE RP.id_rp = @idRecibo
END
GO
/****** Object:  StoredProcedure [dbo].[reciboPago_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[reciboPago_insertar]
@idSuplidor int,
@fecha date,
@detalle type_recibo_ingreso readonly
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @idRecibo int = 1
	IF EXISTS (SELECT id_rp FROM ReciboPago)
		SET @idRecibo = 1 + (SELECT MAX(id_rp) FROM ReciboPago)

	INSERT INTO ReciboPago (id_rp, id_compra, id_suplidor,
	fecha_rp, pago_rp, estado_rp)
	SELECT @idRecibo, D.idFactura, @idSuplidor, @fecha, D.pago, D.estado
	FROM @detalle D

	SELECT MAX(id_rp) FROM ReciboPago
END
GO
/****** Object:  StoredProcedure [dbo].[reciboPago_listar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[reciboPago_listar]
@desde date,
@hasta date
AS
BEGIN
	SET NOCOUNT ON
	SELECT RI.id_rp, RI.fecha_rp, CL.nombre_suplidor, SUM(RI.pago_rp) Monto
	FROM ReciboPago RI
	LEFT JOIN Suplidores CL ON RI.id_suplidor = CL.id_suplidor
	WHERE RI.fecha_rp BETWEEN @desde AND @hasta
	GROUP BY RI.id_rp, RI.fecha_rp, CL.nombre_suplidor
	ORDER BY RI.id_rp DESC
END
GO
/****** Object:  StoredProcedure [dbo].[suplidor_balancePendiente]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[suplidor_balancePendiente]
@idSuplidor int
AS
BEGIN
	SET NOCOUNT ON
	SELECT C.facturaNumero_compra, C.ncf_compra, C.fecha_compra, C.total_compra,
	CP.balance_cxp, C.id_compra
	FROM CuentaPagar CP
	LEFT JOIN Compra C ON CP.id_compra = C.id_compra
	WHERE CP.id_suplidor = @idSuplidor AND CP.balance_cxp > 0
	ORDER BY C.fecha_compra ASC
END
GO
/****** Object:  StoredProcedure [dbo].[suplidor_buscarId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[suplidor_buscarId]
@id int
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_suplidor, nombre_suplidor, rnc_suplidor, direccion_suplidor, telefono_suplidor,
	correo_suplidor, vendedor_suplidor, cell_suplidor, tipoCompra_suplidor, estado_suplidor
	FROM Suplidores
	Where id_suplidor = @id
	ORDER BY nombre_suplidor
END
GO
/****** Object:  StoredProcedure [dbo].[suplidor_buscarNombre]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[suplidor_buscarNombre]
@nombre varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_suplidor, nombre_suplidor, rnc_suplidor, direccion_suplidor, telefono_suplidor,
	correo_suplidor, vendedor_suplidor, cell_suplidor, tipoCompra_suplidor, estado_suplidor
	FROM Suplidores
	Where nombre_suplidor = @nombre
	ORDER BY nombre_suplidor
END
GO
/****** Object:  StoredProcedure [dbo].[suplidor_editar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[suplidor_editar]
@id int,
@nombre varchar(50),
@rnc varchar(15),
@direccion varchar(150),
@telefono varchar(15),
@correo varchar(50),
@vendedor varchar(50),
@cell varchar(15),
@tipoCompra varchar(10),
@estado bit
AS
BEGIN
	SET NOCOUNT ON

	UPDATE Suplidores SET nombre_suplidor = @nombre, rnc_suplidor = @rnc, direccion_suplidor = @direccion,
	telefono_suplidor = @telefono, correo_suplidor = @correo, vendedor_suplidor = @vendedor,
	cell_suplidor = @cell, tipoCompra_suplidor = @tipoCompra, estado_suplidor = @estado
	WHERE id_suplidor = @id
END
GO
/****** Object:  StoredProcedure [dbo].[suplidor_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[suplidor_insertar]
@nombre varchar(50),
@rnc varchar(15),
@direccion varchar(150),
@telefono varchar(15),
@correo varchar(50),
@vendedor varchar(50),
@cell varchar(15),
@tipoCompra varchar(10),
@estado bit
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @id int = 1
	IF EXISTS(SELECT id_suplidor FROM Suplidores)
		SET @id = 1 + (SELECT MAX(id_suplidor) FROM Suplidores)

	INSERT INTO Suplidores VALUES(@id, @nombre, @rnc, @direccion, @telefono,
	@correo, @vendedor, @cell, @tipoCompra, @estado)
END
GO
/****** Object:  StoredProcedure [dbo].[suplidor_listar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[suplidor_listar]
AS
BEGIN
	SET NOCOUNT ON
	SELECT id_suplidor, nombre_suplidor, rnc_suplidor, direccion_suplidor, telefono_suplidor,
	correo_suplidor, vendedor_suplidor, cell_suplidor, tipoCompra_suplidor, estado_suplidor
	FROM Suplidores
	ORDER BY nombre_suplidor
END
GO
/****** Object:  StoredProcedure [dbo].[suplidor_maxId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[suplidor_maxId]
AS
BEGIN
SET NOCOUNT ON
IF EXISTS(SELECT id_suplidor FROM Suplidores)
	SELECT MAX(id_suplidor) as ID FROM Suplidores
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_buscar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[usuario_buscar]
@buscar VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON
    SELECT id_usuario, usuario_usuario, nombre_usuario,cedula_usuario,
    direccion_usuario, telefono_usuario,correo_usuario,
    fechaIngreso_usuario,clave_usuario,estado_usuario
    FROM Usuarios
    WHERE id_usuario LIKE '%'+@buscar+'%' OR
    usuario_usuario LIKE '%'+@buscar+'%' OR
    nombre_usuario LIKE '%'+@buscar+'%' OR
    cedula_usuario LIKE '%'+@buscar+'%' OR
    correo_usuario LIKE '%'+@buscar+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_buscarCedula]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[usuario_buscarCedula]
@buscar VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON
    SELECT id_usuario, usuario_usuario, nombre_usuario,cedula_usuario,
    direccion_usuario, telefono_usuario,correo_usuario,
    fechaIngreso_usuario,clave_usuario,estado_usuario
    FROM Usuarios
    WHERE cedula_usuario LIKE '%'+@buscar+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_buscarCorreo]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[usuario_buscarCorreo]
@buscar VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON
    SELECT id_usuario, usuario_usuario, nombre_usuario,cedula_usuario,
    direccion_usuario, telefono_usuario,correo_usuario,
    fechaIngreso_usuario,clave_usuario,estado_usuario
    FROM Usuarios
    WHERE correo_usuario LIKE '%'+@buscar+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_buscarNombre]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[usuario_buscarNombre]
@buscar VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON
    SELECT id_usuario, usuario_usuario, nombre_usuario,cedula_usuario,
    direccion_usuario, telefono_usuario,correo_usuario,
    fechaIngreso_usuario,clave_usuario,estado_usuario
    FROM Usuarios
    WHERE nombre_usuario LIKE '%'+@buscar+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_buscarUsuario]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[usuario_buscarUsuario]
@buscar VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON
    SELECT id_usuario, usuario_usuario, nombre_usuario,cedula_usuario,
    direccion_usuario, telefono_usuario,correo_usuario,
    fechaIngreso_usuario,clave_usuario,estado_usuario
    FROM Usuarios
    WHERE usuario_usuario LIKE '%'+@buscar+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_editar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usuario_editar] 
	-- Add the parameters for the stored procedure here
	@id int,
	@nombre varchar(50),
	@cedula varchar(15),
	@direccion varchar(155),
	@telefono varchar(15),
	@correo varchar(50),
	@clave varchar(max),
	@estado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE Usuarios SET nombre_usuario = @nombre, cedula_usuario = @cedula,
    direccion_usuario = @direccion, telefono_usuario = @telefono,
    correo_usuario = @correo, clave_usuario = @clave, estado_usuario = @estado
    WHERE id_usuario = @id
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_insertar]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usuario_insertar] 
	-- Add the parameters for the stored procedure here
	@usuario varchar(50),
	@nombre varchar(50),
	@cedula varchar(15),
	@direccion varchar(155),
	@telefono varchar(15),
	@correo varchar(50),
	@fecha date,
	@clave varchar(max),
	@estado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @id int = 1
	IF EXISTS(SELECT id_usuario FROM Usuarios)
		SET @id = 1 + (SELECT max(id_usuario) FROM Usuarios)

    -- Insert statements for procedure here
	INSERT INTO Usuarios VALUES
	(@id, @usuario, @nombre, @cedula,
	@direccion, @telefono, @correo,
	@fecha, @clave, @estado)
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_login]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usuario_login]
	-- Add the parameters for the stored procedure here
	@usuario varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT * FROM Usuarios
	WHERE usuario_usuario = @usuario
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_maxId]    Script Date: 9/7/2022 11:16:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usuario_maxId]
AS
BEGIN
	SET NOCOUNT ON
	SELECT MAX(id_usuario) ID FROM Usuarios
END

GO

/****** Object:  Trigger [dbo].[ComoraEditarDetalle]    Script Date: 9/7/2022 11:17:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[ComoraEditarDetalle] 
   ON  [dbo].[CompraDetalle] 
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE A SET A.cantidad_articulo = A.cantidad_articulo - FD.cantidad_compra
	FROM Articulo A INNER JOIN deleted FD ON FD.id_articulo = A.id_articulo
END
GO

ALTER TABLE [dbo].[CompraDetalle] ENABLE TRIGGER [ComoraEditarDetalle]
GO

/****** Object:  Trigger [dbo].[compraInsertaDetalle]    Script Date: 9/7/2022 11:18:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[compraInsertaDetalle] 
   ON  [dbo].[CompraDetalle]
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE A SET A.cantidad_articulo = A.cantidad_articulo + C.cantidad_compra,
	A.costo_articulo = C.costoFinal_compra, A.precio_articulo = C.precio_compra,
	A.beneficio_articulo = C.beneficio_compra, A.id_suplidor = C.id_suplidor
	FROM Articulo A INNER JOIN inserted C ON C.id_articulo = A.id_articulo

END
GO

ALTER TABLE [dbo].[CompraDetalle] ENABLE TRIGGER [compraInsertaDetalle]
GO

/****** Object:  Trigger [dbo].[compraDevolucionInsertar]    Script Date: 9/7/2022 11:19:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[compraDevolucionInsertar] 
   ON  [dbo].[CompraDevolucionDetalle] 
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	UPDATE A SET A.cantidad_articulo = A.cantidad_articulo - CD.cantidad_devolucionCompra
	FROM Articulo A INNER JOIN inserted CD ON A.id_articulo = CD.id_articulo
END
GO

ALTER TABLE [dbo].[CompraDevolucionDetalle] ENABLE TRIGGER [compraDevolucionInsertar]
GO

/****** Object:  Trigger [dbo].[facturaEditarInventarioArticulo]    Script Date: 9/7/2022 11:20:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[facturaEditarInventarioArticulo] 
   ON  [dbo].[FacturaDetalle] 
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE A SET A.cantidad_articulo = A.cantidad_articulo + FD.cantidad_factura
	FROM Articulo A INNER JOIN deleted FD ON FD.id_articulo = A.id_articulo
	PRINT ' After Delete Trigger activado'
END
GO

ALTER TABLE [dbo].[FacturaDetalle] ENABLE TRIGGER [facturaEditarInventarioArticulo]
GO

/****** Object:  Trigger [dbo].[facturaReduceInventarioArticulo]    Script Date: 9/7/2022 11:21:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[facturaReduceInventarioArticulo] 
   ON  [dbo].[FacturaDetalle] 
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE A SET A.cantidad_articulo = A.cantidad_articulo - FD.cantidad_factura
	FROM Articulo A INNER JOIN inserted FD ON FD.id_articulo = A.id_articulo

END
GO

ALTER TABLE [dbo].[FacturaDetalle] ENABLE TRIGGER [facturaReduceInventarioArticulo]
GO

/****** Object:  Trigger [dbo].[devolucionDetalleInsertar]    Script Date: 9/7/2022 11:21:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[devolucionDetalleInsertar] 
   ON  [dbo].[FacturaDevolucionDetalle] 
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE A SET A.cantidad_articulo = A.cantidad_articulo + FD.cantidad_devolucion
	FROM Articulo A INNER JOIN inserted FD ON FD.id_articulo = A.id_articulo
END
GO

ALTER TABLE [dbo].[FacturaDevolucionDetalle] ENABLE TRIGGER [devolucionDetalleInsertar]
GO

/****** Object:  Trigger [dbo].[reciboIngresoAnular]    Script Date: 9/7/2022 11:21:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[reciboIngresoAnular] 
   ON  [dbo].[ReciboIngreso] 
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE CC SET CC.balance_cxc = CC.balance_cxc + RI.pago_ri,
		CC.estado_cxc = 'PENDIENTE'
	FROM CuentaCobrar CC INNER JOIN deleted RI ON CC.id_factura = RI.id_factura
END
GO

ALTER TABLE [dbo].[ReciboIngreso] ENABLE TRIGGER [reciboIngresoAnular]
GO

/****** Object:  Trigger [dbo].[reciboIngresoInsertar]    Script Date: 9/7/2022 11:22:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[reciboIngresoInsertar] 
   ON  [dbo].[ReciboIngreso] 
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE CC SET CC.balance_cxc = CC.balance_cxc - RI.pago_ri,
		CC.estado_cxc = RI.estado_ri
	FROM CuentaCobrar CC INNER JOIN inserted RI ON CC.id_factura = RI.id_factura
END
GO

ALTER TABLE [dbo].[ReciboIngreso] ENABLE TRIGGER [reciboIngresoInsertar]
GO

/****** Object:  Trigger [dbo].[reciboPagoAnular]    Script Date: 9/7/2022 11:22:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[reciboPagoAnular] 
   ON  [dbo].[ReciboPago] 
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE CC SET CC.balance_cxp = CC.balance_cxp + RI.pago_rp,
		CC.estado_cxp = 'PENDIENTE'
	FROM CuentaPagar CC INNER JOIN deleted RI ON CC.id_compra = RI.id_compra
END
GO

ALTER TABLE [dbo].[ReciboPago] ENABLE TRIGGER [reciboPagoAnular]
GO

/****** Object:  Trigger [dbo].[reciboPagoInsertar]    Script Date: 9/7/2022 11:22:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[reciboPagoInsertar] 
   ON  [dbo].[ReciboPago] 
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE CC SET CC.balance_cxp = CC.balance_cxp - RI.pago_rp,
		CC.estado_cxp = RI.estado_rp
	FROM CuentaPagar CC INNER JOIN inserted RI ON CC.id_compra = RI.id_compra
END
GO

ALTER TABLE [dbo].[ReciboPago] ENABLE TRIGGER [reciboPagoInsertar]
GO

INSERT INTO Comprobantes VALUES('B01',	'Factura de Crédito Fiscal')
INSERT INTO Comprobantes VALUES('B02',	'Factura de Consumo')
INSERT INTO Comprobantes VALUES('B03',	'Notas de Débito')
INSERT INTO Comprobantes VALUES('B04',	'Notas de Crédito')
INSERT INTO Clientes VALUES(0, 'B02', 'VENTA AL CONTADO', '', '', '', '', '', 'CONTADO', 0.00, 0.00, 1)
INSERT INTO ArticuloItbis VALUES(1, 'ITBIS %18', 18.00)
INSERT INTO Usuarios VALUES(0, 'CHE', 'CARLOS J. PACHECO', '', 'ADMIN', '(829) 470-2731', 'CARLOSJ.PACHECO15@GMAIL.COM', '2022-09-06', 'IDHYayL14Dk=', 1)
INSERT INTO Empresa VALUES(1, 'EMPRESA', 'DIRECCION', '031', '809', '829', 'CORREO')
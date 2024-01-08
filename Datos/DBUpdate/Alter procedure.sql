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

create proc facturaDevolucion_rpt_id
@idDevolucion int
as
begin
set nocount on
SELECT d.id_devolucion, d.id_cliente, d.id_comprobante, d.fecha_devolucion,
d.tipo_devolucion, d.importe_devolucion, d.descuento_devolucion, d.itbis_devolucion,
d.total_devolucion, cl.nombre_cliente, cl.cedula_cliente, cl.rnc_cliente,
cl.direccion_cliente, cl.telefono_cliente, cd.ncf_comprobante,
cd.fechaVencimiento_comprobante, cdd.nombre_comprobante,
a.codigo_articulo, a.nombre_articulo, a.referencia_articulo, dd.cantidad_devolucion,
dd.precio_devolucion, dd.totalImporte_devolucion, dd.totalDescuento_devolucion, dd.totalItbis_devolucion
FROM FacturaDevolucion d
left join Clientes cl on d.id_cliente = cl.id_cliente
left join Comprobantes cdd on d.id_comprobante = cdd.id_comprobante
left join ComprobantesDetalle cd on d.id_comprobante = cd.id_comprobante and CONVERT(nvarchar, d.id_devolucion) = cd.id_documento
left join FacturaDevolucionDetalle dd on d.id_devolucion = dd.id_devolucion
left join Articulo a on dd.id_articulo = a.id_articulo
WHERE d.id_devolucion = @idDevolucion
end
go

create proc facturaDevolucion_rpt_listar
@desde date,
@hasta date
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
WHERE d.fecha_devolucion between @desde and @hasta
end
go

select * into temp from Empresa

/****** Object:  Table [dbo].[Empresa]    Script Date: 1/8/2024 9:50:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Empresa]') AND type in (N'U'))
DROP TABLE [dbo].[Empresa]
GO

/****** Object:  Table [dbo].[Empresa]    Script Date: 1/8/2024 9:50:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Empresa](
	[id_empresa] [int] NOT NULL,
	[nombre_empresa] [varchar](50) NULL,
	[direccion_empresa] [varchar](150) NULL,
	[rnc_empresa] [varchar](15) NULL,
	[telefono] [varchar](50) NULL,
	[cell_empresa] [varchar](20) NULL,
	[correo_empresa] [varchar](50) NULL,
	[lisencia_empresa] [date] NOT NULL,
 CONSTRAINT [PK__Empresa__4A0B7E2C1FBB3FFE] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into Empresa select *,'12/31/2040' from temp
go

drop table temp
go
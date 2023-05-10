SELECT * INTO TEMP FROM Empresa
GO

/****** Object:  Table [dbo].[Empresa]    Script Date: 4/28/2023 2:29:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Empresa]') AND type in (N'U'))
DROP TABLE [dbo].[Empresa]
GO

/****** Object:  Table [dbo].[Empresa]    Script Date: 4/28/2023 2:29:12 PM ******/
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
	[fecha_actualizacion] [date] NULL,
 CONSTRAINT [PK__Empresa__4A0B7E2C1FBB3FFE] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO Empresa SELECT *, GETDATE() FROM TEMP
GO

DROP TABLE TEMP
GO

CREATE TABLE FacturaAutomatica
(
	id_factura_automatica int,
	id_cliente int,
	fecha_factura_automatica date,
	descripcion_factura_automatica nvarchar(50),
	precio_factura_automatica decimal(18,2)
)
go

create proc automatica_insertar
@idcliente int,
@fecha date, 
@descripcion nvarchar(50),
@precio decimal(18,2)
as
begin
set nocount on
declare @id int = 1
if exists (select id_factura_automatica from FacturaAutomatica)
	set @id = 1 + (select max(id_factura_automatica) from FacturaAutomatica)

insert into FacturaAutomatica values(@id, @idcliente, @fecha, @descripcion, @precio)
end
go

create proc automatica_listar
as
begin
select FA.id_factura_automatica, FA.id_cliente, FA.fecha_factura_automatica, 
FA.descripcion_factura_automatica, FA.precio_factura_automatica, c.nombre_cliente
from FacturaAutomatica FA
left join Clientes C ON FA.id_cliente = C.id_cliente
order by C.nombre_cliente
end
go

create proc [dbo].[automatica_editar]
@idFactura int,
@idcliente int,
@fecha date, 
@descripcion nvarchar(50),
@precio decimal(18,2)
as
begin
set nocount on
update FacturaAutomatica set id_cliente = @idcliente,
fecha_factura_automatica = @fecha, descripcion_factura_automatica = @descripcion,
precio_factura_automatica = @precio
where id_factura_automatica = @idFactura
end
go

create proc [dbo].[automatica_cancelar]
@idFactura int
as
begin
set nocount on
delete FacturaAutomatica where id_factura_automatica = @idFactura
end
go
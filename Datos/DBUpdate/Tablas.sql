create proc banco_insertar
@nombre nvarchar(50)
as
begin
	set nocount on
	declare @id int = 1
	if exists(select id_banco from Bancos)
		set @id = 1 + (select max(id_banco) from Bancos)
	insert into Bancos values(@id, @nombre)
end
go

create proc banco_editar
@id int,
@nombre nvarchar(50)
as
begin
	set nocount on
	update Bancos set nombre_banco = @nombre
	where id_banco = @id
end
go

create proc banco_buscar
@nombre nvarchar(50)
as
begin
	set nocount on
	select id_banco, nombre_banco from Bancos
	where nombre_banco like '%'+ @nombre + '%'
end
go

ALTER proc [dbo].[banco_buscar]
@nombre nvarchar(50)
as
begin
	set nocount on
	select id_banco, nombre_banco from Bancos
	where nombre_banco like '%'+ @nombre + '%'
	order by nombre_banco
end
go

/****** Object:  Table [dbo].[BancosCuentas]    Script Date: 9/19/2023 3:04:17 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BancosCuentas]') AND type in (N'U'))
DROP TABLE [dbo].[BancosCuentas]
GO

/****** Object:  Table [dbo].[BancosCuentas]    Script Date: 9/19/2023 3:04:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BancosCuentas](
	[id_banco] [int] NULL,
	[id_cnt_banco] [int] NULL,
	[nombre_cnt_banco] [nvarchar](50) NULL,
	[numero_cnt_banco] [nvarchar](50) NULL,
) ON [PRIMARY]
GO

create proc bancoCuenta_insertar
@idBanco int,
@nombre nvarchar(50),
@numero nvarchar(50)
as
begin
	set nocount on
	declare @id int = 1
	if exists(select id_cnt_banco from BancosCuentas)
		set @id = 1 + (select max(id_cnt_banco) from BancosCuentas)
	insert into BancosCuentas values (@idBanco, @id, @nombre, @numero)
end
go

create proc bancoCuenta_editar
@id int,
@idBanco int,
@nombre nvarchar(50),
@numero nvarchar(50)
as
begin
	set nocount on
	update BancosCuentas set id_banco = @idBanco,
	nombre_cnt_banco = @nombre, numero_cnt_banco = @numero
	where id_cnt_banco = @id
end
go

create proc bancoCuenta_buscar
@nombre nvarchar(50)
as
begin
	set nocount on
	select id_banco, id_cnt_banco, nombre_cnt_banco, numero_cnt_banco
	from BancosCuentas
	where nombre_cnt_banco like '%' + @nombre + '%'
	or numero_cnt_banco like '%' + @nombre + '%'
	order by nombre_cnt_banco
end
go

create proc bancoCuenta_buscar_id
@id int
as
begin
	set nocount on
	select id_banco, id_cnt_banco, nombre_cnt_banco, numero_cnt_banco
	from BancosCuentas
	where id_cnt_banco = @id
end
go

create proc banco_buscar_id
@id int
as
begin
	set nocount on
	select id_banco, nombre_banco from Bancos
	where id_banco = @id
end
go
USE [Link]
GO

/****** Object: SqlProcedure [dbo].[bancoCuenta_insertar] Script Date: 10/3/2023 9:29:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER proc bancoCuenta_insertar
@idBanco int,
@nombre nvarchar(50),
@numero nvarchar(50)
as
begin
	set nocount on
	declare @id int = 1
	if exists(select id_cnt_banco from BancosCuentas)
		set @id = 1 + (select max(id_cnt_banco) from BancosCuentas)
	insert into BancosCuentas values (@idBanco, @id, @nombre, @numero, 0)
end
GO

DROP TABLE [dbo].[BancosCuentas];
GO

CREATE TABLE [dbo].[BancosCuentas] (
    [id_banco]          INT           NULL,
    [id_cnt_banco]      INT           NULL,
    [nombre_cnt_banco]  NVARCHAR (50) NULL,
    [numero_cnt_banco]  NVARCHAR (50) NULL,
    [balance_cnt_banco] FLOAT (53)    NULL
);
GO

create proc bancoCuenta_buscar_id
@id int
as
begin
	set nocount on
	select id_banco, id_cnt_banco, nombre_cnt_banco, numero_cnt_banco, balance_cnt_banco
	from BancosCuentas
	where id_cnt_banco = @id
end
go

ALTER proc bancoCuenta_buscar
@nombre nvarchar(50)
as
begin
	set nocount on
	select bc.id_cnt_banco, bc.id_banco, b.nombre_banco, bc.nombre_cnt_banco, bc.numero_cnt_banco, bc.balance_cnt_banco
	from BancosCuentas bc
	left join Bancos b on bc.id_banco = b.id_banco
	where bc.nombre_cnt_banco like '%' + @nombre + '%'
	or bc.numero_cnt_banco like '%' + @nombre + '%'
	or b.nombre_banco like '%' + @nombre + '%'
	order by nombre_cnt_banco
end
go

create proc bancoMovimiento_insertar
@idBanco int,
@idCtnBanco int,
@fecha datetime,
@descripcion nvarchar(50),
@debito float,
@credito float,
@total float
as
begin
	set nocount on
	declare @id int = 1
	if exists(select id_movimiento from BancosMovimiento)
		set @id = 1 + (select max(id_movimiento) from BancosMovimiento)
	insert into BancosMovimiento values (@id, @idBanco, @idCtnBanco,
	@fecha, @descripcion, @debito, @credito, @total)

	update BancosCuentas set balance_cnt_banco = @total
	where id_cnt_banco = @idCtnBanco
end
go
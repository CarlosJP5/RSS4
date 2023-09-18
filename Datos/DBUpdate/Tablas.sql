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
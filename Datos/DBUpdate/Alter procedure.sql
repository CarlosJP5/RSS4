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


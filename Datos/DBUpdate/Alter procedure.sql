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
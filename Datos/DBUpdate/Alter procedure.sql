CREATE TABLE Caja
(
	id_caja int primary key,
	apertura_caja datetime,
	apertura_nombre varchar(50),
	cierre_caja datetime,
	cierre_nombre varchar(50),
	total_caja float,
	estado_caja varchar(15)
)
GO
CREATE TABLE ArticuloAjuste
(
	id_ajuste int,
	id_articulo int,
	fecha_ajuste date,
	nota_ajuste varchar(50),
	cantidad_ajuste decimal(10,2),
	tipo_ajuste char(1),
	costo_ajuste decimal(18,2)
)

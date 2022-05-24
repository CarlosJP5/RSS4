CREATE TYPE [dbo].[type_ajuste_inventario] AS TABLE(
	idArticulo int,
	cantidad decimal(10,2),
	tipoAjuste char(1),
	costo decimal(18,2)
)
GO



CREATE PROC articulo_ajusteInventario_insert
@fecha date,
@detalle type_ajuste_inventario readonly
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Id int = 1
	IF EXISTS (SELECT id_ajuste FROM ArticuloAjuste)
		SET @Id = 1 + (SELECT MAX(id_ajuste) FROM ArticuloAjuste)

	INSERT INTO ArticuloAjuste (id_ajuste, id_articulo, fecha_ajuste,
	cantidad_ajuste, tipo_ajuste, costo_ajuste)
	SELECT  @Id, D.idArticulo, @fecha, D.cantidad, D.tipoAjuste, D.costo
	FROM @detalle D

	SELECT MAX(id_ajuste) FROM ArticuloAjuste
END
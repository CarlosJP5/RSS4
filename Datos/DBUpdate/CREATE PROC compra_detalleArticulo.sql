CREATE PROC compra_detalleArticulo
@idArticulo int
AS
BEGIN
	SET NOCOUNT ON
	SELECT TOP 5 CC.fecha_compra AS Fecha, S.nombre_suplidor AS Nombre, C.costo_compra AS Precio
	FROM CompraDetalle C
	LEFT JOIN Suplidores S ON C.id_suplidor = S.id_suplidor
	LEFT JOIN Compra CC ON C.id_compra = CC.id_compra
	WHERE C.id_articulo = @idArticulo
END

SELECT * FROM CompraDetalle
CREATE PROC articulo_cambiarCodigo
@idArticulo int,
@codigo varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Articulo SET codigo_articulo = @codigo
	WHERE id_articulo = @idArticulo
END
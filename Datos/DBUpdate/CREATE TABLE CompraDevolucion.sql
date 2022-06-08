CREATE TABLE CompraDevolucion
(
	id_devolucionCompra int,
	id_compra int,
	id_suplidor int,
	fecha_devolucionCompra date,
	importe_devolucionCompra decimal(18,2),
	descuento_devolucionCompra decimal(18,2),
	itbis_devolucionCompra decimal(18,2),
	total_devolucionCompra decimal(18,2)
)
GO

CREATE TABLE CompraDevolucionDetalle
(
	id_devolucionCompra int,
	id_articulo int,
	cantidad_devolucionCompra decimal(16,2),
	importeUnitario_devolucionCompra decimal(16,2)
)
GO

CREATE TYPE type_detalle_devolucion AS TABLE
(
	id_articulo int,
	cantidad decimal(16,2),
	importe decimal(16,2)
)
GO

CREATE PROC compraDevolucion_insertar
@id_compra int,
@id_suplidor int,
@fecha date,
@importe decimal(18,2),
@descuento decimal(18,2),
@itbis decimal(18,2),
@total decimal(18,2),
@detalle type_detalle_devolucion readonly
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @Id int = 1
	IF EXISTS (SELECT id_devolucionCompra FROM CompraDevolucion)
		SET @Id = 1 + (SELECT MAX(id_devolucionCompra) FROM CompraDevolucion)

	INSERT INTO CompraDevolucion VALUES(@Id, @id_compra, @id_suplidor,
	@fecha,	@importe, @descuento, @itbis, @total)

	INSERT INTO CompraDevolucionDetalle (id_devolucionCompra, id_articulo,
	cantidad_devolucionCompra, importeUnitario_devolucionCompra)
	SELECT @Id, D.id_articulo, D.cantidad, D.importe
	FROM @detalle D

	IF (SELECT balance_cxp FROM CuentaPagar WHERE id_compra = @id_compra) = @total
		UPDATE CuentaPagar SET estado_cxp = 'SALDO' WHERE id_compra = @id_compra

	UPDATE CuentaPagar SET balance_cxp = balance_cxp - @total WHERE id_compra = @id_compra

	SELECT MAX(id_devolucionCompra) FROM CompraDevolucion
END
GO

CREATE TRIGGER compraDevolucionInsertar 
   ON  CompraDevolucionDetalle 
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	UPDATE A SET A.cantidad_articulo = A.cantidad_articulo - CD.cantidad_devolucionCompra
	FROM Articulo A INNER JOIN inserted CD ON A.id_articulo = CD.id_articulo
END
GO

CREATE PROC compraDevolucion_select
@idCompra int
AS
BEGIN
	SET NOCOUNT ON
	SELECT CD.id_articulo, CD.cantidad_devolucionCompra FROM CompraDevolucion C
	LEFT JOIN CompraDevolucionDetalle CD ON C.id_devolucionCompra = CD.id_devolucionCompra
	WHERE C.id_compra = @idCompra
END
GO
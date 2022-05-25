CREATE PROC facturaDevolucion_cargar
@idFactura int
AS
BEGIN
	SET NOCOUNT ON
	SELECT FD.id_articulo, FD.cantidad_devolucion FROM FacturaDevolucion F
	LEFT JOIN FacturaDevolucionDetalle FD ON F.id_devolucion = FD.id_devolucion
	WHERE F.id_factura = @idFactura
END
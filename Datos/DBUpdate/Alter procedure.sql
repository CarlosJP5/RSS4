CREATE PROC facturaServicio_listar2
@desde datetime,
@hasta datetime
AS
BEGIN
	SET NOCOUNT ON
	SELECT F.id_fservicio_st, F.fecha_fservicio, CD.ncf_comprobante,
	C.nombre_cliente, F.total_fservicio, F.tipoCompra_fservicio
	FROM FacturaServicio F
	LEFT JOIN ComprobantesDetalle CD ON F.id_fservicio_st = CD.id_documento AND F.id_comprobante = CD.id_comprobante
	LEFT JOIN Clientes C on F.id_cliente = C.id_cliente
	WHERE F.fecha_fservicio BETWEEN @desde AND @hasta
	ORDER BY F.id_fservicio DESC
END
GO
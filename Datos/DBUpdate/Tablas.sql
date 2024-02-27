USE [L_y_C_MOTOBIKE]
GO
/****** Object:  StoredProcedure [dbo].[articulo_listar]    Script Date: 2/27/2024 10:41:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[articulo_listar]
AS
BEGIN
	SET NOCOUNT ON

	SELECT A.id_articulo, codigo_articulo, referencia_articulo, nombre_articulo,
	nombre_marca, cantidad_articulo, precio_articulo, estado_articulo, porciento_itbis,
	A.costo_articulo, A.beneficio_minimo, A.puntoReorden_articulo
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis
	ORDER BY A.nombre_articulo
END
GO

ALTER PROC [dbo].[articulo_listaDeCompras]
AS
BEGIN
	SET NOCOUNT ON
	SELECT A.id_articulo, A.codigo_articulo, A.referencia_articulo, A.nombre_articulo,
	M.nombre_marca, A.cantidad_articulo, A.costo_articulo
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	WHERE puntoReorden_articulo >= cantidad_articulo
	ORDER BY A.nombre_articulo
END
GO

UPDATE Empresa SET lisencia_empresa = '3/31/2024'
GO

ALTER PROC [dbo].[articulo_listaDeComprasIdSup]
@IdSup int
AS
BEGIN
	SET NOCOUNT ON
	SELECT A.id_articulo, A.codigo_articulo, A.referencia_articulo, A.nombre_articulo,
	M.nombre_marca, A.cantidad_articulo, A.costo_articulo
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	WHERE puntoReorden_articulo >= cantidad_articulo AND A.id_suplidor = @IdSup
	ORDER BY A.nombre_articulo
END
GO
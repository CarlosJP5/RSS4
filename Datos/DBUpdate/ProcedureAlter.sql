USE [RSS2]
GO
/****** Object:  StoredProcedure [dbo].[articulo_listar]    Script Date: 5/24/2022 10:57:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[articulo_listar]
AS
BEGIN
	SET NOCOUNT ON

	SELECT A.id_articulo, codigo_articulo, referencia_articulo, nombre_articulo,
	nombre_marca, cantidad_articulo, precio_articulo, estado_articulo, porciento_itbis, A.costo_articulo
	FROM Articulo A
	LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
	LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis
	ORDER BY nombre_articulo
END
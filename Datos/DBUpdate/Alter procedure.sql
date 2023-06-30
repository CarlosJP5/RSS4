USE [Reglass]

insert into Comprobantes values('000', '-')
go

GO
/****** Object:  StoredProcedure [dbo].[comprobante_ventas]    Script Date: 6/29/2023 7:57:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[comprobante_ventas]
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT id_comprobante, nombre_comprobante FROM Comprobantes 
	WHERE id_comprobante = 'B01' OR id_comprobante = 'B02'
	OR id_comprobante = '000'
	ORDER BY nombre_comprobante
END


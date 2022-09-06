USE [PachecoMotors]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/6/2022 5:21:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[id_usuario] [int] NOT NULL,
	[usuario_usuario] [varchar](50) NULL,
	[nombre_usuario] [varchar](50) NULL,
	[cedula_usuario] [varchar](15) NULL,
	[direccion_usuario] [varchar](155) NULL,
	[telefono_usuario] [varchar](15) NULL,
	[correo_usuario] [varchar](50) NULL,
	[fechaIngreso_usuario] [date] NULL,
	[clave_usuario] [varchar](max) NULL,
	[estado_usuario] [bit] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

GO
/****** Object:  StoredProcedure [dbo].[usuario_buscar]    Script Date: 9/6/2022 5:19:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[usuario_buscar]
@buscar VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON
    SELECT id_usuario, usuario_usuario, nombre_usuario,cedula_usuario,
    direccion_usuario, telefono_usuario,correo_usuario,
    fechaIngreso_usuario,clave_usuario,estado_usuario
    FROM Usuarios
    WHERE id_usuario LIKE '%'+@buscar+'%' OR
    usuario_usuario LIKE '%'+@buscar+'%' OR
    nombre_usuario LIKE '%'+@buscar+'%' OR
    cedula_usuario LIKE '%'+@buscar+'%' OR
    correo_usuario LIKE '%'+@buscar+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_buscarCedula]    Script Date: 9/6/2022 5:19:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[usuario_buscarCedula]
@buscar VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON
    SELECT id_usuario, usuario_usuario, nombre_usuario,cedula_usuario,
    direccion_usuario, telefono_usuario,correo_usuario,
    fechaIngreso_usuario,clave_usuario,estado_usuario
    FROM Usuarios
    WHERE cedula_usuario LIKE '%'+@buscar+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_buscarCorreo]    Script Date: 9/6/2022 5:19:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[usuario_buscarCorreo]
@buscar VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON
    SELECT id_usuario, usuario_usuario, nombre_usuario,cedula_usuario,
    direccion_usuario, telefono_usuario,correo_usuario,
    fechaIngreso_usuario,clave_usuario,estado_usuario
    FROM Usuarios
    WHERE correo_usuario LIKE '%'+@buscar+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_buscarNombre]    Script Date: 9/6/2022 5:19:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[usuario_buscarNombre]
@buscar VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON
    SELECT id_usuario, usuario_usuario, nombre_usuario,cedula_usuario,
    direccion_usuario, telefono_usuario,correo_usuario,
    fechaIngreso_usuario,clave_usuario,estado_usuario
    FROM Usuarios
    WHERE nombre_usuario LIKE '%'+@buscar+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_buscarUsuario]    Script Date: 9/6/2022 5:19:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[usuario_buscarUsuario]
@buscar VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON
    SELECT id_usuario, usuario_usuario, nombre_usuario,cedula_usuario,
    direccion_usuario, telefono_usuario,correo_usuario,
    fechaIngreso_usuario,clave_usuario,estado_usuario
    FROM Usuarios
    WHERE usuario_usuario LIKE '%'+@buscar+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_editar]    Script Date: 9/6/2022 5:19:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usuario_editar] 
	-- Add the parameters for the stored procedure here
	@id int,
	@nombre varchar(50),
	@cedula varchar(15),
	@direccion varchar(155),
	@telefono varchar(15),
	@correo varchar(50),
	@clave varchar(max),
	@estado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE Usuarios SET nombre_usuario = @nombre, cedula_usuario = @cedula,
    direccion_usuario = @direccion, telefono_usuario = @telefono,
    correo_usuario = @correo, clave_usuario = @clave, estado_usuario = @estado
    WHERE id_usuario = @id
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_insertar]    Script Date: 9/6/2022 5:19:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usuario_insertar] 
	-- Add the parameters for the stored procedure here
	@usuario varchar(50),
	@nombre varchar(50),
	@cedula varchar(15),
	@direccion varchar(155),
	@telefono varchar(15),
	@correo varchar(50),
	@fecha date,
	@clave varchar(max),
	@estado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @id int = 1
	IF EXISTS(SELECT id_usuario FROM Usuarios)
		SET @id = 1 + (SELECT max(id_usuario) FROM Usuarios)

    -- Insert statements for procedure here
	INSERT INTO Usuarios VALUES
	(@id, @usuario, @nombre, @cedula,
	@direccion, @telefono, @correo,
	@fecha, @clave, @estado)
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_login]    Script Date: 9/6/2022 5:19:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usuario_login]
	-- Add the parameters for the stored procedure here
	@usuario varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
	SELECT * FROM Usuarios
	WHERE usuario_usuario = @usuario
END
GO
/****** Object:  StoredProcedure [dbo].[usuario_maxId]    Script Date: 9/6/2022 5:19:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usuario_maxId]
AS
BEGIN
	SET NOCOUNT ON
	SELECT MAX(id_usuario) ID FROM Usuarios
END
GO

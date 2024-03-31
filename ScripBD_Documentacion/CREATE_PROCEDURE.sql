USE [Creditos]
GO

/****** Object:  StoredProcedure [dbo].[sp_cliente_listar]    Script Date: 15/10/2017 10:21:13 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_cliente_listar]
AS
BEGIN
SELECT [IdCliente]
      ,[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,[TipoDocumento]
      ,[NumeroDocumento]
      ,[Sexo]
      ,[FechaNac]
      ,[Direccion]
      ,[CodigoPostal]
      ,[EstadoCivil]
  FROM [dbo].[Cliente]  
END



GO


USE [Creditos]
GO

/****** Object:  StoredProcedure [dbo].[sp_cliente_obtener]    Script Date: 15/10/2017 10:21:18 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_cliente_obtener]
(
@pNumeroDocumento VARCHAR(11)
)
AS
BEGIN
SELECT [IdCliente]
      ,[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,[TipoDocumento]
      ,[NumeroDocumento]
      ,[Sexo]
      ,[FechaNac]
      ,[Direccion]
      ,[CodigoPostal]
      ,[EstadoCivil]
  FROM [dbo].[Cliente]
  WHERE NumeroDocumento = @pNumeroDocumento
END



GO


USE [Creditos]
GO

/****** Object:  StoredProcedure [dbo].[sp_credito_actualizar]    Script Date: 15/10/2017 10:21:36 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_credito_actualizar]
(
	@IdCredito int,
	@TipoCredito int,
	@IdCliente int,
	@Fecha datetime,
	@Monto decimal(18,2),
	@DiaPago date,
	@Tasa decimal(18,2),
	@Comision decimal(18,2)	
)
AS
BEGIN
UPDATE [dbo].[Credito]
          SET TipoCredito = @TipoCredito
           ,IdCliente = @IdCliente
           ,Fecha = @Fecha
           ,Monto = @Monto
           ,DiaPago = @DiaPago
           ,Tasa = @Tasa
           ,Comision = @Comision
    WHERE IdCredito = @IdCredito
END

GO


USE [Creditos]
GO

/****** Object:  StoredProcedure [dbo].[sp_credito_eliminar]    Script Date: 15/10/2017 10:21:48 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_credito_eliminar]
(
	@IdCredito int	
)
AS
BEGIN
	DELETE [dbo].[Credito]
    WHERE IdCredito = @IdCredito
END

GO


USE [Creditos]
GO

/****** Object:  StoredProcedure [dbo].[sp_credito_listar]    Script Date: 15/10/2017 10:21:59 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_credito_listar]
AS
BEGIN
SELECT [IdCredito]
      ,[TipoCredito]
      ,[IdCliente]
      ,[Fecha]
      ,[Monto]
      ,[DiaPago]
      ,[Tasa]
      ,[Comision]
  FROM [dbo].[Credito]
END;

GO


USE [Creditos]
GO

/****** Object:  StoredProcedure [dbo].[sp_credito_obtener]    Script Date: 15/10/2017 10:22:11 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_credito_obtener]
(
	@IdCredito int
)
AS
BEGIN
SELECT IdCredito
      ,TipoCredito
      ,IdCliente
      ,Fecha
      ,Monto
      ,DiaPago
      ,Tasa
      ,Comision
  FROM dbo.Credito
  WHERE IdCredito = @IdCredito
END;

GO


USE [Creditos]
GO

/****** Object:  StoredProcedure [dbo].[sp_credito_registrar]    Script Date: 15/10/2017 10:22:24 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_credito_registrar]
(
	@TipoCredito int,
	@IdCliente int,
	@Fecha datetime,
	@Monto decimal(18,2),
	@DiaPago date,
	@Tasa decimal(18,2),
	@Comision decimal(18,2),
	@IdCredito int OUTPUT
)
AS
BEGIN
INSERT INTO [dbo].[Credito]
           ([TipoCredito]
           ,[IdCliente]
           ,[Fecha]
           ,[Monto]
           ,[DiaPago]
           ,[Tasa]
           ,[Comision])
     VALUES
           (@TipoCredito, @IdCliente, @Fecha, @Monto, @DiaPago, @Tasa, @Comision)

	SET @IdCredito = SCOPE_IDENTITY()
	RETURN @IdCredito
END

GO



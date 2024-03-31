USE [Creditos]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 15/10/2017 10:19:19 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[TipoDocumento] [char](3) NULL,
	[NumeroDocumento] [varchar](11) NULL,
	[Sexo] [char](1) NULL,
	[FechaNac] [datetime] NULL,
	[Direccion] [varchar](200) NULL,
	[CodigoPostal] [varchar](50) NULL,
	[EstadoCivil] [char](1) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [Creditos]
GO

/****** Object:  Table [dbo].[Credito]    Script Date: 15/10/2017 10:19:24 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Credito](
	[IdCredito] [int] IDENTITY(1,1) NOT NULL,
	[TipoCredito] [int] NULL,
	[IdCliente] [int] NULL,
	[Fecha] [datetime] NULL,
	[Monto] [decimal](18, 2) NULL,
	[DiaPago] [datetime] NULL,
	[Tasa] [decimal](18, 2) NULL,
	[Comision] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Credito] PRIMARY KEY CLUSTERED 
(
	[IdCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Credito' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Credito'
GO



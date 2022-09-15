USE [PruebaKevinForero]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TiposDeDocumento](
	[TipoDocumentoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Abreviatura] [varchar](10) NOT NULL,
 CONSTRAINT [PK_TiposDeDocumento] PRIMARY KEY CLUSTERED 
(
	[TipoDocumentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


Insert Into [dbo].[TiposDeDocumento] (Nombre,Abreviatura)values('Cédula','CC')
Insert Into [dbo].[TiposDeDocumento] (Nombre,Abreviatura)values('Tarjeta de Identidad','TI')
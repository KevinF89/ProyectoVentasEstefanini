USE [PruebaKevinForero]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MediosDePago](
	[MedioDePagoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MediosDePago] PRIMARY KEY CLUSTERED 
(
	[MedioDePagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


Insert Into [dbo].[MediosDePago] (Nombre) values('Efectivo')
Insert Into [dbo].[MediosDePago] (Nombre) values('Tarjeta de crédito')
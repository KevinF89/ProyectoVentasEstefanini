USE [PruebaKevinForero]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClienteProducto](
	[ClienteProductoID] [int] IDENTITY(1,1) NOT NULL,
	[ClienteID] [int] NOT NULL,
	[ProductoID] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[ValorTotal] [int] NOT NULL,
	[MedioDePagoID] [int] NOT NULL,
 CONSTRAINT [PK_ClienteProducto] PRIMARY KEY CLUSTERED 
(
	[ClienteProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ClienteProducto]  WITH CHECK ADD  CONSTRAINT [FK_ClienteProducto_Clientes] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Clientes] ([ClienteID])
GO

ALTER TABLE [dbo].[ClienteProducto] CHECK CONSTRAINT [FK_ClienteProducto_Clientes]
GO

ALTER TABLE [dbo].[ClienteProducto]  WITH CHECK ADD  CONSTRAINT [FK_ClienteProducto_MediosDePago] FOREIGN KEY([MedioDePagoID])
REFERENCES [dbo].[MediosDePago] ([MedioDePagoID])
GO

ALTER TABLE [dbo].[ClienteProducto] CHECK CONSTRAINT [FK_ClienteProducto_MediosDePago]
GO

ALTER TABLE [dbo].[ClienteProducto]  WITH CHECK ADD  CONSTRAINT [FK_ClienteProducto_Productos] FOREIGN KEY([ProductoID])
REFERENCES [dbo].[Productos] ([ProductoID])
GO

ALTER TABLE [dbo].[ClienteProducto] CHECK CONSTRAINT [FK_ClienteProducto_Productos]
GO



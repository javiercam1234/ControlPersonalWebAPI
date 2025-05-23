USE [Aprensisaje]
GO
/****** Object:  Table [dbo].[tblPersona]    Script Date: 21/05/2025 01:51:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPersona](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Edad] [numeric](18, 0) NULL,
	[Telefono] [numeric](18, 0) NULL,
	[FechaNacimiento] [date] NULL,
	[Sexo] [nchar](10) NULL,
	[Activo] [bit] NULL,
	[IdPuesto] [int] NULL,
 CONSTRAINT [PK_tblPersona] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPuestos]    Script Date: 21/05/2025 01:51:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPuestos](
	[IdPuesto] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionPuesto] [varchar](50) NULL,
 CONSTRAINT [PK_tblPuestos] PRIMARY KEY CLUSTERED 
(
	[IdPuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblPersona]  WITH CHECK ADD  CONSTRAINT [FK_tblPersona_tblPuestos] FOREIGN KEY([IdPuesto])
REFERENCES [dbo].[tblPuestos] ([IdPuesto])
GO
ALTER TABLE [dbo].[tblPersona] CHECK CONSTRAINT [FK_tblPersona_tblPuestos]
GO

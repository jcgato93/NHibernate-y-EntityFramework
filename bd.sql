USE [master]
GO
/****** Object:  Database [Parcial]    Script Date: 25/11/2017 12:18:22 p.m. ******/
CREATE DATABASE [Parcial]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Parcial', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Parcial.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Parcial_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Parcial_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Parcial] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Parcial].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Parcial] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Parcial] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Parcial] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Parcial] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Parcial] SET ARITHABORT OFF 
GO
ALTER DATABASE [Parcial] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Parcial] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Parcial] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Parcial] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Parcial] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Parcial] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Parcial] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Parcial] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Parcial] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Parcial] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Parcial] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Parcial] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Parcial] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Parcial] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Parcial] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Parcial] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Parcial] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Parcial] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Parcial] SET  MULTI_USER 
GO
ALTER DATABASE [Parcial] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Parcial] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Parcial] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Parcial] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Parcial] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Parcial]
GO
/****** Object:  Table [dbo].[tbCategoria]    Script Date: 25/11/2017 12:18:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbCategoria](
	[cateCodigo] [int] IDENTITY(1,1) NOT NULL,
	[cateDescripcion] [varchar](50) NULL,
 CONSTRAINT [PK_tbCategoria] PRIMARY KEY CLUSTERED 
(
	[cateCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbMembresia]    Script Date: 25/11/2017 12:18:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbMembresia](
	[membCodigo] [int] IDENTITY(1,1) NOT NULL,
	[membDescripcion] [varchar](50) NULL,
	[membCantidad] [int] NULL,
 CONSTRAINT [PK_tbMembresia] PRIMARY KEY CLUSTERED 
(
	[membCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbProducto]    Script Date: 25/11/2017 12:18:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbProducto](
	[prodCodigo] [int] IDENTITY(1,1) NOT NULL,
	[prodDescripcion] [varchar](50) NULL,
	[prodCantidad] [int] NULL,
	[prodValor] [int] NULL,
	[provIdentificacion] [int] NULL,
	[cateCodigo] [int] NULL,
 CONSTRAINT [PK_tbProducto] PRIMARY KEY CLUSTERED 
(
	[prodCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbProveedor]    Script Date: 25/11/2017 12:18:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbProveedor](
	[provIdentificacion] [int] IDENTITY(1,1) NOT NULL,
	[provNombres] [varchar](100) NULL,
	[provApellidos] [varchar](100) NULL,
	[provDireccion] [varchar](50) NULL,
	[provTelefono] [varchar](50) NULL,
	[provCorreo] [varchar](50) NULL,
	[membCodigo] [int] NULL,
 CONSTRAINT [PK_tbProveedor] PRIMARY KEY CLUSTERED 
(
	[provIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbCategoria] ON 

INSERT [dbo].[tbCategoria] ([cateCodigo], [cateDescripcion]) VALUES (2, N'Lacteos')
INSERT [dbo].[tbCategoria] ([cateCodigo], [cateDescripcion]) VALUES (3, N'Abarrotes')
INSERT [dbo].[tbCategoria] ([cateCodigo], [cateDescripcion]) VALUES (4, N'Bebidas')
INSERT [dbo].[tbCategoria] ([cateCodigo], [cateDescripcion]) VALUES (5, N'Condimentos y Salsas')
INSERT [dbo].[tbCategoria] ([cateCodigo], [cateDescripcion]) VALUES (6, N'Golosinas y Postres')
SET IDENTITY_INSERT [dbo].[tbCategoria] OFF
SET IDENTITY_INSERT [dbo].[tbMembresia] ON 

INSERT [dbo].[tbMembresia] ([membCodigo], [membDescripcion], [membCantidad]) VALUES (2, N'Platino', 2)
INSERT [dbo].[tbMembresia] ([membCodigo], [membDescripcion], [membCantidad]) VALUES (3, N'Gold', 1)
SET IDENTITY_INSERT [dbo].[tbMembresia] OFF
SET IDENTITY_INSERT [dbo].[tbProducto] ON 

INSERT [dbo].[tbProducto] ([prodCodigo], [prodDescripcion], [prodCantidad], [prodValor], [provIdentificacion], [cateCodigo]) VALUES (2, N'Leche', 10, 2000, 0, 2)
INSERT [dbo].[tbProducto] ([prodCodigo], [prodDescripcion], [prodCantidad], [prodValor], [provIdentificacion], [cateCodigo]) VALUES (4, N'Cocacola', 100, 0, 2, 4)
SET IDENTITY_INSERT [dbo].[tbProducto] OFF
SET IDENTITY_INSERT [dbo].[tbProveedor] ON 

INSERT [dbo].[tbProveedor] ([provIdentificacion], [provNombres], [provApellidos], [provDireccion], [provTelefono], [provCorreo], [membCodigo]) VALUES (0, N'test', N'test', N'test', N'77777', N'test@test.com', 2)
INSERT [dbo].[tbProveedor] ([provIdentificacion], [provNombres], [provApellidos], [provDireccion], [provTelefono], [provCorreo], [membCodigo]) VALUES (2, N'john', N'Doe', N'street lost', N'310555555', N'correo@test.com', 3)
SET IDENTITY_INSERT [dbo].[tbProveedor] OFF
ALTER TABLE [dbo].[tbProducto]  WITH CHECK ADD  CONSTRAINT [FK_tbProducto_tbCategoria] FOREIGN KEY([cateCodigo])
REFERENCES [dbo].[tbCategoria] ([cateCodigo])
GO
ALTER TABLE [dbo].[tbProducto] CHECK CONSTRAINT [FK_tbProducto_tbCategoria]
GO
ALTER TABLE [dbo].[tbProducto]  WITH CHECK ADD  CONSTRAINT [FK_tbProducto_tbProveedor] FOREIGN KEY([provIdentificacion])
REFERENCES [dbo].[tbProveedor] ([provIdentificacion])
GO
ALTER TABLE [dbo].[tbProducto] CHECK CONSTRAINT [FK_tbProducto_tbProveedor]
GO
ALTER TABLE [dbo].[tbProveedor]  WITH CHECK ADD  CONSTRAINT [FK_tbProveedor_tbMembresia] FOREIGN KEY([membCodigo])
REFERENCES [dbo].[tbMembresia] ([membCodigo])
GO
ALTER TABLE [dbo].[tbProveedor] CHECK CONSTRAINT [FK_tbProveedor_tbMembresia]
GO
USE [master]
GO
ALTER DATABASE [Parcial] SET  READ_WRITE 
GO

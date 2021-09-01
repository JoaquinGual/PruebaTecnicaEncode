USE [master]
GO
/****** Object:  Database [Encode]    Script Date: 31/08/2021 23:41:29 ******/
CREATE DATABASE [Encode]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Encode', FILENAME = N'E:\SQL\MSSQL15.JOAQUIN\MSSQL\DATA\Encode.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Encode_log', FILENAME = N'E:\SQL\MSSQL15.JOAQUIN\MSSQL\DATA\Encode_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Encode] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Encode].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Encode] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Encode] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Encode] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Encode] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Encode] SET ARITHABORT OFF 
GO
ALTER DATABASE [Encode] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Encode] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Encode] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Encode] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Encode] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Encode] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Encode] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Encode] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Encode] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Encode] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Encode] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Encode] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Encode] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Encode] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Encode] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Encode] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Encode] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Encode] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Encode] SET  MULTI_USER 
GO
ALTER DATABASE [Encode] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Encode] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Encode] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Encode] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Encode] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Encode] SET QUERY_STORE = OFF
GO
USE [Encode]
GO
/****** Object:  Table [dbo].[Suscripcion]    Script Date: 31/08/2021 23:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suscripcion](
	[IdAsociacion] [int] IDENTITY(1,1) NOT NULL,
	[IdSuscriptor] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaFin] [date] NULL,
	[MotivoFin] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAsociacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suscriptor]    Script Date: 31/08/2021 23:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suscriptor](
	[IdSuscriptor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[NumeroDocumento] [int] NOT NULL,
	[TipoDocumento] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](12) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSuscriptor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Suscripcion] ON 

INSERT [dbo].[Suscripcion] ([IdAsociacion], [IdSuscriptor], [FechaAlta], [FechaFin], [MotivoFin]) VALUES (8, 16, CAST(N'2021-08-30T00:00:00.000' AS DateTime), NULL, N'1900-01-01')
INSERT [dbo].[Suscripcion] ([IdAsociacion], [IdSuscriptor], [FechaAlta], [FechaFin], [MotivoFin]) VALUES (9, 17, CAST(N'2021-08-30T16:56:51.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Suscripcion] ([IdAsociacion], [IdSuscriptor], [FechaAlta], [FechaFin], [MotivoFin]) VALUES (10, 19, CAST(N'2021-08-30T16:56:51.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Suscripcion] ([IdAsociacion], [IdSuscriptor], [FechaAlta], [FechaFin], [MotivoFin]) VALUES (11, 19, CAST(N'2021-08-30T17:25:56.127' AS DateTime), NULL, NULL)
INSERT [dbo].[Suscripcion] ([IdAsociacion], [IdSuscriptor], [FechaAlta], [FechaFin], [MotivoFin]) VALUES (12, 21, CAST(N'2021-08-31T15:04:02.133' AS DateTime), NULL, NULL)
INSERT [dbo].[Suscripcion] ([IdAsociacion], [IdSuscriptor], [FechaAlta], [FechaFin], [MotivoFin]) VALUES (13, 18, CAST(N'2021-08-31T15:04:43.747' AS DateTime), NULL, NULL)
INSERT [dbo].[Suscripcion] ([IdAsociacion], [IdSuscriptor], [FechaAlta], [FechaFin], [MotivoFin]) VALUES (14, 21, CAST(N'2021-08-31T15:05:14.673' AS DateTime), NULL, NULL)
INSERT [dbo].[Suscripcion] ([IdAsociacion], [IdSuscriptor], [FechaAlta], [FechaFin], [MotivoFin]) VALUES (15, 21, CAST(N'2021-08-31T15:13:06.113' AS DateTime), NULL, NULL)
INSERT [dbo].[Suscripcion] ([IdAsociacion], [IdSuscriptor], [FechaAlta], [FechaFin], [MotivoFin]) VALUES (16, 20, CAST(N'2021-08-31T15:14:36.130' AS DateTime), NULL, NULL)
INSERT [dbo].[Suscripcion] ([IdAsociacion], [IdSuscriptor], [FechaAlta], [FechaFin], [MotivoFin]) VALUES (17, 22, CAST(N'2021-08-31T15:14:56.063' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Suscripcion] OFF
GO
SET IDENTITY_INSERT [dbo].[Suscriptor] ON 

INSERT [dbo].[Suscriptor] ([IdSuscriptor], [Nombre], [Apellido], [NumeroDocumento], [TipoDocumento], [Direccion], [Telefono], [Email], [NombreUsuario], [Password]) VALUES (16, N'Joaquin', N'Gual', 1, N'DNI', N'la pampa 11', N'3512659876', N'Joa@gmail.com', N'JGUAL', N'holajoa')
INSERT [dbo].[Suscriptor] ([IdSuscriptor], [Nombre], [Apellido], [NumeroDocumento], [TipoDocumento], [Direccion], [Telefono], [Email], [NombreUsuario], [Password]) VALUES (17, N'Trinidad', N'Pirola', 2, N'DNI', N'la pampa 11', N'3518004790', N'trini@gmail.com', N'TPIROLA', N'holatrini')
INSERT [dbo].[Suscriptor] ([IdSuscriptor], [Nombre], [Apellido], [NumeroDocumento], [TipoDocumento], [Direccion], [Telefono], [Email], [NombreUsuario], [Password]) VALUES (18, N'Maxi', N'Farias', 3, N'DNI', N'Su casa', N'351698765', N'maxi@gmail.com', N'MFARIAS', N'maxihola')
INSERT [dbo].[Suscriptor] ([IdSuscriptor], [Nombre], [Apellido], [NumeroDocumento], [TipoDocumento], [Direccion], [Telefono], [Email], [NombreUsuario], [Password]) VALUES (19, N'Ignacio', N'Pedrosa', 4, N'DNI', N'nose', N'351565596', N'nacho@gmail.com', N'IPEDROSA', N'holanacho')
INSERT [dbo].[Suscriptor] ([IdSuscriptor], [Nombre], [Apellido], [NumeroDocumento], [TipoDocumento], [Direccion], [Telefono], [Email], [NombreUsuario], [Password]) VALUES (20, N'Catalina', N'Caceres', 5, N'DNI', N'Gabriela Mistral', N'3516985464', N'cati@gmail.com', N'CCACERES', N'holacati')
INSERT [dbo].[Suscriptor] ([IdSuscriptor], [Nombre], [Apellido], [NumeroDocumento], [TipoDocumento], [Direccion], [Telefono], [Email], [NombreUsuario], [Password]) VALUES (21, N'Santiago', N'Mansilla', 6, N'DNI', N'lsdjajd', N'65654564', N'santi@gmail.com', N'SMANSILLA', N'HOLASH')
INSERT [dbo].[Suscriptor] ([IdSuscriptor], [Nombre], [Apellido], [NumeroDocumento], [TipoDocumento], [Direccion], [Telefono], [Email], [NombreUsuario], [Password]) VALUES (22, N'Pedro', N'Garcia', 7, N'DNI', N'asdas', N'35194464', N'pedro@gmail.com', N'PGARCIA', N'pedrito')
INSERT [dbo].[Suscriptor] ([IdSuscriptor], [Nombre], [Apellido], [NumeroDocumento], [TipoDocumento], [Direccion], [Telefono], [Email], [NombreUsuario], [Password]) VALUES (23, N'Valentin', N'Cequeira', 8, N'DNI', N'la casa', N'3512987654', N'valen@gmail.com', N'VCEQUEIRA', N'holavalen')
SET IDENTITY_INSERT [dbo].[Suscriptor] OFF
GO
ALTER TABLE [dbo].[Suscripcion]  WITH CHECK ADD  CONSTRAINT [Suscripcion_Suscriptor] FOREIGN KEY([IdSuscriptor])
REFERENCES [dbo].[Suscriptor] ([IdSuscriptor])
GO
ALTER TABLE [dbo].[Suscripcion] CHECK CONSTRAINT [Suscripcion_Suscriptor]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarSuscriptor]    Script Date: 31/08/2021 23:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ActualizarSuscriptor]
@Nombre varchar(40),
@Apellido varchar (40),
@NumeroDocumento int,
@TipoDocumento varchar(40),
@Direccion varchar (60),
@Telefono varchar(15),
@Email varchar(50),
@NombreUsuario varchar (30),
@Contraseña varchar(40)
as
update Suscriptor set Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Telefono = @Telefono, Email = @Email, NombreUsuario= @NombreUsuario, Password = @Contraseña 
where NumeroDocumento = @NumeroDocumento and TipoDocumento = @TipoDocumento
GO
/****** Object:  StoredProcedure [dbo].[BuscarSuscriptor]    Script Date: 31/08/2021 23:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[BuscarSuscriptor]
@tipoDocumento varchar(20),
@NumeroDoc int
as
Select * from Suscriptor
where TipoDocumento = @tipoDocumento and NumeroDocumento = @NumeroDoc
GO
/****** Object:  StoredProcedure [dbo].[registrarSuscripcion]    Script Date: 31/08/2021 23:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[registrarSuscripcion]
@idSuscriptor int


as
insert into Suscripcion (IdSuscriptor,FechaAlta,FechaFin,MotivoFin)
values (@idSuscriptor,GETDATE(),null,null)
GO
/****** Object:  StoredProcedure [dbo].[registrarSuscriptor]    Script Date: 31/08/2021 23:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[registrarSuscriptor]
@Nombre varchar(40),
@Apellido varchar (40),
@NumeroDocumento int,
@TipoDocumento varchar(40),
@Direccion varchar (60),
@Telefono varchar(40),
@Email varchar(50),
@NombreUsuario varchar (30),
@Contraseña varchar(40)
as
insert into Suscriptor (Nombre,Apellido,NumeroDocumento,TipoDocumento,Direccion,Telefono,Email,NombreUsuario,Password)
values (@Nombre,@Apellido,@NumeroDocumento,@TipoDocumento,@Direccion,@Telefono,@Email,@NombreUsuario,@Contraseña)
GO
USE [master]
GO
ALTER DATABASE [Encode] SET  READ_WRITE 
GO

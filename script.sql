create database Encode
USE [Encode]
GO
/****** Object:  Table [dbo].[Suscripcion]    Script Date: 25/8/2021 16:01:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suscripcion](
	[IdAsociacion] [int] IDENTITY(1,1) NOT NULL,
	[IdSuscriptor] [int] NOT NULL,
	[FechaAlta] [date] NOT NULL,
	[FechaFin] [date] NOT NULL,
	[MotivoFin] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAsociacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suscriptor]    Script Date: 25/8/2021 16:01:13 ******/
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
ALTER TABLE [dbo].[Suscripcion]  WITH CHECK ADD  CONSTRAINT [Suscripcion_Suscriptor] FOREIGN KEY([IdSuscriptor])
REFERENCES [dbo].[Suscriptor] ([IdSuscriptor])
GO
ALTER TABLE [dbo].[Suscripcion] CHECK CONSTRAINT [Suscripcion_Suscriptor]
GO

create proc registrarSuscripcion
@idSuscriptor int,
@FechaAlta datetime,
@FechaFin datetime,
@MotivoFin varchar(80)
as
insert into Suscripcion (IdSuscriptor,FechaAlta,FechaFin,MotivoFin)
values (@idSuscriptor,@FechaAlta,@FechaFin,@MotivoFin)

create proc registrarSuscriptor
@Nombre varchar(40),
@Apellido varchar (40),
@NumeroDocumento int,
@TipoDocumento varchar(40),
@Direccion varchar (60),
@Telefono int,
@Email varchar(50),
@NombreUsuario varchar (30),
@Contraseña varchar(40)
as
insert into Suscriptor (Nombre,Apellido,NumeroDocumento,TipoDocumento,Direccion,Telefono,Email,NombreUsuario,Password)
values (@Nombre,@Apellido,@NumeroDocumento,@TipoDocumento,@Direccion,@Telefono,@Email,@NombreUsuario,@Contraseña)

exec registrarSuscriptor
'Ignacio',
'Pedrosa',
50,
'DNI',
'ASD 123',
341343,
'nachovich@gmail.com',
'IPEDROSA',
'chau'

select * from Suscripcion
create proc ActualizarSuscriptor
@Nombre varchar(40),
@Apellido varchar (40),
@NumeroDocumento int,
@TipoDocumento varchar(40),
@Direccion varchar (60),
@Telefono int,
@Email varchar(50),
@NombreUsuario varchar (30),
@Contraseña varchar(40)
as
update Suscriptor set Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Telefono = @Telefono, Email = @Email, NombreUsuario= @NombreUsuario, Password = @Contraseña 
where NumeroDocumento = @NumeroDocumento and TipoDocumento = @TipoDocumento

create proc BuscarSuscriptor
@tipoDocumento varchar(20),
@NumeroDoc int
as
Select * from Suscripcion
where TipoDocumento = @tipoDocumento and NumeroDocumento = @NumeroDoc

exec BuscarSuscriptor
'DI',
41
alter table Suscripcion alter column FechaAlta datetime not null
drop procedure VerificarSuscripcion

delete from suscriptor
set dateformat dmy
exec  registrarSuscripcion
19,'30/08/2021 16:56:51'

USE [master]
GO
/****** Object:  Database [BD_Empresa]    Script Date: 22/10/2021 23:04:25 ******/
CREATE DATABASE [BD_Empresa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_Empresa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BD_Empresa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_Empresa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BD_Empresa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BD_Empresa] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_Empresa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_Empresa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_Empresa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_Empresa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_Empresa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_Empresa] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_Empresa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_Empresa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_Empresa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_Empresa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_Empresa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_Empresa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_Empresa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_Empresa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_Empresa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_Empresa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_Empresa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_Empresa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_Empresa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_Empresa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_Empresa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_Empresa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_Empresa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_Empresa] SET RECOVERY FULL 
GO
ALTER DATABASE [BD_Empresa] SET  MULTI_USER 
GO
ALTER DATABASE [BD_Empresa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_Empresa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_Empresa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_Empresa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_Empresa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BD_Empresa] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BD_Empresa', N'ON'
GO
ALTER DATABASE [BD_Empresa] SET QUERY_STORE = OFF
GO
USE [BD_Empresa]
GO
/****** Object:  Table [dbo].[TB_Empleado]    Script Date: 22/10/2021 23:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Empleado](
	[EmpleadoCodigo] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadoNombre] [varchar](50) NULL,
	[EmpleadoApellido] [varchar](50) NULL,
	[EmpleadoDireccion] [varchar](100) NULL,
	[EmpleadoTelefono] [varchar](50) NULL,
	[EmpleadoEmail] [varchar](50) NULL,
	[EmpleadoFechaNacimiento] [datetime] NULL,
	[EmpleadoSueldo] [real] NULL,
	[EmpleadoEstado] [bit] NULL,
 CONSTRAINT [PK_TB_Empleado] PRIMARY KEY CLUSTERED 
(
	[EmpleadoCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_Empleado_Eliminar]    Script Date: 22/10/2021 23:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_Empleado_Eliminar]
@EmpleadoCodigo				Int
AS
 
	DELETE FROM TB_Empleado
	WHERE EmpleadoCodigo				 = @EmpleadoCodigo
GO
/****** Object:  StoredProcedure [dbo].[usp_Empleado_Filtrar]    Script Date: 22/10/2021 23:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_Empleado_Filtrar]
@EmpleadoNombre			Varchar(100),
@EmpleadoApellido			Varchar(100)
AS
	SELECT 
		EmpleadoCodigo			,
		EmpleadoNombre		,
		EmpleadoApellido		,
		EmpleadoDireccion		,
		EmpleadoTelefono		,
		EmpleadoEmail			,
		EmpleadoFechaNacimiento	,
		EmpleadoSueldo			,
		EmpleadoEstado						
	FROM Tb_Empleado
	WHERE EmpleadoNombre LIKE '%'+ @EmpleadoNombre +'%'
	AND EmpleadoApellido LIKE '%'+ @EmpleadoApellido +'%'
GO
/****** Object:  StoredProcedure [dbo].[usp_Empleado_ListarTodos]    Script Date: 22/10/2021 23:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_Empleado_ListarTodos]
AS
	SELECT 
		EmpleadoCodigo				,
		EmpleadoNombre			,
		EmpleadoApellido			,
		EmpleadoDireccion			,
		EmpleadoTelefono			,
		EmpleadoEmail			        ,
		EmpleadoFechaNacimiento		,
		EmpleadoSueldo			        ,
		EmpleadoEstado						
	FROM TB_Empleado
GO
/****** Object:  StoredProcedure [dbo].[usp_Empleado_Modificar]    Script Date: 22/10/2021 23:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_Empleado_Modificar]
@EmpleadoCodigo			Int,
@EmpleadoNombre		Varchar(100),
@EmpleadoApellido	Varchar(100),
@EmpleadoDireccion		Varchar(200),
@EmpleadoTelefono		Varchar(200),
@EmpleadoEmail		Varchar(200),
@EmpleadoFechaNacimiento DateTime,
@EmpleadoSueldo		Real,
@EmpleadoEstado			Bit
AS
 
	UPDATE TB_Empleado
	SET
		EmpleadoNombre						= @EmpleadoNombre			, 
		EmpleadoApellido						= @EmpleadoApellido			, 
		EmpleadoDireccion						= @EmpleadoDireccion		,
		EmpleadoTelefono						= @EmpleadoTelefono		, 
		EmpleadoEmail			        			        = @EmpleadoEmail			, 
		EmpleadoFechaNacimiento				= @EmpleadoFechaNacimiento 	,
		EmpleadoSueldo			        			        = @EmpleadoSueldo			, 
		EmpleadoEstado											= @EmpleadoEstado
	WHERE EmpleadoCodigo				 = @EmpleadoCodigo
GO
/****** Object:  StoredProcedure [dbo].[usp_Empleado_Registrar]    Script Date: 22/10/2021 23:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_Empleado_Registrar]
@EmpleadoNombre		Varchar(100),
@EmpleadoApellido		Varchar(100),
@EmpleadoDireccion		Varchar(200),
@EmpleadoTelefono		Varchar(200),
@EmpleadoEmail			Varchar(200),
@EmpleadoFechaNacimiento	DateTime,
@EmpleadoSueldo		Real,
@EmpleadoEstado				Bit
AS
 
	INSERT INTO TB_Empleado
	(
		
		EmpleadoNombre			,
		EmpleadoApellido			,
		EmpleadoDireccion			,
		EmpleadoTelefono			,
		EmpleadoEmail			        ,
		EmpleadoFechaNacimiento		,
		EmpleadoSueldo			        ,
		EmpleadoEstado							
	)
	VALUES
	(
		@EmpleadoNombre	,
@EmpleadoApellido	,
@EmpleadoDireccion	,
@EmpleadoTelefono	,
@EmpleadoEmail	,
@EmpleadoFechaNacimiento,
@EmpleadoSueldo,
@EmpleadoEstado						
	)
GO
USE [master]
GO
ALTER DATABASE [BD_Empresa] SET  READ_WRITE 
GO

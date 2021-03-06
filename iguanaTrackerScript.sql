USE [master]
GO
/****** Object:  Database [FloridaIguanaTrackerDB]    Script Date: 12/11/2020 12:24:22 AM ******/
CREATE DATABASE [FloridaIguanaTrackerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FloridaIguanaTrackerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FloridaIguanaTrackerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FloridaIguanaTrackerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FloridaIguanaTrackerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FloridaIguanaTrackerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET RECOVERY FULL 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET  MULTI_USER 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FloridaIguanaTrackerDB', N'ON'
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET QUERY_STORE = OFF
GO
USE [FloridaIguanaTrackerDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/11/2020 12:24:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Iguanas]    Script Date: 12/11/2020 12:24:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Iguanas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DatePosted] [datetime] NOT NULL,
	[Image] [varbinary](max) NULL,
	[Coordinates] [geography] NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Description] [varchar](max) NULL,
	[Latitude] [decimal](11, 9) NOT NULL,
	[Longitude] [decimal](11, 9) NOT NULL,
 CONSTRAINT [PK_Iguanas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [FloridaIguanaTrackerDB] SET  READ_WRITE 
GO

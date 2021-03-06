USE [master]
GO
/****** Object:  Database [ABC]    Script Date: 05/10/2017 09:12:06 ******/
CREATE DATABASE [ABC] ON  PRIMARY 
( NAME = N'ABC', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\ABC.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ABC_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\ABC_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ABC] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ABC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ABC] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ABC] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ABC] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ABC] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ABC] SET ARITHABORT OFF
GO
ALTER DATABASE [ABC] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ABC] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ABC] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ABC] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ABC] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ABC] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ABC] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ABC] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ABC] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ABC] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ABC] SET  DISABLE_BROKER
GO
ALTER DATABASE [ABC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ABC] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ABC] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ABC] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ABC] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ABC] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ABC] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ABC] SET  READ_WRITE
GO
ALTER DATABASE [ABC] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ABC] SET  MULTI_USER
GO
ALTER DATABASE [ABC] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ABC] SET DB_CHAINING OFF
GO
USE [ABC]
GO
/****** Object:  User [admin]    Script Date: 05/10/2017 09:12:06 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 05/10/2017 09:12:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 05/10/2017 09:12:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NULL,
	[fullname] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 05/10/2017 09:12:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[price] [decimal](18, 2) NULL,
	[amount] [int] NULL,
	[description] [text] NULL,
	[photo] [varchar](50) NULL,
	[idcategory] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Product_Category]    Script Date: 05/10/2017 09:12:06 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([idcategory])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO

USE [master]
GO
/****** Object:  Database [seryiPractika]    Script Date: 20.12.2024 16:36:05 ******/
CREATE DATABASE [seryiPractika]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'seryiPractika', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\seryiPractika.mdf' , SIZE = 270336KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'seryiPractika_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\seryiPractika_log.ldf' , SIZE = 204800KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [seryiPractika] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [seryiPractika].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [seryiPractika] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [seryiPractika] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [seryiPractika] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [seryiPractika] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [seryiPractika] SET ARITHABORT OFF 
GO
ALTER DATABASE [seryiPractika] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [seryiPractika] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [seryiPractika] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [seryiPractika] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [seryiPractika] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [seryiPractika] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [seryiPractika] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [seryiPractika] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [seryiPractika] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [seryiPractika] SET  DISABLE_BROKER 
GO
ALTER DATABASE [seryiPractika] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [seryiPractika] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [seryiPractika] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [seryiPractika] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [seryiPractika] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [seryiPractika] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [seryiPractika] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [seryiPractika] SET RECOVERY FULL 
GO
ALTER DATABASE [seryiPractika] SET  MULTI_USER 
GO
ALTER DATABASE [seryiPractika] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [seryiPractika] SET DB_CHAINING OFF 
GO
ALTER DATABASE [seryiPractika] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [seryiPractika] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [seryiPractika] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [seryiPractika] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'seryiPractika', N'ON'
GO
ALTER DATABASE [seryiPractika] SET QUERY_STORE = OFF
GO
USE [seryiPractika]
GO
/****** Object:  Table [dbo].[categ]    Script Date: 20.12.2024 16:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categ](
	[id] [int] NOT NULL,
	[category_name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_categ] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 20.12.2024 16:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[price] [nvarchar](max) NOT NULL,
	[count] [nvarchar](max) NOT NULL,
	[sum] [nvarchar](max) NOT NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prodact]    Script Date: 20.12.2024 16:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prodact](
	[id] [int] NOT NULL,
	[name_prod] [nvarchar](100) NOT NULL,
	[id_cat] [int] NOT NULL,
 CONSTRAINT [PK_prodact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 20.12.2024 16:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] NOT NULL,
	[family_name] [nvarchar](max) NOT NULL,
	[first_name] [nvarchar](max) NOT NULL,
	[patronymic] [nvarchar](max) NOT NULL,
	[login] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_prodact] FOREIGN KEY([product_id])
REFERENCES [dbo].[prodact] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_prodact]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_users]
GO
ALTER TABLE [dbo].[prodact]  WITH CHECK ADD  CONSTRAINT [FK_prodact_categ] FOREIGN KEY([id_cat])
REFERENCES [dbo].[categ] ([id])
GO
ALTER TABLE [dbo].[prodact] CHECK CONSTRAINT [FK_prodact_categ]
GO
USE [master]
GO
ALTER DATABASE [seryiPractika] SET  READ_WRITE 
GO

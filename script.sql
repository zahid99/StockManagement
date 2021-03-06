USE [master]
GO
/****** Object:  Database [Shop]    Script Date: 1/4/2018 3:57:03 PM ******/
CREATE DATABASE [Shop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Shop', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Shop.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Shop_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Shop_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Shop] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Shop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Shop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Shop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Shop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Shop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Shop] SET ARITHABORT OFF 
GO
ALTER DATABASE [Shop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Shop] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Shop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Shop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Shop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Shop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Shop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Shop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Shop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Shop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Shop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Shop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Shop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Shop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Shop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Shop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Shop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Shop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Shop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Shop] SET  MULTI_USER 
GO
ALTER DATABASE [Shop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Shop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Shop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Shop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Shop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/4/2018 3:57:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Category__19093A0BE6843C38] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 1/4/2018 3:57:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item]    Script Date: 1/4/2018 3:57:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](200) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ReorderLevel] [int] NOT NULL,
	[AvailableQuantity] [int] NOT NULL,
 CONSTRAINT [PK__Item__727E838BE0F43AB2] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 1/4/2018 3:57:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nchar](50) NOT NULL,
	[Password] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockReport]    Script Date: 1/4/2018 3:57:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockReport](
	[StockReportId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_StockReport] PRIMARY KEY CLUSTERED 
(
	[StockReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ItemWithCategory]    Script Date: 1/4/2018 3:57:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ItemWithCategory]
as
SELECT i.ItemName,c.CategoryName,i.CompanyId,i.CategoryId ,Company.CompanyName,i.AvailableQuantity,i.ReorderLevel 
FROM Item AS i INNER JOIN Category AS c ON
 i.CategoryId=c.CategoryId INNER JOIN Company ON 
 i.CompanyId=Company.CompanyId 
GO
/****** Object:  View [dbo].[StockreportView]    Script Date: 1/4/2018 3:57:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StockreportView] 
AS
SELECT Item.ItemName,StockReport.ItemId,StockReport.Quantity,StockReport.Date
FROM StockReport ,Item 
WHERE  status='Sold' AND Item.ItemId=StockReport.ItemId 

GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (9, N'Cosmetics')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Electronics')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Kitchen items')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (6, N'LG')
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (2, N'RFL')
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (7, N'Unilever')
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (1, N'Walton')
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([ItemId], [ItemName], [CategoryId], [CompanyId], [ReorderLevel], [AvailableQuantity]) VALUES (1, N'Television', 1, 1, 0, 8)
INSERT [dbo].[Item] ([ItemId], [ItemName], [CategoryId], [CompanyId], [ReorderLevel], [AvailableQuantity]) VALUES (2, N'Laptop', 1, 1, 1, 6)
INSERT [dbo].[Item] ([ItemId], [ItemName], [CategoryId], [CompanyId], [ReorderLevel], [AvailableQuantity]) VALUES (11, N'Vaseline', 9, 7, 0, 40)
INSERT [dbo].[Item] ([ItemId], [ItemName], [CategoryId], [CompanyId], [ReorderLevel], [AvailableQuantity]) VALUES (12, N'Lux', 9, 7, 0, 25)
INSERT [dbo].[Item] ([ItemId], [ItemName], [CategoryId], [CompanyId], [ReorderLevel], [AvailableQuantity]) VALUES (13, N'Refrigerator', 1, 6, 0, 0)
SET IDENTITY_INSERT [dbo].[Item] OFF
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([UserId], [Username], [Password]) VALUES (1, N'Zahid                                             ', N'zahid                                             ')
SET IDENTITY_INSERT [dbo].[Login] OFF
SET IDENTITY_INSERT [dbo].[StockReport] ON 

INSERT [dbo].[StockReport] ([StockReportId], [CompanyId], [ItemId], [Quantity], [Status], [Date]) VALUES (1031, 7, 11, 5, N'Sold      ', CAST(0xB93D0B00 AS Date))
INSERT [dbo].[StockReport] ([StockReportId], [CompanyId], [ItemId], [Quantity], [Status], [Date]) VALUES (1032, 1, 1, 1, N'Sold      ', CAST(0xB63D0B00 AS Date))
INSERT [dbo].[StockReport] ([StockReportId], [CompanyId], [ItemId], [Quantity], [Status], [Date]) VALUES (1033, 7, 11, 5, N'Lost      ', CAST(0xB93D0B00 AS Date))
INSERT [dbo].[StockReport] ([StockReportId], [CompanyId], [ItemId], [Quantity], [Status], [Date]) VALUES (1034, 7, 12, 5, N'Lost      ', CAST(0xB93D0B00 AS Date))
INSERT [dbo].[StockReport] ([StockReportId], [CompanyId], [ItemId], [Quantity], [Status], [Date]) VALUES (1035, 1, 1, 1, N'Sold      ', CAST(0xB93D0B00 AS Date))
SET IDENTITY_INSERT [dbo].[StockReport] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Category__8517B2E03D6B868D]    Script Date: 1/4/2018 3:57:03 PM ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [UQ__Category__8517B2E03D6B868D] UNIQUE NONCLUSTERED 
(
	[CategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Company__9BCE05DC1AA9BFC6]    Script Date: 1/4/2018 3:57:03 PM ******/
ALTER TABLE [dbo].[Company] ADD UNIQUE NONCLUSTERED 
(
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Item__4E4373F7F4CAF373]    Script Date: 1/4/2018 3:57:03 PM ******/
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [UQ__Item__4E4373F7F4CAF373] UNIQUE NONCLUSTERED 
(
	[ItemName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Login]    Script Date: 1/4/2018 3:57:03 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Login] ON [dbo].[Login]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Category]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Company]
GO
ALTER TABLE [dbo].[StockReport]  WITH CHECK ADD  CONSTRAINT [FK_StockReport_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[StockReport] CHECK CONSTRAINT [FK_StockReport_Item]
GO
USE [master]
GO
ALTER DATABASE [Shop] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [ApaService]    Script Date: 11/27/2014 8:52:48 PM ******/
CREATE DATABASE [ApaService]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApaService', FILENAME = N'H:\IRAPA.ir\ApaService\Database\Version .04\ApaService.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [WAREHOUSE] 
( NAME = N'ApaService_Warehouse', FILENAME = N'H:\IRAPA.ir\ApaService\Database\Version .04\ApaService_Warehouse.ndf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ApaService_log', FILENAME = N'H:\IRAPA.ir\ApaService\Database\Version .04\ApaService_log.LDF' , SIZE = 3456KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
GO
ALTER DATABASE [ApaService] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApaService].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApaService] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApaService] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApaService] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApaService] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApaService] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApaService] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ApaService] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ApaService] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApaService] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApaService] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApaService] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApaService] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApaService] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApaService] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApaService] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApaService] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ApaService] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApaService] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApaService] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApaService] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApaService] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApaService] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ApaService] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApaService] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ApaService] SET  MULTI_USER 
GO
ALTER DATABASE [ApaService] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApaService] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApaService] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApaService] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ApaService', N'ON'
GO
USE [ApaService]
GO
/****** Object:  FullTextCatalog [FullTextCatalog_Category]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE FULLTEXT CATALOG [FullTextCatalog_Category]
GO
/****** Object:  FullTextCatalog [FullTextCatalog_Location]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE FULLTEXT CATALOG [FullTextCatalog_Location]
GO
/****** Object:  FullTextCatalog [FullTextCatalog_Product]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE FULLTEXT CATALOG [FullTextCatalog_Product]
GO
/****** Object:  FullTextCatalog [FullTextCatalog_Shop]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE FULLTEXT CATALOG [FullTextCatalog_Shop]
GO
/****** Object:  UserDefinedDataType [dbo].[AddressType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[AddressType] FROM [nvarchar](100) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[CardNumberType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[CardNumberType] FROM [varchar](16) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[CommonStringType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[CommonStringType] FROM [varchar](50) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[DescriptionType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[DescriptionType] FROM [nvarchar](500) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[EnumeratoinType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[EnumeratoinType] FROM [varchar](50) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[HierarchyIdType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[HierarchyIdType] FROM [char](16) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[MoneyType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[MoneyType] FROM [int] NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[PasswordType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[PasswordType] FROM [binary](32) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[PathAddressType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[PathAddressType] FROM [varchar](100) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[PhoneNumberType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[PhoneNumberType] FROM [varchar](11) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[PrimaryIdType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[PrimaryIdType] FROM [int] NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[RankType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[RankType] FROM [int] NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[ResourceIdType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[ResourceIdType] FROM [uniqueidentifier] NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[SearchHelperType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[SearchHelperType] FROM [nvarchar](500) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[TenCodeType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[TenCodeType] FROM [char](10) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[UnicodeCommonStringType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[UnicodeCommonStringType] FROM [nvarchar](50) NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[UserNameType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE TYPE [dbo].[UserNameType] FROM [nvarchar](50) NOT NULL
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UserId] [dbo].[PrimaryIdType] NOT NULL,
	[Image] [dbo].[ResourceIdType] NULL,
	[ChargeAmount] [dbo].[MoneyType] NOT NULL,
	[Enable] [bit] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountAdministrator]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountAdministrator](
	[Id] [dbo].[PrimaryIdType] NOT NULL,
 CONSTRAINT [PK_AccountAdministrator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountBuyer]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountBuyer](
	[Id] [dbo].[PrimaryIdType] NOT NULL,
 CONSTRAINT [PK_AccountBuyer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountRequirement]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountRequirement](
	[Id] [dbo].[PrimaryIdType] NOT NULL,
 CONSTRAINT [PK_AccountRequirement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountSeller]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountSeller](
	[Id] [dbo].[PrimaryIdType] NOT NULL,
	[MinimumChargeAmountForSelling] [dbo].[MoneyType] NOT NULL,
 CONSTRAINT [PK_AccountSeller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountTransaction]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTransaction](
	[Id] [dbo].[PrimaryIdType] NOT NULL,
	[AccountId] [dbo].[PrimaryIdType] NOT NULL,
 CONSTRAINT [PK_AccountTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Basket]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Basket](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[ShopId] [dbo].[PrimaryIdType] NOT NULL,
	[AccountBuyerId] [dbo].[PrimaryIdType] NOT NULL,
	[SourceLocationId] [dbo].[PrimaryIdType] NOT NULL,
	[DestinationLocationId] [dbo].[PrimaryIdType] NOT NULL,
	[ShopDeliveryMethodId] [dbo].[PrimaryIdType] NOT NULL,
	[ShopPaymentMethodId] [dbo].[PrimaryIdType] NOT NULL,
	[Fullname] [dbo].[UnicodeCommonStringType] NOT NULL,
	[PhoneNumber] [dbo].[PhoneNumberType] NOT NULL,
	[MobileNumber] [dbo].[PhoneNumberType] NOT NULL,
	[DestinationAddress] [dbo].[AddressType] NOT NULL,
	[Status] [dbo].[EnumeratoinType] NOT NULL,
	[StatusDescriptions] [xml] NULL,
	[Workflow] [dbo].[EnumeratoinType] NOT NULL,
	[UserDescription] [dbo].[DescriptionType] NULL,
	[IsTheUserDescriptionNeededToConfirm] [bit] NOT NULL,
	[TotalItemsOriginAmount] [dbo].[MoneyType] NOT NULL,
	[TotalItemsTaxAmount] [dbo].[MoneyType] NOT NULL,
	[TotalItemsDiscountAmount] [dbo].[MoneyType] NOT NULL,
	[DeliveryAmount] [dbo].[MoneyType] NOT NULL,
	[TaxAmount] [dbo].[MoneyType] NOT NULL,
	[DiscountAmount] [dbo].[MoneyType] NOT NULL,
	[ApaGroupCommissionAmount] [dbo].[MoneyType] NOT NULL,
	[FinalAmount] [dbo].[MoneyType] NOT NULL,
 CONSTRAINT [PK_Basket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [WAREHOUSE]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BasketItem]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasketItem](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[BasketId] [dbo].[PrimaryIdType] NOT NULL,
	[ProductId] [dbo].[PrimaryIdType] NOT NULL,
	[Ordered] [nvarchar](20) NOT NULL,
	[OriginAmount] [dbo].[MoneyType] NOT NULL,
	[TaxAmount] [dbo].[MoneyType] NOT NULL,
	[DiscountAmount] [dbo].[MoneyType] NOT NULL,
	[FinalAmount] [dbo].[MoneyType] NOT NULL,
	[Description] [dbo].[DescriptionType] NULL,
 CONSTRAINT [PK_BasketItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BasketTransaction]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasketTransaction](
	[Id] [dbo].[PrimaryIdType] NOT NULL,
	[BasketId] [dbo].[PrimaryIdType] NOT NULL,
 CONSTRAINT [PK_BasketTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Brand]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[Title] [dbo].[UnicodeCommonStringType] NOT NULL,
	[LogoIdentifier] [dbo].[ResourceIdType] NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ParentId] [dbo].[PrimaryIdType] NULL,
	[HierarchyCode] [dbo].[HierarchyIdType] NOT NULL,
	[Title] [dbo].[UnicodeCommonStringType] NOT NULL,
	[LogoIdentifier] [dbo].[ResourceIdType] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ParentId] [dbo].[PrimaryIdType] NULL,
	[HierarchyCode] [dbo].[HierarchyIdType] NOT NULL,
	[Title] [dbo].[UnicodeCommonStringType] NOT NULL,
	[LogoIdentifier] [dbo].[ResourceIdType] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PrivacyAccountPermissionGroup]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrivacyAccountPermissionGroup](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[AccountId] [dbo].[PrimaryIdType] NOT NULL,
	[PrivacyPermisionGroupId] [dbo].[PrimaryIdType] NOT NULL,
 CONSTRAINT [PK_AccountPermissionGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PrivacyGroup]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PrivacyGroup](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[Name] [dbo].[CommonStringType] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PrivacyPermission]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PrivacyPermission](
	[Id] [dbo].[PrimaryIdType] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[Name] [dbo].[EnumeratoinType] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PrivacyPermissionGroup]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrivacyPermissionGroup](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[PrivacyGroupId] [dbo].[PrimaryIdType] NOT NULL,
	[PrivacyPermisionId] [dbo].[PrimaryIdType] NOT NULL,
 CONSTRAINT [PK_PermissionGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PrivacySecureData]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrivacySecureData](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[AccountId] [dbo].[PrimaryIdType] NOT NULL,
	[TableId] [smallint] NOT NULL,
	[SecureId] [dbo].[PrimaryIdType] NOT NULL,
 CONSTRAINT [PK_SecureData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[BrandId] [dbo].[PrimaryIdType] NULL,
	[ShopId] [dbo].[PrimaryIdType] NOT NULL,
	[PersianName] [dbo].[UnicodeCommonStringType] NOT NULL,
	[EnglishName] [dbo].[CommonStringType] NOT NULL,
	[SearchHelper] [dbo].[SearchHelperType] NOT NULL,
	[LogoIdentifier] [dbo].[ResourceIdType] NULL,
	[ExhibitionStartDate] [datetime] NOT NULL,
	[ExhibitionExpireDate] [datetime] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[IsModifingCausedDisable] [bit] NOT NULL,
	[Enable] [bit] NOT NULL,
	[IsProductNeededToConfirm] [bit] NOT NULL,
	[IsPriceNeededToConfirm] [bit] NOT NULL,
	[Properties] [xml] NULL,
	[SelectableProperties] [xml] NULL,
	[SupportedSelectableProperties] [xml] NULL,
	[AttachmentIdentifiers] [xml] NULL,
	[ImageIdentifiers] [xml] NULL,
	[Description] [dbo].[DescriptionType] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [WAREHOUSE]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ProductId] [dbo].[PrimaryIdType] NOT NULL,
	[CategoryId] [dbo].[PrimaryIdType] NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductComment]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductComment](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ProductId] [dbo].[PrimaryIdType] NOT NULL,
	[Username] [dbo].[UserNameType] NOT NULL,
	[CommentType] [dbo].[EnumeratoinType] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductNumerable]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductNumerable](
	[Id] [dbo].[PrimaryIdType] NOT NULL,
	[Weight] [int] NOT NULL,
	[Unit] [dbo].[UnicodeCommonStringType] NULL,
	[Store] [int] NULL,
	[RetailUnitPriceAmount] [dbo].[MoneyType] NULL,
	[RetailConditions] [xml] NULL,
	[WholesaleUnitPriceAmount] [dbo].[MoneyType] NULL,
	[WholesaleConditions] [xml] NULL,
	[Tax] [xml] NULL,
	[Discount] [xml] NULL,
 CONSTRAINT [PK_ProductNumerable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductRank]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductRank](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ProductId] [dbo].[PrimaryIdType] NOT NULL,
	[Username] [dbo].[UserNameType] NOT NULL,
	[Rank] [dbo].[EnumeratoinType] NOT NULL,
 CONSTRAINT [PK_ProductRank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductStatistics]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStatistics](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[LikeProduct] [dbo].[RankType] NOT NULL,
	[DislikeProduct] [dbo].[RankType] NOT NULL,
	[VisitCount] [int] NOT NULL,
	[BoughtCount] [int] NOT NULL,
 CONSTRAINT [PK_ProductStatistics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Resource]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Resource](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[Title] [dbo].[UnicodeCommonStringType] NULL,
	[ResourceIdentifier] [dbo].[ResourceIdType] NOT NULL,
	[Size] [int] NOT NULL,
	[PhysicalAddress] [dbo].[PathAddressType] NOT NULL,
 CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Shop]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Shop](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[AccountSellerId] [dbo].[PrimaryIdType] NOT NULL,
	[LocationId] [dbo].[PrimaryIdType] NOT NULL,
	[Enable] [bit] NOT NULL,
	[PersianName] [dbo].[UnicodeCommonStringType] NOT NULL,
	[EnglishName] [dbo].[CommonStringType] NOT NULL,
	[SearchHelper] [dbo].[SearchHelperType] NOT NULL,
	[LogoIdentifier] [dbo].[ResourceIdType] NULL,
	[AreBasketsNeededToConfirm] [bit] NOT NULL,
	[ImageIdentifiers] [xml] NULL,
	[Tax] [xml] NULL,
	[Discount] [xml] NULL,
	[ApaGroupCommission] [xml] NOT NULL,
	[Description] [dbo].[DescriptionType] NULL,
 CONSTRAINT [PK_Shop] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [WAREHOUSE]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShopCategory]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopCategory](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ShopId] [dbo].[PrimaryIdType] NOT NULL,
	[CategoryId] [dbo].[PrimaryIdType] NOT NULL,
 CONSTRAINT [PK_ShopCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShopComment]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShopComment](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ShopId] [dbo].[PrimaryIdType] NOT NULL,
	[Username] [dbo].[UserNameType] NOT NULL,
	[CommentType] [dbo].[EnumeratoinType] NOT NULL,
	[Comment] [dbo].[DescriptionType] NOT NULL,
 CONSTRAINT [PK_ShopComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShopDeliveryMethod]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShopDeliveryMethod](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ShopId] [dbo].[PrimaryIdType] NOT NULL,
	[Title] [dbo].[UnicodeCommonStringType] NOT NULL,
	[Type] [dbo].[EnumeratoinType] NOT NULL,
	[Enable] [bit] NOT NULL,
 CONSTRAINT [PK_ShopDeliveryMethod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShopPaymentMethod]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShopPaymentMethod](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ShopId] [dbo].[PrimaryIdType] NOT NULL,
	[Title] [dbo].[UnicodeCommonStringType] NOT NULL,
	[Type] [dbo].[EnumeratoinType] NOT NULL,
	[Enable] [bit] NOT NULL,
 CONSTRAINT [PK_ShopPaymentMethod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShopRank]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShopRank](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ShopId] [dbo].[PrimaryIdType] NOT NULL,
	[Username] [dbo].[UserNameType] NOT NULL,
	[Rank] [dbo].[EnumeratoinType] NOT NULL,
 CONSTRAINT [PK_ShopRank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShopServeLocation]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopServeLocation](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ShopId] [dbo].[PrimaryIdType] NOT NULL,
	[LocationId] [dbo].[PrimaryIdType] NOT NULL,
 CONSTRAINT [PK_ShopServeLocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShopStatistics]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShopStatistics](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[ApaGroupRank] [dbo].[EnumeratoinType] NOT NULL,
	[LikeShop] [dbo].[RankType] NOT NULL,
	[DislikeShop] [dbo].[RankType] NOT NULL,
	[BoughtCount] [int] NOT NULL,
 CONSTRAINT [PK_ShopStatistics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[ReferenceNumber] [dbo].[CommonStringType] NOT NULL,
	[TransactionState] [dbo].[EnumeratoinType] NOT NULL,
	[BuyerAccountNumber] [dbo].[CommonStringType] NOT NULL,
	[TotalAmount] [dbo].[MoneyType] NOT NULL,
	[ReverseAmount] [dbo].[MoneyType] NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [dbo].[PrimaryIdType] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[Username] [dbo].[UserNameType] NOT NULL,
	[Type] [dbo].[EnumeratoinType] NOT NULL,
	[Name] [dbo].[UnicodeCommonStringType] NOT NULL,
	[Family] [dbo].[UnicodeCommonStringType] NOT NULL,
	[Gender] [dbo].[EnumeratoinType] NOT NULL,
	[PersonalCode] [dbo].[TenCodeType] NULL,
	[Birthday] [datetime] NULL,
	[PhoneNumber] [dbo].[PhoneNumberType] NULL,
	[MobileNumber] [dbo].[PhoneNumberType] NOT NULL,
	[Email] [dbo].[CommonStringType] NOT NULL,
	[LocationId] [dbo].[PrimaryIdType] NOT NULL,
	[Address] [dbo].[AddressType] NOT NULL,
	[PostalCode] [dbo].[TenCodeType] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserLogin](
	[Id] [dbo].[PrimaryIdType] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[Password] [dbo].[PasswordType] NOT NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[PrivacyAccountPermission]    Script Date: 11/27/2014 8:52:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[PrivacyAccountPermission]
with schemabinding
AS
SELECT     dbo.PrivacyAccountPermissionGroup.Id, dbo.PrivacyAccountPermissionGroup.RowVersion, dbo.PrivacyAccountPermissionGroup.AccountId, 
                      dbo.PrivacyPermissionGroup.PrivacyPermisionId
FROM         dbo.PrivacyAccountPermissionGroup INNER JOIN
                      dbo.PrivacyPermissionGroup ON dbo.PrivacyAccountPermissionGroup.PrivacyPermisionGroupId = dbo.PrivacyPermissionGroup.Id


GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
/****** Object:  Index [Index_PrivacyAccountPermission_Id]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE CLUSTERED INDEX [Index_PrivacyAccountPermission_Id] ON [dbo].[PrivacyAccountPermission]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Account_IdUserIdEnable]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_Account_IdUserIdEnable] ON [dbo].[Account]
(
	[Id] ASC,
	[UserId] ASC,
	[Enable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Account_UserId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Account_UserId] ON [dbo].[Account]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_AccountTransaction_AccountId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_AccountTransaction_AccountId] ON [dbo].[AccountTransaction]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Basket_AccountBuyerId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Basket_AccountBuyerId] ON [dbo].[Basket]
(
	[AccountBuyerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Basket_AccountBuyerIdIsTheUserDescriptionNeededToConfirm]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Basket_AccountBuyerIdIsTheUserDescriptionNeededToConfirm] ON [dbo].[Basket]
(
	[AccountBuyerId] ASC,
	[IsTheUserDescriptionNeededToConfirm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_Basket_AccountBuyerIdStatus]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Basket_AccountBuyerIdStatus] ON [dbo].[Basket]
(
	[AccountBuyerId] ASC,
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Basket_ShopId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Basket_ShopId] ON [dbo].[Basket]
(
	[ShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Basket_ShopIdIsTheUserDescriptionNeededToConfirm]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Basket_ShopIdIsTheUserDescriptionNeededToConfirm] ON [dbo].[Basket]
(
	[ShopId] ASC,
	[IsTheUserDescriptionNeededToConfirm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_Basket_ShopIdStatus]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Basket_ShopIdStatus] ON [dbo].[Basket]
(
	[ShopId] ASC,
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_Basket_Status]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Basket_Status] ON [dbo].[Basket]
(
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_BasketItem_BasketId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_BasketItem_BasketId] ON [dbo].[BasketItem]
(
	[BasketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_BasketItem_ProductId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_BasketItem_ProductId] ON [dbo].[BasketItem]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_BasketTransaction_BasketId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_BasketTransaction_BasketId] ON [dbo].[BasketTransaction]
(
	[BasketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_Brand_Title]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_Brand_Title] ON [dbo].[Brand]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Category_ParentId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Category_ParentId] ON [dbo].[Category]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_Category_ParentIdTitle]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_Category_ParentIdTitle] ON [dbo].[Category]
(
	[ParentId] ASC,
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_Category_Title]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Category_Title] ON [dbo].[Category]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Location_ParentId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Location_ParentId] ON [dbo].[Location]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_Location_ParentIdTitle]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_Location_ParentIdTitle] ON [dbo].[Location]
(
	[ParentId] ASC,
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_Location_Title]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Location_Title] ON [dbo].[Location]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_PrivacyAccountPermissionGroup_AccountId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_PrivacyAccountPermissionGroup_AccountId] ON [dbo].[PrivacyAccountPermissionGroup]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_PrivacyAccountPermissionGroup_AccountIdPrivacyPermissionGroupId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_PrivacyAccountPermissionGroup_AccountIdPrivacyPermissionGroupId] ON [dbo].[PrivacyAccountPermissionGroup]
(
	[AccountId] ASC,
	[PrivacyPermisionGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_PrivacyGroup_Name]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_PrivacyGroup_Name] ON [dbo].[PrivacyGroup]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_PrivacyPermission_Name]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_PrivacyPermission_Name] ON [dbo].[PrivacyPermission]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_SecurityPermissionGroups_SecurityGroupIdSecurityPermissionId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_SecurityPermissionGroups_SecurityGroupIdSecurityPermissionId] ON [dbo].[PrivacyPermissionGroup]
(
	[PrivacyGroupId] ASC,
	[PrivacyPermisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_SecureData_AccountIdTableIdSecureId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_SecureData_AccountIdTableIdSecureId] ON [dbo].[PrivacySecureData]
(
	[AccountId] ASC,
	[TableId] ASC,
	[SecureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Product_BrandId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Product_BrandId] ON [dbo].[Product]
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Product_ShopId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Product_ShopId] ON [dbo].[Product]
(
	[ShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_ProductCategory_ProductIdCategoryId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_ProductCategory_ProductIdCategoryId] ON [dbo].[ProductCategory]
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_ProductComment_ProductId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_ProductComment_ProductId] ON [dbo].[ProductComment]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_ProductComment_ProductIdCommentType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_ProductComment_ProductIdCommentType] ON [dbo].[ProductComment]
(
	[ProductId] ASC,
	[CommentType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_ProductRank_ProductIdUsername]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_ProductRank_ProductIdUsername] ON [dbo].[ProductRank]
(
	[ProductId] ASC,
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Resource_IdentifierSize]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_Resource_IdentifierSize] ON [dbo].[Resource]
(
	[ResourceIdentifier] ASC,
	[Size] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Shop_AccountSellerId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_Shop_AccountSellerId] ON [dbo].[Shop]
(
	[AccountSellerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_Shop_EnglishName]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_Shop_EnglishName] ON [dbo].[Shop]
(
	[EnglishName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_Shop_LocationId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_Shop_LocationId] ON [dbo].[Shop]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_Shop_PersianName]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_Shop_PersianName] ON [dbo].[Shop]
(
	[PersianName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_ShopCategory_ShopIdCategoryId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_ShopCategory_ShopIdCategoryId] ON [dbo].[ShopCategory]
(
	[ShopId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_ShopComment_ShopId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_ShopComment_ShopId] ON [dbo].[ShopComment]
(
	[ShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_ShopComment_ShopIdCommentType]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_ShopComment_ShopIdCommentType] ON [dbo].[ShopComment]
(
	[ShopId] ASC,
	[CommentType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_ShopDeliveryMethod_ShopId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_ShopDeliveryMethod_ShopId] ON [dbo].[ShopDeliveryMethod]
(
	[ShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_ShopPaymentMethod_ShopId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_ShopPaymentMethod_ShopId] ON [dbo].[ShopPaymentMethod]
(
	[ShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_ShopRank_ShopIdUsername]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_ShopRank_ShopIdUsername] ON [dbo].[ShopRank]
(
	[ShopId] ASC,
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_ShopServeLocation_LocationId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE NONCLUSTERED INDEX [Index_ShopServeLocation_LocationId] ON [dbo].[ShopServeLocation]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Index_ShopServeLocation_ShopIdLocationId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_ShopServeLocation_ShopIdLocationId] ON [dbo].[ShopServeLocation]
(
	[ShopId] ASC,
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_Transaction_ReferenceNumber]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_Transaction_ReferenceNumber] ON [dbo].[Transaction]
(
	[ReferenceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Index_User_UserName]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_User_UserName] ON [dbo].[User]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
/****** Object:  Index [Index_PrivacyAccountPermission_AccountId]    Script Date: 11/27/2014 8:52:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Index_PrivacyAccountPermission_AccountId] ON [dbo].[PrivacyAccountPermission]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_User]
GO
ALTER TABLE [dbo].[AccountAdministrator]  WITH CHECK ADD  CONSTRAINT [FK_AccountAdministrator_Account] FOREIGN KEY([Id])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[AccountAdministrator] CHECK CONSTRAINT [FK_AccountAdministrator_Account]
GO
ALTER TABLE [dbo].[AccountBuyer]  WITH CHECK ADD  CONSTRAINT [FK_AccountBuyer_Account] FOREIGN KEY([Id])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[AccountBuyer] CHECK CONSTRAINT [FK_AccountBuyer_Account]
GO
ALTER TABLE [dbo].[AccountRequirement]  WITH CHECK ADD  CONSTRAINT [FK_AccountRequirement_Account] FOREIGN KEY([Id])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[AccountRequirement] CHECK CONSTRAINT [FK_AccountRequirement_Account]
GO
ALTER TABLE [dbo].[AccountSeller]  WITH CHECK ADD  CONSTRAINT [FK_AccountSeller_Account] FOREIGN KEY([Id])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[AccountSeller] CHECK CONSTRAINT [FK_AccountSeller_Account]
GO
ALTER TABLE [dbo].[AccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_AccountTransaction_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[AccountTransaction] CHECK CONSTRAINT [FK_AccountTransaction_Account]
GO
ALTER TABLE [dbo].[AccountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_AccountTransaction_Transaction] FOREIGN KEY([Id])
REFERENCES [dbo].[Transaction] ([Id])
GO
ALTER TABLE [dbo].[AccountTransaction] CHECK CONSTRAINT [FK_AccountTransaction_Transaction]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_AccountBuyer] FOREIGN KEY([AccountBuyerId])
REFERENCES [dbo].[AccountBuyer] ([Id])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_AccountBuyer]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Location_DestinationLocation] FOREIGN KEY([DestinationLocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Location_DestinationLocation]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Location_SourceLocation] FOREIGN KEY([SourceLocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Location_SourceLocation]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Shop] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([Id])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Shop]
GO
ALTER TABLE [dbo].[BasketItem]  WITH CHECK ADD  CONSTRAINT [FK_BasketItem_Basket] FOREIGN KEY([BasketId])
REFERENCES [dbo].[Basket] ([Id])
GO
ALTER TABLE [dbo].[BasketItem] CHECK CONSTRAINT [FK_BasketItem_Basket]
GO
ALTER TABLE [dbo].[BasketItem]  WITH CHECK ADD  CONSTRAINT [FK_BasketItem_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[BasketItem] CHECK CONSTRAINT [FK_BasketItem_Product]
GO
ALTER TABLE [dbo].[BasketTransaction]  WITH CHECK ADD  CONSTRAINT [FK_BasketTransaction_Basket] FOREIGN KEY([BasketId])
REFERENCES [dbo].[Basket] ([Id])
GO
ALTER TABLE [dbo].[BasketTransaction] CHECK CONSTRAINT [FK_BasketTransaction_Basket]
GO
ALTER TABLE [dbo].[BasketTransaction]  WITH CHECK ADD  CONSTRAINT [FK_BasketTransaction_Transaction] FOREIGN KEY([Id])
REFERENCES [dbo].[Transaction] ([Id])
GO
ALTER TABLE [dbo].[BasketTransaction] CHECK CONSTRAINT [FK_BasketTransaction_Transaction]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Location] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Location]
GO
ALTER TABLE [dbo].[PrivacyAccountPermissionGroup]  WITH CHECK ADD  CONSTRAINT [FK_AccountPermissionGroup_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[PrivacyAccountPermissionGroup] CHECK CONSTRAINT [FK_AccountPermissionGroup_Account]
GO
ALTER TABLE [dbo].[PrivacyAccountPermissionGroup]  WITH CHECK ADD  CONSTRAINT [FK_AccountPermissionGroup_PermissionGroup] FOREIGN KEY([PrivacyPermisionGroupId])
REFERENCES [dbo].[PrivacyPermissionGroup] ([Id])
GO
ALTER TABLE [dbo].[PrivacyAccountPermissionGroup] CHECK CONSTRAINT [FK_AccountPermissionGroup_PermissionGroup]
GO
ALTER TABLE [dbo].[PrivacyPermissionGroup]  WITH CHECK ADD  CONSTRAINT [FK_PermissionGroup_Group] FOREIGN KEY([PrivacyGroupId])
REFERENCES [dbo].[PrivacyGroup] ([Id])
GO
ALTER TABLE [dbo].[PrivacyPermissionGroup] CHECK CONSTRAINT [FK_PermissionGroup_Group]
GO
ALTER TABLE [dbo].[PrivacyPermissionGroup]  WITH CHECK ADD  CONSTRAINT [FK_PermissionGroup_Permission] FOREIGN KEY([PrivacyPermisionId])
REFERENCES [dbo].[PrivacyPermission] ([Id])
GO
ALTER TABLE [dbo].[PrivacyPermissionGroup] CHECK CONSTRAINT [FK_PermissionGroup_Permission]
GO
ALTER TABLE [dbo].[PrivacySecureData]  WITH CHECK ADD  CONSTRAINT [FK_SecureData_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[PrivacySecureData] CHECK CONSTRAINT [FK_SecureData_Account]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Shop] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Shop]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Category]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Product]
GO
ALTER TABLE [dbo].[ProductComment]  WITH CHECK ADD  CONSTRAINT [FK_ProductComment_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductComment] CHECK CONSTRAINT [FK_ProductComment_Product]
GO
ALTER TABLE [dbo].[ProductNumerable]  WITH CHECK ADD  CONSTRAINT [FK_ProductNumerable_Product] FOREIGN KEY([Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductNumerable] CHECK CONSTRAINT [FK_ProductNumerable_Product]
GO
ALTER TABLE [dbo].[ProductRank]  WITH CHECK ADD  CONSTRAINT [FK_ProductRank_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductRank] CHECK CONSTRAINT [FK_ProductRank_Product]
GO
ALTER TABLE [dbo].[ProductStatistics]  WITH CHECK ADD  CONSTRAINT [FK_ProductStatistics_Product] FOREIGN KEY([Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductStatistics] CHECK CONSTRAINT [FK_ProductStatistics_Product]
GO
ALTER TABLE [dbo].[Shop]  WITH CHECK ADD  CONSTRAINT [FK_Shop_AccountSeller] FOREIGN KEY([AccountSellerId])
REFERENCES [dbo].[AccountSeller] ([Id])
GO
ALTER TABLE [dbo].[Shop] CHECK CONSTRAINT [FK_Shop_AccountSeller]
GO
ALTER TABLE [dbo].[Shop]  WITH CHECK ADD  CONSTRAINT [FK_Shop_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Shop] CHECK CONSTRAINT [FK_Shop_Location]
GO
ALTER TABLE [dbo].[ShopCategory]  WITH CHECK ADD  CONSTRAINT [FK_ShopCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ShopCategory] CHECK CONSTRAINT [FK_ShopCategory_Category]
GO
ALTER TABLE [dbo].[ShopCategory]  WITH CHECK ADD  CONSTRAINT [FK_ShopCategory_Shop] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([Id])
GO
ALTER TABLE [dbo].[ShopCategory] CHECK CONSTRAINT [FK_ShopCategory_Shop]
GO
ALTER TABLE [dbo].[ShopComment]  WITH CHECK ADD  CONSTRAINT [FK_ShopComment_Shop] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([Id])
GO
ALTER TABLE [dbo].[ShopComment] CHECK CONSTRAINT [FK_ShopComment_Shop]
GO
ALTER TABLE [dbo].[ShopDeliveryMethod]  WITH CHECK ADD  CONSTRAINT [FK_ShopDeliveryMethod_Shop] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([Id])
GO
ALTER TABLE [dbo].[ShopDeliveryMethod] CHECK CONSTRAINT [FK_ShopDeliveryMethod_Shop]
GO
ALTER TABLE [dbo].[ShopPaymentMethod]  WITH CHECK ADD  CONSTRAINT [FK_ShopPaymentMethod_Shop] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([Id])
GO
ALTER TABLE [dbo].[ShopPaymentMethod] CHECK CONSTRAINT [FK_ShopPaymentMethod_Shop]
GO
ALTER TABLE [dbo].[ShopRank]  WITH CHECK ADD  CONSTRAINT [FK_ShopRank_Shop] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([Id])
GO
ALTER TABLE [dbo].[ShopRank] CHECK CONSTRAINT [FK_ShopRank_Shop]
GO
ALTER TABLE [dbo].[ShopServeLocation]  WITH CHECK ADD  CONSTRAINT [FK_ShopServeLocation_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[ShopServeLocation] CHECK CONSTRAINT [FK_ShopServeLocation_Location]
GO
ALTER TABLE [dbo].[ShopServeLocation]  WITH CHECK ADD  CONSTRAINT [FK_ShopServeLocation_Shop] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shop] ([Id])
GO
ALTER TABLE [dbo].[ShopServeLocation] CHECK CONSTRAINT [FK_ShopServeLocation_Shop]
GO
ALTER TABLE [dbo].[ShopStatistics]  WITH CHECK ADD  CONSTRAINT [FK_ShopStatistics_Shop] FOREIGN KEY([Id])
REFERENCES [dbo].[Shop] ([Id])
GO
ALTER TABLE [dbo].[ShopStatistics] CHECK CONSTRAINT [FK_ShopStatistics_Shop]
GO
ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_UserLogin_User] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserLogin] CHECK CONSTRAINT [FK_UserLogin_User]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PrivacyAccountPermissionGroup"
            Begin Extent = 
               Top = 48
               Left = 44
               Bottom = 184
               Right = 287
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PrivacyPermissionGroup"
            Begin Extent = 
               Top = 50
               Left = 388
               Bottom = 184
               Right = 640
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2175
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PrivacyAccountPermission'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PrivacyAccountPermission'
GO
USE [master]
GO
ALTER DATABASE [ApaService] SET  READ_WRITE 
GO

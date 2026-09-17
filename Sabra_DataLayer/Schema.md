USE [master]
GO
/****** Object:  Database [SabraForSparePartsDatabase]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE DATABASE [SabraForSparePartsDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SabraForSpareParts', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SabraForSpareParts.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SabraForSpareParts_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SabraForSpareParts_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SabraForSparePartsDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SabraForSparePartsDatabase', N'ON'
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET QUERY_STORE = ON
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SabraForSparePartsDatabase]
GO
/****** Object:  User [JustUser]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE USER [JustUser] FOR LOGIN [AppUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [db_app_execute]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE ROLE [db_app_execute]
GO
ALTER ROLE [db_app_execute] ADD MEMBER [JustUser]
GO
/****** Object:  UserDefinedTableType [dbo].[InvoiceDetailTableType]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE TYPE [dbo].[InvoiceDetailTableType] AS TABLE(
	[Part_ID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit_Price] [decimal](18, 2) NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[Part_ID] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[PODetailTableType]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE TYPE [dbo].[PODetailTableType] AS TABLE(
	[Part_ID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit_Price] [decimal](18, 2) NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[Part_ID] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Treasury_GetCurrentBalance]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   FUNCTION [dbo].[fn_Treasury_GetCurrentBalance]()
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @Balance DECIMAL(18,2);

    SELECT TOP (1)
        @Balance = Balance_After
    FROM dbo.TREASURY_LOG
    ORDER BY
        Action_Date DESC,
        Transation_ID DESC;

    RETURN ISNULL(@Balance, 0);
END;
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Supplier_ID] [int] IDENTITY(1,1) NOT NULL,
	[Supplier_Name] [nvarchar](150) NOT NULL,
	[Contact_Person] [nvarchar](100) NULL,
	[Phone_Number] [nvarchar](20) NULL,
	[Supplier_Balance] [decimal](14, 2) NOT NULL,
	[Address] [nvarchar](300) NULL,
	[Created_At] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Supplier_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Part_ID] [int] IDENTITY(1,1) NOT NULL,
	[Part_Name] [nvarchar](200) NOT NULL,
	[Barcode] [nvarchar](50) NULL,
	[Technical_Number] [nvarchar](100) NULL,
	[Category_ID] [int] NULL,
	[Brand_ID] [int] NULL,
	[Unit_ID] [int] NULL,
	[Purchase_Price] [decimal](12, 2) NOT NULL,
	[Markup_Percent] [decimal](5, 2) NOT NULL,
	[Selling_Price] [decimal](12, 2) NOT NULL,
	[Current_Stock] [int] NOT NULL,
	[Min_Limit] [int] NOT NULL,
	[Cross_Ref_ID] [int] NULL,
	[Supplier_ID] [int] NULL,
	[Is_Deleted] [bit] NOT NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Updated_At] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Part_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Barcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[Unit_ID] [int] IDENTITY(1,1) NOT NULL,
	[Unit_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Unit_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Unit_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Category_ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Category_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Brand_ID] [int] IDENTITY(1,1) NOT NULL,
	[Brand_Name] [nvarchar](100) NOT NULL,
	[Country] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Brand_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Brand_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Inventory_Detail]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_Inventory_Detail] AS
SELECT
    i.Part_ID,
    i.Barcode,
    i.Technical_Number,
    i.Part_Name,
    c.Category_Name,
    b.Brand_Name,
    b.Country      AS Brand_Country,
    u.Unit_Name,
    i.Purchase_Price,
    i.Markup_Percent,
    i.Selling_Price,
    i.Current_Stock,
    i.Min_Limit,
    CASE WHEN i.Current_Stock <= i.Min_Limit THEN 1 ELSE 0 END AS Is_Low_Stock,
    s.Supplier_Name,
    i.Is_Deleted
FROM INVENTORY i
LEFT JOIN Categories c ON i.Category_ID = c.Category_ID
LEFT JOIN Brands     b ON i.Brand_ID    = b.Brand_ID
LEFT JOIN Units      u ON i.Unit_ID     = u.Unit_ID
LEFT JOIN Suppliers  s ON i.Supplier_ID = s.Supplier_ID
WHERE i.Is_Deleted = 0;
GO
/****** Object:  Table [dbo].[Payment_Status]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Status](
	[Status_ID] [int] IDENTITY(1,1) NOT NULL,
	[Status_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Status_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Status_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Customer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Name] [nvarchar](150) NOT NULL,
	[Phone_Number] [nvarchar](20) NULL,
	[Customer_Type_ID] [int] NULL,
	[Credit_Limit] [decimal](12, 2) NOT NULL,
	[Total_Balance] [decimal](14, 2) NOT NULL,
	[Last_Payment_Date] [date] NULL,
	[Created_At] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales_Invoices]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_Invoices](
	[Invoice_ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [int] NULL,
	[Employee_ID] [int] NOT NULL,
	[Date_Time] [datetime2](7) NOT NULL,
	[Total_Amount] [decimal](14, 2) NOT NULL,
	[Discount] [decimal](14, 2) NOT NULL,
	[Paid_Amount] [decimal](14, 2) NOT NULL,
	[Payment_Status_ID] [int] NOT NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Final_Amount]  AS ([Total_Amount]-[Discount]) PERSISTED,
	[Remaining_Balance]  AS (([Total_Amount]-[Discount])-[Paid_Amount]) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[Invoice_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Employee_ID] [int] IDENTITY(1,1) NOT NULL,
	[Position_ID] [int] NOT NULL,
	[Full_Name] [nvarchar](150) NOT NULL,
	[Basic_Salary] [decimal](12, 2) NOT NULL,
	[Hire_Date] [date] NOT NULL,
	[Phone_Number] [nvarchar](20) NULL,
	[National_ID] [nvarchar](20) NULL,
	[Is_Active] [bit] NOT NULL,
	[Created_At] [datetime] NOT NULL,
	[Updated_At] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Employee_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[National_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Sales_Summary]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Sales_Summary] AS
SELECT
    si.Invoice_ID,
    si.Date_Time,
    ISNULL(cu.Customer_Name, N'عميل نقدي') AS Customer_Name,
    cu.Phone_Number                          AS Customer_Phone,
    e.Full_Name                              AS Employee_Name,
    si.Total_Amount,
    si.Discount,
    si.Final_Amount,
    si.Paid_Amount,
    si.Remaining_Balance,
    ps.Status_Name                           AS Payment_Status
FROM SALES_INVOICES si
LEFT JOIN Customers      cu ON si.Customer_ID        = cu.Customer_ID
LEFT JOIN Employees      e  ON si.Employee_ID        = e.Employee_ID
LEFT JOIN Payment_Status ps ON si.Payment_Status_ID  = ps.Status_ID;
GO
/****** Object:  View [dbo].[V_Low_Stock_Alert]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Low_Stock_Alert] AS
SELECT
    Part_ID,
    Part_Name,
    Current_Stock,
    Min_Limit,
    (Min_Limit - Current_Stock) AS Shortage_Qty
FROM Inventory
WHERE Is_Deleted = 0
  AND Current_Stock <= Min_Limit;
GO
/****** Object:  Table [dbo].[Treasury_Log]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treasury_Log](
	[Transation_ID] [int] IDENTITY(1,1) NOT NULL,
	[Transaction_Type_ID] [int] NOT NULL,
	[Payment_Method_ID] [int] NOT NULL,
	[Amount] [decimal](14, 2) NOT NULL,
	[Invoice_ID] [int] NULL,
	[PO_ID] [int] NULL,
	[Expense_ID] [int] NULL,
	[Payroll_ID] [int] NULL,
	[Advance_ID] [int] NULL,
	[Employee_ID] [int] NULL,
	[Action_Date] [datetime2](7) NOT NULL,
	[Balance_After] [decimal](14, 2) NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[Reversal_Of_Transaction_ID] [int] NULL,
	[Created_By] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Transation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Treasury_Balance]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   VIEW [dbo].[V_Treasury_Balance]
AS
SELECT TOP (1)
    Balance_After AS Current_Balance,
    Action_Date   AS Last_Transaction
FROM dbo.TREASURY_LOG
ORDER BY
    Action_Date DESC,
    Transation_ID DESC;
GO
/****** Object:  Table [dbo].[Advances]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advances](
	[Advance_ID] [int] IDENTITY(1,1) NOT NULL,
	[Employee_ID] [int] NOT NULL,
	[Amount] [decimal](12, 2) NOT NULL,
	[Advance_Date] [date] NOT NULL,
	[Status_ID] [int] NOT NULL,
	[Approved_By] [int] NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Treasury_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Advance_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Positions]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Positions](
	[Position_ID] [int] IDENTITY(1,1) NOT NULL,
	[Position_Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Position_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Position_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Advance_Status]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advance_Status](
	[Status_ID] [int] IDENTITY(1,1) NOT NULL,
	[Status_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Status_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Status_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff_Wallets]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff_Wallets](
	[Wallet_ID] [int] IDENTITY(1,1) NOT NULL,
	[Employee_ID] [int] NOT NULL,
	[Wallet_Number] [nvarchar](50) NULL,
	[Current_Balance] [decimal](14, 2) NOT NULL,
	[Last_Update] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Wallet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Employee_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payroll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payroll](
	[Payroll_ID] [int] IDENTITY(1,1) NOT NULL,
	[Employee_ID] [int] NOT NULL,
	[Amount_Paid] [decimal](12, 2) NOT NULL,
	[Deductions] [decimal](12, 2) NOT NULL,
	[Bonuses] [decimal](12, 2) NOT NULL,
	[Payment_Date] [date] NOT NULL,
	[Month_Year] [char](7) NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[Created_At] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Payroll_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Payroll_EmpMonth] UNIQUE NONCLUSTERED 
(
	[Employee_ID] ASC,
	[Month_Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Employee_Financial_Summary]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Employee_Financial_Summary] AS
SELECT 
    e.Employee_ID,
    e.Full_Name,
    ep.Position_Name,
    e.Basic_Salary,

    sw.Current_Balance AS Wallet_Balance,

    -- الرواتب
    ISNULL(p.Total_Paid, 0)        AS Total_Salary_Received,
    ISNULL(p.Total_Bonuses, 0)     AS Total_Bonuses,
    ISNULL(p.Total_Deductions, 0)  AS Total_Deductions,

    -- السلف
    ISNULL(a.Total_Advances, 0)    AS Total_Advances_Taken,
    ISNULL(a.Pending_Advances, 0)  AS Pending_Advances,

    -- المبيعات
    ISNULL(s.Total_Sales, 0)       AS Total_Sales_Made,
    ISNULL(s.Invoice_Count, 0)     AS Invoices_Made

FROM EMPLOYEES e

LEFT JOIN EMPLOYEE_POSITIONS ep 
    ON e.Position_ID = ep.Position_ID

LEFT JOIN STAFF_WALLETS sw 
    ON e.Employee_ID = sw.Employee_ID

-- الرواتب
LEFT JOIN (
    SELECT 
        Employee_ID,
        SUM(Amount_Paid) AS Total_Paid,
        SUM(Bonuses)     AS Total_Bonuses,
        SUM(Deductions)  AS Total_Deductions
    FROM PAYROLL
    GROUP BY Employee_ID
) p ON e.Employee_ID = p.Employee_ID

-- السلف (بعد الإصلاح)
LEFT JOIN (
    SELECT 
        a.Employee_ID,
        SUM(a.Amount) AS Total_Advances,
        SUM(CASE 
            WHEN s.Status_Name = N'قيد الانتظار' 
            THEN a.Amount ELSE 0 
        END) AS Pending_Advances
    FROM ADVANCES a
    LEFT JOIN ADVANCE_STATUS s 
        ON a.Status_ID = s.Status_ID
    GROUP BY a.Employee_ID
) a ON e.Employee_ID = a.Employee_ID

-- المبيعات
LEFT JOIN (
    SELECT 
        Employee_ID,
        SUM(Final_Amount) AS Total_Sales,
        COUNT(Invoice_ID) AS Invoice_Count
    FROM SALES_INVOICES
    GROUP BY Employee_ID
) s ON e.Employee_ID = s.Employee_ID

WHERE e.Is_Active = 1;
GO
/****** Object:  Table [dbo].[Invoice_Details]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice_Details](
	[Detail_ID] [int] IDENTITY(1,1) NOT NULL,
	[Invoice_ID] [int] NOT NULL,
	[Part_ID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit_Price] [decimal](12, 2) NOT NULL,
	[Line_Total]  AS ([Quantity]*[Unit_Price]) PERSISTED,
	[Unit_Cost] [decimal](12, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Detail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Invoice_Profit]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ============================================================================
   3) FINANCIAL REPORTS - USE STORED HISTORICAL COST
============================================================================ */

CREATE   VIEW [dbo].[V_Invoice_Profit]
AS
WITH Costs AS
(
    SELECT
        id.Invoice_ID,
        SUM(id.Quantity * id.Unit_Cost) AS Total_Cost
    FROM dbo.INVOICE_DETAILS id
    GROUP BY id.Invoice_ID
)
SELECT
    si.Invoice_ID,
    si.Date_Time,
    ISNULL(cu.Customer_Name, N'عميل نقدي') AS Customer_Name,
    e.Full_Name AS Employee_Name,
    si.Total_Amount,
    si.Discount,
    si.Final_Amount,
    si.Paid_Amount,
    si.Remaining_Balance,
    ISNULL(c.Total_Cost, 0) AS Total_Cost,
    si.Final_Amount - ISNULL(c.Total_Cost, 0) AS Net_Profit,
    CASE
        WHEN si.Final_Amount = 0 THEN 0
        ELSE ROUND(
            (si.Final_Amount - ISNULL(c.Total_Cost, 0))
            / si.Final_Amount * 100, 2
        )
    END AS Profit_Percent,
    ps.Status_Name AS Payment_Status
FROM dbo.SALES_INVOICES si
LEFT JOIN Costs c
    ON c.Invoice_ID = si.Invoice_ID
LEFT JOIN dbo.CUSTOMERS cu
    ON cu.Customer_ID = si.Customer_ID
LEFT JOIN dbo.EMPLOYEES e
    ON e.Employee_ID = si.Employee_ID
LEFT JOIN dbo.PAYMENT_STATUS ps
    ON ps.Status_ID = si.Payment_Status_ID;
GO
/****** Object:  View [dbo].[V_Daily_Profit]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   VIEW [dbo].[V_Daily_Profit]
AS
WITH InvoiceCost AS
(
    SELECT
        si.Invoice_ID,
        CAST(si.Date_Time AS DATE) AS Sale_Date,
        si.Final_Amount,
        si.Paid_Amount,
        si.Remaining_Balance,
        SUM(id.Quantity * id.Unit_Cost) AS Total_Cost
    FROM dbo.SALES_INVOICES si
    LEFT JOIN dbo.INVOICE_DETAILS id
        ON id.Invoice_ID = si.Invoice_ID
    GROUP BY
        si.Invoice_ID,
        CAST(si.Date_Time AS DATE),
        si.Final_Amount,
        si.Paid_Amount,
        si.Remaining_Balance
)
SELECT
    Sale_Date,
    COUNT(*) AS Invoice_Count,
    SUM(Final_Amount) AS Total_Revenue,
    SUM(Total_Cost) AS Total_Cost,
    SUM(Final_Amount) - SUM(Total_Cost) AS Net_Profit,
    SUM(Paid_Amount) AS Total_Collected,
    SUM(Remaining_Balance) AS Total_Remaining
FROM InvoiceCost
GROUP BY Sale_Date;
GO
/****** Object:  UserDefinedFunction [dbo].[fn_FormatMonthYear]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_FormatMonthYear] (@Date DATE)
RETURNS CHAR(7)
WITH SCHEMABINDING
AS
BEGIN
    RETURN CONVERT(CHAR(4), YEAR(@Date)) + '-' + RIGHT('0' + CONVERT(VARCHAR(2), MONTH(@Date)), 2);
END
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[Expense_ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_ID] [int] NOT NULL,
	[Amount] [decimal](12, 2) NOT NULL,
	[Expense_Date] [date] NOT NULL,
	[Paid_By] [int] NULL,
	[Notes] [nvarchar](500) NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Is_Voided] [bit] NOT NULL,
	[Voided_At] [datetime2](7) NULL,
	[Voided_By] [int] NULL,
	[Void_Reason] [nvarchar](500) NULL,
	[Updated_At] [datetime2](7) NOT NULL,
	[Treasury_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Expense_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Monthly_Profit]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   VIEW [dbo].[V_Monthly_Profit]
AS
WITH Sales AS
(
    SELECT
        dbo.fn_FormatMonthYear(CAST(si.Date_Time AS DATE)) AS Month_Year,
        SUM(si.Final_Amount) AS Revenue,
        SUM(si.Paid_Amount) AS Collected,
        SUM(si.Remaining_Balance) AS Remaining,
        COUNT(*) AS Invoice_Count
    FROM dbo.SALES_INVOICES si
    GROUP BY dbo.fn_FormatMonthYear(CAST(si.Date_Time AS DATE))
),
COGS AS
(
    SELECT
        dbo.fn_FormatMonthYear(CAST(si.Date_Time AS DATE)) AS Month_Year,
        SUM(id.Quantity * id.Unit_Cost) AS Total_Cost
    FROM dbo.SALES_INVOICES si
    INNER JOIN dbo.INVOICE_DETAILS id
        ON id.Invoice_ID = si.Invoice_ID
    GROUP BY dbo.fn_FormatMonthYear(CAST(si.Date_Time AS DATE))
),
Expenses AS
(
    SELECT
        dbo.fn_FormatMonthYear(Expense_Date) AS Month_Year,
        SUM(Amount) AS Total_Expenses
    FROM dbo.EXPENSES
    WHERE Is_Voided = 0
    GROUP BY dbo.fn_FormatMonthYear(Expense_Date)
),
Payroll AS
(
    SELECT
        Month_Year,
        SUM(Amount_Paid) AS Total_Payroll
    FROM dbo.PAYROLL
    GROUP BY Month_Year
),
Periods AS
(
    SELECT Month_Year FROM Sales
    UNION
    SELECT Month_Year FROM COGS
    UNION
    SELECT Month_Year FROM Expenses
    UNION
    SELECT Month_Year FROM Payroll
)
SELECT
    p.Month_Year,
    ISNULL(s.Invoice_Count, 0) AS Invoice_Count,
    ISNULL(s.Revenue, 0) AS Total_Revenue,
    ISNULL(c.Total_Cost, 0) AS Total_Cost,
    ISNULL(s.Revenue, 0) - ISNULL(c.Total_Cost, 0) AS Gross_Profit,
    ISNULL(s.Collected, 0) AS Total_Collected,
    ISNULL(s.Remaining, 0) AS Total_Remaining,
    ISNULL(x.Total_Expenses, 0) AS Total_Expenses,
    ISNULL(py.Total_Payroll, 0) AS Total_Payroll,
    ISNULL(s.Revenue, 0)
      - ISNULL(c.Total_Cost, 0)
      - ISNULL(x.Total_Expenses, 0)
      - ISNULL(py.Total_Payroll, 0) AS Net_Profit_After_Expenses
FROM Periods p
LEFT JOIN Sales s
    ON s.Month_Year = p.Month_Year
LEFT JOIN COGS c
    ON c.Month_Year = p.Month_Year
LEFT JOIN Expenses x
    ON x.Month_Year = p.Month_Year
LEFT JOIN Payroll py
    ON py.Month_Year = p.Month_Year;
GO
/****** Object:  Table [dbo].[Transaction_Types]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction_Types](
	[Transaction_Type_ID] [int] IDENTITY(1,1) NOT NULL,
	[Type_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Transaction_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Type_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Daily_Cash_Flow]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ============================================================================
   6) TREASURY DAILY CASH FLOW
   Because Amount is signed, outgoing values must be converted to ABS() for
   display/reporting. Closing balance must be the LAST transaction of the day,
   not MAX(Balance_After).
============================================================================ */

CREATE   VIEW [dbo].[V_Daily_Cash_Flow]
AS
WITH RankedTransactions AS
(
    SELECT
        tl.*,
        tt.Type_Name,
        ROW_NUMBER() OVER
        (
            PARTITION BY CAST(tl.Action_Date AS DATE)
            ORDER BY
                tl.Action_Date DESC,
                tl.Transation_ID DESC
        ) AS rn
    FROM dbo.TREASURY_LOG tl
    LEFT JOIN dbo.TRANSACTION_TYPES tt
        ON tl.Transaction_Type_ID = tt.Transaction_Type_ID
)
SELECT
    CAST(Action_Date AS DATE) AS Flow_Date,

    SUM
    (
        CASE
            WHEN Type_Name = N'وارد'
            THEN ABS(Amount)
            ELSE 0
        END
    ) AS Total_In,

    SUM
    (
        CASE
            WHEN Type_Name = N'صادر'
            THEN ABS(Amount)
            ELSE 0
        END
    ) AS Total_Out,

    SUM
    (
        CASE
            WHEN Type_Name = N'وارد'
            THEN ABS(Amount)
            WHEN Type_Name = N'صادر'
            THEN -ABS(Amount)
            ELSE 0
        END
    ) AS Net_Flow,

    SUM
    (
        CASE
            WHEN Invoice_ID IS NOT NULL
             AND Type_Name = N'وارد'
            THEN ABS(Amount)
            ELSE 0
        END
    ) AS Sales_In,

    SUM
    (
        CASE
            WHEN Expense_ID IS NOT NULL
            THEN ABS(Amount)
            ELSE 0
        END
    ) AS Expenses_Out,

    SUM
    (
        CASE
            WHEN Payroll_ID IS NOT NULL
            THEN ABS(Amount)
            ELSE 0
        END
    ) AS Payroll_Out,

    SUM
    (
        CASE
            WHEN PO_ID IS NOT NULL
            THEN ABS(Amount)
            ELSE 0
        END
    ) AS Purchases_Out,

    SUM
    (
        CASE
            WHEN Advance_ID IS NOT NULL
            THEN ABS(Amount)
            ELSE 0
        END
    ) AS Advances_Out,

    MAX
    (
        CASE
            WHEN rn = 1 THEN Balance_After
            ELSE NULL
        END
    ) AS Closing_Balance

FROM RankedTransactions
GROUP BY CAST(Action_Date AS DATE);
GO
/****** Object:  View [dbo].[V_Profit_Loss_Summary]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[V_Profit_Loss_Summary] AS
SELECT Month_Year AS Period,Total_Revenue AS Revenue,Total_Cost AS COGS,
       Gross_Profit,Total_Expenses AS Operating_Expenses,Total_Payroll AS Payroll_Cost,Net_Profit_After_Expenses AS Net_Profit
FROM dbo.V_Monthly_Profit;

GO
/****** Object:  View [dbo].[V_Dead_Stock]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Dead_Stock] AS
SELECT
    inv.Part_ID,
    inv.Barcode,
    inv.Part_Name,
    c.Category_Name,
    b.Brand_Name,
    inv.Current_Stock,
    inv.Selling_Price,
    inv.Current_Stock * inv.Purchase_Price AS Stock_Value,
    inv.Purchase_Price,

    -- آخر مرة اتباعت فيها القطعة دي
    MAX(si.Date_Time) AS Last_Sale_Date,

    -- كام يوم من آخر بيع
    DATEDIFF(DAY, MAX(si.Date_Time), GETDATE()) AS Days_Since_Last_Sale,

    -- لو مابيعتش خالص
    CASE
        WHEN MAX(si.Date_Time) IS NULL THEN N'لم تُباع مطلقاً'
        WHEN DATEDIFF(DAY, MAX(si.Date_Time), GETDATE()) > 180 THEN N'ميت جداً +180 يوم'
        WHEN DATEDIFF(DAY, MAX(si.Date_Time), GETDATE()) > 90  THEN N'ميت +90 يوم'
        ELSE N'بطيء'
    END AS Stock_Status,

    s.Supplier_Name
FROM INVENTORY inv
LEFT JOIN CATEGORIES c ON inv.Category_ID = c.Category_ID
LEFT JOIN BRANDS     b ON inv.Brand_ID    = b.Brand_ID
LEFT JOIN SUPPLIERS  s ON inv.Supplier_ID = s.Supplier_ID
LEFT JOIN INVOICE_DETAILS id ON inv.Part_ID = id.Part_ID
LEFT JOIN SALES_INVOICES  si ON id.Invoice_ID = si.Invoice_ID
WHERE inv.Is_Deleted = 0
  AND inv.Current_Stock > 0
GROUP BY
    inv.Part_ID, inv.Barcode, inv.Part_Name, c.Category_Name,
    b.Brand_Name, inv.Current_Stock, inv.Selling_Price,
    inv.Purchase_Price, s.Supplier_Name
HAVING
    MAX(si.Date_Time) IS NULL
    OR DATEDIFF(DAY, MAX(si.Date_Time), GETDATE()) > 90;
GO
/****** Object:  View [dbo].[V_Top_Selling_Parts]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[V_Top_Selling_Parts]
AS
SELECT
    inv.Part_ID,
    inv.Barcode,
    inv.Part_Name,
    c.Category_Name,
    b.Brand_Name,
    SUM(id.Quantity) AS Total_Qty_Sold,
    SUM(id.Line_Total) AS Total_Revenue,
    SUM(id.Quantity * id.Unit_Cost) AS Total_Cost,
    SUM(id.Line_Total) - SUM(id.Quantity * id.Unit_Cost) AS Total_Profit,
    COUNT(DISTINCT id.Invoice_ID) AS Invoice_Count,
    inv.Current_Stock,
    inv.Selling_Price,
    MAX(si.Date_Time) AS Last_Sale_Date
FROM dbo.INVENTORY inv
LEFT JOIN dbo.CATEGORIES c
    ON inv.Category_ID = c.Category_ID
LEFT JOIN dbo.BRANDS b
    ON inv.Brand_ID = b.Brand_ID
LEFT JOIN dbo.INVOICE_DETAILS id
    ON inv.Part_ID = id.Part_ID
LEFT JOIN dbo.SALES_INVOICES si
    ON id.Invoice_ID = si.Invoice_ID
WHERE inv.Is_Deleted = 0
GROUP BY
    inv.Part_ID,
    inv.Barcode,
    inv.Part_Name,
    c.Category_Name,
    b.Brand_Name,
    inv.Current_Stock,
    inv.Selling_Price;
GO
/****** Object:  View [dbo].[V_Fast_Moving_Stock]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Fast_Moving_Stock] AS
SELECT
    inv.Part_ID,
    inv.Part_Name,
    c.Category_Name,
    b.Brand_Name,
    inv.Current_Stock,
    inv.Min_Limit,
    SUM(id.Quantity)                                AS Total_Qty_Sold,
    COUNT(DISTINCT CAST(si.Date_Time AS DATE))      AS Active_Sale_Days,

    -- متوسط الكمية المباعة يومياً
    CASE
        WHEN COUNT(DISTINCT CAST(si.Date_Time AS DATE)) = 0 THEN 0
        ELSE CAST(SUM(id.Quantity) AS DECIMAL(10,2))
             / COUNT(DISTINCT CAST(si.Date_Time AS DATE))
    END AS Avg_Daily_Sales,

    -- كام يوم هيكفي المخزون الحالي
    CASE
        WHEN COUNT(DISTINCT CAST(si.Date_Time AS DATE)) = 0 THEN NULL
        ELSE CAST(inv.Current_Stock AS DECIMAL(10,2))
             / NULLIF(
                 CAST(SUM(id.Quantity) AS DECIMAL(10,2))
                 / COUNT(DISTINCT CAST(si.Date_Time AS DATE))
               , 0)
    END AS Days_Of_Stock_Left,

    -- تصنيف السرعة
    CASE
        WHEN CAST(SUM(id.Quantity) AS DECIMAL(10,2))
             / NULLIF(COUNT(DISTINCT CAST(si.Date_Time AS DATE)), 0) >= 5
             THEN N'سريع جداً'
        WHEN CAST(SUM(id.Quantity) AS DECIMAL(10,2))
             / NULLIF(COUNT(DISTINCT CAST(si.Date_Time AS DATE)), 0) >= 2
             THEN N'سريع'
        WHEN CAST(SUM(id.Quantity) AS DECIMAL(10,2))
             / NULLIF(COUNT(DISTINCT CAST(si.Date_Time AS DATE)), 0) >= 0.5
             THEN N'متوسط'
        ELSE N'بطيء'
    END AS Movement_Speed

FROM INVENTORY inv
LEFT JOIN CATEGORIES      c  ON inv.Category_ID = c.Category_ID
LEFT JOIN BRANDS          b  ON inv.Brand_ID    = b.Brand_ID
LEFT JOIN INVOICE_DETAILS id ON inv.Part_ID     = id.Part_ID
LEFT JOIN SALES_INVOICES  si ON id.Invoice_ID   = si.Invoice_ID
WHERE inv.Is_Deleted = 0
GROUP BY
    inv.Part_ID, inv.Part_Name, c.Category_Name,
    b.Brand_Name, inv.Current_Stock, inv.Min_Limit;
GO
/****** Object:  View [dbo].[V_Inventory_Valuation]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Inventory_Valuation] AS
SELECT
    inv.Part_ID,
    inv.Barcode,
    inv.Part_Name,
    c.Category_Name,
    b.Brand_Name,
    s.Supplier_Name,
    inv.Current_Stock,
    inv.Purchase_Price,
    inv.Selling_Price,
    inv.Markup_Percent,

    -- القيمة بسعر الشراء
    inv.Current_Stock * inv.Purchase_Price  AS Value_At_Cost,

    -- القيمة بسعر البيع
    inv.Current_Stock * inv.Selling_Price   AS Value_At_Selling,

    -- الربح المتوقع لو بعنا كل المخزون
    inv.Current_Stock * (inv.Selling_Price - inv.Purchase_Price) AS Potential_Profit,

    inv.Min_Limit,
    CASE WHEN inv.Current_Stock <= inv.Min_Limit THEN N'نعم' ELSE N'لا' END AS Is_Low_Stock

FROM INVENTORY inv
LEFT JOIN CATEGORIES c ON inv.Category_ID = c.Category_ID
LEFT JOIN BRANDS     b ON inv.Brand_ID    = b.Brand_ID
LEFT JOIN SUPPLIERS  s ON inv.Supplier_ID = s.Supplier_ID
WHERE inv.Is_Deleted = 0;
GO
/****** Object:  View [dbo].[V_Reorder_Suggestion]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Reorder_Suggestion] AS
SELECT
    inv.Part_ID,
    inv.Barcode,
    inv.Part_Name,
    c.Category_Name,
    s.Supplier_Name,
    s.Phone_Number              AS Supplier_Phone,
    inv.Current_Stock,
    inv.Min_Limit,
    inv.Min_Limit - inv.Current_Stock AS Shortage,

    -- متوسط الاستهلاك الشهري (آخر 3 شهور)
    ISNULL((
        SELECT SUM(id2.Quantity) / 3.0
        FROM INVOICE_DETAILS id2
        JOIN SALES_INVOICES  si2 ON id2.Invoice_ID = si2.Invoice_ID
        WHERE id2.Part_ID = inv.Part_ID
          AND si2.Date_Time >= DATEADD(MONTH, -3, GETDATE())
    ), 0) AS Avg_Monthly_Usage,

    -- المقترح للشراء = استهلاك شهرين + النقص الحالي
    CEILING(
        ISNULL((
            SELECT SUM(id2.Quantity) / 3.0 * 2
            FROM INVOICE_DETAILS id2
            JOIN SALES_INVOICES  si2 ON id2.Invoice_ID = si2.Invoice_ID
            WHERE id2.Part_ID = inv.Part_ID
              AND si2.Date_Time >= DATEADD(MONTH, -3, GETDATE())
        ), inv.Min_Limit * 2)
        + (inv.Min_Limit - inv.Current_Stock)
    ) AS Suggested_Order_Qty,

    -- التكلفة التقديرية للطلبية
    inv.Purchase_Price * CEILING(
        ISNULL((
            SELECT SUM(id2.Quantity) / 3.0 * 2
            FROM INVOICE_DETAILS id2
            JOIN SALES_INVOICES  si2 ON id2.Invoice_ID = si2.Invoice_ID
            WHERE id2.Part_ID = inv.Part_ID
              AND si2.Date_Time >= DATEADD(MONTH, -3, GETDATE())
        ), inv.Min_Limit * 2)
        + (inv.Min_Limit - inv.Current_Stock)
    ) AS Estimated_Order_Cost
FROM INVENTORY inv
LEFT JOIN CATEGORIES c ON inv.Category_ID = c.Category_ID
LEFT JOIN SUPPLIERS  s ON inv.Supplier_ID = s.Supplier_ID
WHERE inv.Is_Deleted = 0
  AND inv.Current_Stock <= inv.Min_Limit;
GO
/****** Object:  Table [dbo].[Customer_Types]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Types](
	[Customer_Type_ID] [int] IDENTITY(1,1) NOT NULL,
	[Type_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Customer_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Type_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Customer_Statement]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Customer_Statement] AS
SELECT
    cu.Customer_ID,
    cu.Customer_Name,
    cu.Phone_Number,
    ct.Type_Name        AS Customer_Type,
    si.Invoice_ID,
    si.Date_Time        AS Invoice_Date,
    si.Final_Amount,
    si.Paid_Amount,
    si.Remaining_Balance,
    ps.Status_Name      AS Payment_Status,
    cu.Credit_Limit,
    cu.Total_Balance    AS Current_Total_Debt,

    -- كام فاتورة عنده
    COUNT(si.Invoice_ID) OVER (PARTITION BY cu.Customer_ID) AS Total_Invoices,

    -- إجمالي مشترياته
    SUM(si.Final_Amount) OVER (PARTITION BY cu.Customer_ID) AS Lifetime_Purchases,

    -- إجمالي المدفوع
    SUM(si.Paid_Amount) OVER (PARTITION BY cu.Customer_ID)  AS Lifetime_Paid,

    cu.Last_Payment_Date
FROM CUSTOMERS cu
LEFT JOIN CUSTOMER_TYPES ct ON cu.Customer_Type_ID  = ct.Customer_Type_ID
LEFT JOIN SALES_INVOICES si ON cu.Customer_ID       = si.Customer_ID
LEFT JOIN PAYMENT_STATUS ps ON si.Payment_Status_ID = ps.Status_ID;
GO
/****** Object:  View [dbo].[V_Top_Customers]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Top_Customers] AS
SELECT
    cu.Customer_ID,
    cu.Customer_Name,
    cu.Phone_Number,
    ct.Type_Name                AS Customer_Type,
    COUNT(si.Invoice_ID)        AS Total_Invoices,
    SUM(si.Final_Amount)        AS Total_Purchases,
    SUM(si.Paid_Amount)         AS Total_Paid,
    SUM(si.Remaining_Balance)   AS Total_Debt,
    AVG(si.Final_Amount)        AS Avg_Invoice_Value,
    MIN(si.Date_Time)           AS First_Purchase,
    MAX(si.Date_Time)           AS Last_Purchase,
    cu.Credit_Limit
FROM CUSTOMERS cu
LEFT JOIN CUSTOMER_TYPES ct ON cu.Customer_Type_ID = ct.Customer_Type_ID
LEFT JOIN SALES_INVOICES si ON cu.Customer_ID      = si.Customer_ID
GROUP BY
    cu.Customer_ID, cu.Customer_Name, cu.Phone_Number,
    ct.Type_Name, cu.Credit_Limit;
GO
/****** Object:  View [dbo].[V_Customers_With_Debt]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Customers_With_Debt] AS
SELECT
    cu.Customer_ID,
    cu.Customer_Name,
    cu.Phone_Number,
    ct.Type_Name            AS Customer_Type,
    cu.Total_Balance        AS Total_Debt,
    cu.Credit_Limit,
    cu.Credit_Limit - cu.Total_Balance AS Available_Credit,
    cu.Last_Payment_Date,
    DATEDIFF(DAY, cu.Last_Payment_Date, GETDATE()) AS Days_Since_Last_Payment,

    -- تصنيف المديونية
    CASE
        WHEN cu.Total_Balance = 0 THEN N'لا مديونية'
        WHEN cu.Total_Balance >= cu.Credit_Limit THEN N'وصل الحد الائتماني'
        WHEN DATEDIFF(DAY, cu.Last_Payment_Date, GETDATE()) > 60 THEN N'متأخر جداً'
        WHEN DATEDIFF(DAY, cu.Last_Payment_Date, GETDATE()) > 30 THEN N'متأخر'
        ELSE N'عادي'
    END AS Debt_Status,

    COUNT(si.Invoice_ID) AS Open_Invoices
FROM CUSTOMERS cu
LEFT JOIN CUSTOMER_TYPES ct ON cu.Customer_Type_ID  = ct.Customer_Type_ID
LEFT JOIN SALES_INVOICES  si ON cu.Customer_ID      = si.Customer_ID
       AND si.Payment_Status_ID IN (
           SELECT Status_ID FROM PAYMENT_STATUS
           WHERE Status_Name IN (N'مدفوع جزئياً', N'آجل')
       )
WHERE cu.Total_Balance > 0
GROUP BY
    cu.Customer_ID, cu.Customer_Name, cu.Phone_Number,
    ct.Type_Name, cu.Total_Balance, cu.Credit_Limit,
    cu.Last_Payment_Date;
GO
/****** Object:  Table [dbo].[Purchase_Orders]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase_Orders](
	[PO_ID] [int] IDENTITY(1,1) NOT NULL,
	[Supplier_ID] [int] NOT NULL,
	[Employee_ID] [int] NOT NULL,
	[Order_Date] [date] NOT NULL,
	[Total_Amount] [decimal](14, 2) NOT NULL,
	[Paid_Amount] [decimal](14, 2) NOT NULL,
	[Remaining]  AS ([Total_Amount]-[Paid_Amount]) PERSISTED,
	[Status_ID] [int] NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Received_At] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[PO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase_Order_Status]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase_Order_Status](
	[Status_ID] [int] IDENTITY(1,1) NOT NULL,
	[Status_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Status_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Status_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Supplier_Statement]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Supplier_Statement] AS
SELECT
    sup.Supplier_ID,
    sup.Supplier_Name,
    sup.Phone_Number,
    sup.Contact_Person,
    po.PO_ID,
    po.Order_Date,
    po.Total_Amount,
    po.Paid_Amount,
    po.Remaining,
    pos2.Status_Name            AS PO_Status,
    sup.Supplier_Balance        AS Current_Total_Debt,

    -- إجمالي الطلبيات
    COUNT(po.PO_ID) OVER (PARTITION BY sup.Supplier_ID) AS Total_Orders,

    -- إجمالي المشتريات منه
    SUM(po.Total_Amount) OVER (PARTITION BY sup.Supplier_ID) AS Lifetime_Purchases,

    -- إجمالي المدفوع ليه
    SUM(po.Paid_Amount) OVER (PARTITION BY sup.Supplier_ID)  AS Lifetime_Paid
FROM SUPPLIERS sup
LEFT JOIN PURCHASE_ORDERS          po   ON sup.Supplier_ID = po.Supplier_ID
LEFT JOIN PURCHASE_ORDER_STATUS    pos2 ON po.Status_ID    = pos2.Status_ID;
GO
/****** Object:  Table [dbo].[Purchase_Order_Details]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase_Order_Details](
	[Detail_ID] [int] IDENTITY(1,1) NOT NULL,
	[PO_ID] [int] NOT NULL,
	[Part_ID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit_Price] [decimal](12, 2) NOT NULL,
	[Line_Total]  AS ([Quantity]*[Unit_Price]) PERSISTED,
	[Received_Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Detail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Supplier_Performance]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Supplier_Performance] AS
SELECT
    sup.Supplier_ID,
    sup.Supplier_Name,
    sup.Phone_Number,

    -- عدد الطلبيات
    COUNT(po.PO_ID)                     AS Total_Orders,

    -- إجمالي قيمة المشتريات
    SUM(po.Total_Amount)                AS Total_Purchased,

    -- إجمالي عدد القطع
    SUM(pod.Quantity)                   AS Total_Parts_Ordered,

    -- عدد القطع المختلفة
    COUNT(DISTINCT pod.Part_ID)         AS Distinct_Parts,

    -- متوسط قيمة الطلبية
    AVG(po.Total_Amount)                AS Avg_Order_Value,

    -- أرخص سعر متوسط للقطعة
    AVG(pod.Unit_Price)                 AS Avg_Unit_Price,

    -- نسبة الطلبيات المكتملة
    ROUND(
        100.0 * SUM(CASE WHEN pos2.Status_Name = N'مستلم بالكامل' THEN 1 ELSE 0 END)
        / NULLIF(COUNT(po.PO_ID), 0)
    , 1) AS Completion_Rate_Percent,

    -- آخر طلبية
    MAX(po.Order_Date)                  AS Last_Order_Date,

    -- مديونيتنا عنده
    sup.Supplier_Balance                AS Current_Balance
FROM SUPPLIERS sup
LEFT JOIN PURCHASE_ORDERS       po   ON sup.Supplier_ID = po.Supplier_ID
LEFT JOIN PURCHASE_ORDER_DETAILS pod ON po.PO_ID        = pod.PO_ID
LEFT JOIN PURCHASE_ORDER_STATUS pos2 ON po.Status_ID    = pos2.Status_ID
GROUP BY
    sup.Supplier_ID, sup.Supplier_Name,
    sup.Phone_Number, sup.Supplier_Balance;
GO
/****** Object:  View [dbo].[V_Daily_Sales_Dashboard]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[V_Daily_Sales_Dashboard] AS
WITH InvoiceTotals AS
(
    SELECT si.Invoice_ID,CAST(si.Date_Time AS DATE) Sale_Date,si.Customer_ID,si.Total_Amount,si.Discount,si.Final_Amount,si.Paid_Amount,si.Remaining_Balance
    FROM dbo.SALES_INVOICES si
)
, DetailTotals AS
(
    SELECT Invoice_ID,SUM(Quantity) Total_Qty,COUNT(DISTINCT Part_ID) Distinct_Parts
    FROM dbo.INVOICE_DETAILS GROUP BY Invoice_ID
)
SELECT i.Sale_Date,COUNT(*) Invoice_Count,COUNT(DISTINCT i.Customer_ID) Customer_Count,
       SUM(ISNULL(d.Total_Qty,0)) Total_Parts_Sold,SUM(ISNULL(d.Distinct_Parts,0)) Distinct_Parts_Sold,
       SUM(i.Total_Amount) Gross_Sales,SUM(i.Discount) Total_Discounts,SUM(i.Final_Amount) Net_Sales,
       SUM(i.Paid_Amount) Cash_Collected,SUM(i.Remaining_Balance) On_Credit,AVG(i.Final_Amount) Avg_Invoice_Value,
       MAX(i.Final_Amount) Highest_Invoice,MIN(i.Final_Amount) Lowest_Invoice
FROM InvoiceTotals i LEFT JOIN DetailTotals d ON d.Invoice_ID=i.Invoice_ID
GROUP BY i.Sale_Date;

GO
/****** Object:  View [dbo].[V_Employee_Performance]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Employee_Performance] AS
SELECT
    e.Employee_ID,
    e.Full_Name,
    ep.Position_Name,
    e.Basic_Salary,

    -- المبيعات
    COUNT(DISTINCT si.Invoice_ID)       AS Total_Invoices,
    SUM(si.Final_Amount)                AS Total_Sales,
    AVG(si.Final_Amount)                AS Avg_Invoice_Value,
    SUM(si.Discount)                    AS Total_Discounts_Given,
    SUM(si.Remaining_Balance)           AS Total_Credit_Created,

    -- عدد العملاء المختلفين خدمهم
    COUNT(DISTINCT si.Customer_ID)      AS Unique_Customers_Served,

    -- آخر فاتورة
    MAX(si.Date_Time)                   AS Last_Invoice_Date,

    -- هذا الشهر
    SUM(CASE WHEN FORMAT(si.Date_Time,'yyyy-MM') = FORMAT(GETDATE(),'yyyy-MM')
        THEN si.Final_Amount ELSE 0 END) AS This_Month_Sales,

    -- المرتب + الحوافز
    ISNULL((
        SELECT SUM(Amount_Paid) FROM PAYROLL pr
        WHERE pr.Employee_ID = e.Employee_ID
    ), 0) AS Total_Paid_Salary,

    ISNULL((
        SELECT SUM(Bonuses) FROM PAYROLL pr
        WHERE pr.Employee_ID = e.Employee_ID
    ), 0) AS Total_Bonuses
FROM EMPLOYEES e
LEFT JOIN EMPLOYEE_POSITIONS ep ON e.Position_ID   = ep.Position_ID
LEFT JOIN SALES_INVOICES     si ON e.Employee_ID   = si.Employee_ID
WHERE e.Is_Active = 1
GROUP BY
    e.Employee_ID, e.Full_Name, ep.Position_Name, e.Basic_Salary;
GO
/****** Object:  Table [dbo].[Expense_Categories]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expense_Categories](
	[Category_ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Category_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Methods]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Methods](
	[Payment_Method_ID] [int] IDENTITY(1,1) NOT NULL,
	[Method_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Payment_Method_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Method_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Treasury_Flow]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Treasury_Flow] AS
SELECT
    tl.Transation_ID,
    tl.Action_Date,
    tt.Type_Name                AS Transaction_Direction,
    pm.Method_Name              AS Payment_Method,
    tl.Amount,
    tl.Balance_After,

    -- مصدر أو سبب العملية
    CASE
        WHEN tl.Invoice_ID  IS NOT NULL THEN N'تحصيل فاتورة بيع'
        WHEN tl.PO_ID       IS NOT NULL THEN N'دفع لمورد'
        WHEN tl.Expense_ID  IS NOT NULL THEN N'مصروف'
        WHEN tl.Payroll_ID  IS NOT NULL THEN N'راتب موظف'
        WHEN tl.Advance_ID  IS NOT NULL THEN N'سلفة موظف'
        ELSE N'عملية يدوية'
    END AS Transaction_Source,

    -- التفاصيل
    tl.Invoice_ID,
    tl.PO_ID,
    tl.Expense_ID,
    tl.Payroll_ID,
    tl.Advance_ID,

    -- اسم العميل لو فاتورة بيع
    ISNULL(cu.Customer_Name, N'') AS Related_Customer,

    -- اسم المورد لو أمر شراء
    ISNULL(sup.Supplier_Name, N'') AS Related_Supplier,

    -- اسم الموظف لو راتب أو سلفة
    ISNULL(e.Full_Name, N'') AS Related_Employee,

    -- تصنيف المصروف لو مصروف
    ISNULL(ec.Category_Name, N'') AS Expense_Category,

    tl.Notes
FROM TREASURY_LOG tl
LEFT JOIN TRANSACTION_TYPES  tt  ON tl.Transaction_Type_ID = tt.Transaction_Type_ID
LEFT JOIN PAYMENT_METHODS    pm  ON tl.Payment_Method_ID   = pm.Payment_Method_ID
LEFT JOIN SALES_INVOICES     si  ON tl.Invoice_ID          = si.Invoice_ID
LEFT JOIN CUSTOMERS          cu  ON si.Customer_ID         = cu.Customer_ID
LEFT JOIN PURCHASE_ORDERS    po  ON tl.PO_ID               = po.PO_ID
LEFT JOIN SUPPLIERS          sup ON po.Supplier_ID         = sup.Supplier_ID
LEFT JOIN PAYROLL            pr  ON tl.Payroll_ID          = pr.Payroll_ID
LEFT JOIN ADVANCES           adv ON tl.Advance_ID          = adv.Advance_ID
LEFT JOIN EMPLOYEES          e   ON ISNULL(pr.Employee_ID, adv.Employee_ID) = e.Employee_ID
LEFT JOIN EXPENSES           ex  ON tl.Expense_ID          = ex.Expense_ID
LEFT JOIN EXPENSE_CATEGORIES ec  ON ex.Category_ID         = ec.Category_ID;
GO
/****** Object:  View [dbo].[V_Net_Cash_Position]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Net_Cash_Position] AS
SELECT
    FORMAT(tl.Action_Date, 'yyyy-MM')   AS Period,

    -- الداخل
    SUM(CASE WHEN tt.Type_Name = N'وارد' THEN tl.Amount ELSE 0 END) AS Total_In,

    -- الخارج موزعاً
    SUM(CASE WHEN tl.Invoice_ID  IS NOT NULL AND tt.Type_Name = N'وارد'
        THEN tl.Amount ELSE 0 END) AS From_Sales,
    SUM(CASE WHEN tl.Expense_ID  IS NOT NULL
        THEN tl.Amount ELSE 0 END) AS To_Expenses,
    SUM(CASE WHEN tl.PO_ID       IS NOT NULL
        THEN tl.Amount ELSE 0 END) AS To_Suppliers,
    SUM(CASE WHEN tl.Payroll_ID  IS NOT NULL
        THEN tl.Amount ELSE 0 END) AS To_Payroll,
    SUM(CASE WHEN tl.Advance_ID  IS NOT NULL
        THEN tl.Amount ELSE 0 END) AS To_Advances,

    -- إجمالي الخارج
    SUM(CASE WHEN tt.Type_Name = N'صادر' THEN tl.Amount ELSE 0 END) AS Total_Out,

    -- الصافي
    SUM(CASE WHEN tt.Type_Name = N'وارد' THEN tl.Amount ELSE 0 END)
    - SUM(CASE WHEN tt.Type_Name = N'صادر' THEN tl.Amount ELSE 0 END) AS Net_Position,

    -- رصيد الخزنة في نهاية الفترة
    MAX(tl.Balance_After) AS Closing_Balance,

    -- عدد العمليات
    COUNT(tl.Transation_ID) AS Transaction_Count
FROM TREASURY_LOG tl
LEFT JOIN TRANSACTION_TYPES tt ON tl.Transaction_Type_ID = tt.Transaction_Type_ID
GROUP BY FORMAT(tl.Action_Date, 'yyyy-MM');
GO
/****** Object:  View [dbo].[V_Current_Treasury_Balance]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Current_Treasury_Balance] AS
SELECT TOP 1
    tl.Balance_After                    AS Current_Balance,
    tl.Action_Date                      AS As_Of,
    tt.Type_Name                        AS Last_Transaction_Type,
    tl.Amount                           AS Last_Transaction_Amount,
    pm.Method_Name                      AS Last_Payment_Method
FROM TREASURY_LOG tl
LEFT JOIN TRANSACTION_TYPES tt ON tl.Transaction_Type_ID = tt.Transaction_Type_ID
LEFT JOIN PAYMENT_METHODS   pm ON tl.Payment_Method_ID   = pm.Payment_Method_ID
ORDER BY tl.Action_Date DESC;
GO
/****** Object:  Table [dbo].[Item_Status]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item_Status](
	[Status_ID] [int] IDENTITY(1,1) NOT NULL,
	[Status_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Status_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Status_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Returns]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Returns](
	[Return_ID] [int] IDENTITY(1,1) NOT NULL,
	[Invoice_ID] [int] NOT NULL,
	[Part_ID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Reason] [nvarchar](300) NULL,
	[Status_ID] [int] NOT NULL,
	[Return_Date] [date] NOT NULL,
	[Created_At] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Return_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Returns_Analysis]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[V_Returns_Analysis] AS
SELECT
    r.Return_ID,
    r.Return_Date,
    si.Invoice_ID,
    si.Date_Time        AS Original_Invoice_Date,
    ISNULL(cu.Customer_Name, N'عميل نقدي') AS Customer_Name,
    inv.Part_Name,
    c.Category_Name,
    r.Quantity,
    id.Unit_Price,
    r.Quantity * id.Unit_Price  AS Return_Value,
    r.Reason,
    its.Status_Name             AS Item_Status,
    DATEDIFF(DAY, si.Date_Time, r.Return_Date) AS Days_To_Return
FROM RETURNS r
LEFT JOIN SALES_INVOICES  si  ON r.Invoice_ID  = si.Invoice_ID
LEFT JOIN CUSTOMERS       cu  ON si.Customer_ID = cu.Customer_ID
LEFT JOIN INVENTORY       inv ON r.Part_ID      = inv.Part_ID
LEFT JOIN CATEGORIES      c   ON inv.Category_ID = c.Category_ID
LEFT JOIN ITEM_STATUS     its ON r.Status_ID    = its.Status_ID
LEFT JOIN INVOICE_DETAILS id  ON r.Invoice_ID   = id.Invoice_ID
                              AND r.Part_ID     = id.Part_ID;
GO
/****** Object:  View [dbo].[V_Purchase_vs_Sales]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[V_Purchase_vs_Sales] AS
WITH Sales_Summary AS (
    SELECT FORMAT(Date_Time, 'yyyy-MM') AS Period,
           SUM(Final_Amount)             AS Total_Sales
    FROM SALES_INVOICES
    GROUP BY FORMAT(Date_Time, 'yyyy-MM')
),
Purchase_Summary AS (
    SELECT FORMAT(Order_Date, 'yyyy-MM') AS Period,
           SUM(Total_Amount)              AS Total_Purchases
    FROM PURCHASE_ORDERS
    GROUP BY FORMAT(Order_Date, 'yyyy-MM')
),
Expense_Summary AS (
    SELECT FORMAT(Expense_Date, 'yyyy-MM') AS Period,
           SUM(Amount)                      AS Total_Expenses
    FROM EXPENSES
    GROUP BY FORMAT(Expense_Date, 'yyyy-MM')
),
Payroll_Summary AS (
    SELECT Month_Year                        AS Period,
           SUM(Amount_Paid)                  AS Total_Payroll
    FROM PAYROLL
    GROUP BY Month_Year
),
All_Periods AS (
    SELECT Period FROM Sales_Summary
    UNION
    SELECT Period FROM Purchase_Summary
    UNION
    SELECT Period FROM Expense_Summary
    UNION
    SELECT Period FROM Payroll_Summary
)
SELECT
    ap.Period,
    ISNULL(ss.Total_Sales,     0)  AS Total_Sales,
    ISNULL(ps.Total_Purchases, 0)  AS Total_Purchases,
    ISNULL(es.Total_Expenses,  0)  AS Total_Expenses,
    ISNULL(py.Total_Payroll,   0)  AS Total_Payroll,
    ISNULL(ss.Total_Sales, 0)
        - ISNULL(ps.Total_Purchases, 0)
        - ISNULL(es.Total_Expenses, 0)
        - ISNULL(py.Total_Payroll, 0) AS Net_Position
FROM All_Periods ap
LEFT JOIN Sales_Summary    ss ON ap.Period = ss.Period
LEFT JOIN Purchase_Summary ps ON ap.Period = ps.Period
LEFT JOIN Expense_Summary  es ON ap.Period = es.Period
LEFT JOIN Payroll_Summary  py ON ap.Period = py.Period;
GO
/****** Object:  Table [dbo].[FINANCIAL_AUDIT_LOG]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FINANCIAL_AUDIT_LOG](
	[Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[Entity_Type] [nvarchar](50) NOT NULL,
	[Entity_ID] [int] NOT NULL,
	[Action_Type] [nvarchar](50) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Action_Date] [datetime2](7) NOT NULL,
	[Remarks] [nvarchar](500) NULL,
	[Old_Data] [nvarchar](max) NULL,
	[New_Data] [nvarchar](max) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Transaction_ID] [int] NULL,
	[Host_Name] [nvarchar](128) NULL,
	[Application_Name] [nvarchar](128) NULL,
	[Session_Login] [nvarchar](128) NULL,
	[Old_Value] [nvarchar](500) NULL,
	[New_Value] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Log_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[Employee_ID] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password_Hash] [nvarchar](256) NOT NULL,
	[Is_Active] [bit] NOT NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Permissions] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Employee_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Financial_Audit]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Do NOT grant INSERT/UPDATE/DELETE on financial tables to the app role.
   Application code should call stored procedures only. */

/* ================================================================
   17) AUDIT VIEW
   ================================================================ */
CREATE   VIEW [dbo].[V_Financial_Audit] AS
SELECT fal.Log_ID,fal.Action_Date,fal.Entity_Type,fal.Entity_ID,fal.Action_Type,
       fal.User_ID,u.Username,e.Full_Name AS User_Name,fal.Amount,fal.Transaction_ID,
       fal.Remarks,fal.Old_Data,fal.New_Data,fal.Host_Name,fal.Application_Name,fal.Session_Login
FROM dbo.FINANCIAL_AUDIT_LOG fal
LEFT JOIN dbo.USERS u ON u.User_ID=fal.User_ID
LEFT JOIN dbo.EMPLOYEES e ON e.Employee_ID=u.Employee_ID;

GO
/****** Object:  UserDefinedFunction [dbo].[fn_CalculateSellingPrice]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_CalculateSellingPrice]
(
    @PurchasePrice DECIMAL(18,2),
    @MarkupPercent DECIMAL(5,2)
)
RETURNS DECIMAL(18,2)
WITH SCHEMABINDING
AS
BEGIN
    RETURN @PurchasePrice + (@PurchasePrice * @MarkupPercent / 100.0);
END
GO
/****** Object:  Table [dbo].[Audit_Log]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audit_Log](
	[Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[Part_ID] [int] NOT NULL,
	[Movement_Type_ID] [int] NOT NULL,
	[Quantity_Change] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Action_Date] [datetime2](7) NOT NULL,
	[Remarks] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[Log_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Car_Compatibility]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car_Compatibility](
	[Compatibility_ID] [int] IDENTITY(1,1) NOT NULL,
	[Part_ID] [int] NOT NULL,
	[Car_Make] [nvarchar](100) NOT NULL,
	[Car_Model] [nvarchar](100) NOT NULL,
	[Year_Range] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Compatibility_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Compat] UNIQUE NONCLUSTERED 
(
	[Part_ID] ASC,
	[Car_Make] ASC,
	[Car_Model] ASC,
	[Year_Range] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movement_Types]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movement_Types](
	[Movement_Type_ID] [int] IDENTITY(1,1) NOT NULL,
	[Type_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Movement_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Type_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Price_History]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Price_History](
	[Price_ID] [int] IDENTITY(1,1) NOT NULL,
	[Part_ID] [int] NOT NULL,
	[Price] [decimal](12, 2) NOT NULL,
	[Start_Date] [date] NOT NULL,
	[End_Date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Price_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [UX_Advances_Treasury_ID]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Advances_Treasury_ID] ON [dbo].[Advances]
(
	[Treasury_ID] ASC
)
WHERE ([Treasury_ID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AuditLog_Date]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_AuditLog_Date] ON [dbo].[Audit_Log]
(
	[Action_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AuditLog_Part]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_AuditLog_Part] ON [dbo].[Audit_Log]
(
	[Part_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CarCompat_Make_Model]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_CarCompat_Make_Model] ON [dbo].[Car_Compatibility]
(
	[Car_Make] ASC,
	[Car_Model] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Customers_Balance]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Customers_Balance] ON [dbo].[Customers]
(
	[Total_Balance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Customers_Type]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Customers_Type] ON [dbo].[Customers]
(
	[Customer_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_IsActive]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Employees_IsActive] ON [dbo].[Employees]
(
	[Is_Active] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_Position]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Employees_Position] ON [dbo].[Employees]
(
	[Position_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Expenses_ExpenseDate]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Expenses_ExpenseDate] ON [dbo].[Expenses]
(
	[Expense_Date] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UX_Expenses_Treasury_ID]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Expenses_Treasury_ID] ON [dbo].[Expenses]
(
	[Treasury_ID] ASC
)
WHERE ([Treasury_ID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FinancialAudit_Date]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_FinancialAudit_Date] ON [dbo].[FINANCIAL_AUDIT_LOG]
(
	[Action_Date] DESC,
	[Log_ID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FinancialAudit_Entity]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_FinancialAudit_Entity] ON [dbo].[FINANCIAL_AUDIT_LOG]
(
	[Entity_Type] ASC,
	[Entity_ID] ASC,
	[Action_Date] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FinancialAudit_User]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_FinancialAudit_User] ON [dbo].[FINANCIAL_AUDIT_LOG]
(
	[User_ID] ASC,
	[Action_Date] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FinancialAuditLog_Entity]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_FinancialAuditLog_Entity] ON [dbo].[FINANCIAL_AUDIT_LOG]
(
	[Entity_Type] ASC,
	[Entity_ID] ASC,
	[Action_Date] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Inventory_Barcode]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Inventory_Barcode] ON [dbo].[Inventory]
(
	[Barcode] ASC
)
WHERE ([Barcode] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Inventory_Category]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Inventory_Category] ON [dbo].[Inventory]
(
	[Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Inventory_IsDeleted]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Inventory_IsDeleted] ON [dbo].[Inventory]
(
	[Is_Deleted] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Inventory_LowStock]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Inventory_LowStock] ON [dbo].[Inventory]
(
	[Current_Stock] ASC,
	[Min_Limit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Inventory_Supplier]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Inventory_Supplier] ON [dbo].[Inventory]
(
	[Supplier_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvDetails_Invoice]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_InvDetails_Invoice] ON [dbo].[Invoice_Details]
(
	[Invoice_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvDetails_Part]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_InvDetails_Part] ON [dbo].[Invoice_Details]
(
	[Part_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Payroll_Employee_Month]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Payroll_Employee_Month] ON [dbo].[Payroll]
(
	[Employee_ID] ASC,
	[Month_Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PODetails_Part]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_PODetails_Part] ON [dbo].[Purchase_Order_Details]
(
	[Part_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PODetails_PO]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_PODetails_PO] ON [dbo].[Purchase_Order_Details]
(
	[PO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PO_Date]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_PO_Date] ON [dbo].[Purchase_Orders]
(
	[Order_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PO_Supplier]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_PO_Supplier] ON [dbo].[Purchase_Orders]
(
	[Supplier_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseOrders_OrderDate]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseOrders_OrderDate] ON [dbo].[Purchase_Orders]
(
	[Order_Date] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesInv_Customer]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_SalesInv_Customer] ON [dbo].[Sales_Invoices]
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesInv_DateTime]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_SalesInv_DateTime] ON [dbo].[Sales_Invoices]
(
	[Date_Time] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesInv_Employee]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_SalesInv_Employee] ON [dbo].[Sales_Invoices]
(
	[Employee_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesInv_Status]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_SalesInv_Status] ON [dbo].[Sales_Invoices]
(
	[Payment_Status_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesInvoices_DateTime]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_SalesInvoices_DateTime] ON [dbo].[Sales_Invoices]
(
	[Date_Time] DESC
)
INCLUDE([Customer_ID],[Final_Amount],[Paid_Amount]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Treasury_ActionDate]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Treasury_ActionDate] ON [dbo].[Treasury_Log]
(
	[Action_Date] DESC
)
INCLUDE([Amount],[Balance_After]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Treasury_ActionDate_ID]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Treasury_ActionDate_ID] ON [dbo].[Treasury_Log]
(
	[Action_Date] DESC,
	[Transation_ID] DESC
)
INCLUDE([Balance_After]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Treasury_Advance]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Treasury_Advance] ON [dbo].[Treasury_Log]
(
	[Advance_ID] ASC
)
WHERE ([Advance_ID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Treasury_Date]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Treasury_Date] ON [dbo].[Treasury_Log]
(
	[Action_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Treasury_Expense]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Treasury_Expense] ON [dbo].[Treasury_Log]
(
	[Expense_ID] ASC
)
WHERE ([Expense_ID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Treasury_Invoice]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Treasury_Invoice] ON [dbo].[Treasury_Log]
(
	[Invoice_ID] ASC
)
WHERE ([Invoice_ID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Treasury_PO]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Treasury_PO] ON [dbo].[Treasury_Log]
(
	[PO_ID] ASC
)
WHERE ([PO_ID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Treasury_Reversal]    Script Date: 9/17/2026 7:01:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Treasury_Reversal] ON [dbo].[Treasury_Log]
(
	[Reversal_Of_Transaction_ID] ASC
)
WHERE ([Reversal_Of_Transaction_ID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Advances] ADD  DEFAULT (CONVERT([date],getdate())) FOR [Advance_Date]
GO
ALTER TABLE [dbo].[Advances] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[Audit_Log] ADD  DEFAULT (getdate()) FOR [Action_Date]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [Credit_Limit]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [Total_Balance]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT ((0)) FOR [Basic_Salary]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT (getdate()) FOR [Updated_At]
GO
ALTER TABLE [dbo].[Expenses] ADD  DEFAULT (CONVERT([date],getdate())) FOR [Expense_Date]
GO
ALTER TABLE [dbo].[Expenses] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[Expenses] ADD  CONSTRAINT [DF_Expenses_IsVoided]  DEFAULT ((0)) FOR [Is_Voided]
GO
ALTER TABLE [dbo].[Expenses] ADD  CONSTRAINT [DF_Expenses_UpdatedAt]  DEFAULT (getdate()) FOR [Updated_At]
GO
ALTER TABLE [dbo].[FINANCIAL_AUDIT_LOG] ADD  CONSTRAINT [DF_FINANCIAL_AUDIT_LOG_Action_Date]  DEFAULT (getdate()) FOR [Action_Date]
GO
ALTER TABLE [dbo].[Inventory] ADD  DEFAULT ((0)) FOR [Purchase_Price]
GO
ALTER TABLE [dbo].[Inventory] ADD  DEFAULT ((0)) FOR [Markup_Percent]
GO
ALTER TABLE [dbo].[Inventory] ADD  DEFAULT ((0)) FOR [Selling_Price]
GO
ALTER TABLE [dbo].[Inventory] ADD  DEFAULT ((0)) FOR [Current_Stock]
GO
ALTER TABLE [dbo].[Inventory] ADD  DEFAULT ((0)) FOR [Min_Limit]
GO
ALTER TABLE [dbo].[Inventory] ADD  DEFAULT ((0)) FOR [Is_Deleted]
GO
ALTER TABLE [dbo].[Inventory] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[Inventory] ADD  DEFAULT (getdate()) FOR [Updated_At]
GO
ALTER TABLE [dbo].[Payroll] ADD  DEFAULT ((0)) FOR [Deductions]
GO
ALTER TABLE [dbo].[Payroll] ADD  DEFAULT ((0)) FOR [Bonuses]
GO
ALTER TABLE [dbo].[Payroll] ADD  DEFAULT (CONVERT([date],getdate())) FOR [Payment_Date]
GO
ALTER TABLE [dbo].[Payroll] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[Price_History] ADD  DEFAULT (CONVERT([date],getdate())) FOR [Start_Date]
GO
ALTER TABLE [dbo].[Purchase_Order_Details] ADD  CONSTRAINT [DF_PODetails_Received]  DEFAULT ((0)) FOR [Received_Quantity]
GO
ALTER TABLE [dbo].[Purchase_Orders] ADD  DEFAULT (CONVERT([date],getdate())) FOR [Order_Date]
GO
ALTER TABLE [dbo].[Purchase_Orders] ADD  DEFAULT ((0)) FOR [Total_Amount]
GO
ALTER TABLE [dbo].[Purchase_Orders] ADD  DEFAULT ((0)) FOR [Paid_Amount]
GO
ALTER TABLE [dbo].[Purchase_Orders] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[Returns] ADD  DEFAULT (CONVERT([date],getdate())) FOR [Return_Date]
GO
ALTER TABLE [dbo].[Returns] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[Sales_Invoices] ADD  DEFAULT (getdate()) FOR [Date_Time]
GO
ALTER TABLE [dbo].[Sales_Invoices] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Sales_Invoices] ADD  DEFAULT ((0)) FOR [Paid_Amount]
GO
ALTER TABLE [dbo].[Sales_Invoices] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[Staff_Wallets] ADD  DEFAULT ((0)) FOR [Current_Balance]
GO
ALTER TABLE [dbo].[Staff_Wallets] ADD  DEFAULT (getdate()) FOR [Last_Update]
GO
ALTER TABLE [dbo].[Suppliers] ADD  DEFAULT ((0)) FOR [Supplier_Balance]
GO
ALTER TABLE [dbo].[Suppliers] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[Treasury_Log] ADD  DEFAULT (getdate()) FOR [Action_Date]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [Created_At]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [Permissions]
GO
ALTER TABLE [dbo].[Advances]  WITH CHECK ADD  CONSTRAINT [FK_Advances_ApprovedBy] FOREIGN KEY([Approved_By])
REFERENCES [dbo].[Employees] ([Employee_ID])
GO
ALTER TABLE [dbo].[Advances] CHECK CONSTRAINT [FK_Advances_ApprovedBy]
GO
ALTER TABLE [dbo].[Advances]  WITH CHECK ADD  CONSTRAINT [FK_Advances_Employee] FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employees] ([Employee_ID])
GO
ALTER TABLE [dbo].[Advances] CHECK CONSTRAINT [FK_Advances_Employee]
GO
ALTER TABLE [dbo].[Advances]  WITH CHECK ADD  CONSTRAINT [FK_Advances_Status] FOREIGN KEY([Status_ID])
REFERENCES [dbo].[Advance_Status] ([Status_ID])
GO
ALTER TABLE [dbo].[Advances] CHECK CONSTRAINT [FK_Advances_Status]
GO
ALTER TABLE [dbo].[Advances]  WITH CHECK ADD  CONSTRAINT [FK_Advances_Treasury] FOREIGN KEY([Treasury_ID])
REFERENCES [dbo].[Treasury_Log] ([Transation_ID])
GO
ALTER TABLE [dbo].[Advances] CHECK CONSTRAINT [FK_Advances_Treasury]
GO
ALTER TABLE [dbo].[Audit_Log]  WITH CHECK ADD  CONSTRAINT [FK_AuditLog_MovType] FOREIGN KEY([Movement_Type_ID])
REFERENCES [dbo].[Movement_Types] ([Movement_Type_ID])
GO
ALTER TABLE [dbo].[Audit_Log] CHECK CONSTRAINT [FK_AuditLog_MovType]
GO
ALTER TABLE [dbo].[Audit_Log]  WITH CHECK ADD  CONSTRAINT [FK_AuditLog_Part] FOREIGN KEY([Part_ID])
REFERENCES [dbo].[Inventory] ([Part_ID])
GO
ALTER TABLE [dbo].[Audit_Log] CHECK CONSTRAINT [FK_AuditLog_Part]
GO
ALTER TABLE [dbo].[Audit_Log]  WITH CHECK ADD  CONSTRAINT [FK_AuditLog_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[Users] ([User_ID])
GO
ALTER TABLE [dbo].[Audit_Log] CHECK CONSTRAINT [FK_AuditLog_User]
GO
ALTER TABLE [dbo].[Car_Compatibility]  WITH CHECK ADD  CONSTRAINT [FK_Compat_Part] FOREIGN KEY([Part_ID])
REFERENCES [dbo].[Inventory] ([Part_ID])
GO
ALTER TABLE [dbo].[Car_Compatibility] CHECK CONSTRAINT [FK_Compat_Part]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Type] FOREIGN KEY([Customer_Type_ID])
REFERENCES [dbo].[Customer_Types] ([Customer_Type_ID])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Type]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Position] FOREIGN KEY([Position_ID])
REFERENCES [dbo].[Employee_Positions] ([Position_ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Position]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_Category] FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Expense_Categories] ([Category_ID])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_Category]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_PaidBy] FOREIGN KEY([Paid_By])
REFERENCES [dbo].[Employees] ([Employee_ID])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_PaidBy]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_Treasury] FOREIGN KEY([Treasury_ID])
REFERENCES [dbo].[Treasury_Log] ([Transation_ID])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_Treasury]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Brand] FOREIGN KEY([Brand_ID])
REFERENCES [dbo].[Brands] ([Brand_ID])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Brand]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Category] FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Categories] ([Category_ID])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Category]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_CrossRef] FOREIGN KEY([Cross_Ref_ID])
REFERENCES [dbo].[Inventory] ([Part_ID])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_CrossRef]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Supplier] FOREIGN KEY([Supplier_ID])
REFERENCES [dbo].[Suppliers] ([Supplier_ID])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Supplier]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Unit] FOREIGN KEY([Unit_ID])
REFERENCES [dbo].[Units] ([Unit_ID])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Unit]
GO
ALTER TABLE [dbo].[Invoice_Details]  WITH CHECK ADD  CONSTRAINT [FK_InDetails_Part] FOREIGN KEY([Part_ID])
REFERENCES [dbo].[Inventory] ([Part_ID])
GO
ALTER TABLE [dbo].[Invoice_Details] CHECK CONSTRAINT [FK_InDetails_Part]
GO
ALTER TABLE [dbo].[Invoice_Details]  WITH CHECK ADD  CONSTRAINT [FK_InvDetails_Invoice] FOREIGN KEY([Invoice_ID])
REFERENCES [dbo].[Sales_Invoices] ([Invoice_ID])
GO
ALTER TABLE [dbo].[Invoice_Details] CHECK CONSTRAINT [FK_InvDetails_Invoice]
GO
ALTER TABLE [dbo].[Payroll]  WITH CHECK ADD  CONSTRAINT [FK_Payroll_Employee] FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employees] ([Employee_ID])
GO
ALTER TABLE [dbo].[Payroll] CHECK CONSTRAINT [FK_Payroll_Employee]
GO
ALTER TABLE [dbo].[Price_History]  WITH CHECK ADD  CONSTRAINT [FK_PriceHistory_Part] FOREIGN KEY([Part_ID])
REFERENCES [dbo].[Inventory] ([Part_ID])
GO
ALTER TABLE [dbo].[Price_History] CHECK CONSTRAINT [FK_PriceHistory_Part]
GO
ALTER TABLE [dbo].[Purchase_Order_Details]  WITH CHECK ADD  CONSTRAINT [FK_PODetails_Part] FOREIGN KEY([Part_ID])
REFERENCES [dbo].[Inventory] ([Part_ID])
GO
ALTER TABLE [dbo].[Purchase_Order_Details] CHECK CONSTRAINT [FK_PODetails_Part]
GO
ALTER TABLE [dbo].[Purchase_Order_Details]  WITH CHECK ADD  CONSTRAINT [FK_PODetails_PO] FOREIGN KEY([PO_ID])
REFERENCES [dbo].[Purchase_Orders] ([PO_ID])
GO
ALTER TABLE [dbo].[Purchase_Order_Details] CHECK CONSTRAINT [FK_PODetails_PO]
GO
ALTER TABLE [dbo].[Purchase_Orders]  WITH CHECK ADD  CONSTRAINT [FK_PO_Employee] FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employees] ([Employee_ID])
GO
ALTER TABLE [dbo].[Purchase_Orders] CHECK CONSTRAINT [FK_PO_Employee]
GO
ALTER TABLE [dbo].[Purchase_Orders]  WITH CHECK ADD  CONSTRAINT [FK_PO_Status] FOREIGN KEY([Status_ID])
REFERENCES [dbo].[Purchase_Order_Status] ([Status_ID])
GO
ALTER TABLE [dbo].[Purchase_Orders] CHECK CONSTRAINT [FK_PO_Status]
GO
ALTER TABLE [dbo].[Purchase_Orders]  WITH CHECK ADD  CONSTRAINT [FK_PO_Supplier] FOREIGN KEY([Supplier_ID])
REFERENCES [dbo].[Suppliers] ([Supplier_ID])
GO
ALTER TABLE [dbo].[Purchase_Orders] CHECK CONSTRAINT [FK_PO_Supplier]
GO
ALTER TABLE [dbo].[Returns]  WITH CHECK ADD  CONSTRAINT [FK_Returns_Invoice] FOREIGN KEY([Invoice_ID])
REFERENCES [dbo].[Sales_Invoices] ([Invoice_ID])
GO
ALTER TABLE [dbo].[Returns] CHECK CONSTRAINT [FK_Returns_Invoice]
GO
ALTER TABLE [dbo].[Returns]  WITH CHECK ADD  CONSTRAINT [FK_Returns_Part] FOREIGN KEY([Part_ID])
REFERENCES [dbo].[Inventory] ([Part_ID])
GO
ALTER TABLE [dbo].[Returns] CHECK CONSTRAINT [FK_Returns_Part]
GO
ALTER TABLE [dbo].[Returns]  WITH CHECK ADD  CONSTRAINT [FK_Returns_Status] FOREIGN KEY([Status_ID])
REFERENCES [dbo].[Item_Status] ([Status_ID])
GO
ALTER TABLE [dbo].[Returns] CHECK CONSTRAINT [FK_Returns_Status]
GO
ALTER TABLE [dbo].[Sales_Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customers] ([Customer_ID])
GO
ALTER TABLE [dbo].[Sales_Invoices] CHECK CONSTRAINT [FK_Invoice_Customer]
GO
ALTER TABLE [dbo].[Sales_Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Employee] FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employees] ([Employee_ID])
GO
ALTER TABLE [dbo].[Sales_Invoices] CHECK CONSTRAINT [FK_Invoices_Employee]
GO
ALTER TABLE [dbo].[Sales_Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Status] FOREIGN KEY([Payment_Status_ID])
REFERENCES [dbo].[Payment_Status] ([Status_ID])
GO
ALTER TABLE [dbo].[Sales_Invoices] CHECK CONSTRAINT [FK_Invoices_Status]
GO
ALTER TABLE [dbo].[Staff_Wallets]  WITH CHECK ADD  CONSTRAINT [FK_Wallets_Employee] FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employees] ([Employee_ID])
GO
ALTER TABLE [dbo].[Staff_Wallets] CHECK CONSTRAINT [FK_Wallets_Employee]
GO
ALTER TABLE [dbo].[Treasury_Log]  WITH CHECK ADD  CONSTRAINT [FK_Treasury_Advance] FOREIGN KEY([Advance_ID])
REFERENCES [dbo].[Advances] ([Advance_ID])
GO
ALTER TABLE [dbo].[Treasury_Log] CHECK CONSTRAINT [FK_Treasury_Advance]
GO
ALTER TABLE [dbo].[Treasury_Log]  WITH CHECK ADD  CONSTRAINT [FK_Treasury_CreatedBy] FOREIGN KEY([Created_By])
REFERENCES [dbo].[Users] ([User_ID])
GO
ALTER TABLE [dbo].[Treasury_Log] CHECK CONSTRAINT [FK_Treasury_CreatedBy]
GO
ALTER TABLE [dbo].[Treasury_Log]  WITH CHECK ADD  CONSTRAINT [FK_Treasury_Employee] FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employees] ([Employee_ID])
GO
ALTER TABLE [dbo].[Treasury_Log] CHECK CONSTRAINT [FK_Treasury_Employee]
GO
ALTER TABLE [dbo].[Treasury_Log]  WITH CHECK ADD  CONSTRAINT [FK_Treasury_Expense] FOREIGN KEY([Expense_ID])
REFERENCES [dbo].[Expenses] ([Expense_ID])
GO
ALTER TABLE [dbo].[Treasury_Log] CHECK CONSTRAINT [FK_Treasury_Expense]
GO
ALTER TABLE [dbo].[Treasury_Log]  WITH CHECK ADD  CONSTRAINT [FK_Treasury_Invoice] FOREIGN KEY([Invoice_ID])
REFERENCES [dbo].[Sales_Invoices] ([Invoice_ID])
GO
ALTER TABLE [dbo].[Treasury_Log] CHECK CONSTRAINT [FK_Treasury_Invoice]
GO
ALTER TABLE [dbo].[Treasury_Log]  WITH CHECK ADD  CONSTRAINT [FK_Treasury_Method] FOREIGN KEY([Payment_Method_ID])
REFERENCES [dbo].[Payment_Methods] ([Payment_Method_ID])
GO
ALTER TABLE [dbo].[Treasury_Log] CHECK CONSTRAINT [FK_Treasury_Method]
GO
ALTER TABLE [dbo].[Treasury_Log]  WITH CHECK ADD  CONSTRAINT [FK_Treasury_Payroll] FOREIGN KEY([Payroll_ID])
REFERENCES [dbo].[Payroll] ([Payroll_ID])
GO
ALTER TABLE [dbo].[Treasury_Log] CHECK CONSTRAINT [FK_Treasury_Payroll]
GO
ALTER TABLE [dbo].[Treasury_Log]  WITH CHECK ADD  CONSTRAINT [FK_Treasury_Type] FOREIGN KEY([Transaction_Type_ID])
REFERENCES [dbo].[Transaction_Types] ([Transaction_Type_ID])
GO
ALTER TABLE [dbo].[Treasury_Log] CHECK CONSTRAINT [FK_Treasury_Type]
GO
ALTER TABLE [dbo].[Treasury_Log]  WITH CHECK ADD  CONSTRAINT [FK_Tresury_PO] FOREIGN KEY([PO_ID])
REFERENCES [dbo].[Purchase_Orders] ([PO_ID])
GO
ALTER TABLE [dbo].[Treasury_Log] CHECK CONSTRAINT [FK_Tresury_PO]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Employee] FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employees] ([Employee_ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Employee]
GO
ALTER TABLE [dbo].[Advances]  WITH CHECK ADD  CONSTRAINT [CK_Advances_Amount] CHECK  (([Amount]>(0)))
GO
ALTER TABLE [dbo].[Advances] CHECK CONSTRAINT [CK_Advances_Amount]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [CK_Customers_Balance] CHECK  (([Total_Balance]>=(0)))
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [CK_Customers_Balance]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [CK_Customers_CreditLimit] CHECK  (([Credit_Limit]>=(0)))
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [CK_Customers_CreditLimit]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [CK_Employees_Salary] CHECK  (([Basic_Salary]>=(0)))
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [CK_Employees_Salary]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [CK_Expenses_Amount] CHECK  (([Amount]>(0)))
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [CK_Expenses_Amount]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [CK_Inventory_Prices] CHECK  (([Purchase_Price]>=(0) AND [Selling_Price]>=(0)))
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [CK_Inventory_Prices]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [CK_Inventory_Stock] CHECK  (([Current_Stock]>=(0)))
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [CK_Inventory_Stock]
GO
ALTER TABLE [dbo].[Invoice_Details]  WITH CHECK ADD  CONSTRAINT [CK_InDetails_Qty] CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[Invoice_Details] CHECK CONSTRAINT [CK_InDetails_Qty]
GO
ALTER TABLE [dbo].[Invoice_Details]  WITH CHECK ADD  CONSTRAINT [CK_invDetails_Price] CHECK  (([Unit_Price]>=(0)))
GO
ALTER TABLE [dbo].[Invoice_Details] CHECK CONSTRAINT [CK_invDetails_Price]
GO
ALTER TABLE [dbo].[Invoice_Details]  WITH CHECK ADD  CONSTRAINT [CK_InvoiceDetails_Prices] CHECK  (([Unit_Price]>=(0) AND [Unit_Cost]>=(0)))
GO
ALTER TABLE [dbo].[Invoice_Details] CHECK CONSTRAINT [CK_InvoiceDetails_Prices]
GO
ALTER TABLE [dbo].[Payroll]  WITH CHECK ADD  CONSTRAINT [CK_Payroll_Amounts] CHECK  (([Amount_Paid]>=(0) AND [Deductions]>=(0) AND [Bonuses]>=(0)))
GO
ALTER TABLE [dbo].[Payroll] CHECK CONSTRAINT [CK_Payroll_Amounts]
GO
ALTER TABLE [dbo].[Purchase_Order_Details]  WITH CHECK ADD  CONSTRAINT [CK_PODetails_Price] CHECK  (([Unit_Price]>=(0)))
GO
ALTER TABLE [dbo].[Purchase_Order_Details] CHECK CONSTRAINT [CK_PODetails_Price]
GO
ALTER TABLE [dbo].[Purchase_Order_Details]  WITH CHECK ADD  CONSTRAINT [CK_PODetails_Qty] CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[Purchase_Order_Details] CHECK CONSTRAINT [CK_PODetails_Qty]
GO
ALTER TABLE [dbo].[Purchase_Order_Details]  WITH CHECK ADD  CONSTRAINT [CK_PurchaseOrderDetails_ReceivedQty] CHECK  (([Received_Quantity]>=(0) AND [Received_Quantity]<=[Quantity]))
GO
ALTER TABLE [dbo].[Purchase_Order_Details] CHECK CONSTRAINT [CK_PurchaseOrderDetails_ReceivedQty]
GO
ALTER TABLE [dbo].[Purchase_Orders]  WITH CHECK ADD  CONSTRAINT [CK_PO_Amounts] CHECK  (([Total_Amount]>=(0) AND [Paid_Amount]>=(0) AND [Paid_Amount]<=[Total_Amount]))
GO
ALTER TABLE [dbo].[Purchase_Orders] CHECK CONSTRAINT [CK_PO_Amounts]
GO
ALTER TABLE [dbo].[Returns]  WITH CHECK ADD  CONSTRAINT [CK_Return_Qty] CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[Returns] CHECK CONSTRAINT [CK_Return_Qty]
GO
ALTER TABLE [dbo].[Sales_Invoices]  WITH CHECK ADD  CONSTRAINT [CK_Invoices_Amounts] CHECK  (([Total_Amount]>=(0) AND [Discount]>=(0) AND [Paid_Amount]>=(0)))
GO
ALTER TABLE [dbo].[Sales_Invoices] CHECK CONSTRAINT [CK_Invoices_Amounts]
GO
ALTER TABLE [dbo].[Sales_Invoices]  WITH CHECK ADD  CONSTRAINT [CK_Invoices_Discount_NotOverFinal] CHECK  (([Discount]<=[Total_Amount]))
GO
ALTER TABLE [dbo].[Sales_Invoices] CHECK CONSTRAINT [CK_Invoices_Discount_NotOverFinal]
GO
ALTER TABLE [dbo].[Sales_Invoices]  WITH CHECK ADD  CONSTRAINT [CK_Invoices_Paid_NotOverFinal] CHECK  (([Paid_Amount]<=([Total_Amount]-[Discount])))
GO
ALTER TABLE [dbo].[Sales_Invoices] CHECK CONSTRAINT [CK_Invoices_Paid_NotOverFinal]
GO
ALTER TABLE [dbo].[Suppliers]  WITH CHECK ADD  CONSTRAINT [CK_Suppliers_Balance] CHECK  (([Supplier_Balance]>=(0)))
GO
ALTER TABLE [dbo].[Suppliers] CHECK CONSTRAINT [CK_Suppliers_Balance]
GO
ALTER TABLE [dbo].[Treasury_Log]  WITH CHECK ADD  CONSTRAINT [CK_Treasury_AmountNotZero] CHECK  (([Amount]<>(0)))
GO
ALTER TABLE [dbo].[Treasury_Log] CHECK CONSTRAINT [CK_Treasury_AmountNotZero]
GO
/****** Object:  StoredProcedure [dbo].[sp_Advance_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- 2.10 sp_Advance_Add : تسجيل تدقيق فقط عند الطلب (لسه معتمدة). التحقق من صحة المبلغ.
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_Advance_Add]
    @EmployeeID   INT,
    @Amount       DECIMAL(18,2),
    @AdvanceDate  DATETIME2,
    @StatusID     INT,
    @UserID       INT,
    @NewAdvanceID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @Amount <= 0
    BEGIN
        RAISERROR(N'قيمة السلفة يجب أن تكون أكبر من صفر.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO dbo.ADVANCES (Employee_ID, Amount, Advance_Date, Status_ID, Created_At)
        VALUES (@EmployeeID, @Amount, @AdvanceDate, @StatusID, GETDATE());

        SET @NewAdvanceID = CAST(SCOPE_IDENTITY() AS INT);

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks, New_Value)
        VALUES (N'Advance', @NewAdvanceID, N'Request', @UserID, GETDATE(), N'طلب سلفة جديدة', CAST(@Amount AS NVARCHAR(50)));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Advance_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Advance_GetAll]
    @StatusID   INT = NULL,
    @EmployeeID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT a.*, e.Full_Name AS Employee_Name, appr.Full_Name AS Approver_Name, ads.Status_Name
    FROM dbo.ADVANCES a
    JOIN dbo.EMPLOYEES       e    ON a.Employee_ID = e.Employee_ID
    JOIN dbo.ADVANCE_STATUS  ads  ON a.Status_ID   = ads.Status_ID
    LEFT JOIN dbo.EMPLOYEES  appr ON a.Approved_By = appr.Employee_ID
    WHERE (@StatusID   IS NULL OR a.Status_ID   = @StatusID)
      AND (@EmployeeID IS NULL OR a.Employee_ID = @EmployeeID)
    ORDER BY a.Advance_Date DESC
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Advance_Pay]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Advance_Pay]
    @AdvanceID INT,
    @PaymentMethodID INT,
    @UserID INT,
    @NewTransactionID INT OUTPUT
AS
BEGIN
    SET NOCOUNT OFF;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @EmployeeID INT,@Amount DECIMAL(18,2),@OldData NVARCHAR(MAX),@Balance DECIMAL(18,2);
        SELECT @EmployeeID=Employee_ID,@Amount=Amount,
               @OldData=(SELECT Advance_ID,Employee_ID,Amount,Advance_Date,Status_ID,Approved_By FROM dbo.ADVANCES WHERE Advance_ID=@AdvanceID FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM dbo.ADVANCES WITH(UPDLOCK,HOLDLOCK) WHERE Advance_ID=@AdvanceID;
        IF @OldData IS NULL THROW 50110,N'Advance does not exist.',1;
        IF EXISTS(SELECT 1 FROM dbo.TREASURY_LOG WHERE Advance_ID=@AdvanceID AND Reversal_Of_Transaction_ID IS NULL)
            THROW 50111,N'Advance has already been paid.',1;

        DECLARE @OutTypeID INT=(SELECT TOP 1 Transaction_Type_ID FROM dbo.TRANSACTION_TYPES WHERE Type_Name=N'صادر');
        EXEC dbo.sp_Treasury_Add @TransactionTypeID=@OutTypeID,@PaymentMethodID=@PaymentMethodID,@Amount=@Amount,@AdvanceID=@AdvanceID,@EmployeeID=@EmployeeID,
            @Notes=N'صرف سلفة موظف',@UserID=@UserID,@NewTransactionID=@NewTransactionID OUTPUT,@NewBalance=@Balance OUTPUT;

        INSERT dbo.FINANCIAL_AUDIT_LOG
        (Entity_Type,Entity_ID,Action_Type,User_ID,Action_Date,Amount,Transaction_ID,Old_Data,New_Data,Remarks,Host_Name,Application_Name,Session_Login)
        VALUES(N'Advance',@AdvanceID,N'PAYMENT',@UserID,GETDATE(),@Amount,@NewTransactionID,@OldData,@OldData,N'Advance paid',HOST_NAME(),APP_NAME(),SUSER_SNAME());
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE()<>0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_Advance_UpdateStatus]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------
-- 2.11 sp_Advance_UpdateStatus : تحديث حالة السلفة وتسجيل حركة الصرف في الخزينة
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_Advance_UpdateStatus]
    @AdvanceID                     INT,
    @NewStatusID                   INT,
    @ApprovedBy                    INT = NULL,
    @UserID                        INT,
    @IsDisbursement                BIT = 0,          -- 1 = الحالة دي معناها صرف فلوس فعلي
    @PaymentMethodID               INT = NULL,
    @DisbursementTransactionTypeID INT = NULL     -- الـ ID بتاع "صرف سلفة" في TRANSACTION_TYPES
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @EmployeeID INT, @Amount DECIMAL(18,2), @AlreadyDisbursed BIT;

        SELECT @EmployeeID = Employee_ID, 
               @Amount = Amount, 
               @AlreadyDisbursed = CASE WHEN Treasury_ID IS NULL THEN 0 ELSE 1 END
        FROM dbo.ADVANCES WITH (UPDLOCK, ROWLOCK)
        WHERE Advance_ID = @AdvanceID;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR(N'السلفة غير موجودة.', 16, 1);
        END

        UPDATE dbo.ADVANCES
        SET Status_ID = @NewStatusID, 
            Approved_By = ISNULL(@ApprovedBy, Approved_By)
        WHERE Advance_ID = @AdvanceID;

        IF @IsDisbursement = 1
        BEGIN
            IF @AlreadyDisbursed = 1
            BEGIN
                RAISERROR(N'تم صرف هذه السلفة بالفعل.', 16, 1);
            END

            IF @PaymentMethodID IS NULL OR @DisbursementTransactionTypeID IS NULL
            BEGIN
                RAISERROR(N'يجب تحديد طريقة الدفع ونوع المعاملة عند صرف السلفة.', 16, 1);
            END

            -- تجهيز المتغيرات قبل استدعاء EXEC لتفادي خطأ بناء الجملة (Incorrect syntax near)
            DECLARE @SignedAmount DECIMAL(18,2) = -@Amount;
            DECLARE @Notes NVARCHAR(200) = N'صرف سلفة رقم ' + CAST(@AdvanceID AS NVARCHAR(20));
            DECLARE @NewTxnID INT, @NewBalance DECIMAL(18,2);

            EXEC dbo.sp_Treasury_Add
                 @TransactionTypeID = @DisbursementTransactionTypeID,
                 @PaymentMethodID   = @PaymentMethodID,
                 @SignedAmount      = @SignedAmount,
                 @AdvanceID         = @AdvanceID,
                 @EmployeeID        = @EmployeeID,
                 @CreatedBy         = @UserID,
                 @Notes             = @Notes,
                 @NewTransactionID  = @NewTxnID OUTPUT,
                 @NewBalance        = @NewBalance OUTPUT;

            UPDATE dbo.ADVANCES SET Treasury_ID = @NewTxnID WHERE Advance_ID = @AdvanceID;
        END

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks)
        VALUES (N'Advance', @AdvanceID, N'StatusUpdate', @UserID, GETDATE(), N'تغيير حالة السلفة');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AuditLog_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AuditLog_Add]
    @PartID         INT,
    @MovementTypeID INT,
    @QuantityChange INT,
    @UserID         INT,
    @Remarks        NVARCHAR(200) = NULL,
    @NewLogID       INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.AUDIT_LOG (Part_ID, Movement_Type_ID, Quantity_Change, User_ID, Action_Date, Remarks)
    VALUES (@PartID, @MovementTypeID, @QuantityChange, @UserID, GETDATE(), @Remarks);
    SET @NewLogID = CAST(SCOPE_IDENTITY() AS INT);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AuditLog_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AuditLog_GetAll]
    @PartID    INT       = NULL,
    @MovTypeID INT       = NULL,
    @From      DATETIME2 = NULL,
    @To        DATETIME2 = NULL,
    @UserID    INT       = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT al.*, i.Part_Name, mt.Type_Name AS Movement_Type_Name, u.Username
    FROM dbo.AUDIT_LOG al
    JOIN dbo.INVENTORY      i  ON al.Part_ID          = i.Part_ID
    JOIN dbo.MOVEMENT_TYPES mt ON al.Movement_Type_ID = mt.Movement_Type_ID
    JOIN dbo.USERS          u  ON al.User_ID          = u.User_ID
    WHERE (@PartID    IS NULL OR al.Part_ID          = @PartID)
      AND (@MovTypeID IS NULL OR al.Movement_Type_ID = @MovTypeID)
      AND (@From      IS NULL OR al.Action_Date      >= @From)
      AND (@To        IS NULL OR al.Action_Date      <= @To)
      AND (@UserID    IS NULL OR al.User_ID          = @UserID)
    ORDER BY al.Action_Date DESC
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CarCompatibility_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CarCompatibility_Add]
    @PartID    INT,
    @CarMake   NVARCHAR(50),
    @CarModel  NVARCHAR(50),
    @YearRange NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.CAR_COMPATIBILITY (Part_ID, Car_Make, Car_Model, Year_Range)
    VALUES (@PartID, @CarMake, @CarModel, @YearRange);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CarCompatibility_Delete]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CarCompatibility_Delete]
    @CompatibilityID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.CAR_COMPATIBILITY WHERE Compatibility_ID = @CompatibilityID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CarCompatibility_GetByPart]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CarCompatibility_GetByPart]
    @PartID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT cc.*, i.Part_Name
    FROM dbo.CAR_COMPATIBILITY cc
    JOIN dbo.INVENTORY i ON cc.Part_ID = i.Part_ID
    WHERE cc.Part_ID = @PartID
    ORDER BY cc.Car_Make, cc.Car_Model;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CarCompatibility_SearchByCar]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CarCompatibility_SearchByCar]
    @Make  NVARCHAR(50),
    @Model NVARCHAR(50),
    @Year  NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT cc.*, i.Part_Name
    FROM dbo.CAR_COMPATIBILITY cc
    JOIN dbo.INVENTORY i ON cc.Part_ID = i.Part_ID
    WHERE cc.Car_Make LIKE N'%' + @Make + N'%'
      AND cc.Car_Model LIKE N'%' + @Model + N'%'
      AND (@Year IS NULL OR cc.Year_Range LIKE N'%' + @Year + N'%')
    ORDER BY i.Part_Name
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customer_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Customer_Add]
    @CustomerName   NVARCHAR(150),
    @PhoneNumber    NVARCHAR(20)  = NULL,
    @CustomerTypeID INT           = NULL,
    @CreditLimit    DECIMAL(18,2) = 0,
    @NewCustomerID  INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.CUSTOMERS (Customer_Name, Phone_Number,  Customer_Type_ID, Credit_Limit, Total_Balance, Created_At)
    VALUES (@CustomerName, @PhoneNumber, @CustomerTypeID, @CreditLimit, 0, GETDATE());
    SET @NewCustomerID = CAST(SCOPE_IDENTITY() AS INT);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customer_AdjustBalance]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- 2.13 sp_Customer_AdjustBalance : تسجيل كل تعديل يدوي في سجل التدقيق (أهم حاجة
--      يراجعها أي مراجع حسابات - أي تعديل يدوي على رصيد عميل لازم يتسجل مين عمله وليه)
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_Customer_AdjustBalance]
    @CustomerID         INT,
    @Delta              DECIMAL(18,2),
    @IsPayment          BIT = 0,
    @EnforceCreditLimit BIT = 1,
    @UserID             INT,
    @Reason             NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @CurrentBalance DECIMAL(18,2), @CreditLimit DECIMAL(18,2);

        SELECT @CurrentBalance = Total_Balance, @CreditLimit = Credit_Limit
        FROM dbo.CUSTOMERS WITH (ROWLOCK, UPDLOCK)
        WHERE Customer_ID = @CustomerID;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR(N'The Customer Is Not Exists', 16, 1);
        END

        IF @EnforceCreditLimit = 1 AND @Delta > 0 AND @CreditLimit > 0
           AND (@CurrentBalance + @Delta) > @CreditLimit
        BEGIN
            RAISERROR(N'The transaction exceeds the customer''s allowed credit limit.', 16, 1);
        END

        UPDATE dbo.CUSTOMERS
        SET Total_Balance     = Total_Balance + @Delta,
            Last_Payment_Date = CASE WHEN @IsPayment = 1 THEN GETDATE() ELSE Last_Payment_Date END
        WHERE Customer_ID = @CustomerID;

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks, Old_Value, New_Value)
        VALUES (N'Customer', @CustomerID, N'ManualBalanceAdjust', @UserID, GETDATE(), @Reason,
                CAST(@CurrentBalance AS NVARCHAR(50)), CAST(@CurrentBalance + @Delta AS NVARCHAR(50)));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customer_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Customer_GetAll]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT cu.*, ct.Type_Name
    FROM dbo.CUSTOMERS cu
    LEFT JOIN dbo.CUSTOMER_TYPES ct ON cu.Customer_Type_ID = ct.Customer_Type_ID
    ORDER BY cu.Customer_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customer_GetByID]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Customer_GetByID]
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT cu.*, ct.Type_Name
    FROM dbo.CUSTOMERS cu
    LEFT JOIN dbo.CUSTOMER_TYPES ct ON cu.Customer_Type_ID = ct.Customer_Type_ID
    WHERE cu.Customer_ID = @CustomerID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customer_Search]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Customer_Search]
    @Keyword    NVARCHAR(200) = NULL,
    @TypeID     INT           = NULL,
    @DebtFilter NVARCHAR(10)  = NULL   -- 'hasDebt' | 'exceeded' | NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @kw NVARCHAR(202) = N'%' + ISNULL(@Keyword,'') + N'%';
    SELECT cu.*, ct.Type_Name
    FROM dbo.CUSTOMERS cu
    LEFT JOIN dbo.CUSTOMER_TYPES ct ON cu.Customer_Type_ID = ct.Customer_Type_ID
    WHERE (@Keyword IS NULL OR cu.Customer_Name LIKE @kw OR cu.Phone_Number LIKE @kw)
      AND (@TypeID  IS NULL OR cu.Customer_Type_ID = @TypeID)
      AND (
            @DebtFilter IS NULL
         OR (@DebtFilter = 'hasDebt'  AND cu.Total_Balance > 0)
         OR (@DebtFilter = 'exceeded' AND cu.Total_Balance >= cu.Credit_Limit AND cu.Credit_Limit > 0)
          )
    ORDER BY cu.Customer_Name
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customer_Update]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Customer_Update]
    @CustomerID     INT,
    @CustomerName   NVARCHAR(150),
    @PhoneNumber    NVARCHAR(20)  = NULL,
    @CustomerTypeID INT           = NULL,
    @CreditLimit    DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.CUSTOMERS SET
        Customer_Name    = @CustomerName,
        Phone_Number     = @PhoneNumber,
        Customer_Type_ID = @CustomerTypeID,
        Credit_Limit     = @CreditLimit
    WHERE Customer_ID = @CustomerID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employee_Activate]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_Employee_Activate]  
    @EmployeeID INT  
AS  
BEGIN  
    SET NOCOUNT ON;  
    UPDATE dbo.EMPLOYEES SET Is_Active = 1, Updated_At = GETDATE() WHERE Employee_ID = @EmployeeID;  
END  
GO
/****** Object:  StoredProcedure [dbo].[sp_Employee_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Employee_Add]
    @PositionID   INT,
    @FullName     NVARCHAR(150),
    @BasicSalary  DECIMAL(18,2),
    @HireDate     DATE,
    @PhoneNumber  NVARCHAR(20)  = NULL,
    @NationalID   NVARCHAR(20)  = NULL,
    @IsActive     BIT           = 1,
    @NewEmployeeID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF @NationalID IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.EMPLOYEES WHERE National_ID = @NationalID)
    BEGIN
        RAISERROR(N'The National ID is already registered for another employee.', 16, 1);
        RETURN;
    END

    INSERT INTO dbo.EMPLOYEES (Position_ID, Full_Name, Basic_Salary, Hire_Date, Phone_Number, National_ID, Is_Active, Created_At, Updated_At)
    VALUES (@PositionID, @FullName, @BasicSalary, @HireDate, @PhoneNumber, @NationalID, @IsActive, GETDATE(), GETDATE());

    SET @NewEmployeeID = CAST(SCOPE_IDENTITY() AS INT);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employee_Deactivate]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Employee_Deactivate]
    @EmployeeID INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.EMPLOYEES SET Is_Active = 0, Updated_At = GETDATE() WHERE Employee_ID = @EmployeeID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employee_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Employee_GetAll]
    @ActiveOnly BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SELECT e.*, ep.Position_Name
    FROM dbo.EMPLOYEES e
    LEFT JOIN dbo.EMPLOYEE_POSITIONS ep ON e.Position_ID = ep.Position_ID
    WHERE (@ActiveOnly = 0 OR e.Is_Active = 1)
    ORDER BY e.Full_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employee_GetByID]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Employee_GetByID]
    @EmployeeID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT e.*, ep.Position_Name
    FROM dbo.EMPLOYEES e
    LEFT JOIN dbo.EMPLOYEE_POSITIONS ep ON e.Position_ID = ep.Position_ID
    WHERE e.Employee_ID = @EmployeeID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employee_Search]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Employee_Search]
    @Keyword NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @kw NVARCHAR(202) = N'%' + @Keyword + N'%';
    SELECT e.*, ep.Position_Name
    FROM dbo.EMPLOYEES e
    LEFT JOIN dbo.EMPLOYEE_POSITIONS ep ON e.Position_ID = ep.Position_ID
    WHERE e.Is_Active = 1
      AND (e.Full_Name LIKE @kw OR e.Phone_Number LIKE @kw OR e.National_ID LIKE @kw)
    ORDER BY e.Full_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Employee_Update]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Employee_Update]
    @EmployeeID   INT,
    @PositionID   INT,
    @FullName     NVARCHAR(150),
    @BasicSalary  DECIMAL(18,2),
    @HireDate     DATE,
    @PhoneNumber  NVARCHAR(20) = NULL,
    @NationalID   NVARCHAR(20) = NULL,
    @IsActive     BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.EMPLOYEES SET
        Position_ID  = @PositionID,
        Full_Name    = @FullName,
        Basic_Salary = @BasicSalary,
        Hire_Date    = @HireDate,
        Phone_Number = @PhoneNumber,
        National_ID  = @NationalID,
        Is_Active    = @IsActive,
        Updated_At   = GETDATE()
    WHERE Employee_ID = @EmployeeID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Expense_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------
-- 2.7  sp_Expense_Add : تسجيل تلقائي في الخزينة (خصم فوري) + تدقيق
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_Expense_Add]
    @CategoryID               INT,
    @Amount                   DECIMAL(18,2),
    @ExpenseDate              DATETIME2,
    @PaidBy                   INT           = NULL,
    @PaymentMethodID          INT,
    @ExpenseTransactionTypeID INT,   -- الـ ID بتاع "مصروف" في TRANSACTION_TYPES
    @UserID                   INT,
    @Notes                    NVARCHAR(500) = NULL,
    @NewExpenseID             INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @Amount <= 0
    BEGIN
        RAISERROR(N'قيمة المصروف يجب أن تكون أكبر من صفر.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO dbo.EXPENSES (Category_ID, Amount, Expense_Date, Paid_By, Notes, Created_At)
        VALUES (@CategoryID, @Amount, @ExpenseDate, @PaidBy, @Notes, GETDATE());

        SET @NewExpenseID = CAST(SCOPE_IDENTITY() AS INT);

        -- تجهيز المتغيرات قبل استدعاء إجراء الخزينة لتفادي خطأ بناء الجملة (Syntax Error)
        DECLARE @SignedAmount DECIMAL(18,2) = -@Amount;
        DECLARE @TreasuryNotes NVARCHAR(500) = ISNULL(@Notes, N'') + N' - مصروف رقم ' + CAST(@NewExpenseID AS NVARCHAR(20));
        DECLARE @NewTxnID INT, @NewBalance DECIMAL(18,2);

        EXEC dbo.sp_Treasury_Add
             @TransactionTypeID = @ExpenseTransactionTypeID,
             @PaymentMethodID   = @PaymentMethodID,
             @SignedAmount      = @SignedAmount,
             @ExpenseID         = @NewExpenseID,
             @EmployeeID        = @PaidBy,
             @CreatedBy         = @UserID,
             @Notes             = @TreasuryNotes,
             @NewTransactionID  = @NewTxnID OUTPUT,
             @NewBalance        = @NewBalance OUTPUT;

        UPDATE dbo.EXPENSES SET Treasury_ID = @NewTxnID WHERE Expense_ID = @NewExpenseID;

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks, New_Value)
        VALUES (N'Expense', @NewExpenseID, N'Create', @UserID, GETDATE(), N'إنشاء مصروف جديد', CAST(@Amount AS NVARCHAR(50)));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Expense_Delete]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_Expense_Delete]
    @Expense_ID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. حذف الحركة المرتبطة في الخزينة (أو جعل الخانة NULL حسب تصميم النظام)
        DELETE FROM dbo.Treasury_Log 
        WHERE Expense_ID = @Expense_ID;

        -- إذا كانت الخزينة تحتفظ بالسجل ويتم فقط فك الربط، استخدم:
        -- UPDATE dbo.Treasury_Log SET Expense_ID = NULL WHERE Expense_ID = @ExpenseID;

        -- 2. حذف المصروف
        DELETE FROM dbo.Expenses 
        WHERE Expense_ID = @Expense_ID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Expense_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Expense_GetAll]
    @From       DATETIME2 = NULL,
    @To         DATETIME2 = NULL,
    @CategoryID INT       = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ex.*, ec.Category_Name, e.Full_Name AS Paid_By_Name
    FROM dbo.EXPENSES ex
    JOIN dbo.EXPENSE_CATEGORIES ec ON ex.Category_ID = ec.Category_ID
    LEFT JOIN dbo.EMPLOYEES     e  ON ex.Paid_By     = e.Employee_ID
    WHERE (@From       IS NULL OR ex.Expense_Date >= @From)
      AND (@To         IS NULL OR ex.Expense_Date <= @To)
      AND (@CategoryID IS NULL OR ex.Category_ID   = @CategoryID)
    ORDER BY ex.Expense_Date DESC
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Expense_Reverse]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------
-- 2.9  sp_Expense_Reverse : عكس مصروف بتسجيل حركة عكسية في الخزينة + تدقيق
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_Expense_Reverse]
    @ExpenseID                 INT,
    @ReversalTransactionTypeID INT,  -- الـ ID بتاع "عكس مصروف" في TRANSACTION_TYPES
    @UserID                    INT,
    @Reason                    NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @Amount DECIMAL(18,2), @PaymentMethodID INT;

        -- جلب بيانات المصروف مع قفل السجل لمنع التعديل المتزامن (Concurrency Control)
        SELECT @Amount = ex.Amount, 
               @PaymentMethodID = tl.Payment_Method_ID
        FROM dbo.EXPENSES ex WITH (UPDLOCK, ROWLOCK)
        LEFT JOIN dbo.TREASURY_LOG tl ON tl.Transation_ID = ex.Treasury_ID
        WHERE ex.Expense_ID = @ExpenseID;

        IF @Amount IS NULL
        BEGIN
            RAISERROR(N'المصروف غير موجود.', 16, 1);
        END

        -- تجهيز نص الملاحظات في متغير منفصل قبل استدعاء EXEC لتفادي خطأ (Syntax Error)
        DECLARE @Notes NVARCHAR(500) = N'عكس مصروف رقم ' + CAST(@ExpenseID AS NVARCHAR(20)) + N' - ' + ISNULL(@Reason, N'');
        DECLARE @NewTxnID INT, @NewBalance DECIMAL(18,2);

        EXEC dbo.sp_Treasury_Add
             @TransactionTypeID = @ReversalTransactionTypeID,
             @PaymentMethodID   = @PaymentMethodID,
             @SignedAmount      = @Amount,   -- إرجاع المبلغ للخزينة (قيمة موجبة)
             @ExpenseID         = @ExpenseID,
             @CreatedBy         = @UserID,
             @Notes             = @Notes,
             @NewTransactionID  = @NewTxnID OUTPUT,
             @NewBalance        = @NewBalance OUTPUT;

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks, Old_Value)
        VALUES (N'Expense', @ExpenseID, N'Reverse', @UserID, GETDATE(), ISNULL(@Reason, N'عكس مصروف'), CAST(@Amount AS NVARCHAR(50)));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Expense_Update]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- 2.8  sp_Expense_Update : ممنوع تغيير المبلغ بعد ما يترحّل في الخزينة (لأن
--      Balance_After في كل الصفوف اللي بعده هيبقى غلط لو غيرنا مبلغ قديم).
--      المسموح: تعديل البيانات الوصفية بس (الفئة / التاريخ / الملاحظات / مين دفع).
--      لو محتاج تصحيح مبلغ مصروف مترحّل: اعمل "عكس" (Reversal) عن طريق مصروف
--      تصحيحي جديد بعلامة سالبة أو موجبة بدل تعديل السجل القديم.
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_Expense_Update]
    @ExpenseID   INT,
    @CategoryID  INT,
    @ExpenseDate DATETIME2,
    @PaidBy      INT           = NULL,
    @UserID      INT,
    @Notes       NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM dbo.EXPENSES WHERE Expense_ID = @ExpenseID)
        BEGIN
            RAISERROR(N'المصروف غير موجود.', 16, 1);
        END

        UPDATE dbo.EXPENSES SET
            Category_ID  = @CategoryID,
            Expense_Date = @ExpenseDate,
            Paid_By      = @PaidBy,
            Notes        = @Notes
        WHERE Expense_ID = @ExpenseID;

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks)
        VALUES (N'Expense', @ExpenseID, N'Update', @UserID, GETDATE(), N'تعديل بيانات مصروف (بدون تغيير المبلغ)');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Expense_Void]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Expense_Void]
    @ExpenseID INT,
    @UserID INT,
    @Reason NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT OFF;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @Amount DECIMAL(18,2), @OldData NVARCHAR(MAX), @OriginalTransactionID INT,
                @PaymentMethodID INT, @InTypeID INT, @NewTransactionID INT, @NewBalance DECIMAL(18,2);
        SELECT @Amount=Amount,
               @OldData=(SELECT Expense_ID,Category_ID,Amount,Expense_Date,Paid_By,Notes,Is_Voided FROM dbo.EXPENSES WHERE Expense_ID=@ExpenseID FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM dbo.EXPENSES WITH (UPDLOCK,HOLDLOCK)
        WHERE Expense_ID=@ExpenseID AND Is_Voided=0;
        IF @OldData IS NULL THROW 50020, N'Expense does not exist or is already voided.', 1;

        SELECT TOP 1 @OriginalTransactionID=Transation_ID,@PaymentMethodID=Payment_Method_ID
        FROM dbo.TREASURY_LOG
        WHERE Expense_ID=@ExpenseID AND Reversal_Of_Transaction_ID IS NULL
        ORDER BY Transation_ID DESC;

        IF @OriginalTransactionID IS NOT NULL
        BEGIN
            SET @InTypeID=(SELECT TOP 1 Transaction_Type_ID FROM dbo.TRANSACTION_TYPES WHERE Type_Name=N'وارد');
            IF @InTypeID IS NULL THROW 50021, N'Transaction type وارد is missing.', 1;
            DECLARE @ReversalNotes NVARCHAR(500)=COALESCE(@Reason,N'Reversal of expense');
            EXEC dbo.sp_Treasury_Add
                @TransactionTypeID=@InTypeID,@PaymentMethodID=@PaymentMethodID,@Amount=@Amount,
                @ExpenseID=@ExpenseID,@Notes=@ReversalNotes,@UserID=@UserID,
                @ReversalOfTransactionID=@OriginalTransactionID,
                @NewTransactionID=@NewTransactionID OUTPUT,@NewBalance=@NewBalance OUTPUT;
        END

        UPDATE dbo.EXPENSES
        SET Is_Voided=1, Voided_At=GETDATE(), Voided_By=@UserID, Void_Reason=@Reason, Updated_At=GETDATE()
        WHERE Expense_ID=@ExpenseID;

        INSERT dbo.FINANCIAL_AUDIT_LOG
        (Entity_Type,Entity_ID,Action_Type,User_ID,Action_Date,Amount,Transaction_ID,Old_Data,New_Data,Remarks,Host_Name,Application_Name,Session_Login)
        SELECT N'Expense',@ExpenseID,N'VOID',@UserID,GETDATE(),@Amount,@NewTransactionID,@OldData,
               (SELECT Expense_ID,Category_ID,Amount,Expense_Date,Paid_By,Notes,Is_Voided,Voided_At,Voided_By,Void_Reason FROM dbo.EXPENSES WHERE Expense_ID=@ExpenseID FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
               COALESCE(@Reason,N'Expense voided'),HOST_NAME(),APP_NAME(),SUSER_SNAME();
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE()<>0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_FinancialAuditLog_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_FinancialAuditLog_Add]
    @EntityType NVARCHAR(50),
    @EntityID   INT,
    @ActionType NVARCHAR(50),
    @UserID     INT,
    @Remarks    NVARCHAR(500) = NULL,
    @NewLogID   INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.FINANCIAL_AUDIT_LOG
    (
        Entity_Type,
        Entity_ID,
        Action_Type,
        User_ID,
        Action_Date,
        Remarks
    )
    VALUES
    (
        @EntityType,
        @EntityID,
        @ActionType,
        @UserID,
        GETDATE(),
        @Remarks
    );

    SET @NewLogID = CAST(SCOPE_IDENTITY() AS INT);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_FinancialAuditLog_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ================================================================
   5) COMMON READ REPORT: complete audit trail
   ================================================================ */
CREATE   PROCEDURE [dbo].[sp_FinancialAuditLog_GetAll]
    @EntityType NVARCHAR(50) = NULL,
    @EntityID INT = NULL,
    @ActionType NVARCHAR(50) = NULL,
    @UserID INT = NULL,
    @From DATETIME2 = NULL,
    @To DATETIME2 = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        fal.Log_ID,
        fal.Entity_Type,
        fal.Entity_ID,
        fal.Action_Type,
        fal.User_ID,
        u.Username,
        e.Full_Name AS User_Full_Name,
        fal.Action_Date,
        fal.Amount,
        fal.Transaction_ID,
        fal.Old_Data,
        fal.New_Data,
        fal.Remarks,
        fal.Host_Name,
        fal.Application_Name,
        fal.Session_Login
    FROM dbo.FINANCIAL_AUDIT_LOG fal
    INNER JOIN dbo.USERS u ON fal.User_ID = u.User_ID
    LEFT JOIN dbo.EMPLOYEES e ON u.Employee_ID = e.Employee_ID
    WHERE (@EntityType IS NULL OR fal.Entity_Type = @EntityType)
      AND (@EntityID IS NULL OR fal.Entity_ID = @EntityID)
      AND (@ActionType IS NULL OR fal.Action_Type = @ActionType)
      AND (@UserID IS NULL OR fal.User_ID = @UserID)
      AND (@From IS NULL OR fal.Action_Date >= @From)
      AND (@To IS NULL OR fal.Action_Date < DATEADD(DAY, 1, CAST(@To AS DATE)))
    ORDER BY fal.Action_Date DESC, fal.Log_ID DESC;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_FinancialAuditLog_GetByEntity]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_FinancialAuditLog_GetByEntity]
    @EntityType NVARCHAR(50),
    @EntityID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        fal.Log_ID,
        fal.Entity_Type,
        fal.Entity_ID,
        fal.Action_Type,
        fal.User_ID,
        u.Username,
        e.Full_Name AS User_Full_Name,
        fal.Action_Date,
        fal.Amount,
        fal.Transaction_ID,
        fal.Old_Data,
        fal.New_Data,
        fal.Remarks,
        fal.Host_Name,
        fal.Application_Name,
        fal.Session_Login
    FROM dbo.FINANCIAL_AUDIT_LOG fal
    INNER JOIN dbo.USERS u ON fal.User_ID = u.User_ID
    LEFT JOIN dbo.EMPLOYEES e ON u.Employee_ID = e.Employee_ID
    WHERE fal.Entity_Type = @EntityType
      AND fal.Entity_ID = @EntityID
    ORDER BY fal.Action_Date ASC, fal.Log_ID ASC;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_Inventory_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Inventory_Add]
    @Barcode         NVARCHAR(50)  = NULL,
    @TechnicalNumber NVARCHAR(50)  = NULL,
    @PartName        NVARCHAR(200),
    @CategoryID      INT           = NULL,
    @BrandID         INT           = NULL,
    @UnitID          INT           = NULL,
    @PurchasePrice   DECIMAL(18,2),
    @MarkupPercent   DECIMAL(5,2),
    @SellingPrice    DECIMAL(18,2),
    @CurrentStock    INT,
    @MinLimit        INT,
    @CrossRefID      INT           = NULL,
    @SupplierID      INT           = NULL,
    @NewPartID       INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF @Barcode IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.INVENTORY WHERE Barcode = @Barcode AND Is_Deleted = 0)
    BEGIN
        RAISERROR(N'الباركود مستخدم بالفعل لقطعة أخرى.', 16, 1);
        RETURN;
    END

    INSERT INTO dbo.INVENTORY
        (Barcode, Technical_Number, Part_Name, Category_ID, Brand_ID, Unit_ID,
         Purchase_Price, Markup_Percent, Selling_Price, Current_Stock, Min_Limit,
         Cross_Ref_ID, Supplier_ID, Is_Deleted, Created_At, Updated_At)
    VALUES
        (@Barcode, @TechnicalNumber, @PartName, @CategoryID, @BrandID, @UnitID,
         @PurchasePrice, @MarkupPercent, @SellingPrice, @CurrentStock, @MinLimit,
         @CrossRefID, @SupplierID, 0, GETDATE(), GETDATE());

    SET @NewPartID = CAST(SCOPE_IDENTITY() AS INT);

    -- أول سعر بيع بيتسجل كأول سطر في تاريخ الأسعار تلقائيًا
    INSERT INTO dbo.PRICE_HISTORY (Part_ID, Price, Start_Date)
    VALUES (@NewPartID, @SellingPrice, GETDATE());
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inventory_AdjustStock]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ================================================================
   13) INVENTORY financial/audit movements
   ================================================================ */
CREATE   PROCEDURE [dbo].[sp_Inventory_AdjustStock]
    @PartID INT,
    @Delta INT,
    @MovementTypeID INT,
    @UserID INT,
    @Remarks NVARCHAR(200)=NULL
AS
BEGIN
    SET NOCOUNT OFF;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @OldStock INT,@OldData NVARCHAR(MAX);
        SELECT @OldStock=Current_Stock,@OldData=(SELECT Part_ID,Part_Name,Purchase_Price,Selling_Price,Current_Stock FROM dbo.INVENTORY WHERE Part_ID=@PartID AND Is_Deleted=0 FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM dbo.INVENTORY WITH(UPDLOCK,HOLDLOCK) WHERE Part_ID=@PartID AND Is_Deleted=0;
        IF @OldData IS NULL THROW 50140,N'Part does not exist.',1;
        IF @OldStock+@Delta<0 THROW 50141,N'Stock cannot become negative.',1;

        UPDATE dbo.INVENTORY SET Current_Stock=Current_Stock+@Delta,Updated_At=GETDATE() WHERE Part_ID=@PartID;
        INSERT dbo.AUDIT_LOG(Part_ID,Movement_Type_ID,Quantity_Change,User_ID,Action_Date,Remarks) VALUES(@PartID,@MovementTypeID,@Delta,@UserID,GETDATE(),@Remarks);
        INSERT dbo.FINANCIAL_AUDIT_LOG
        (Entity_Type,Entity_ID,Action_Type,User_ID,Action_Date,Amount,Old_Data,New_Data,Remarks,Host_Name,Application_Name,Session_Login)
        VALUES(N'Inventory',@PartID,N'STOCK_ADJUSTMENT',@UserID,GETDATE(),ABS(@Delta),@OldData,
               (SELECT Part_ID,Part_Name,Purchase_Price,Selling_Price,Current_Stock FROM dbo.INVENTORY WHERE Part_ID=@PartID FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
               COALESCE(@Remarks,N'Stock adjustment'),HOST_NAME(),APP_NAME(),SUSER_SNAME());
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE()<>0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_Inventory_BarcodeExists]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Inventory_BarcodeExists]
    @Barcode       NVARCHAR(50),
    @ExcludePartID INT = NULL,
    @Exists        BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @Exists = CASE WHEN EXISTS (
        SELECT 1 FROM dbo.INVENTORY
        WHERE Barcode = @Barcode AND Is_Deleted = 0
          AND (@ExcludePartID IS NULL OR Part_ID <> @ExcludePartID)
    ) THEN 1 ELSE 0 END;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inventory_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Inventory_GetAll]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT i.*, c.Category_Name, b.Brand_Name, u.Unit_Name, s.Supplier_Name
    FROM dbo.INVENTORY i
    LEFT JOIN dbo.CATEGORIES c ON i.Category_ID = c.Category_ID
    LEFT JOIN dbo.BRANDS     b ON i.Brand_ID    = b.Brand_ID
    LEFT JOIN dbo.UNITS      u ON i.Unit_ID     = u.Unit_ID
    LEFT JOIN dbo.SUPPLIERS  s ON i.Supplier_ID = s.Supplier_ID
    WHERE i.Is_Deleted = 0
    ORDER BY i.Part_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inventory_GetByBarcode]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Inventory_GetByBarcode]
    @Barcode NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT i.*, c.Category_Name, b.Brand_Name, u.Unit_Name, s.Supplier_Name
    FROM dbo.INVENTORY i
    LEFT JOIN dbo.CATEGORIES c ON i.Category_ID = c.Category_ID
    LEFT JOIN dbo.BRANDS     b ON i.Brand_ID    = b.Brand_ID
    LEFT JOIN dbo.UNITS      u ON i.Unit_ID     = u.Unit_ID
    LEFT JOIN dbo.SUPPLIERS  s ON i.Supplier_ID = s.Supplier_ID
    WHERE i.Is_Deleted = 0 AND i.Barcode = @Barcode;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inventory_GetByID]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Inventory_GetByID]
    @PartID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT i.*, c.Category_Name, b.Brand_Name, u.Unit_Name, s.Supplier_Name
    FROM dbo.INVENTORY i
    LEFT JOIN dbo.CATEGORIES c ON i.Category_ID = c.Category_ID
    LEFT JOIN dbo.BRANDS     b ON i.Brand_ID    = b.Brand_ID
    LEFT JOIN dbo.UNITS      u ON i.Unit_ID     = u.Unit_ID
    LEFT JOIN dbo.SUPPLIERS  s ON i.Supplier_ID = s.Supplier_ID
    WHERE i.Is_Deleted = 0 AND i.Part_ID = @PartID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inventory_Search]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Inventory_Search]
    @Keyword     NVARCHAR(200) = NULL,
    @CategoryID  INT           = NULL,
    @BrandID     INT           = NULL,
    @StockFilter NVARCHAR(10)  = NULL   -- 'low' | 'zero' | NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @kw NVARCHAR(202) = N'%' + ISNULL(@Keyword,'') + N'%';

    SELECT i.*, c.Category_Name, b.Brand_Name, u.Unit_Name, s.Supplier_Name
    FROM dbo.INVENTORY i
    LEFT JOIN dbo.CATEGORIES c ON i.Category_ID = c.Category_ID
    LEFT JOIN dbo.BRANDS     b ON i.Brand_ID    = b.Brand_ID
    LEFT JOIN dbo.UNITS      u ON i.Unit_ID     = u.Unit_ID
    LEFT JOIN dbo.SUPPLIERS  s ON i.Supplier_ID = s.Supplier_ID
    WHERE i.Is_Deleted = 0
      AND (@Keyword    IS NULL OR i.Part_Name LIKE @kw OR i.Barcode LIKE @kw OR i.Technical_Number LIKE @kw)
      AND (@CategoryID IS NULL OR i.Category_ID = @CategoryID)
      AND (@BrandID    IS NULL OR i.Brand_ID    = @BrandID)
      AND (
            @StockFilter IS NULL
         OR (@StockFilter = 'low'  AND i.Current_Stock <= i.Min_Limit AND i.Current_Stock > 0)
         OR (@StockFilter = 'zero' AND i.Current_Stock = 0)
          )
    ORDER BY i.Part_Name
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inventory_SoftDelete]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Inventory_SoftDelete]
    @PartID INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.INVENTORY SET Is_Deleted = 1, Updated_At = GETDATE() WHERE Part_ID = @PartID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inventory_Update]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Inventory_Update]
    @PartID          INT,
    @Barcode         NVARCHAR(50)  = NULL,
    @TechnicalNumber NVARCHAR(50)  = NULL,
    @PartName        NVARCHAR(200),
    @CategoryID      INT           = NULL,
    @BrandID         INT           = NULL,
    @UnitID          INT           = NULL,
    @PurchasePrice   DECIMAL(18,2),
    @MarkupPercent   DECIMAL(5,2),
    @SellingPrice    DECIMAL(18,2),
    @MinLimit        INT,
    @CrossRefID      INT           = NULL,
    @SupplierID      INT           = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @Barcode IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.INVENTORY WHERE Barcode = @Barcode AND Is_Deleted = 0 AND Part_ID <> @PartID)
    BEGIN
        RAISERROR(N'The Barcode is already registered for another Part.', 16, 1);
        RETURN;
    END

    UPDATE dbo.INVENTORY SET
        Barcode          = @Barcode,
        Technical_Number = @TechnicalNumber,
        Part_Name        = @PartName,
        Category_ID      = @CategoryID,
        Brand_ID         = @BrandID,
        Unit_ID          = @UnitID,
        Purchase_Price   = @PurchasePrice,
        Markup_Percent   = @MarkupPercent,
        Selling_Price    = @SellingPrice,
        Min_Limit        = @MinLimit,
        Cross_Ref_ID     = @CrossRefID,
        Supplier_ID      = @SupplierID,
        Updated_At       = GETDATE()
    WHERE Part_ID = @PartID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Inventory_UpdatePrice]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Inventory_UpdatePrice]
    @PartID INT,
    @NewSellingPrice DECIMAL(18,2),
    @UserID INT
AS
BEGIN
    SET NOCOUNT OFF;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        IF @NewSellingPrice<0 THROW 50150,N'Selling price cannot be negative.',1;
        DECLARE @OldData NVARCHAR(MAX);
        SELECT @OldData=(SELECT Part_ID,Purchase_Price,Selling_Price,Markup_Percent FROM dbo.INVENTORY WHERE Part_ID=@PartID AND Is_Deleted=0 FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM dbo.INVENTORY WITH(UPDLOCK,HOLDLOCK) WHERE Part_ID=@PartID AND Is_Deleted=0;
        IF @OldData IS NULL THROW 50151,N'Part does not exist.',1;

        UPDATE dbo.PRICE_HISTORY SET End_Date=CAST(GETDATE() AS DATE) WHERE Part_ID=@PartID AND End_Date IS NULL;
        INSERT dbo.PRICE_HISTORY(Part_ID,Price,Start_Date) VALUES(@PartID,@NewSellingPrice,CAST(GETDATE() AS DATE));
        UPDATE dbo.INVENTORY SET Selling_Price=@NewSellingPrice,Updated_At=GETDATE() WHERE Part_ID=@PartID;

        INSERT dbo.FINANCIAL_AUDIT_LOG
        (Entity_Type,Entity_ID,Action_Type,User_ID,Action_Date,Amount,Old_Data,New_Data,Remarks,Host_Name,Application_Name,Session_Login)
        VALUES(N'Inventory',@PartID,N'PRICE_CHANGE',@UserID,GETDATE(),@NewSellingPrice,@OldData,
               (SELECT Part_ID,Purchase_Price,Selling_Price,Markup_Percent FROM dbo.INVENTORY WHERE Part_ID=@PartID FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
               N'Selling price changed',HOST_NAME(),APP_NAME(),SUSER_SNAME());
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE()<>0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_AddBrand]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_AddBrand]
    @Name    NVARCHAR(100),
    @Country NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.BRANDS WHERE Brand_Name = @Name)
    BEGIN
        RAISERROR(N'The brand already exists.', 16, 1);
        RETURN;
    END
    INSERT INTO dbo.BRANDS (Brand_Name, Country) VALUES (@Name, @Country);
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NewID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_AddCategory]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_AddCategory]
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.CATEGORIES WHERE Category_Name = @Name)
    BEGIN
        RAISERROR(N'The category already exists.', 16, 1);
        RETURN;
    END
    INSERT INTO dbo.CATEGORIES (Category_Name) VALUES (@Name);
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NewID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_AddExpenseCategory]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_AddExpenseCategory]
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.EXPENSE_CATEGORIES WHERE Category_Name = @Name)
    BEGIN
        RAISERROR(N'The category already exists.', 16, 1);
        RETURN;
    END
    INSERT INTO dbo.EXPENSE_CATEGORIES (Category_Name) VALUES (@Name);
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NewID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_AddPosition]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_AddPosition]
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.EMPLOYEE_POSITIONS WHERE Position_Name = @Name)
    BEGIN
        RAISERROR(N'The position already exists.', 16, 1);
        RETURN;
    END
    INSERT INTO dbo.EMPLOYEE_POSITIONS (Position_Name) VALUES (@Name);
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NewID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_AddUnit]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_AddUnit]
    @Name NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.UNITS WHERE Unit_Name = @Name)
    BEGIN
        RAISERROR(N'The Unit already exists.', 16, 1);
        RETURN;
    END
    INSERT INTO dbo.UNITS (Unit_Name) VALUES (@Name);
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NewID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllAdvanceStatuses]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllAdvanceStatuses]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Status_ID, Status_Name FROM dbo.ADVANCE_STATUS ORDER BY Status_ID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllBrands]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllBrands]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Brand_ID, Brand_Name, Country FROM dbo.BRANDS ORDER BY Brand_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllCategories]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllCategories]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Category_ID, Category_Name FROM dbo.CATEGORIES ORDER BY Category_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllCustomerTypes]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllCustomerTypes]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Customer_Type_ID, Type_Name FROM dbo.CUSTOMER_TYPES ORDER BY Type_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllExpenseCategories]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllExpenseCategories]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Category_ID, Category_Name FROM dbo.EXPENSE_CATEGORIES ORDER BY Category_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllItemStatuses]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllItemStatuses]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Status_ID, Status_Name FROM dbo.ITEM_STATUS ORDER BY Status_ID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllMovementTypes]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllMovementTypes]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Movement_Type_ID, Type_Name FROM dbo.MOVEMENT_TYPES ORDER BY Movement_Type_ID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllPaymentMethods]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllPaymentMethods]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Payment_Method_ID, Method_Name
    FROM dbo.PAYMENT_METHODS
    ORDER BY Method_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllPaymentStatuses]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllPaymentStatuses]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Status_ID, Status_Name FROM dbo.PAYMENT_STATUS ORDER BY Status_ID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllPositions]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Lookup_GetAllPositions]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Position_ID, Position_Name
    FROM dbo.EMPLOYEE_POSITIONS
    ORDER BY Position_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllPOStatuses]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllPOStatuses]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Status_ID, Status_Name FROM dbo.PURCHASE_ORDER_STATUS ORDER BY Status_ID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllTransactionTypes]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllTransactionTypes]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Transaction_Type_ID, Type_Name FROM dbo.TRANSACTION_TYPES;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Lookup_GetAllUnits]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lookup_GetAllUnits]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Unit_ID, Unit_Name FROM dbo.UNITS ORDER BY Unit_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Payroll_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------
-- 2.12 sp_Payroll_Add : تسجيل صرف المرتب في الخزينة تلقائيًا + تدقيق
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_Payroll_Add]
    @EmployeeID               INT,
    @AmountPaid               DECIMAL(18,2),
    @Deductions               DECIMAL(18,2) = 0,
    @Bonuses                  DECIMAL(18,2) = 0,
    @PaymentDate              DATETIME2,
    @MonthYear                NVARCHAR(7),
    @PaymentMethodID          INT,
    @PayrollTransactionTypeID INT,   -- الـ ID بتاع "صرف مرتبات" في TRANSACTION_TYPES
    @UserID                   INT,
    @Notes                    NVARCHAR(500) = NULL,
    @NewPayrollID             INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @AmountPaid < 0 OR @Deductions < 0 OR @Bonuses < 0
    BEGIN
        RAISERROR(N'قيم المرتب لا يمكن أن تكون سالبة.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS (
            SELECT 1 FROM dbo.PAYROLL WITH (UPDLOCK, HOLDLOCK)
            WHERE Employee_ID = @EmployeeID AND Month_Year = @MonthYear
        )
        BEGIN
            RAISERROR(N'تم صرف مرتب هذا الشهر لهذا الموظف من قبل.', 16, 1);
        END

        INSERT INTO dbo.PAYROLL (Employee_ID, Amount_Paid, Deductions, Bonuses, Payment_Date, Month_Year, Notes, Created_At)
        VALUES (@EmployeeID, @AmountPaid, @Deductions, @Bonuses, @PaymentDate, @MonthYear, @Notes, GETDATE());

        SET @NewPayrollID = CAST(SCOPE_IDENTITY() AS INT);

        DECLARE @NetPaid DECIMAL(18,2) = @AmountPaid - @Deductions + @Bonuses;
        DECLARE @NewTxnID INT, @NewBalance DECIMAL(18,2);

        IF @NetPaid <> 0
        BEGIN
            -- تجهيز القيم الحسابية والنصية في متغيرات قبل استدعاء EXEC
            DECLARE @SignedAmount DECIMAL(18,2) = -@NetPaid;
            DECLARE @TreasuryNotes NVARCHAR(500) = N'صرف مرتب ' + ISNULL(@MonthYear, N'') + N' للموظف رقم ' + CAST(@EmployeeID AS NVARCHAR(20));

            EXEC dbo.sp_Treasury_Add
                 @TransactionTypeID = @PayrollTransactionTypeID,
                 @PaymentMethodID   = @PaymentMethodID,
                 @SignedAmount      = @SignedAmount,
                 @PayrollID         = @NewPayrollID,
                 @EmployeeID        = @EmployeeID,
                 @CreatedBy         = @UserID,
                 @Notes             = @TreasuryNotes,
                 @NewTransactionID  = @NewTxnID OUTPUT,
                 @NewBalance        = @NewBalance OUTPUT;
        END

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks, New_Value)
        VALUES (N'Payroll', @NewPayrollID, N'Create', @UserID, GETDATE(), N'صرف مرتب', CAST(@NetPaid AS NVARCHAR(50)));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Payroll_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Payroll_GetAll]
    @MonthYear  NVARCHAR(7) = NULL,
    @EmployeeID INT         = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.*, e.Full_Name
    FROM dbo.PAYROLL p
    JOIN dbo.EMPLOYEES e ON p.Employee_ID = e.Employee_ID
    WHERE (@MonthYear  IS NULL OR p.Month_Year = @MonthYear)
      AND (@EmployeeID IS NULL OR p.Employee_ID = @EmployeeID)
    ORDER BY p.Payment_Date DESC
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Payroll_MonthYearExists]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Payroll_MonthYearExists]
    @EmployeeID INT,
    @MonthYear  NVARCHAR(7),
    @Exists     BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @Exists = CASE WHEN EXISTS (
        SELECT 1 FROM dbo.PAYROLL WHERE Employee_ID = @EmployeeID AND Month_Year = @MonthYear
    ) THEN 1 ELSE 0 END;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PriceHistory_AddRecord]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PriceHistory_AddRecord]
    @PartID    INT,
    @Price     DECIMAL(18,2),
    @StartDate DATETIME2
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.PRICE_HISTORY (Part_ID, Price, Start_Date) VALUES (@PartID, @Price, @StartDate);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PriceHistory_CloseCurrent]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PriceHistory_CloseCurrent]
    @PartID  INT,
    @EndDate DATETIME2
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.PRICE_HISTORY SET End_Date = @EndDate WHERE Part_ID = @PartID AND End_Date IS NULL;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PriceHistory_GetByPart]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PriceHistory_GetByPart]
    @PartID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ph.*, i.Part_Name
    FROM dbo.PRICE_HISTORY ph
    JOIN dbo.INVENTORY i ON ph.Part_ID = i.Part_ID
    WHERE ph.Part_ID = @PartID
    ORDER BY ph.Start_Date DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PurchaseOrder_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- 2.4  sp_PurchaseOrder_Add : تحقق أقوى + تسجيل تدقيق
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_PurchaseOrder_Add]
    @SupplierID INT,
    @EmployeeID INT,
    @OrderDate  DATETIME2,
    @PaidAmount DECIMAL(18,2) = 0,
    @StatusID   INT,
    @UserID     INT,
    @Notes      NVARCHAR(500) = NULL,
    @Details    dbo.PODetailTableType READONLY,
    @NewPOID    INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS (SELECT 1 FROM @Details)
    BEGIN
        RAISERROR(N'لا يمكن حفظ أمر شراء بدون أي أصناف.', 16, 1);
        RETURN;
    END

    IF @PaidAmount < 0
    BEGIN
        RAISERROR(N'المبلغ المدفوع لا يمكن أن يكون سالبًا.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @TotalAmount DECIMAL(18,2);
        SELECT @TotalAmount = SUM(Quantity * Unit_Price) FROM @Details;

        IF @PaidAmount > @TotalAmount
            RAISERROR(N'المبلغ المدفوع أكبر من إجمالي أمر الشراء.', 16, 1);

        INSERT INTO dbo.PURCHASE_ORDERS (Supplier_ID, Employee_ID, Order_Date, Total_Amount, Paid_Amount, Status_ID, Notes, Created_At)
        VALUES (@SupplierID, @EmployeeID, @OrderDate, @TotalAmount, @PaidAmount, @StatusID, @Notes, GETDATE());

        SET @NewPOID = CAST(SCOPE_IDENTITY() AS INT);

        INSERT INTO dbo.PURCHASE_ORDER_DETAILS (PO_ID, Part_ID, Quantity, Unit_Price)
        SELECT @NewPOID, Part_ID, Quantity, Unit_Price FROM @Details;

        IF (@TotalAmount - @PaidAmount) <> 0
        BEGIN
            UPDATE dbo.SUPPLIERS WITH (ROWLOCK, UPDLOCK)
            SET Supplier_Balance = Supplier_Balance + (@TotalAmount - @PaidAmount)
            WHERE Supplier_ID = @SupplierID;
        END

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks, New_Value)
        VALUES (N'PurchaseOrder', @NewPOID, N'Create', @UserID, GETDATE(),
                N'إنشاء أمر شراء جديد', CAST(@TotalAmount AS NVARCHAR(50)));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PurchaseOrder_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PurchaseOrder_GetAll]
    @SupplierID INT = NULL,
    @StatusID   INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT po.*, s.Supplier_Name, e.Full_Name AS Employee_Name, pos2.Status_Name
    FROM dbo.PURCHASE_ORDERS po
    JOIN dbo.SUPPLIERS             s    ON po.Supplier_ID = s.Supplier_ID
    JOIN dbo.EMPLOYEES             e    ON po.Employee_ID = e.Employee_ID
    JOIN dbo.PURCHASE_ORDER_STATUS pos2 ON po.Status_ID   = pos2.Status_ID
    WHERE (@SupplierID IS NULL OR po.Supplier_ID = @SupplierID)
      AND (@StatusID   IS NULL OR po.Status_ID   = @StatusID)
    ORDER BY po.Order_Date DESC
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PurchaseOrder_GetByID]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PurchaseOrder_GetByID]
    @POID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT po.*, s.Supplier_Name, e.Full_Name AS Employee_Name, pos2.Status_Name
    FROM dbo.PURCHASE_ORDERS po
    JOIN dbo.SUPPLIERS             s    ON po.Supplier_ID = s.Supplier_ID
    JOIN dbo.EMPLOYEES             e    ON po.Employee_ID = e.Employee_ID
    JOIN dbo.PURCHASE_ORDER_STATUS pos2 ON po.Status_ID   = pos2.Status_ID
    WHERE po.PO_ID = @POID;

    SELECT pod.*, i.Part_Name
    FROM dbo.PURCHASE_ORDER_DETAILS pod
    JOIN dbo.INVENTORY i ON pod.Part_ID = i.Part_ID
    WHERE pod.PO_ID = @POID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PurchaseOrder_Receive]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- 2.5  sp_PurchaseOrder_Receive : منع الاستلام المزدوج + دعم استلام جزئي + تسجيل تدقيق
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_PurchaseOrder_Receive]
    @POID                   INT,
    @ReceivedStatusID       INT,
    @PurchaseMovementTypeID INT,
    @UserID                 INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS (
            SELECT 1 FROM dbo.PURCHASE_ORDERS WITH (UPDLOCK, ROWLOCK)
            WHERE PO_ID = @POID AND Status_ID = @ReceivedStatusID
        )
        BEGIN
            RAISERROR(N'أمر الشراء هذا تم استلامه بالفعل.', 16, 1);
        END

        IF NOT EXISTS (SELECT 1 FROM dbo.PURCHASE_ORDERS WHERE PO_ID = @POID)
        BEGIN
            RAISERROR(N'أمر الشراء غير موجود.', 16, 1);
        END

        UPDATE i
        SET i.Current_Stock = i.Current_Stock + (pod.Quantity - pod.Received_Quantity),
            i.Updated_At     = GETDATE()
        FROM dbo.INVENTORY i
        JOIN dbo.PURCHASE_ORDER_DETAILS pod ON pod.Part_ID = i.Part_ID
        WHERE pod.PO_ID = @POID AND pod.Received_Quantity < pod.Quantity;

        INSERT INTO dbo.AUDIT_LOG (Part_ID, Movement_Type_ID, Quantity_Change, User_ID, Action_Date, Remarks)
        SELECT Part_ID, @PurchaseMovementTypeID, (Quantity - Received_Quantity), @UserID, GETDATE(),
               N'استلام أمر شراء رقم ' + CAST(@POID AS NVARCHAR(20))
        FROM dbo.PURCHASE_ORDER_DETAILS
        WHERE PO_ID = @POID AND Received_Quantity < Quantity;

        UPDATE dbo.PURCHASE_ORDER_DETAILS
        SET Received_Quantity = Quantity
        WHERE PO_ID = @POID;

        UPDATE dbo.PURCHASE_ORDERS
        SET Status_ID = @ReceivedStatusID, Received_At = GETDATE()
        WHERE PO_ID = @POID;

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks)
        VALUES (N'PurchaseOrder', @POID, N'Receive', @UserID, GETDATE(), N'استلام بضاعة أمر الشراء');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PurchaseOrder_UpdatePayment]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_PurchaseOrder_UpdatePayment]
    @POID                    INT,
    @AdditionalPaid          DECIMAL(18,2),
    @PaymentMethodID         INT,
    @PaymentTransactionTypeID INT,   -- الـ ID بتاع "سداد مورد" في TRANSACTION_TYPES
    @UserID                  INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @AdditionalPaid <= 0
    BEGIN
        RAISERROR(N'قيمة السداد يجب أن تكون أكبر من صفر.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @SupplierID INT, @TotalAmount DECIMAL(18,2), @CurrentPaid DECIMAL(18,2);

        SELECT @SupplierID  = Supplier_ID,
               @TotalAmount = Total_Amount,
               @CurrentPaid = Paid_Amount
        FROM dbo.PURCHASE_ORDERS WITH (UPDLOCK, ROWLOCK)
        WHERE PO_ID = @POID;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR(N'أمر الشراء غير موجود.', 16, 1);
        END

        IF (@CurrentPaid + @AdditionalPaid) > @TotalAmount
        BEGIN
            RAISERROR(N'مبلغ السداد يتجاوز المتبقي على أمر الشراء.', 16, 1);
        END

        UPDATE dbo.PURCHASE_ORDERS 
        SET Paid_Amount = Paid_Amount + @AdditionalPaid 
        WHERE PO_ID = @POID;

        UPDATE dbo.SUPPLIERS WITH (UPDLOCK)
        SET Supplier_Balance = Supplier_Balance - @AdditionalPaid
        WHERE Supplier_ID = @SupplierID;

        -- FIX: Pre-calculate expression variables before EXEC
        DECLARE @Notes NVARCHAR(200) = N'سداد دفعة لأمر شراء رقم ' + CAST(@POID AS NVARCHAR(20));
        DECLARE @SignedAmount DECIMAL(18,2) = -@AdditionalPaid;
        DECLARE @NewTxnID INT, @NewBalance DECIMAL(18,2);

        EXEC dbo.sp_Treasury_Add
             @TransactionTypeID = @PaymentTransactionTypeID,
             @PaymentMethodID   = @PaymentMethodID,
             @SignedAmount      = @SignedAmount,
             @POID              = @POID,
             @CreatedBy         = @UserID,
             @Notes             = @Notes,
             @NewTransactionID  = @NewTxnID OUTPUT,
             @NewBalance        = @NewBalance OUTPUT;

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks, New_Value)
        VALUES (N'PurchaseOrder', @POID, N'PaymentUpdate', @UserID, GETDATE(), N'سداد دفعة للمورد', CAST(@AdditionalPaid AS NVARCHAR(50)));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PurchaseOrder_UpdateStatus]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PurchaseOrder_UpdateStatus]
    @POID        INT,
    @NewStatusID INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.PURCHASE_ORDERS SET Status_ID = @NewStatusID WHERE PO_ID = @POID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Report_CurrentTreasuryBalance]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ================================================================
   15) REPORT PROCEDURES: reads stay NOCOUNT ON
   ================================================================ */
CREATE   PROCEDURE [dbo].[sp_Report_CurrentTreasuryBalance]
AS BEGIN SET NOCOUNT ON; SELECT * FROM dbo.V_Current_Treasury_Balance; END;

GO
/****** Object:  StoredProcedure [dbo].[sp_Report_DailyCashFlow]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_Report_DailyCashFlow] @From DATE=NULL,@To DATE=NULL
AS BEGIN SET NOCOUNT ON; SELECT * FROM dbo.V_Daily_Cash_Flow WHERE (@From IS NULL OR Flow_Date>=@From) AND (@To IS NULL OR Flow_Date<=@To) ORDER BY Flow_Date DESC; END;

GO
/****** Object:  StoredProcedure [dbo].[sp_Report_DailyProfits]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_Report_DailyProfits] @From DATE=NULL,@To DATE=NULL
AS BEGIN SET NOCOUNT ON; SELECT * FROM dbo.V_Daily_Profit WHERE (@From IS NULL OR Sale_Date>=@From) AND (@To IS NULL OR Sale_Date<=@To) ORDER BY Sale_Date DESC; END;

GO
/****** Object:  StoredProcedure [dbo].[sp_Report_EmployeePerformance]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Report_EmployeePerformance]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.V_Employee_Performance ORDER BY Total_Sales DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Report_InventoryValuation]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Report_InventoryValuation]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.V_Inventory_Valuation ORDER BY Value_At_Cost DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Report_InvoiceProfits]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Report_InvoiceProfits]
    @From DATETIME2 = NULL,
    @To   DATETIME2 = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.V_Invoice_Profit
    WHERE (@From IS NULL OR Date_Time >= @From)
      AND (@To   IS NULL OR Date_Time <= @To)
    ORDER BY Date_Time DESC
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Report_LowStockSuggestions]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Report_LowStockSuggestions]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.V_Reorder_Suggestion ORDER BY Shortage DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Report_MonthlyProfits]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_Report_MonthlyProfits] @Year INT=NULL
AS BEGIN SET NOCOUNT ON; SELECT * FROM dbo.V_Monthly_Profit WHERE (@Year IS NULL OR Month_Year LIKE CONVERT(NVARCHAR(4),@Year)+'%') ORDER BY Month_Year DESC; END;

GO
/****** Object:  StoredProcedure [dbo].[sp_Report_TopCustomers]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Report_TopCustomers]
    @Top INT = 20
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP (@Top) *
    FROM dbo.V_Top_Customers
    ORDER BY Total_Purchases DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Report_TopSellingParts]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Report_TopSellingParts]
    @Top INT = 10
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP (@Top) *
    FROM dbo.V_Top_Selling_Parts
    ORDER BY Total_Qty_Sold DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Returns_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- 2.16 sp_Returns_Add : تحقق من الكمية المتاحة للإرجاع + Transaction كامل + تدقيق
--      (كانت بترجع كمية بدون التأكد إنها فعلاً كانت في الفاتورة الأصلية)
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_Returns_Add]
    @InvoiceID             INT,
    @PartID                INT,
    @Quantity              INT,
    @Reason                NVARCHAR(250) = NULL,
    @StatusID              INT,
    @ReturnDate            DATETIME2,
    @RestockOnAccept       BIT = 0,
    @AcceptedStatusID      INT = NULL,
    @RestockMovementTypeID INT = NULL,
    @UserID                INT,
    @NewReturnID           INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @Quantity <= 0
    BEGIN
        RAISERROR(N'كمية المرتجع يجب أن تكون أكبر من صفر.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @SoldQty INT, @AlreadyReturnedQty INT;

        SELECT @SoldQty = SUM(Quantity) FROM dbo.INVOICE_DETAILS WHERE Invoice_ID = @InvoiceID AND Part_ID = @PartID;

        SELECT @AlreadyReturnedQty = ISNULL(SUM(Quantity), 0)
        FROM dbo.RETURNS
        WHERE Invoice_ID = @InvoiceID AND Part_ID = @PartID AND Status_ID = @AcceptedStatusID;

        IF @SoldQty IS NULL OR (@AlreadyReturnedQty + @Quantity) > @SoldQty
        BEGIN
            RAISERROR(N'الكمية المطلوب إرجاعها أكبر من الكمية المباعة فعليًا في هذه الفاتورة.', 16, 1);
        END

        INSERT INTO dbo.RETURNS (Invoice_ID, Part_ID, Quantity, Reason, Status_ID, Return_Date, Created_At)
        VALUES (@InvoiceID, @PartID, @Quantity, @Reason, @StatusID, @ReturnDate, GETDATE());

        SET @NewReturnID = CAST(SCOPE_IDENTITY() AS INT);

        IF @RestockOnAccept = 1 AND @StatusID = @AcceptedStatusID
        BEGIN
            UPDATE dbo.INVENTORY WITH (ROWLOCK, UPDLOCK)
            SET Current_Stock = Current_Stock + @Quantity, Updated_At = GETDATE()
            WHERE Part_ID = @PartID;

            IF @RestockMovementTypeID IS NOT NULL
                INSERT INTO dbo.AUDIT_LOG (Part_ID, Movement_Type_ID, Quantity_Change, User_ID, Action_Date, Remarks)
                VALUES (@PartID, @RestockMovementTypeID, @Quantity, @UserID, GETDATE(),
                        N'مرتجع مقبول - رقم ' + CAST(@NewReturnID AS NVARCHAR(20)));
        END

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks)
        VALUES (N'Return', @NewReturnID, N'Create', @UserID, GETDATE(), N'تسجيل مرتجع على فاتورة رقم ' + CAST(@InvoiceID AS NVARCHAR(20)));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Returns_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Returns_GetAll]
    @From DATETIME2 = NULL,
    @To   DATETIME2 = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT r.*, i.Part_Name, its.Status_Name
    FROM dbo.RETURNS r
    JOIN dbo.INVENTORY   i   ON r.Part_ID   = i.Part_ID
    JOIN dbo.ITEM_STATUS its ON r.Status_ID = its.Status_ID
    WHERE (@From IS NULL OR r.Return_Date >= @From)
      AND (@To   IS NULL OR r.Return_Date <= @To)
    ORDER BY r.Return_Date DESC
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SalesInvoice_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ============================================================================
   2) FIX SALES PROCEDURE
   Every NEW invoice detail gets Unit_Cost from Inventory while the inventory
   row is locked inside the transaction.
============================================================================ */

CREATE   PROCEDURE [dbo].[sp_SalesInvoice_Add]
    @CustomerID         INT              = NULL,
    @EmployeeID         INT,
    @DateTime           DATETIME2,
    @Discount           DECIMAL(18,2)    = 0,
    @PaidAmount         DECIMAL(18,2)    = 0,
    @PaymentStatusID    INT,
    @SaleMovementTypeID INT,
    @UserID             INT,
    @Details            dbo.InvoiceDetailTableType READONLY,
    @NewInvoiceID       INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS (SELECT 1 FROM @Details)
    BEGIN
        RAISERROR(N'لا يمكن حفظ فاتورة بدون أي أصناف.', 16, 1);
        RETURN;
    END;

    IF @Discount < 0 OR @PaidAmount < 0
    BEGIN
        RAISERROR(N'قيم الخصم أو المدفوع لا يمكن أن تكون سالبة.', 16, 1);
        RETURN;
    END;

    BEGIN TRY
        BEGIN TRANSACTION;

        /*
          Lock inventory rows first.
          This both validates stock and guarantees that Unit_Cost is captured
          consistently for this sale.
        */
        IF EXISTS
        (
            SELECT 1
            FROM dbo.INVENTORY i WITH (ROWLOCK, UPDLOCK)
            INNER JOIN @Details d ON d.Part_ID = i.Part_ID
            WHERE i.Current_Stock < d.Quantity
               OR i.Is_Deleted = 1
        )
        BEGIN
            RAISERROR(N'رصيد المخزون غير كافٍ لأحد الأصناف في الفاتورة.', 16, 1);
        END;

        IF EXISTS
        (
            SELECT 1
            FROM @Details
            WHERE Quantity <= 0 OR Unit_Price < 0
        )
        BEGIN
            RAISERROR(N'الكمية يجب أن تكون أكبر من صفر والسعر لا يمكن أن يكون سالبًا.', 16, 1);
        END;

        DECLARE @TotalAmount DECIMAL(18,2);

        SELECT @TotalAmount = SUM(Quantity * Unit_Price)
        FROM @Details;

        IF @Discount > @TotalAmount
            RAISERROR(N'قيمة الخصم أكبر من إجمالي الفاتورة.', 16, 1);

        IF @PaidAmount > (@TotalAmount - @Discount)
            RAISERROR(N'المبلغ المدفوع أكبر من صافي الفاتورة.', 16, 1);

        INSERT INTO dbo.SALES_INVOICES
        (
            Customer_ID,
            Employee_ID,
            Date_Time,
            Total_Amount,
            Discount,
            Paid_Amount,
            Payment_Status_ID,
            Created_At
        )
        VALUES
        (
            @CustomerID,
            @EmployeeID,
            @DateTime,
            @TotalAmount,
            @Discount,
            @PaidAmount,
            @PaymentStatusID,
            GETDATE()
        );

        SET @NewInvoiceID = CAST(SCOPE_IDENTITY() AS INT);

        /*
          IMPORTANT:
          Unit_Cost is captured from Inventory at the exact sale transaction.
        */
        INSERT INTO dbo.INVOICE_DETAILS
        (
            Invoice_ID,
            Part_ID,
            Quantity,
            Unit_Price,
            Unit_Cost
        )
        SELECT
            @NewInvoiceID,
            d.Part_ID,
            d.Quantity,
            d.Unit_Price,
            i.Purchase_Price
        FROM @Details d
        INNER JOIN dbo.INVENTORY i WITH (ROWLOCK, UPDLOCK)
            ON i.Part_ID = d.Part_ID;

        UPDATE i
        SET
            i.Current_Stock = i.Current_Stock - d.Quantity,
            i.Updated_At    = GETDATE()
        FROM dbo.INVENTORY i
        INNER JOIN @Details d
            ON d.Part_ID = i.Part_ID;

        INSERT INTO dbo.AUDIT_LOG
        (
            Part_ID,
            Movement_Type_ID,
            Quantity_Change,
            User_ID,
            Action_Date,
            Remarks
        )
        SELECT
            Part_ID,
            @SaleMovementTypeID,
            -Quantity,
            @UserID,
            GETDATE(),
            N'بيع - فاتورة رقم ' + CAST(@NewInvoiceID AS NVARCHAR(20))
        FROM @Details;

        IF @CustomerID IS NOT NULL
           AND (@TotalAmount - @Discount - @PaidAmount) <> 0
        BEGIN
            UPDATE dbo.CUSTOMERS WITH (ROWLOCK, UPDLOCK)
            SET Total_Balance =
                Total_Balance + (@TotalAmount - @Discount - @PaidAmount)
            WHERE Customer_ID = @CustomerID;
        END;

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG
        (
            Entity_Type,
            Entity_ID,
            Action_Type,
            User_ID,
            Action_Date,
            Remarks,
            New_Value
        )
        VALUES
        (
            N'SalesInvoice',
            @NewInvoiceID,
            N'Create',
            @UserID,
            GETDATE(),
            N'إنشاء فاتورة بيع جديدة',
            CAST(@TotalAmount - @Discount AS NVARCHAR(50))
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_SalesInvoice_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SalesInvoice_GetAll]
    @From       DATETIME2 = NULL,
    @To         DATETIME2 = NULL,
    @CustomerID INT       = NULL,
    @EmployeeID INT       = NULL,
    @StatusID   INT       = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT si.*,
           ISNULL(cu.Customer_Name, N'عميل نقدي') AS Customer_Name,
           e.Full_Name  AS Employee_Name,
           ps.Status_Name
    FROM dbo.SALES_INVOICES si
    LEFT JOIN dbo.CUSTOMERS      cu ON si.Customer_ID       = cu.Customer_ID
    LEFT JOIN dbo.EMPLOYEES      e  ON si.Employee_ID       = e.Employee_ID
    LEFT JOIN dbo.PAYMENT_STATUS ps ON si.Payment_Status_ID = ps.Status_ID
    WHERE (@From       IS NULL OR si.Date_Time >= @From)
      AND (@To         IS NULL OR si.Date_Time <= DATEADD(SECOND, -1, DATEADD(DAY, 1, @To)))
      AND (@CustomerID IS NULL OR si.Customer_ID = @CustomerID)
      AND (@EmployeeID IS NULL OR si.Employee_ID = @EmployeeID)
      AND (@StatusID   IS NULL OR si.Payment_Status_ID = @StatusID)
    ORDER BY si.Date_Time DESC
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SalesInvoice_GetByID]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SalesInvoice_GetByID]
    @InvoiceID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT si.*,
           ISNULL(cu.Customer_Name, N'عميل نقدي') AS Customer_Name,
           e.Full_Name  AS Employee_Name,
           ps.Status_Name
    FROM dbo.SALES_INVOICES si
    LEFT JOIN dbo.CUSTOMERS      cu ON si.Customer_ID       = cu.Customer_ID
    LEFT JOIN dbo.EMPLOYEES      e  ON si.Employee_ID       = e.Employee_ID
    LEFT JOIN dbo.PAYMENT_STATUS ps ON si.Payment_Status_ID = ps.Status_ID
    WHERE si.Invoice_ID = @InvoiceID;

    SELECT id.*, i.Part_Name
    FROM dbo.INVOICE_DETAILS id
    JOIN dbo.INVENTORY i ON id.Part_ID = i.Part_ID
    WHERE id.Invoice_ID = @InvoiceID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SalesInvoice_UpdatePayment]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- 2.3  sp_SalesInvoice_UpdatePayment : كانت من غير Transaction ولا تحديث لرصيد
--      العميل ولا تسجيل في الخزينة. دلوقتي بقت العملية الكاملة atomic:
--        (1) تتأكد إن الفاتورة موجودة والمبلغ الجديد منطقي
--        (2) تحدّث الفاتورة
--        (3) تخصم من رصيد العميل (لو الفاتورة عليه)
--        (4) تسجل تحصيل نقدي في الخزينة تلقائيًا
--        (5) تسجل في سجل التدقيق المالي
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_SalesInvoice_UpdatePayment]
    @InvoiceID                   INT,
    @AdditionalPaid              DECIMAL(18,2),
    @NewStatusID                 INT,
    @PaymentMethodID             INT,
    @CollectionTransactionTypeID INT,   -- الـ ID بتاع "تحصيل فاتورة" في TRANSACTION_TYPES
    @UserID                      INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @AdditionalPaid <= 0
    BEGIN
        RAISERROR(N'قيمة الدفعة يجب أن تكون أكبر من صفر.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @CustomerID INT, @FinalAmount DECIMAL(18,2), @CurrentPaid DECIMAL(18,2);

        SELECT @CustomerID  = Customer_ID,
               @FinalAmount = Final_Amount,
               @CurrentPaid = Paid_Amount
        FROM dbo.SALES_INVOICES WITH (UPDLOCK, ROWLOCK)
        WHERE Invoice_ID = @InvoiceID;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR(N'الفاتورة غير موجودة.', 16, 1);
        END

        IF (@CurrentPaid + @AdditionalPaid) > @FinalAmount
        BEGIN
            RAISERROR(N'المبلغ المدفوع يتجاوز المتبقي على الفاتورة.', 16, 1);
        END

        UPDATE dbo.SALES_INVOICES SET
            Paid_Amount       = Paid_Amount + @AdditionalPaid,
            Payment_Status_ID = @NewStatusID
        WHERE Invoice_ID = @InvoiceID;

        IF @CustomerID IS NOT NULL
        BEGIN
            UPDATE dbo.CUSTOMERS WITH (UPDLOCK)
            SET Total_Balance = Total_Balance - @AdditionalPaid
            WHERE Customer_ID = @CustomerID;
        END

        -- FIX: Store concatenated string in a variable prior to EXEC
        DECLARE @Notes NVARCHAR(200) = N'تحصيل دفعة على فاتورة بيع رقم ' + CAST(@InvoiceID AS NVARCHAR(20));
        DECLARE @NewTxnID INT, @NewBalance DECIMAL(18,2);

        EXEC dbo.sp_Treasury_Add
             @TransactionTypeID = @CollectionTransactionTypeID,
             @PaymentMethodID   = @PaymentMethodID,
             @SignedAmount      = @AdditionalPaid,
             @InvoiceID         = @InvoiceID,
             @CreatedBy         = @UserID,
             @Notes             = @Notes,
             @NewTransactionID  = @NewTxnID OUTPUT,
             @NewBalance        = @NewBalance OUTPUT;

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks, New_Value)
        VALUES (N'SalesInvoice', @InvoiceID, N'PaymentUpdate', @UserID, GETDATE(),
                N'تسجيل دفعة إضافية', CAST(@AdditionalPaid AS NVARCHAR(50)));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_StaffWallet_AdjustBalance]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- 2.15 sp_StaffWallet_AdjustBalance : إضافة Transaction ومنع الرصيد السالب
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_StaffWallet_AdjustBalance]
    @EmployeeID INT,
    @Delta      DECIMAL(18,2),
    @UserID     INT,
    @Reason     NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @CurrentBalance DECIMAL(18,2);

        SELECT @CurrentBalance = Current_Balance
        FROM dbo.STAFF_WALLETS WITH (ROWLOCK, UPDLOCK)
        WHERE Employee_ID = @EmployeeID;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR(N'لا توجد محفظة لهذا الموظف.', 16, 1);
        END

        IF (@CurrentBalance + @Delta) < 0
        BEGIN
            RAISERROR(N'الرصيد غير كافٍ في محفظة الموظف.', 16, 1);
        END

        UPDATE dbo.STAFF_WALLETS
        SET Current_Balance = Current_Balance + @Delta, Last_Update = GETDATE()
        WHERE Employee_ID = @EmployeeID;

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks, Old_Value, New_Value)
        VALUES (N'StaffWallet', @EmployeeID, N'BalanceAdjust', @UserID, GETDATE(), @Reason,
                CAST(@CurrentBalance AS NVARCHAR(50)), CAST(@CurrentBalance + @Delta AS NVARCHAR(50)));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_StaffWallet_Create]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_StaffWallet_Create]
    @EmployeeID   INT,
    @WalletNumber NVARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.STAFF_WALLETS WHERE Employee_ID = @EmployeeID)
    BEGIN
        RAISERROR(N'يوجد محفظة بالفعل لهذا الموظف.', 16, 1);
        RETURN;
    END
    INSERT INTO dbo.STAFF_WALLETS (Employee_ID, Wallet_Number, Current_Balance, Last_Update)
    VALUES (@EmployeeID, @WalletNumber, 0, GETDATE());
END
GO
/****** Object:  StoredProcedure [dbo].[sp_StaffWallet_GetByEmployee]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_StaffWallet_GetByEmployee]
    @EmployeeID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sw.*, e.Full_Name
    FROM dbo.STAFF_WALLETS sw
    JOIN dbo.EMPLOYEES e ON sw.Employee_ID = e.Employee_ID
    WHERE sw.Employee_ID = @EmployeeID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Supplier_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Supplier_Add]
    @SupplierName    NVARCHAR(150),
    @ContactPerson   NVARCHAR(100) = NULL,
    @PhoneNumber     NVARCHAR(20)  = NULL,
    @SupplierBalance DECIMAL(18,2) = 0,
    @Address         NVARCHAR(250) = NULL,
    @NewSupplierID   INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.SUPPLIERS (Supplier_Name, Contact_Person, Phone_Number, Supplier_Balance, Address, Created_At)
    VALUES (@SupplierName, @ContactPerson, @PhoneNumber, @SupplierBalance, @Address, GETDATE());
    SET @NewSupplierID = CAST(SCOPE_IDENTITY() AS INT);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Supplier_AdjustBalance]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- 2.14 sp_Supplier_AdjustBalance : نفس فكرة العميل - Transaction + تدقيق
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_Supplier_AdjustBalance]
    @SupplierID INT,
    @Delta      DECIMAL(18,2),
    @UserID     INT,
    @Reason     NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @CurrentBalance DECIMAL(18,2);

        SELECT @CurrentBalance = Supplier_Balance
        FROM dbo.SUPPLIERS WITH (ROWLOCK, UPDLOCK)
        WHERE Supplier_ID = @SupplierID;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR(N'The Supplier Is not Exists.', 16, 1);
        END

        UPDATE dbo.SUPPLIERS SET Supplier_Balance = Supplier_Balance + @Delta WHERE Supplier_ID = @SupplierID;

        INSERT INTO dbo.FINANCIAL_AUDIT_LOG (Entity_Type, Entity_ID, Action_Type, User_ID, Action_Date, Remarks, Old_Value, New_Value)
        VALUES (N'Supplier', @SupplierID, N'ManualBalanceAdjust', @UserID, GETDATE(), @Reason,
                CAST(@CurrentBalance AS NVARCHAR(50)), CAST(@CurrentBalance + @Delta AS NVARCHAR(50)));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Supplier_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Supplier_GetAll]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.SUPPLIERS ORDER BY Supplier_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Supplier_GetByID]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Supplier_GetByID]
    @SupplierID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.SUPPLIERS WHERE Supplier_ID = @SupplierID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Supplier_Search]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Supplier_Search]
    @Keyword NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @kw NVARCHAR(202) = N'%' + @Keyword + N'%';
    SELECT * FROM dbo.SUPPLIERS
    WHERE Supplier_Name LIKE @kw OR Phone_Number LIKE @kw OR Contact_Person LIKE @kw
    ORDER BY Supplier_Name;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Supplier_Update]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Supplier_Update]
    @SupplierID    INT,
    @SupplierName  NVARCHAR(150),
    @ContactPerson NVARCHAR(100) = NULL,
    @PhoneNumber   NVARCHAR(20)  = NULL,
    @Address       NVARCHAR(250) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.SUPPLIERS SET
        Supplier_Name  = @SupplierName,
        Contact_Person = @ContactPerson,
        Phone_Number   = @PhoneNumber,
        Address        = @Address
    WHERE Supplier_ID = @SupplierID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Treasury_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- 2.1  sp_Treasury_Add : إضافة باراميتر Created_By لتسجيل مين دخل الحركة
-------------------------------------------------------------------------------------
CREATE   PROCEDURE [dbo].[sp_Treasury_Add]
    @TransactionTypeID INT,
    @PaymentMethodID   INT,
    @SignedAmount      DECIMAL(18,2),
    @InvoiceID         INT = NULL,
    @POID              INT = NULL,
    @ExpenseID         INT = NULL,
    @PayrollID         INT = NULL,
    @AdvanceID         INT = NULL,
    @EmployeeID        INT = NULL,
    @CreatedBy         INT = NULL,
    @Notes             NVARCHAR(500) = NULL,
    @NewTransactionID  INT OUTPUT,
    @NewBalance        DECIMAL(18,2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @SignedAmount = 0
    BEGIN
        RAISERROR(N'قيمة الحركة لا يمكن أن تكون صفرًا.', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;

    DECLARE @lockResult INT;
    EXEC @lockResult = sp_getapplock
         @Resource    = 'TreasuryBalance',
         @LockMode    = 'Exclusive',
         @LockOwner   = 'Transaction',
         @LockTimeout = 10000;

    IF @lockResult < 0
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR(N'تعذر الوصول للخزينة حاليًا، حاول مرة أخرى.', 16, 1);
        RETURN;
    END

    DECLARE @CurrentBalance DECIMAL(18,2) = dbo.fn_Treasury_GetCurrentBalance();
    SET @NewBalance = @CurrentBalance + @SignedAmount;

    IF @NewBalance < 0
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR(N'الرصيد غير كافٍ لإتمام هذه العملية.', 16, 1);
        RETURN;
    END

    INSERT INTO dbo.TREASURY_LOG
        (Transaction_Type_ID, Payment_Method_ID, Amount,
         Invoice_ID, PO_ID, Expense_ID, Payroll_ID, Advance_ID, Employee_ID, Created_By,
         Action_Date, Balance_After, Notes)
    VALUES
        (@TransactionTypeID, @PaymentMethodID, @SignedAmount,
         @InvoiceID, @POID, @ExpenseID, @PayrollID, @AdvanceID, @EmployeeID, @CreatedBy,
         GETDATE(), @NewBalance, @Notes);

    SET @NewTransactionID = CAST(SCOPE_IDENTITY() AS INT);

    COMMIT TRANSACTION;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Treasury_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Treasury_GetAll]
    @From     DATETIME2 = NULL,
    @To       DATETIME2 = NULL,
    @TypeID   INT       = NULL,
    @MethodID INT       = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT tl.*, tt.Type_Name, pm.Method_Name
    FROM dbo.TREASURY_LOG tl
    JOIN dbo.TRANSACTION_TYPES tt ON tl.Transaction_Type_ID = tt.Transaction_Type_ID
    JOIN dbo.PAYMENT_METHODS   pm ON tl.Payment_Method_ID   = pm.Payment_Method_ID
    WHERE (@From     IS NULL OR tl.Action_Date >= @From)
      AND (@To       IS NULL OR tl.Action_Date <= @To)
      AND (@TypeID   IS NULL OR tl.Transaction_Type_ID = @TypeID)
      AND (@MethodID IS NULL OR tl.Payment_Method_ID   = @MethodID)
    ORDER BY tl.Action_Date DESC
    OPTION (RECOMPILE);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_User_Add]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_User_Add]
    @EmployeeID    INT,
    @Username      NVARCHAR(50),
    @PasswordHash  NVARCHAR(256),
    @IsActive      BIT = 1,
    @Permissions   INT = 0,
    @NewUserID     INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM dbo.USERS
        WHERE Username = @Username
    )
    BEGIN
        RAISERROR(N'The Username already exists.', 16, 1);
        RETURN;
    END;

    INSERT INTO dbo.USERS
    (
        Employee_ID,
        Username,
        Password_Hash,
        Is_Active,
        Created_At,
        Permissions
    )
    VALUES
    (
        @EmployeeID,
        @Username,
        @PasswordHash,
        @IsActive,
        GETDATE(),
        @Permissions
    );

    SET @NewUserID = CAST(SCOPE_IDENTITY() AS INT);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_User_GetAll]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_User_GetAll]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.*, e.Full_Name
    FROM dbo.USERS u
    JOIN dbo.EMPLOYEES e ON u.Employee_ID = e.Employee_ID
    ORDER BY u.Username;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_User_GetByEmployeeID]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_User_GetByEmployeeID]
    @EmployeeID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.*, e.Full_Name
    FROM dbo.USERS u
    JOIN dbo.EMPLOYEES e ON u.Employee_ID = e.Employee_ID
    WHERE u.Employee_ID = @EmployeeID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_User_GetByID]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_User_GetByID]
    @UserID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.*, e.Full_Name
    FROM dbo.USERS u
    JOIN dbo.EMPLOYEES e ON u.Employee_ID = e.Employee_ID
    WHERE u.User_ID = @UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_User_GetByUsername]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_User_GetByUsername]
    @Username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.*, e.Full_Name
    FROM dbo.USERS u
    JOIN dbo.EMPLOYEES e ON u.Employee_ID = e.Employee_ID
    WHERE u.Username = @Username AND u.Is_Active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_User_SetActive]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_User_SetActive]
    @UserID   INT,
    @IsActive BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.USERS SET Is_Active = @IsActive WHERE User_ID = @UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_User_UpdatePassword]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_User_UpdatePassword]
    @UserID      INT,
    @NewHash     NVARCHAR(256)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.USERS SET Password_Hash = @NewHash WHERE User_ID = @UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_User_UpdatePermissions]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_User_UpdatePermissions]
    @UserID      INT,
    @Permissions INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.USERS
    SET Permissions = @Permissions
    WHERE User_ID = @UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_User_UsernameExists]    Script Date: 9/17/2026 7:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_User_UsernameExists]
    @Username      NVARCHAR(50),
    @ExcludeUserID INT = NULL,
    @Exists        BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @Exists = CASE WHEN EXISTS (
        SELECT 1 FROM dbo.USERS
        WHERE Username = @Username
          AND (@ExcludeUserID IS NULL OR User_ID <> @ExcludeUserID)
    ) THEN 1 ELSE 0 END;
END
GO
USE [master]
GO
ALTER DATABASE [SabraForSparePartsDatabase] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [272Project]    Script Date: 2019/10/01 20:45:36 ******/
CREATE DATABASE [272Project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'272Project', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\272Project.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'272Project_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\272Project_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [272Project] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [272Project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [272Project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [272Project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [272Project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [272Project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [272Project] SET ARITHABORT OFF 
GO
ALTER DATABASE [272Project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [272Project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [272Project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [272Project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [272Project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [272Project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [272Project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [272Project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [272Project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [272Project] SET  DISABLE_BROKER 
GO
ALTER DATABASE [272Project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [272Project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [272Project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [272Project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [272Project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [272Project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [272Project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [272Project] SET RECOVERY FULL 
GO
ALTER DATABASE [272Project] SET  MULTI_USER 
GO
ALTER DATABASE [272Project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [272Project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [272Project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [272Project] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [272Project] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'272Project', N'ON'
GO
USE [272Project]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminName] [char](50) NOT NULL,
	[AdminSurname] [char](50) NOT NULL,
	[AdminEmailAddress] [char](50) NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Budget Limit]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Budget Limit](
	[LimitID] [int] NOT NULL,
	[LimitAmount] [decimal](6, 2) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[LimitType] [int] NOT NULL,
 CONSTRAINT [PK_Budget Limit] PRIMARY KEY CLUSTERED 
(
	[LimitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Budget Limit Type]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Budget Limit Type](
	[LimitType] [int] NOT NULL,
	[Description] [char](10) NOT NULL,
 CONSTRAINT [PK_Budget Limit Type] PRIMARY KEY CLUSTERED 
(
	[LimitType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Compound Interest]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Compound Interest](
	[CompoundInterest] [char](50) NOT NULL,
	[Annually] [char](50) NOT NULL,
	[Semi-Annually] [char](50) NOT NULL,
	[Quarterly] [char](50) NOT NULL,
	[Monthly] [char](50) NOT NULL,
	[InterestType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Compound Interest] PRIMARY KEY CLUSTERED 
(
	[CompoundInterest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] NOT NULL,
	[CustName] [char](10) NOT NULL,
	[CustSurname] [char](10) NOT NULL,
	[CustEmailAddress] [varchar](50) NOT NULL,
	[UserID] [int] NOT NULL,
	[NetWorthID] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fixed Interest]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fixed Interest](
	[FixedInterest] [char](50) NOT NULL,
	[Annually] [char](50) NOT NULL,
	[Semi-Annually] [char](50) NOT NULL,
	[Quarterly] [char](50) NOT NULL,
	[Monthly] [char](50) NOT NULL,
	[InterestType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Fixed Interest] PRIMARY KEY CLUSTERED 
(
	[FixedInterest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Income Type]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Income Type](
	[IncomeType] [int] NOT NULL,
	[Description] [char](50) NOT NULL,
 CONSTRAINT [PK_Income Type] PRIMARY KEY CLUSTERED 
(
	[IncomeType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Income.]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Income.](
	[IncomeID] [int] NOT NULL,
	[IncomeAmout] [decimal](6, 2) NOT NULL,
	[IncomeType] [int] NOT NULL,
	[IncomeDate] [date] NOT NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK_Income.] PRIMARY KEY CLUSTERED 
(
	[IncomeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Interest Type]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Interest Type](
	[InterestType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Interest Type] PRIMARY KEY CLUSTERED 
(
	[InterestType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Investment]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Investment](
	[InvestID] [int] NOT NULL,
	[InvestAmount] [int] NOT NULL,
	[InterestRate] [int] NOT NULL,
	[NumOfYears] [decimal](6, 2) NOT NULL,
	[InterestType] [varchar](50) NOT NULL,
	[InvestType] [varchar](50) NOT NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK_Investment] PRIMARY KEY CLUSTERED 
(
	[InvestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Investment Type]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Investment Type](
	[InvestType] [varchar](50) NOT NULL,
	[Description] [char](50) NOT NULL,
 CONSTRAINT [PK_Investment Type] PRIMARY KEY CLUSTERED 
(
	[InvestType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person NetWorth]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person NetWorth](
	[NetWorthID] [int] NOT NULL,
	[NetWorthAmount] [decimal](6, 2) NOT NULL,
	[TransID] [int] NOT NULL,
	[IncomeID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK_Person NetWorth] PRIMARY KEY CLUSTERED 
(
	[NetWorthID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Spending Transactions]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spending Transactions](
	[TransID] [int] NOT NULL,
	[TransAmount] [int] NOT NULL,
	[TransDate] [date] NOT NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK_Spending Transactions] PRIMARY KEY CLUSTERED 
(
	[TransID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[UserTypeID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User Type]    Script Date: 2019/10/01 20:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User Type](
	[UserTypeID] [int] NOT NULL,
	[Description] [char](50) NOT NULL,
 CONSTRAINT [PK_User Type] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Admin]  WITH CHECK ADD  CONSTRAINT [FK_Admin_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Admin] CHECK CONSTRAINT [FK_Admin_User]
GO
ALTER TABLE [dbo].[Budget Limit]  WITH CHECK ADD  CONSTRAINT [FK_Budget Limit_Budget Limit Type] FOREIGN KEY([LimitType])
REFERENCES [dbo].[Budget Limit Type] ([LimitType])
GO
ALTER TABLE [dbo].[Budget Limit] CHECK CONSTRAINT [FK_Budget Limit_Budget Limit Type]
GO
ALTER TABLE [dbo].[Budget Limit]  WITH CHECK ADD  CONSTRAINT [FK_Budget Limit_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Budget Limit] CHECK CONSTRAINT [FK_Budget Limit_Customer]
GO
ALTER TABLE [dbo].[Compound Interest]  WITH CHECK ADD  CONSTRAINT [FK_Compound Interest_Interest Type] FOREIGN KEY([InterestType])
REFERENCES [dbo].[Interest Type] ([InterestType])
GO
ALTER TABLE [dbo].[Compound Interest] CHECK CONSTRAINT [FK_Compound Interest_Interest Type]
GO
ALTER TABLE [dbo].[Fixed Interest]  WITH CHECK ADD  CONSTRAINT [FK_Fixed Interest_Interest Type] FOREIGN KEY([InterestType])
REFERENCES [dbo].[Interest Type] ([InterestType])
GO
ALTER TABLE [dbo].[Fixed Interest] CHECK CONSTRAINT [FK_Fixed Interest_Interest Type]
GO
ALTER TABLE [dbo].[Income.]  WITH CHECK ADD  CONSTRAINT [FK_Income._Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Income.] CHECK CONSTRAINT [FK_Income._Customer]
GO
ALTER TABLE [dbo].[Income.]  WITH CHECK ADD  CONSTRAINT [FK_Income._Income Type] FOREIGN KEY([IncomeType])
REFERENCES [dbo].[Income Type] ([IncomeType])
GO
ALTER TABLE [dbo].[Income.] CHECK CONSTRAINT [FK_Income._Income Type]
GO
ALTER TABLE [dbo].[Investment]  WITH CHECK ADD  CONSTRAINT [FK_Investment_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Investment] CHECK CONSTRAINT [FK_Investment_Customer]
GO
ALTER TABLE [dbo].[Investment]  WITH CHECK ADD  CONSTRAINT [FK_Investment_Interest Type] FOREIGN KEY([InterestType])
REFERENCES [dbo].[Interest Type] ([InterestType])
GO
ALTER TABLE [dbo].[Investment] CHECK CONSTRAINT [FK_Investment_Interest Type]
GO
ALTER TABLE [dbo].[Investment]  WITH CHECK ADD  CONSTRAINT [FK_Investment_Investment Type] FOREIGN KEY([InvestType])
REFERENCES [dbo].[Investment Type] ([InvestType])
GO
ALTER TABLE [dbo].[Investment] CHECK CONSTRAINT [FK_Investment_Investment Type]
GO
ALTER TABLE [dbo].[Person NetWorth]  WITH CHECK ADD  CONSTRAINT [FK_Person NetWorth_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Person NetWorth] CHECK CONSTRAINT [FK_Person NetWorth_Customer]
GO
ALTER TABLE [dbo].[Person NetWorth]  WITH CHECK ADD  CONSTRAINT [FK_Person NetWorth_Income.] FOREIGN KEY([IncomeID])
REFERENCES [dbo].[Income.] ([IncomeID])
GO
ALTER TABLE [dbo].[Person NetWorth] CHECK CONSTRAINT [FK_Person NetWorth_Income.]
GO
ALTER TABLE [dbo].[Person NetWorth]  WITH CHECK ADD  CONSTRAINT [FK_Person NetWorth_Spending Transactions] FOREIGN KEY([TransID])
REFERENCES [dbo].[Spending Transactions] ([TransID])
GO
ALTER TABLE [dbo].[Person NetWorth] CHECK CONSTRAINT [FK_Person NetWorth_Spending Transactions]
GO
ALTER TABLE [dbo].[Spending Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Spending Transactions_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Spending Transactions] CHECK CONSTRAINT [FK_Spending Transactions_Customer]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Customer]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User Type] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[User Type] ([UserTypeID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User Type]
GO
USE [master]
GO
ALTER DATABASE [272Project] SET  READ_WRITE 
GO

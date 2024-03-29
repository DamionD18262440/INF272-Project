USE [master]
GO
Drop Database [tr4y]
/****** Object:  Database [tr4y]    Script Date: 2019/10/22 02:21:26 ******/
CREATE DATABASE [tr4y]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tr4y', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\tr4y.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'tr4y_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\tr4y_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [tr4y] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tr4y].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tr4y] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tr4y] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tr4y] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tr4y] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tr4y] SET ARITHABORT OFF 
GO
ALTER DATABASE [tr4y] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tr4y] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tr4y] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tr4y] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tr4y] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tr4y] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tr4y] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tr4y] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tr4y] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tr4y] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tr4y] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tr4y] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tr4y] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tr4y] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tr4y] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tr4y] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tr4y] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tr4y] SET RECOVERY FULL 
GO
ALTER DATABASE [tr4y] SET  MULTI_USER 
GO
ALTER DATABASE [tr4y] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tr4y] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tr4y] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tr4y] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [tr4y] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'tr4y', N'ON'
GO
USE [tr4y]
GO
/****** Object:  Table [dbo].[BudgetLimit]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetLimit](
	[BudgetLimitID] [int] IDENTITY(1,1) NOT NULL,
	[FoodLimit] [float] NULL,
	[ClothesLimit] [float] NULL,
	[AlcoholLimit] [float] NULL,
	[OtherLimit] [float] NULL,
 CONSTRAINT [PK_BudgetLimit] PRIMARY KEY CLUSTERED 
(
	[BudgetLimitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Donation]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donation](
	[DonationID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Amount] [float] NULL,
	[LocationID] [int] NULL,
	[DonationTypeID] [int] NULL,
 CONSTRAINT [PK_Donation] PRIMARY KEY CLUSTERED 
(
	[DonationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonationType]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DonationType](
	[DonationTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_DonationType] PRIMARY KEY CLUSTERED 
(
	[DonationTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Income]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Income](
	[IncomeID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[Amount] [float] NULL,
	[IncomeTypeID] [int] NULL,
 CONSTRAINT [PK_Income] PRIMARY KEY CLUSTERED 
(
	[IncomeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncomeType]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IncomeType](
	[IncomeTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_IncomeType] PRIMARY KEY CLUSTERED 
(
	[IncomeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InterestPeriod]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InterestPeriod](
	[InterestPeriodID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_InterestPeriod] PRIMARY KEY CLUSTERED 
(
	[InterestPeriodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InterestType]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InterestType](
	[InterestTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_InterestType] PRIMARY KEY CLUSTERED 
(
	[InterestTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Investment]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Investment](
	[InvestmentID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Amount] [float] NULL,
	[NumOfYears] [float] NULL,
	[TotalInvest] [float] NULL,
	[InterestRate] [float] NULL,
	[InterestPeriodID] [int] NULL,
	[InterestTypeID] [int] NULL,
	[InvestmentTypeID] [int] NULL,
 CONSTRAINT [PK_Investment] PRIMARY KEY CLUSTERED 
(
	[InvestmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvestmentType]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InvestmentType](
	[InvestmentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_InvestmentType] PRIMARY KEY CLUSTERED 
(
	[InvestmentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MonthlySpending]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonthlySpending](
	[MonthlySpendingID] [int] IDENTITY(1,1) NOT NULL,
	[FoodAmount] [float] NULL,
	[ClothesAmount] [float] NULL,
	[AlcoholAmount] [float] NULL,
	[OtherAmount] [float] NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_MonthlySpending] PRIMARY KEY CLUSTERED 
(
	[MonthlySpendingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NetWorth]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NetWorth](
	[NetWorthID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_NetWorth] PRIMARY KEY CLUSTERED 
(
	[NetWorthID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](55) NOT NULL,
	[UserSurname] [varchar](55) NOT NULL,
	[UserUseName] [varchar](55) NOT NULL,
	[UserPassword] [varchar](55) NOT NULL,
	[UserTypeID] [int] NOT NULL,
	[BudgetLimitID] [int] NULL,
	[MonthlySpendingID] [int] NULL,
	[NetWorthID] [int] NULL,
	[IncomeID] [int] NULL,
	[InvestmentID] [int] NULL,
	[DonationID] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](10) NOT NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Donation]  WITH CHECK ADD  CONSTRAINT [FK_Donation_DonationType] FOREIGN KEY([DonationTypeID])
REFERENCES [dbo].[DonationType] ([DonationTypeID])
GO
ALTER TABLE [dbo].[Donation] CHECK CONSTRAINT [FK_Donation_DonationType]
GO
ALTER TABLE [dbo].[Donation]  WITH CHECK ADD  CONSTRAINT [FK_Donation_Location] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([LocationID])
GO
ALTER TABLE [dbo].[Donation] CHECK CONSTRAINT [FK_Donation_Location]
GO
ALTER TABLE [dbo].[Income]  WITH CHECK ADD  CONSTRAINT [FK_Income_IncomeType] FOREIGN KEY([IncomeTypeID])
REFERENCES [dbo].[IncomeType] ([IncomeTypeID])
GO
ALTER TABLE [dbo].[Income] CHECK CONSTRAINT [FK_Income_IncomeType]
GO
ALTER TABLE [dbo].[Investment]  WITH CHECK ADD  CONSTRAINT [FK_Investment_InterestPeriod] FOREIGN KEY([InterestPeriodID])
REFERENCES [dbo].[InterestPeriod] ([InterestPeriodID])
GO
ALTER TABLE [dbo].[Investment] CHECK CONSTRAINT [FK_Investment_InterestPeriod]
GO
ALTER TABLE [dbo].[Investment]  WITH CHECK ADD  CONSTRAINT [FK_Investment_InterestType] FOREIGN KEY([InterestTypeID])
REFERENCES [dbo].[InterestType] ([InterestTypeID])
GO
ALTER TABLE [dbo].[Investment] CHECK CONSTRAINT [FK_Investment_InterestType]
GO
ALTER TABLE [dbo].[Investment]  WITH CHECK ADD  CONSTRAINT [FK_Investment_InvestmentType] FOREIGN KEY([InvestmentTypeID])
REFERENCES [dbo].[InvestmentType] ([InvestmentTypeID])
GO
ALTER TABLE [dbo].[Investment] CHECK CONSTRAINT [FK_Investment_InvestmentType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_BudgetLimit] FOREIGN KEY([BudgetLimitID])
REFERENCES [dbo].[BudgetLimit] ([BudgetLimitID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_BudgetLimit]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Donation] FOREIGN KEY([DonationID])
REFERENCES [dbo].[Donation] ([DonationID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Donation]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Income] FOREIGN KEY([IncomeID])
REFERENCES [dbo].[Income] ([IncomeID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Income]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Investment] FOREIGN KEY([InvestmentID])
REFERENCES [dbo].[Investment] ([InvestmentID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Investment]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_MonthlySpending] FOREIGN KEY([MonthlySpendingID])
REFERENCES [dbo].[MonthlySpending] ([MonthlySpendingID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_MonthlySpending]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_NetWorth] FOREIGN KEY([NetWorthID])
REFERENCES [dbo].[NetWorth] ([NetWorthID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_NetWorth]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserType] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserType] ([UserTypeID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserType]
GO
/****** Object:  StoredProcedure [dbo].[Insert_Users]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insert_Users]
       @UserUseName NVARCHAR(20),
       @UserPassword NVARCHAR(20),
	   @UserName NVARCHAR(20),
	   @UserSurname NVARCHAR(20),
	   @UserTypeID int
       
AS
BEGIN
       SET NOCOUNT ON;
       IF EXISTS(SELECT UserID FROM [dbo].[User] WHERE UserUseName = @Username)
       BEGIN
              SELECT -1 AS UserID -- Username exists.
       END
      
      
       ELSE
       BEGIN
              INSERT INTO [dbo].[User]
                        ([UserUseName]
                        ,[UserPassword],
						[UserName],
						[UserSurname],
						[UserTypeID])
              VALUES
                        (@UserUseName,
                         @UserPassword,
	                     @UserName,
	                     @UserSurname,
	                     @UserTypeID)
                       
                        
              SELECT SCOPE_IDENTITY() AS UserId -- UserId                     
     END
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Userss]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insert_Userss]
       @UserUseName NVARCHAR(20),
       @UserPassword NVARCHAR(20),
	   @UserName NVARCHAR(20),
	   @UserSurname NVARCHAR(20),
	   @UserTypeID int
       
AS
BEGIN
       SET NOCOUNT ON;
       IF EXISTS(SELECT UserID FROM [dbo].[User] WHERE UserUseName = @UserUseName)
       BEGIN
              SELECT -1 AS UserID -- Username exists.
       END
      
      
       ELSE
       BEGIN
              INSERT INTO [dbo].[User]
                        ([UserUseName]
                        ,[UserPassword],
						[UserName],
						[UserSurname],
						[UserTypeID])
              VALUES
                        (@UserUseName,
                         @UserPassword,
	                     @UserName,
	                     @UserSurname,
	                     @UserTypeID)
                       
                        
              SELECT SCOPE_IDENTITY() AS UserId -- UserId                     
     END
END
GO
/****** Object:  StoredProcedure [dbo].[Validate_User]    Script Date: 2019/10/22 02:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Validate_User]
      @UserUseName NVARCHAR(20),
      @UserPassword NVARCHAR(20)
AS
BEGIN
      SET NOCOUNT ON;
      DECLARE @UserID INT
     
      SELECT @UserID = UserID
      FROM [dbo].[User] WHERE UserUseName = @UserUseName AND [UserPassword] = @UserPassword
     
      IF @UserID IS NOT NULL
      BEGIN
            IF NOT EXISTS(SELECT @UserID FROM [dbo].[User] WHERE UserID = @UserId)
            BEGIN
                  SELECT @UserID [UserID] -- User Valid
            END
            ELSE
            BEGIN
                  SELECT -2 -- User not activated.
            END
      END
      ELSE
      BEGIN
            SELECT -1 -- User invalid.
      END
END
GO
USE [master]
GO
ALTER DATABASE [tr4y] SET  READ_WRITE 
GO

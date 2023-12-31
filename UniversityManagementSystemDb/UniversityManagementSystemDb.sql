USE [master]
GO
/****** Object:  Database [UniversityMS]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE DATABASE [UniversityMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\UniversityMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UniversityMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\UniversityMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [UniversityMS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityMS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UniversityMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityMS] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [UniversityMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityMS] SET RECOVERY FULL 
GO
ALTER DATABASE [UniversityMS] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UniversityMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UniversityMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'UniversityMS', N'ON'
GO
ALTER DATABASE [UniversityMS] SET QUERY_STORE = ON
GO
ALTER DATABASE [UniversityMS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [UniversityMS]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/5/2023 8:06:48 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allocates]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allocates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[DayId] [int] NOT NULL,
	[FromTime] [nvarchar](max) NOT NULL,
	[ToTime] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Allocates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
	[TeacherId] [int] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Days]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Days](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Days] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](7) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designations]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Designations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrolls]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrolls](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Grade] [nvarchar](max) NULL,
 CONSTRAINT [PK_Enrolls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GradeLetter] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Department] [nvarchar](max) NOT NULL,
	[CourseId] [int] NOT NULL,
	[Grade] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[ContactNo] [nvarchar](11) NOT NULL,
	[RegistrationDate] [datetime2](7) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[RegistrationNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 12/5/2023 8:06:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[ContactNo] [nvarchar](11) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[DesignationId] [int] NOT NULL,
	[CreditsToBeTaken] [float] NOT NULL,
	[RemainingCredit] [float] NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231125151048_initails', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231125174740_addSemesterTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231125223205_addCourseTableDb', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231127115349_addTeacherDesignationTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231127151406_addColumnToCourseTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231127170252_addColumnToTeacherTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231129205123_addStudentTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231203131442_AddDayRoomAllocateTableToDb', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231204204720_addEnrollTableToDb', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231204222833_addGradeAndResultTableToDb', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231205002649_addColumnToEnroll', N'7.0.14')
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [TeacherId]) VALUES (1003, N'CSE-002', N'Computer Programming Sessional', CAST(1.00 AS Decimal(18, 2)), N'Computer Programming Sessional', 6, 1, NULL)
INSERT [dbo].[Courses] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [TeacherId]) VALUES (1004, N'CSE-001', N'Computer Programming', CAST(3.00 AS Decimal(18, 2)), N'Computer Programming', 6, 1, NULL)
INSERT [dbo].[Courses] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [TeacherId]) VALUES (1005, N'BBA-001', N'Accounting fundamentals', CAST(2.00 AS Decimal(18, 2)), N'Accounting fundamentals', 4, 1, NULL)
INSERT [dbo].[Courses] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [TeacherId]) VALUES (1006, N'EEE-001', N'Basic Electrical Engineering', CAST(3.00 AS Decimal(18, 2)), N'Basic Electrical Engineering', 5, 2, NULL)
INSERT [dbo].[Courses] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [TeacherId]) VALUES (2006, N'CSE-003', N'Computer Fundamentals', CAST(2.00 AS Decimal(18, 2)), N'Computer Fundamentals', 6, 1, NULL)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Days] ON 

INSERT [dbo].[Days] ([Id], [DayName]) VALUES (7, N'Friday')
INSERT [dbo].[Days] ([Id], [DayName]) VALUES (3, N'Monday')
INSERT [dbo].[Days] ([Id], [DayName]) VALUES (1, N'Saturday')
INSERT [dbo].[Days] ([Id], [DayName]) VALUES (2, N'Sunday')
INSERT [dbo].[Days] ([Id], [DayName]) VALUES (6, N'Thursday')
INSERT [dbo].[Days] ([Id], [DayName]) VALUES (4, N'Tuesday')
INSERT [dbo].[Days] ([Id], [DayName]) VALUES (5, N'Wednesday')
SET IDENTITY_INSERT [dbo].[Days] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (4, N'BBA', N'Bachelor of Business Administration')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (5, N'EEE', N'Electronics & Electrical Engineering')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (6, N'CSE', N'Computer Science & Engineering')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Designations] ON 

INSERT [dbo].[Designations] ([Id], [Name]) VALUES (1, N'Professor')
INSERT [dbo].[Designations] ([Id], [Name]) VALUES (2, N'Assistant Professor')
INSERT [dbo].[Designations] ([Id], [Name]) VALUES (3, N'Lecturer')
INSERT [dbo].[Designations] ([Id], [Name]) VALUES (4, N'Adjunct')
SET IDENTITY_INSERT [dbo].[Designations] OFF
GO
SET IDENTITY_INSERT [dbo].[Enrolls] ON 

INSERT [dbo].[Enrolls] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (1, 1, 1004, CAST(N'2023-12-05T00:00:00.0000000' AS DateTime2), N'A+')
INSERT [dbo].[Enrolls] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (2, 1, 1003, CAST(N'2023-12-05T00:00:00.0000000' AS DateTime2), N'A')
INSERT [dbo].[Enrolls] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (4, 3, 1006, CAST(N'2023-12-05T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Enrolls] ([Id], [StudentId], [CourseId], [Date], [Grade]) VALUES (5, 1, 2006, CAST(N'2023-12-05T00:00:00.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Enrolls] OFF
GO
SET IDENTITY_INSERT [dbo].[Grades] ON 

INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (1, N'A+')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (2, N'A')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (3, N'A-')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (4, N'B+')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (5, N'B')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (6, N'B-')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (7, N'C+')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (8, N'C')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (9, N'C-')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (10, N'D+')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (11, N'D')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (12, N'D-')
INSERT [dbo].[Grades] ([Id], [GradeLetter]) VALUES (13, N'F')
SET IDENTITY_INSERT [dbo].[Grades] OFF
GO
SET IDENTITY_INSERT [dbo].[Results] ON 

INSERT [dbo].[Results] ([Id], [StudentId], [Name], [Email], [Department], [CourseId], [Grade]) VALUES (5, 1, N'Iftekhar Hasan', N'iftekharhasanrifat@gmail.com', N'CSE', 1004, N'A+')
INSERT [dbo].[Results] ([Id], [StudentId], [Name], [Email], [Department], [CourseId], [Grade]) VALUES (7, 1, N'Iftekhar Hasan', N'iftekharhasanrifat@gmail.com', N'CSE', 1003, N'A')
SET IDENTITY_INSERT [dbo].[Results] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (1, N'AB-201')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (2, N'AB-202')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (3, N'AB-LAB1')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (4, N'AB-LAB2')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Semesters] ON 

INSERT [dbo].[Semesters] ([Id], [Name]) VALUES (1, N'1st')
INSERT [dbo].[Semesters] ([Id], [Name]) VALUES (2, N'2nd')
INSERT [dbo].[Semesters] ([Id], [Name]) VALUES (3, N'3rd')
INSERT [dbo].[Semesters] ([Id], [Name]) VALUES (4, N'4th')
INSERT [dbo].[Semesters] ([Id], [Name]) VALUES (5, N'5th')
INSERT [dbo].[Semesters] ([Id], [Name]) VALUES (6, N'6th')
INSERT [dbo].[Semesters] ([Id], [Name]) VALUES (7, N'7th')
INSERT [dbo].[Semesters] ([Id], [Name]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[Semesters] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name], [Address], [Email], [ContactNo], [RegistrationDate], [DepartmentId], [RegistrationNumber]) VALUES (1, N'Iftekhar Hasan', N'Mogoltooly, Commerce College road, Agrabad, Chattogram.', N'iftekharhasanrifat@gmail.com', N'01812794985', CAST(N'2023-11-30T00:00:00.0000000' AS DateTime2), 6, N'CSE-2023-001')
INSERT [dbo].[Students] ([Id], [Name], [Address], [Email], [ContactNo], [RegistrationDate], [DepartmentId], [RegistrationNumber]) VALUES (2, N'Abu Taher', N'Mogoltooly, Commerce College road, Agrabad, Chattogram.', N'iftekharhasanrifat1@gmail.com', N'01812794985', CAST(N'2023-11-30T00:00:00.0000000' AS DateTime2), 6, N'CSE-2023-002')
INSERT [dbo].[Students] ([Id], [Name], [Address], [Email], [ContactNo], [RegistrationDate], [DepartmentId], [RegistrationNumber]) VALUES (3, N'Hasan Abdullah', N'Mogoltooly, Commerce College road, Agrabad, Chattogram.', N'iftekharhasanrifat2@gmail.com', N'01812794985', CAST(N'2023-11-29T00:00:00.0000000' AS DateTime2), 5, N'EEE-2023-001')
INSERT [dbo].[Students] ([Id], [Name], [Address], [Email], [ContactNo], [RegistrationDate], [DepartmentId], [RegistrationNumber]) VALUES (4, N'Iftekhar Hasan', N'Mogoltooly, Commerce College road, Agrabad, Chattogram.', N'iftekharhasanrifat4@gmail.com', N'01812794985', CAST(N'2022-11-30T00:00:00.0000000' AS DateTime2), 6, N'CSE-2022-001')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([Id], [Name], [Address], [Email], [ContactNo], [DepartmentId], [DesignationId], [CreditsToBeTaken], [RemainingCredit]) VALUES (5, N'Iftekhar Hasan Rifat', N'Mogoltooly, Commerce College road, Agrabad, Chattogram.', N'iftekharhasanrifat@gmail.com', N'01812794985', 6, 3, 4, 4)
INSERT [dbo].[Teachers] ([Id], [Name], [Address], [Email], [ContactNo], [DepartmentId], [DesignationId], [CreditsToBeTaken], [RemainingCredit]) VALUES (6, N'Abu Taher', N'Mogoltooly, Commerce College road, Agrabad, Chattogram.', N'iftekharhasanrifat1@gmail.com', N'01812794985', 4, 3, 3, 3)
INSERT [dbo].[Teachers] ([Id], [Name], [Address], [Email], [ContactNo], [DepartmentId], [DesignationId], [CreditsToBeTaken], [RemainingCredit]) VALUES (7, N'Hasan Abdullah', N'Mogoltooly, Commerce College road, Agrabad, Chattogram.', N'iftekharhasanrifat2@gmail.com', N'01812794985', 5, 3, 6, 6)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
/****** Object:  Index [IX_Allocates_CourseId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Allocates_CourseId] ON [dbo].[Allocates]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Allocates_DayId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Allocates_DayId] ON [dbo].[Allocates]
(
	[DayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Allocates_DepartmentId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Allocates_DepartmentId] ON [dbo].[Allocates]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Allocates_RoomId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Allocates_RoomId] ON [dbo].[Allocates]
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Courses_Code]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Courses_Code] ON [dbo].[Courses]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Courses_DepartmentId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Courses_DepartmentId] ON [dbo].[Courses]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Courses_Name]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Courses_Name] ON [dbo].[Courses]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Courses_SemesterId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Courses_SemesterId] ON [dbo].[Courses]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Courses_TeacherId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Courses_TeacherId] ON [dbo].[Courses]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Days_DayName]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Days_DayName] ON [dbo].[Days]
(
	[DayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Departments_Code]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Departments_Code] ON [dbo].[Departments]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Departments_Name]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Departments_Name] ON [dbo].[Departments]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enrolls_CourseId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Enrolls_CourseId] ON [dbo].[Enrolls]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enrolls_StudentId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Enrolls_StudentId] ON [dbo].[Enrolls]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Results_CourseId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Results_CourseId] ON [dbo].[Results]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Results_StudentId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Results_StudentId] ON [dbo].[Results]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Rooms_RoomNo]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Rooms_RoomNo] ON [dbo].[Rooms]
(
	[RoomNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_DepartmentId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Students_DepartmentId] ON [dbo].[Students]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Students_Email]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Students_Email] ON [dbo].[Students]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teachers_DepartmentId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Teachers_DepartmentId] ON [dbo].[Teachers]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teachers_DesignationId]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Teachers_DesignationId] ON [dbo].[Teachers]
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Teachers_Email]    Script Date: 12/5/2023 8:06:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Teachers_Email] ON [dbo].[Teachers]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Allocates]  WITH CHECK ADD  CONSTRAINT [FK_Allocates_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Allocates] CHECK CONSTRAINT [FK_Allocates_Courses_CourseId]
GO
ALTER TABLE [dbo].[Allocates]  WITH CHECK ADD  CONSTRAINT [FK_Allocates_Days_DayId] FOREIGN KEY([DayId])
REFERENCES [dbo].[Days] ([Id])
GO
ALTER TABLE [dbo].[Allocates] CHECK CONSTRAINT [FK_Allocates_Days_DayId]
GO
ALTER TABLE [dbo].[Allocates]  WITH CHECK ADD  CONSTRAINT [FK_Allocates_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Allocates] CHECK CONSTRAINT [FK_Allocates_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Allocates]  WITH CHECK ADD  CONSTRAINT [FK_Allocates_Rooms_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[Allocates] CHECK CONSTRAINT [FK_Allocates_Rooms_RoomId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Semesters_SemesterId] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Semesters_SemesterId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Teachers_TeacherId]
GO
ALTER TABLE [dbo].[Enrolls]  WITH CHECK ADD  CONSTRAINT [FK_Enrolls_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Enrolls] CHECK CONSTRAINT [FK_Enrolls_Courses_CourseId]
GO
ALTER TABLE [dbo].[Enrolls]  WITH CHECK ADD  CONSTRAINT [FK_Enrolls_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Enrolls] CHECK CONSTRAINT [FK_Enrolls_Students_StudentId]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_Courses_CourseId]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_Students_StudentId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Designations_DesignationId] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Designations_DesignationId]
GO
USE [master]
GO
ALTER DATABASE [UniversityMS] SET  READ_WRITE 
GO

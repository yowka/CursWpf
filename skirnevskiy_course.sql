USE [master]
GO
/****** Object:  Database [skirnevskiy_course]    Script Date: 12.02.2025 10:58:32 ******/
CREATE DATABASE [skirnevskiy_course]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'skirnevskiy_course', FILENAME = N'/var/opt/mssql/data/skirnevskiy_course.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'skirnevskiy_course_log', FILENAME = N'/var/opt/mssql/data/skirnevskiy_course_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [skirnevskiy_course] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [skirnevskiy_course].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [skirnevskiy_course] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET ARITHABORT OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [skirnevskiy_course] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [skirnevskiy_course] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET  DISABLE_BROKER 
GO
ALTER DATABASE [skirnevskiy_course] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [skirnevskiy_course] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET RECOVERY FULL 
GO
ALTER DATABASE [skirnevskiy_course] SET  MULTI_USER 
GO
ALTER DATABASE [skirnevskiy_course] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [skirnevskiy_course] SET DB_CHAINING OFF 
GO
ALTER DATABASE [skirnevskiy_course] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [skirnevskiy_course] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [skirnevskiy_course] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [skirnevskiy_course] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'skirnevskiy_course', N'ON'
GO
ALTER DATABASE [skirnevskiy_course] SET QUERY_STORE = ON
GO
ALTER DATABASE [skirnevskiy_course] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [skirnevskiy_course]
GO
/****** Object:  Table [dbo].[Automobile]    Script Date: 12.02.2025 10:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Automobile](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[year_of_production] [int] NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[Brand_ID] [int] NOT NULL,
	[Color_ID] [int] NOT NULL,
	[Category_ID] [int] NOT NULL,
 CONSTRAINT [PK__Automobi__3213E83FE7EEC587] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 12.02.2025 10:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[country] [nvarchar](50) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[factory] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Brand__3213E83FAFD4ED49] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buyer]    Script Date: 12.02.2025 10:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buyer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[age] [int] NOT NULL,
	[town] [nvarchar](50) NOT NULL,
	[passport_details] [int] NOT NULL,
	[gender] [bit] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[lastname] [nvarchar](50) NULL,
 CONSTRAINT [PK__Buyer__3213E83F1A4D27B9] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12.02.2025 10:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Category__3213E83F663A989B] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 12.02.2025 10:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Color__3213E83F09F7014C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12.02.2025 10:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[salary] [decimal](7, 2) NOT NULL,
	[experience] [decimal](3, 1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[lastname] [nvarchar](50) NULL,
	[number] [nvarchar](11) NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK__Employee__3213E83FC53F4E15] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12.02.2025 10:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] NOT NULL,
	[name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale_automobile]    Script Date: 12.02.2025 10:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_automobile](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
	[Automobile_ID] [int] NOT NULL,
	[Employee_ID] [int] NOT NULL,
	[Buyer_ID] [int] NOT NULL,
 CONSTRAINT [PK__Sale_aut__3213E83FFAA42828] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Automobile] ON 

INSERT [dbo].[Automobile] ([id], [year_of_production], [price], [title], [Brand_ID], [Color_ID], [Category_ID]) VALUES (24, 2023, CAST(50000.00 AS Decimal(10, 2)), N'Cayenne', 21, 11, 11)
INSERT [dbo].[Automobile] ([id], [year_of_production], [price], [title], [Brand_ID], [Color_ID], [Category_ID]) VALUES (25, 2023, CAST(50000.00 AS Decimal(10, 2)), N'Cayenne', 21, 11, 11)
INSERT [dbo].[Automobile] ([id], [year_of_production], [price], [title], [Brand_ID], [Color_ID], [Category_ID]) VALUES (26, 2022, CAST(45000.00 AS Decimal(10, 2)), N'Model Y', 20, 12, 21)
INSERT [dbo].[Automobile] ([id], [year_of_production], [price], [title], [Brand_ID], [Color_ID], [Category_ID]) VALUES (27, 2021, CAST(40000.00 AS Decimal(10, 2)), N'Model 3', 20, 13, 21)
INSERT [dbo].[Automobile] ([id], [year_of_production], [price], [title], [Brand_ID], [Color_ID], [Category_ID]) VALUES (28, 2020, CAST(35000.00 AS Decimal(10, 2)), N'Model S', 20, 14, 21)
INSERT [dbo].[Automobile] ([id], [year_of_production], [price], [title], [Brand_ID], [Color_ID], [Category_ID]) VALUES (29, 2019, CAST(57500.00 AS Decimal(10, 2)), N'Corolla', 12, 15, 11)
INSERT [dbo].[Automobile] ([id], [year_of_production], [price], [title], [Brand_ID], [Color_ID], [Category_ID]) VALUES (31, 2022, CAST(55000.00 AS Decimal(10, 2)), N'X5', 11, 17, 12)
INSERT [dbo].[Automobile] ([id], [year_of_production], [price], [title], [Brand_ID], [Color_ID], [Category_ID]) VALUES (32, 2021, CAST(60000.00 AS Decimal(10, 2)), N'X7', 11, 18, 12)
INSERT [dbo].[Automobile] ([id], [year_of_production], [price], [title], [Brand_ID], [Color_ID], [Category_ID]) VALUES (33, 2020, CAST(70000.00 AS Decimal(10, 2)), N'Mustang', 13, 19, 18)
INSERT [dbo].[Automobile] ([id], [year_of_production], [price], [title], [Brand_ID], [Color_ID], [Category_ID]) VALUES (34, 2019, CAST(65000.00 AS Decimal(10, 2)), N'F-150', 13, 20, 17)
INSERT [dbo].[Automobile] ([id], [year_of_production], [price], [title], [Brand_ID], [Color_ID], [Category_ID]) VALUES (35, 2023, CAST(57500.00 AS Decimal(10, 2)), N'New Toyota', 12, 11, 11)
SET IDENTITY_INSERT [dbo].[Automobile] OFF
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (11, N'Germany', N'BMW', N'BMW Plant Munich', N'Munich, Germany')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (12, N'Japan', N'Toyota', N'Toyota City Plant', N'Toyota City, Japan')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (13, N'USA', N'Ford', N'Ford Dearborn Plant', N'Dearborn, USA')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (14, N'Germany', N'Mercedes-Benz', N'Mercedes-Benz Factory Sindelfingen', N'Sindelfingen, Germany')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (15, N'Italy', N'Ferrari', N'Ferrari Factory Maranello', N'Maranello, Italy')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (16, N'Japan', N'Honda', N'Honda Plant Sayama', N'Sayama, Japan')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (17, N'USA', N'Chevrolet', N'Chevrolet Detroit Plant', N'Detroit, USA')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (18, N'Germany', N'Audi', N'Audi Factory Ingolstadt', N'Ingolstadt, Germany')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (19, N'Japan', N'Nissan', N'Nissan Plant Yokohama', N'Yokohama, Japan')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (20, N'USA', N'Tesla', N'Tesla Factory Fremont', N'Fremont, USA')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (21, N'Germany', N'Porsche', N'Porsche Factory Stuttgart', N'Stuttgart, Germany')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (22, N'Japan', N'Mazda', N'Mazda Plant Hiroshima', N'Hiroshima, Japan')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (23, N'USA', N'Jeep', N'Jeep Toledo Plant', N'Toledo, USA')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (24, N'Germany', N'Volkswagen', N'Volkswagen Factory Wolfsburg', N'Wolfsburg, Germany')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (25, N'Italy', N'Lamborghini', N'Lamborghini Factory Sant''Agata Bolognese', N'Sant''Agata Bolognese, Italy')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (26, N'Japan', N'Subaru', N'Subaru Plant Ota', N'Ota, Japan')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (27, N'USA', N'Dodge', N'Dodge Detroit Plant', N'Detroit, USA')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (28, N'Germany', N'Opel', N'Opel Factory Rüsselsheim', N'Rüsselsheim, Germany')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (29, N'Japan', N'Lexus', N'Lexus Plant Tahara', N'Tahara, Japan')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (30, N'USA', N'Cadillac', N'Cadillac Detroit Plant', N'Detroit, USA')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (31, N'Germany', N'Porsche', N'Porsche Factory Stuttgart', N'Stuttgart, Germany')
INSERT [dbo].[Brand] ([id], [country], [title], [factory], [address]) VALUES (32, N'Germany', N'Porsche', N'Porsche Factory Stuttgart', N'Stuttgart, Germany')
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Buyer] ON 

INSERT [dbo].[Buyer] ([id], [address], [age], [town], [passport_details], [gender], [name], [surname], [lastname]) VALUES (12, N'456 Elm St', 25, N'Los Angeles', 987654321, 0, N'Jane', N'Smith', N'Elizabeth')
INSERT [dbo].[Buyer] ([id], [address], [age], [town], [passport_details], [gender], [name], [surname], [lastname]) VALUES (24, N'888 Willow St', 29, N'Columbus', 112233445, 0, N'Jessica', N'Gonzalez', N'Margaret')
INSERT [dbo].[Buyer] ([id], [address], [age], [town], [passport_details], [gender], [name], [surname], [lastname]) VALUES (30, N'505 Cedar St', 23, N'Washington', 321321321, 0, N'Lisa', N'Jackson', N'Betty')
SET IDENTITY_INSERT [dbo].[Buyer] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [title]) VALUES (11, N'Sedan')
INSERT [dbo].[Category] ([id], [title]) VALUES (12, N'SUV')
INSERT [dbo].[Category] ([id], [title]) VALUES (13, N'Hatchback')
INSERT [dbo].[Category] ([id], [title]) VALUES (14, N'Coupe')
INSERT [dbo].[Category] ([id], [title]) VALUES (15, N'Convertible')
INSERT [dbo].[Category] ([id], [title]) VALUES (16, N'Minivan')
INSERT [dbo].[Category] ([id], [title]) VALUES (17, N'Pickup Truck')
INSERT [dbo].[Category] ([id], [title]) VALUES (18, N'Sports Car')
INSERT [dbo].[Category] ([id], [title]) VALUES (19, N'Compact')
INSERT [dbo].[Category] ([id], [title]) VALUES (20, N'Luxury')
INSERT [dbo].[Category] ([id], [title]) VALUES (21, N'Electric')
INSERT [dbo].[Category] ([id], [title]) VALUES (22, N'Hybrid')
INSERT [dbo].[Category] ([id], [title]) VALUES (23, N'Crossover')
INSERT [dbo].[Category] ([id], [title]) VALUES (24, N'Wagon')
INSERT [dbo].[Category] ([id], [title]) VALUES (25, N'Van')
INSERT [dbo].[Category] ([id], [title]) VALUES (26, N'Off-Road')
INSERT [dbo].[Category] ([id], [title]) VALUES (27, N'Performance')
INSERT [dbo].[Category] ([id], [title]) VALUES (28, N'Classic')
INSERT [dbo].[Category] ([id], [title]) VALUES (29, N'Muscle Car')
INSERT [dbo].[Category] ([id], [title]) VALUES (30, N'Supercar')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([id], [title]) VALUES (11, N'Red')
INSERT [dbo].[Color] ([id], [title]) VALUES (12, N'Blue')
INSERT [dbo].[Color] ([id], [title]) VALUES (13, N'Black')
INSERT [dbo].[Color] ([id], [title]) VALUES (14, N'White')
INSERT [dbo].[Color] ([id], [title]) VALUES (15, N'Silver')
INSERT [dbo].[Color] ([id], [title]) VALUES (16, N'Gray')
INSERT [dbo].[Color] ([id], [title]) VALUES (17, N'Green')
INSERT [dbo].[Color] ([id], [title]) VALUES (18, N'Yellow')
INSERT [dbo].[Color] ([id], [title]) VALUES (19, N'Orange')
INSERT [dbo].[Color] ([id], [title]) VALUES (20, N'Purple')
INSERT [dbo].[Color] ([id], [title]) VALUES (21, N'Brown')
INSERT [dbo].[Color] ([id], [title]) VALUES (22, N'Gold')
INSERT [dbo].[Color] ([id], [title]) VALUES (23, N'Beige')
INSERT [dbo].[Color] ([id], [title]) VALUES (24, N'Maroon')
INSERT [dbo].[Color] ([id], [title]) VALUES (25, N'Navy')
INSERT [dbo].[Color] ([id], [title]) VALUES (26, N'Teal')
INSERT [dbo].[Color] ([id], [title]) VALUES (27, N'Cyan')
INSERT [dbo].[Color] ([id], [title]) VALUES (28, N'Magenta')
INSERT [dbo].[Color] ([id], [title]) VALUES (29, N'Turquoise')
INSERT [dbo].[Color] ([id], [title]) VALUES (30, N'Indigo')
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (22, CAST(50000.00 AS Decimal(7, 2)), CAST(5.5 AS Decimal(3, 1)), N'John', N'Doe', N'Michael', N'12345678901', 1)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (23, CAST(60000.00 AS Decimal(7, 2)), CAST(3.2 AS Decimal(3, 1)), N'Jane', N'Smith', N'Elizabeth', N'19876543210', 2)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (24, CAST(55000.00 AS Decimal(7, 2)), CAST(7.8 AS Decimal(3, 1)), N'Robert', N'Johnson', N'William', N'15551234567', 2)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (25, CAST(70000.00 AS Decimal(7, 2)), CAST(4.5 AS Decimal(3, 1)), N'Mary', N'Williams', N'Anne', N'17778889999', 2)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (26, CAST(65000.00 AS Decimal(7, 2)), CAST(6.1 AS Decimal(3, 1)), N'James', N'Brown', N'David', N'16667778888', 2)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (27, CAST(58000.00 AS Decimal(7, 2)), CAST(2.9 AS Decimal(3, 1)), N'Patricia', N'Jones', N'Louise', N'14443332222', 2)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (28, CAST(72000.00 AS Decimal(7, 2)), CAST(8.3 AS Decimal(3, 1)), N'Michael', N'Garcia', N'Joseph', N'12223334444', 2)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (29, CAST(53000.00 AS Decimal(7, 2)), CAST(1.7 AS Decimal(3, 1)), N'Linda', N'Miller', N'Marie', N'19998887777', 2)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (30, CAST(67000.00 AS Decimal(7, 2)), CAST(9.0 AS Decimal(3, 1)), N'William', N'Davis', N'Thomas', N'13334445555', 2)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (31, CAST(59000.00 AS Decimal(7, 2)), CAST(3.8 AS Decimal(3, 1)), N'Barbara', N'Rodriguez', N'Catherine', N'16669998888', 2)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (32, CAST(64000.00 AS Decimal(7, 2)), CAST(5.6 AS Decimal(3, 1)), N'Richard', N'Martinez', N'Charles', N'17775556666', 2)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (33, CAST(57000.00 AS Decimal(7, 2)), CAST(2.4 AS Decimal(3, 1)), N'Susan', N'Hernandez', N'Elizabeth', N'18882223333', 2)
INSERT [dbo].[Employee] ([id], [salary], [experience], [name], [surname], [lastname], [number], [role_id]) VALUES (34, CAST(71000.00 AS Decimal(7, 2)), CAST(7.9 AS Decimal(3, 1)), N'Joseph', N'Lopez', N'Daniel', N'19991112222', 2)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
INSERT [dbo].[Role] ([id], [name]) VALUES (1, N'Администратор')
INSERT [dbo].[Role] ([id], [name]) VALUES (2, N'Менеджер')
GO
ALTER TABLE [dbo].[Automobile]  WITH CHECK ADD  CONSTRAINT [FK_Automobile_Brand] FOREIGN KEY([Brand_ID])
REFERENCES [dbo].[Brand] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Automobile] CHECK CONSTRAINT [FK_Automobile_Brand]
GO
ALTER TABLE [dbo].[Automobile]  WITH CHECK ADD  CONSTRAINT [FK_Automobile_Category] FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Category] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Automobile] CHECK CONSTRAINT [FK_Automobile_Category]
GO
ALTER TABLE [dbo].[Automobile]  WITH CHECK ADD  CONSTRAINT [FK_Automobile_Color] FOREIGN KEY([Color_ID])
REFERENCES [dbo].[Color] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Automobile] CHECK CONSTRAINT [FK_Automobile_Color]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[Sale_automobile]  WITH CHECK ADD  CONSTRAINT [FK__Sale_auto__Autom__5535A963] FOREIGN KEY([Automobile_ID])
REFERENCES [dbo].[Automobile] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sale_automobile] CHECK CONSTRAINT [FK__Sale_auto__Autom__5535A963]
GO
ALTER TABLE [dbo].[Sale_automobile]  WITH CHECK ADD  CONSTRAINT [FK_Sale_automobile_Buyer1] FOREIGN KEY([Buyer_ID])
REFERENCES [dbo].[Buyer] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sale_automobile] CHECK CONSTRAINT [FK_Sale_automobile_Buyer1]
GO
ALTER TABLE [dbo].[Sale_automobile]  WITH CHECK ADD  CONSTRAINT [FK_Sale_automobile_Employee] FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employee] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sale_automobile] CHECK CONSTRAINT [FK_Sale_automobile_Employee]
GO
USE [master]
GO
ALTER DATABASE [skirnevskiy_course] SET  READ_WRITE 
GO

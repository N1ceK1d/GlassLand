/* НАПИШИ USE НАЗВАНИЕ БАЗЫ */
/* НАПРИМЕР USE Glassland */
USE БАЗА

/****** Object:  Table [dbo].[Employeers]    Script Date: 12/14/2022 12:56:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employeers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Post] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterSlave]    Script Date: 12/14/2022 12:56:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterSlave](
	[MasterId] [int] NOT NULL,
	[SlaveId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MasterId] ASC,
	[SlaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measurements]    Script Date: 12/14/2022 12:56:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measurements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[MeasurerId] [int] NOT NULL,
	[WindowWidth] [float] NOT NULL,
	[WindowHeight] [float] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MontageOrders]    Script Date: 12/14/2022 12:56:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MontageOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MasterId] [int] NOT NULL,
	[MeasurementId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/14/2022 12:56:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employeers] ON 

INSERT [dbo].[Employeers] ([Id], [Name], [Post]) VALUES (1, N'Measurer 1', N'Measurer')
INSERT [dbo].[Employeers] ([Id], [Name], [Post]) VALUES (2, N'Master 1', N'Master')
INSERT [dbo].[Employeers] ([Id], [Name], [Post]) VALUES (3, N'Slave 1', N'Slave')
INSERT [dbo].[Employeers] ([Id], [Name], [Post]) VALUES (4, N'Slave 2', N'Slave')
SET IDENTITY_INSERT [dbo].[Employeers] OFF
GO
INSERT [dbo].[MasterSlave] ([MasterId], [SlaveId]) VALUES (2, 3)
INSERT [dbo].[MasterSlave] ([MasterId], [SlaveId]) VALUES (2, 4)
GO
SET IDENTITY_INSERT [dbo].[Measurements] ON 

INSERT [dbo].[Measurements] ([Id], [CustomerName], [MeasurerId], [WindowWidth], [WindowHeight], [Address], [Date]) VALUES (1, N'Customer 1', 1, 100, 200, N'City 1 Street 1 Builing 1', CAST(N'2022-12-12T06:50:13.827' AS DateTime))
SET IDENTITY_INSERT [dbo].[Measurements] OFF
GO
SET IDENTITY_INSERT [dbo].[MontageOrders] ON 

INSERT [dbo].[MontageOrders] ([Id], [MasterId], [MeasurementId], [Date], [Status]) VALUES (1, 2, 1, CAST(N'2022-12-05T00:00:00.000' AS DateTime), N'Accepted')
INSERT [dbo].[MontageOrders] ([Id], [MasterId], [MeasurementId], [Date], [Status]) VALUES (2, 2, 1, CAST(N'2022-12-01T00:00:00.000' AS DateTime), N'Declined')
INSERT [dbo].[MontageOrders] ([Id], [MasterId], [MeasurementId], [Date], [Status]) VALUES (3, 2, 1, CAST(N'2022-11-29T00:00:00.000' AS DateTime), N'Accepted')
INSERT [dbo].[MontageOrders] ([Id], [MasterId], [MeasurementId], [Date], [Status]) VALUES (4, 2, 1, CAST(N'2022-12-13T00:00:00.000' AS DateTime), N'Accepted')
SET IDENTITY_INSERT [dbo].[MontageOrders] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (1, N'L_manager', N'changeme', N'Manager')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

USE [D:\GLASSLAND-MASTER\GLASSLAND\GLASSLAND.MDF]
GO
/****** Object:  Table [dbo].[Employeers]    Script Date: 25.03.2023 21:12:45 ******/
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
/****** Object:  Table [dbo].[History]    Script Date: 25.03.2023 21:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[MasterName] [nvarchar](50) NOT NULL,
	[MeasurerName] [nvarchar](50) NOT NULL,
	[Window] [nvarchar](50) NOT NULL,
	[WindowHeight] [int] NOT NULL,
	[WindowWidth] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterSlave]    Script Date: 25.03.2023 21:12:46 ******/
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
/****** Object:  Table [dbo].[Measurements]    Script Date: 25.03.2023 21:12:46 ******/
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
/****** Object:  Table [dbo].[MontageOrders]    Script Date: 25.03.2023 21:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MontageOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MasterId] [int] NOT NULL,
	[MeasurementId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[WindowId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.03.2023 21:12:46 ******/
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
/****** Object:  Table [dbo].[Windows]    Script Date: 25.03.2023 21:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Windows](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MasterSlave]  WITH CHECK ADD  CONSTRAINT [FK_MasterSlave_Employeers] FOREIGN KEY([MasterId])
REFERENCES [dbo].[Employeers] ([Id])
GO
ALTER TABLE [dbo].[MasterSlave] CHECK CONSTRAINT [FK_MasterSlave_Employeers]
GO
ALTER TABLE [dbo].[MasterSlave]  WITH CHECK ADD  CONSTRAINT [FK_MasterSlave_Employeers1] FOREIGN KEY([SlaveId])
REFERENCES [dbo].[Employeers] ([Id])
GO
ALTER TABLE [dbo].[MasterSlave] CHECK CONSTRAINT [FK_MasterSlave_Employeers1]
GO
ALTER TABLE [dbo].[Measurements]  WITH CHECK ADD  CONSTRAINT [FK_Measurements_Employeers] FOREIGN KEY([MeasurerId])
REFERENCES [dbo].[Employeers] ([Id])
GO
ALTER TABLE [dbo].[Measurements] CHECK CONSTRAINT [FK_Measurements_Employeers]
GO
ALTER TABLE [dbo].[MontageOrders]  WITH CHECK ADD FOREIGN KEY([MasterId])
REFERENCES [dbo].[Employeers] ([Id])
GO
ALTER TABLE [dbo].[MontageOrders]  WITH CHECK ADD FOREIGN KEY([MeasurementId])
REFERENCES [dbo].[Measurements] ([Id])
GO
ALTER TABLE [dbo].[MontageOrders]  WITH CHECK ADD FOREIGN KEY([WindowId])
REFERENCES [dbo].[Windows] ([Id])
GO

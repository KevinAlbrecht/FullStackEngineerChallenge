USE [master]
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Paybaymax')
BEGIN
	PRINT N'Already existing [Paybaymax] database please drop it';
END
GO
BEGIN
	PRINT N'Creating [Paybaymax] database'
	CREATE DATABASE [Paybaymax]
END
GO
	USE [Paybaymax]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
PRINT N'Creating [dbo].[Employee] ...'
CREATE TABLE [dbo].[Employee](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Job] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
PRINT N'Creating [dbo].[Performance] ...'
CREATE TABLE [dbo].[Performance](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Date] [date] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Performance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
PRINT N'Creating [dbo].[PerformanceAssignedEmployee] ...'
CREATE TABLE [dbo].[PerformanceAssignedEmployee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[PerformanceId] [uniqueidentifier] NOT NULL,
	[Done] [bit] NOT NULL,
 CONSTRAINT [PK_PerformanceAssignedEmployee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
PRINT N'Creating [dbo].[Review] ...'
CREATE TABLE [dbo].[Review](
	[Id] [uniqueidentifier] NOT NULL,
	[GlobalRating] [tinyint] NOT NULL,
	[QualityRating] [tinyint] NOT NULL,
	[InitiativeRating] [tinyint] NOT NULL,
	[CooperationRating] [tinyint] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[UpdatedDate] [date] NULL,
	[PerformanceId] [uniqueidentifier] NOT NULL,
	[CreatorEmployeeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
PRINT N'Creating [dbo].[User] ...'
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[UserType] [tinyint] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
PRINT N'Creating [dbo].[UserType] ...'
CREATE TABLE [dbo].[UserType](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [master]
GO
ALTER DATABASE [Paybaymax] SET  READ_WRITE 
GO

USE [Paybaymax]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Performance] ADD  CONSTRAINT [DF_Performance_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[PerformanceAssignedEmployee] ADD  CONSTRAINT [DF_PerformanceAssignedEmployee_Done]  DEFAULT ((0)) FOR [Done]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Performance]  WITH CHECK ADD  CONSTRAINT [FK_Performance_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Performance] CHECK CONSTRAINT [FK_Performance_Employee]
GO
ALTER TABLE [dbo].[PerformanceAssignedEmployee]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceAssignedEmployee_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[PerformanceAssignedEmployee] CHECK CONSTRAINT [FK_PerformanceAssignedEmployee_Employee]
GO
ALTER TABLE [dbo].[PerformanceAssignedEmployee]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceAssignedEmployee_Performance] FOREIGN KEY([PerformanceId])
REFERENCES [dbo].[Performance] ([Id])
GO
ALTER TABLE [dbo].[PerformanceAssignedEmployee] CHECK CONSTRAINT [FK_PerformanceAssignedEmployee_Performance]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Employee] FOREIGN KEY([CreatorEmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Employee]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Performance] FOREIGN KEY([PerformanceId])
REFERENCES [dbo].[Performance] ([Id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Performance]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserType] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserType]
GO
USE [master]
GO
ALTER DATABASE [Paybaymax] SET  READ_WRITE 
GO

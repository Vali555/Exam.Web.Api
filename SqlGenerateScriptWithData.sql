USE [ExamProject]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17.07.2025 20:52:10 ******/
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
/****** Object:  Table [dbo].[Classes]    Script Date: 17.07.2025 20:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamProcesses]    Script Date: 17.07.2025 20:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamProcesses](
	[Id] [uniqueidentifier] NOT NULL,
	[LessonId] [uniqueidentifier] NOT NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
	[ExamDate] [datetime2](7) NOT NULL,
	[ExamGrade] [int] NOT NULL,
 CONSTRAINT [PK_ExamProcesses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 17.07.2025 20:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[Id] [uniqueidentifier] NOT NULL,
	[LessonCode] [char](3) NOT NULL,
	[LessonName] [nvarchar](30) NOT NULL,
	[ClassId] [uniqueidentifier] NOT NULL,
	[TeacherId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 17.07.2025 20:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [int] NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[ClassId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 17.07.2025 20:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250717090538_InitialCreate', N'9.0.7')
GO
INSERT [dbo].[Classes] ([Id], [Number]) VALUES (N'd567d144-7144-4782-861b-9b4111e11399', 1)
INSERT [dbo].[Classes] ([Id], [Number]) VALUES (N'6f4bbae5-31f3-452e-97b5-f4f2c9009383', 2)
GO
INSERT [dbo].[ExamProcesses] ([Id], [LessonId], [StudentId], [ExamDate], [ExamGrade]) VALUES (N'bd3b1325-c0ea-41a7-80ed-234ef53fc9c7', N'3321a96a-81d3-4c31-b7a5-4206a59d506c', N'7e54c54e-e616-40ab-b090-4035292468c8', CAST(N'2025-07-17T12:06:04.0030000' AS DateTime2), 5)
INSERT [dbo].[ExamProcesses] ([Id], [LessonId], [StudentId], [ExamDate], [ExamGrade]) VALUES (N'3321a96a-81d3-4c31-b7a5-4206a59d506c', N'3321a96a-81d3-4c31-b7a5-4206a59d506c', N'23cda873-eb27-437b-b604-cc0ba5b2b0af', CAST(N'1992-03-28T00:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[ExamProcesses] ([Id], [LessonId], [StudentId], [ExamDate], [ExamGrade]) VALUES (N'86e9a3b1-d873-4f23-93d5-9f8aa513949f', N'3321a96a-81d3-4c31-b7a5-4206a59d506c', N'23cda873-eb27-437b-b604-cc0ba5b2b0af', CAST(N'2025-07-17T16:40:20.3250000' AS DateTime2), 5)
GO
INSERT [dbo].[Lessons] ([Id], [LessonCode], [LessonName], [ClassId], [TeacherId]) VALUES (N'3321a96a-81d3-4c31-b7a5-4206a59d506c', N'333', N'Riyaziyyat', N'6f4bbae5-31f3-452e-97b5-f4f2c9009383', N'3321a96a-81d3-4c31-b7a5-4206a59d506c')
GO
INSERT [dbo].[Students] ([Id], [Number], [FirstName], [LastName], [ClassId]) VALUES (N'7e54c54e-e616-40ab-b090-4035292468c8', 5, N'string', N'string', N'6f4bbae5-31f3-452e-97b5-f4f2c9009383')
INSERT [dbo].[Students] ([Id], [Number], [FirstName], [LastName], [ClassId]) VALUES (N'23cda873-eb27-437b-b604-cc0ba5b2b0af', 11, N'Boyuk', N'Boyuk', N'6f4bbae5-31f3-452e-97b5-f4f2c9009383')
GO
INSERT [dbo].[Teachers] ([Id], [FirstName], [LastName]) VALUES (N'3321a96a-81d3-4c31-b7a5-4206a59d506c', N'Muellime', N'Muellime')
GO
ALTER TABLE [dbo].[ExamProcesses]  WITH CHECK ADD  CONSTRAINT [FK_ExamProcesses_Lessons_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons] ([Id])
GO
ALTER TABLE [dbo].[ExamProcesses] CHECK CONSTRAINT [FK_ExamProcesses_Lessons_LessonId]
GO
ALTER TABLE [dbo].[ExamProcesses]  WITH CHECK ADD  CONSTRAINT [FK_ExamProcesses_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[ExamProcesses] CHECK CONSTRAINT [FK_ExamProcesses_Students_StudentId]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lessons_Classes_ClassId] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lessons_Classes_ClassId]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lessons_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lessons_Teachers_TeacherId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Classes_ClassId] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Classes_ClassId]
GO

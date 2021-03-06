USE [IndividualProject]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 5/11/2020 3:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[AssignmentID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[Description] [varchar](30) NOT NULL,
	[SubDateTime] [date] NOT NULL,
	[OralMark] [decimal](5, 2) NOT NULL,
	[TotalMark] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED 
(
	[AssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignmentsPerCourse]    Script Date: 5/11/2020 3:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignmentsPerCourse](
	[AssignmentID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
 CONSTRAINT [PK_AssignmentsPerCourse] PRIMARY KEY CLUSTERED 
(
	[AssignmentID] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 5/11/2020 3:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[Stream] [varchar](30) NOT NULL,
	[Type] [varchar](30) NOT NULL,
	[Start_Date] [date] NOT NULL,
	[End_Date] [date] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 5/11/2020 3:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[TuitionFees] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentsPerCourse]    Script Date: 5/11/2020 3:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsPerCourse](
	[CourseID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
 CONSTRAINT [PK_StudentsPerCourse] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainers]    Script Date: 5/11/2020 3:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainers](
	[TrainerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Subject] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Trainers] PRIMARY KEY CLUSTERED 
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainersPerCourse]    Script Date: 5/11/2020 3:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainersPerCourse](
	[TrainerID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
 CONSTRAINT [PK_TrainersPerCourse] PRIMARY KEY CLUSTERED 
(
	[TrainerID] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Assignments] ON 

INSERT [dbo].[Assignments] ([AssignmentID], [Title], [Description], [SubDateTime], [OralMark], [TotalMark]) VALUES (1, N'IndividualProject', N'PartA', CAST(N'2020-04-11' AS Date), CAST(40.00 AS Decimal(5, 2)), CAST(85.00 AS Decimal(5, 2)))
INSERT [dbo].[Assignments] ([AssignmentID], [Title], [Description], [SubDateTime], [OralMark], [TotalMark]) VALUES (2, N'IndividualProject', N'PartB', CAST(N'2020-05-11' AS Date), CAST(40.00 AS Decimal(5, 2)), CAST(90.00 AS Decimal(5, 2)))
INSERT [dbo].[Assignments] ([AssignmentID], [Title], [Description], [SubDateTime], [OralMark], [TotalMark]) VALUES (3, N'OOP', N'Basics', CAST(N'2020-07-16' AS Date), CAST(55.00 AS Decimal(5, 2)), CAST(95.00 AS Decimal(5, 2)))
INSERT [dbo].[Assignments] ([AssignmentID], [Title], [Description], [SubDateTime], [OralMark], [TotalMark]) VALUES (4, N'SQL', N'Basics', CAST(N'2020-06-25' AS Date), CAST(60.00 AS Decimal(5, 2)), CAST(99.00 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[Assignments] OFF
GO
INSERT [dbo].[AssignmentsPerCourse] ([AssignmentID], [CourseID]) VALUES (1, 1)
INSERT [dbo].[AssignmentsPerCourse] ([AssignmentID], [CourseID]) VALUES (1, 2)
INSERT [dbo].[AssignmentsPerCourse] ([AssignmentID], [CourseID]) VALUES (1, 3)
INSERT [dbo].[AssignmentsPerCourse] ([AssignmentID], [CourseID]) VALUES (2, 1)
INSERT [dbo].[AssignmentsPerCourse] ([AssignmentID], [CourseID]) VALUES (2, 2)
INSERT [dbo].[AssignmentsPerCourse] ([AssignmentID], [CourseID]) VALUES (3, 1)
INSERT [dbo].[AssignmentsPerCourse] ([AssignmentID], [CourseID]) VALUES (3, 3)
INSERT [dbo].[AssignmentsPerCourse] ([AssignmentID], [CourseID]) VALUES (4, 2)
INSERT [dbo].[AssignmentsPerCourse] ([AssignmentID], [CourseID]) VALUES (4, 3)
INSERT [dbo].[AssignmentsPerCourse] ([AssignmentID], [CourseID]) VALUES (4, 4)
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseID], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (1, N'CB10', N'C#', N'Part-Time', CAST(N'2020-08-24' AS Date), CAST(N'2021-02-24' AS Date))
INSERT [dbo].[Courses] ([CourseID], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (2, N'CB10', N'C#', N'Full-Time', CAST(N'2020-08-28' AS Date), CAST(N'2020-11-28' AS Date))
INSERT [dbo].[Courses] ([CourseID], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (3, N'CB10', N'Java', N'Part-Time', CAST(N'2020-08-24' AS Date), CAST(N'2021-02-24' AS Date))
INSERT [dbo].[Courses] ([CourseID], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (4, N'CB10', N'Java', N'Full-Time', CAST(N'2020-08-28' AS Date), CAST(N'2020-11-28' AS Date))
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (1, N'Giannhs', N'Petrou', CAST(N'1994-05-11' AS Date), CAST(350.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (2, N'Kostas', N'Tsep', CAST(N'1994-03-11' AS Date), CAST(350.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (3, N'Nektarios', N'Papagewrgiou', CAST(N'1995-07-14' AS Date), CAST(800.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (4, N'Nikos', N'Kastriths', CAST(N'1994-10-25' AS Date), CAST(800.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (5, N'Panagioths', N'Maroniths', CAST(N'1995-03-20' AS Date), CAST(350.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (6, N'Stefanos', N'Iordanopoulos', CAST(N'1995-06-15' AS Date), CAST(800.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (7, N'Thanasis', N'Setel', CAST(N'1991-07-26' AS Date), CAST(350.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
INSERT [dbo].[StudentsPerCourse] ([CourseID], [StudentID]) VALUES (1, 1)
INSERT [dbo].[StudentsPerCourse] ([CourseID], [StudentID]) VALUES (1, 3)
INSERT [dbo].[StudentsPerCourse] ([CourseID], [StudentID]) VALUES (1, 7)
INSERT [dbo].[StudentsPerCourse] ([CourseID], [StudentID]) VALUES (2, 1)
INSERT [dbo].[StudentsPerCourse] ([CourseID], [StudentID]) VALUES (2, 4)
INSERT [dbo].[StudentsPerCourse] ([CourseID], [StudentID]) VALUES (2, 5)
INSERT [dbo].[StudentsPerCourse] ([CourseID], [StudentID]) VALUES (3, 4)
INSERT [dbo].[StudentsPerCourse] ([CourseID], [StudentID]) VALUES (3, 6)
INSERT [dbo].[StudentsPerCourse] ([CourseID], [StudentID]) VALUES (4, 6)
GO
SET IDENTITY_INSERT [dbo].[Trainers] ON 

INSERT [dbo].[Trainers] ([TrainerID], [FirstName], [LastName], [Subject]) VALUES (1, N'Mixalhs', N'Xamhlos', N'C#')
INSERT [dbo].[Trainers] ([TrainerID], [FirstName], [LastName], [Subject]) VALUES (2, N'Kostas', N'Stroggylos', N'Java')
INSERT [dbo].[Trainers] ([TrainerID], [FirstName], [LastName], [Subject]) VALUES (3, N'panos', N'Bozas', N'C#')
INSERT [dbo].[Trainers] ([TrainerID], [FirstName], [LastName], [Subject]) VALUES (4, N'Periklhs', N'Aidino', N'Java')
SET IDENTITY_INSERT [dbo].[Trainers] OFF
GO
INSERT [dbo].[TrainersPerCourse] ([TrainerID], [CourseID]) VALUES (1, 1)
INSERT [dbo].[TrainersPerCourse] ([TrainerID], [CourseID]) VALUES (1, 2)
INSERT [dbo].[TrainersPerCourse] ([TrainerID], [CourseID]) VALUES (2, 3)
INSERT [dbo].[TrainersPerCourse] ([TrainerID], [CourseID]) VALUES (2, 4)
INSERT [dbo].[TrainersPerCourse] ([TrainerID], [CourseID]) VALUES (3, 1)
INSERT [dbo].[TrainersPerCourse] ([TrainerID], [CourseID]) VALUES (4, 3)
INSERT [dbo].[TrainersPerCourse] ([TrainerID], [CourseID]) VALUES (4, 4)
GO
ALTER TABLE [dbo].[AssignmentsPerCourse]  WITH CHECK ADD  CONSTRAINT [AssignmentsC] FOREIGN KEY([AssignmentID])
REFERENCES [dbo].[Assignments] ([AssignmentID])
GO
ALTER TABLE [dbo].[AssignmentsPerCourse] CHECK CONSTRAINT [AssignmentsC]
GO
ALTER TABLE [dbo].[AssignmentsPerCourse]  WITH CHECK ADD  CONSTRAINT [CoursesA] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[AssignmentsPerCourse] CHECK CONSTRAINT [CoursesA]
GO
ALTER TABLE [dbo].[StudentsPerCourse]  WITH CHECK ADD  CONSTRAINT [CoursesS] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[StudentsPerCourse] CHECK CONSTRAINT [CoursesS]
GO
ALTER TABLE [dbo].[StudentsPerCourse]  WITH CHECK ADD  CONSTRAINT [StudentsC] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[StudentsPerCourse] CHECK CONSTRAINT [StudentsC]
GO
ALTER TABLE [dbo].[TrainersPerCourse]  WITH CHECK ADD  CONSTRAINT [CoursesT] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[TrainersPerCourse] CHECK CONSTRAINT [CoursesT]
GO
ALTER TABLE [dbo].[TrainersPerCourse]  WITH CHECK ADD  CONSTRAINT [TrainersC] FOREIGN KEY([TrainerID])
REFERENCES [dbo].[Trainers] ([TrainerID])
GO
ALTER TABLE [dbo].[TrainersPerCourse] CHECK CONSTRAINT [TrainersC]
GO

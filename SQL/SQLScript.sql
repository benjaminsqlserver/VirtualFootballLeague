USE [master]
GO
/****** Object:  Database [VirtualLeagueDB]    Script Date: 03/10/2022 1:48:41 PM ******/
CREATE DATABASE [VirtualLeagueDB]

GO
USE [VirtualLeagueDB]
GO
/****** Object:  Table [dbo].[FixtureTemplates]    Script Date: 03/10/2022 1:48:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureTemplates](
	[TemplateID] [int] IDENTITY(1,1) NOT NULL,
	[HomeTeam] [nvarchar](50) NOT NULL,
	[AwayTeam] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FixtureTemplates] PRIMARY KEY CLUSTERED 
(
	[TemplateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeagueSeasons]    Script Date: 03/10/2022 1:48:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeagueSeasons](
	[SeasonID] [int] IDENTITY(1,1) NOT NULL,
	[SeasonName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LeagueSeasons] PRIMARY KEY CLUSTERED 
(
	[SeasonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatchDays]    Script Date: 03/10/2022 1:48:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchDays](
	[MatchDayID] [int] IDENTITY(1,1) NOT NULL,
	[MatchDayName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MatchDays] PRIMARY KEY CLUSTERED 
(
	[MatchDayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 03/10/2022 1:48:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VirtualLeagueResults]    Script Date: 03/10/2022 1:48:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VirtualLeagueResults](
	[RecordID] [bigint] IDENTITY(1,1) NOT NULL,
	[SeasonID] [int] NOT NULL,
	[MatchDayID] [int] NOT NULL,
	[HomeTeamID] [int] NOT NULL,
	[HomeScore] [int] NOT NULL,
	[AwayTeamID] [int] NOT NULL,
	[AwayScore] [int] NOT NULL,
 CONSTRAINT [PK_VirtualLeagueResults] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FixtureTemplates] ON 
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (1, N'PL1', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (2, N'PL3', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (3, N'PL5', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (4, N'PL7', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (5, N'PL9', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (6, N'PL11', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (7, N'PL13', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (8, N'PL15', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (9, N'PL17', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (10, N'PL19', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (11, N'PL14', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (12, N'PL6', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (13, N'PL2', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (14, N'PL12', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (15, N'PL8', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (16, N'PL1', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (17, N'PL16', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (18, N'PL10', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (19, N'PL4', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (20, N'PL20', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (21, N'PL15', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (22, N'PL5', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (23, N'PL17', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (24, N'PL7', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (25, N'PL19', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (26, N'PL9', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (27, N'PL3', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (28, N'PL13', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (29, N'PL11', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (30, N'PL18', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (31, N'PL14', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (32, N'PL16', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (33, N'PL1', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (34, N'PL19', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (35, N'PL20', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (36, N'PL4', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (37, N'PL2', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (38, N'PL8', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (39, N'PL6', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (40, N'PL12', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (41, N'PL9', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (42, N'PL3', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (43, N'PL15', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (44, N'PL7', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (45, N'PL10', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (46, N'PL5', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (47, N'PL18', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (48, N'PL17', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (49, N'PL11', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (50, N'PL13', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (51, N'PL19', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (52, N'PL1', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (53, N'PL3', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (54, N'PL14', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (55, N'PL4', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (56, N'PL2', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (57, N'PL20', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (58, N'PL6', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (59, N'PL12', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (60, N'PL16', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (61, N'PL17', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (62, N'PL13', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (63, N'PL15', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (64, N'PL7', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (65, N'PL5', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (66, N'PL18', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (67, N'PL8', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (68, N'PL11', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (69, N'PL10', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (70, N'PL9', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (71, N'PL19', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (72, N'PL2', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (73, N'PL12', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (74, N'PL1', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (75, N'PL14', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (76, N'PL20', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (77, N'PL3', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (78, N'PL6', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (79, N'PL4', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (80, N'PL5', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (81, N'PL10', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (82, N'PL7', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (83, N'PL13', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (84, N'PL17', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (85, N'PL16', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (86, N'PL18', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (87, N'PL8', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (88, N'PL11', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (89, N'PL9', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (90, N'PL15', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (91, N'PL6', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (92, N'PL5', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (93, N'PL20', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (94, N'PL19', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (95, N'PL4', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (96, N'PL11', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (97, N'PL2', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (98, N'PL12', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (99, N'PL3', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (100, N'PL1', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (101, N'PL13', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (102, N'PL18', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (103, N'PL10', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (104, N'PL15', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (105, N'PL9', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (106, N'PL17', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (107, N'PL16', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (108, N'PL8', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (109, N'PL14', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (110, N'PL7', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (111, N'PL5', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (112, N'PL3', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (113, N'PL19', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (114, N'PL11', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (115, N'PL2', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (116, N'PL6', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (117, N'PL13', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (118, N'PL1', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (119, N'PL4', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (120, N'PL20', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (121, N'PL10', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (122, N'PL16', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (123, N'PL9', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (124, N'PL15', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (125, N'PL14', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (126, N'PL17', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (127, N'PL12', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (128, N'PL18', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (129, N'PL7', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (130, N'PL8', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (131, N'PL1', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (132, N'PL5', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (133, N'PL13', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (134, N'PL20', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (135, N'PL19', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (136, N'PL11', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (137, N'PL15', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (138, N'PL4', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (139, N'PL2', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (140, N'PL3', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (141, N'PL12', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (142, N'PL18', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (143, N'PL9', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (144, N'PL6', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (145, N'PL14', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (146, N'PL17', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (147, N'PL10', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (148, N'PL7', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (149, N'PL8', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (150, N'PL16', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (151, N'PL13', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (152, N'PL3', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (153, N'PL19', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (154, N'PL5', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (155, N'PL1', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (156, N'PL20', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (157, N'PL7', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (158, N'PL11', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (159, N'PL2', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (160, N'PL15', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (161, N'PL16', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (162, N'PL12', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (163, N'PL14', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (164, N'PL6', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (165, N'PL17', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (166, N'PL18', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (167, N'PL4', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (168, N'PL8', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (169, N'PL9', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (170, N'PL10', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (171, N'PL5', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (172, N'PL13', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (173, N'PL15', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (174, N'PL7', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (175, N'PL3', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (176, N'PL9', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (177, N'PL1', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (178, N'PL19', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (179, N'PL2', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (180, N'PL11', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (181, N'PL16', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (182, N'PL10', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (183, N'PL20', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (184, N'PL17', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (185, N'PL14', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (186, N'PL18', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (187, N'PL6', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (188, N'PL4', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (189, N'PL8', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (190, N'PL12', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (191, N'PL4', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (192, N'PL14', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (193, N'PL20', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (194, N'PL6', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (195, N'PL16', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (196, N'PL8', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (197, N'PL12', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (198, N'PL10', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (199, N'PL2', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (200, N'PL18', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (201, N'PL5', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (202, N'PL7', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (203, N'PL9', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (204, N'PL17', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (205, N'PL11', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (206, N'PL13', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (207, N'PL18', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (208, N'PL3', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (209, N'PL19', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (210, N'PL15', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (211, N'PL14', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (212, N'PL2', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (213, N'PL8', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (214, N'PL6', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (215, N'PL12', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (216, N'PL16', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (217, N'PL1', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (218, N'PL4', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (219, N'PL10', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (220, N'PL20', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (221, N'PL7', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (222, N'PL5', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (223, N'PL17', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (224, N'PL18', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (225, N'PL15', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (226, N'PL13', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (227, N'PL3', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (228, N'PL10', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (229, N'PL11', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (230, N'PL9', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (231, N'PL8', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (232, N'PL14', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (233, N'PL6', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (234, N'PL19', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (235, N'PL1', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (236, N'PL4', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (237, N'PL20', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (238, N'PL2', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (239, N'PL12', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (240, N'PL16', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (241, N'PL9', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (242, N'PL8', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (243, N'PL15', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (244, N'PL7', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (245, N'PL13', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (246, N'PL10', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (247, N'PL11', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (248, N'PL18', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (249, N'PL17', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (250, N'PL5', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (251, N'PL14', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (252, N'PL4', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (253, N'PL12', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (254, N'PL20', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (255, N'PL6', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (256, N'PL16', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (257, N'PL1', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (258, N'PL19', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (259, N'PL3', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (260, N'PL2', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (261, N'PL17', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (262, N'PL10', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (263, N'PL16', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (264, N'PL18', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (265, N'PL7', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (266, N'PL15', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (267, N'PL13', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (268, N'PL11', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (269, N'PL9', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (270, N'PL8', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (271, N'PL14', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (272, N'PL3', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (273, N'PL19', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (274, N'PL2', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (275, N'PL1', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (276, N'PL12', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (277, N'PL20', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (278, N'PL6', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (279, N'PL5', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (280, N'PL4', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (281, N'PL14', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (282, N'PL7', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (283, N'PL17', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (284, N'PL13', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (285, N'PL16', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (286, N'PL8', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (287, N'PL18', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (288, N'PL9', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (289, N'PL10', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (290, N'PL15', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (291, N'PL11', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (292, N'PL4', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (293, N'PL3', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (294, N'PL2', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (295, N'PL6', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (296, N'PL19', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (297, N'PL12', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (298, N'PL5', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (299, N'PL1', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (300, N'PL20', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (301, N'PL17', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (302, N'PL10', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (303, N'PL14', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (304, N'PL9', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (305, N'PL12', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (306, N'PL7', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (307, N'PL18', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (308, N'PL16', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (309, N'PL15', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (310, N'PL8', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (311, N'PL13', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (312, N'PL11', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (313, N'PL2', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (314, N'PL6', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (315, N'PL19', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (316, N'PL4', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (317, N'PL5', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (318, N'PL20', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (319, N'PL3', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (320, N'PL1', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (321, N'PL7', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (322, N'PL8', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (323, N'PL17', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (324, N'PL16', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (325, N'PL6', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (326, N'PL12', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (327, N'PL14', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (328, N'PL9', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (329, N'PL18', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (330, N'PL10', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (331, N'PL19', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (332, N'PL3', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (333, N'PL4', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (334, N'PL2', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (335, N'PL15', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (336, N'PL5', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (337, N'PL1', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (338, N'PL20', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (339, N'PL13', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (340, N'PL11', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (341, N'PL8', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (342, N'PL9', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (343, N'PL16', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (344, N'PL14', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (345, N'PL4', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (346, N'PL17', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (347, N'PL18', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (348, N'PL12', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (349, N'PL10', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (350, N'PL6', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (351, N'PL1', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (352, N'PL15', N'PL18')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (353, N'PL2', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (354, N'PL20', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (355, N'PL7', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (356, N'PL13', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (357, N'PL5', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (358, N'PL11', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (359, N'PL19', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (360, N'PL3', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (361, N'PL16', N'PL11')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (362, N'PL12', N'PL3')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (363, N'PL10', N'PL15')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (364, N'PL14', N'PL5')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (365, N'PL18', N'PL7')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (366, N'PL4', N'PL1')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (367, N'PL6', N'PL19')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (368, N'PL20', N'PL2')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (369, N'PL17', N'PL9')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (370, N'PL8', N'PL13')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (371, N'PL7', N'PL10')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (372, N'PL2', N'PL17')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (373, N'PL1', N'PL20')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (374, N'PL19', N'PL4')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (375, N'PL15', N'PL8')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (376, N'PL5', N'PL12')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (377, N'PL13', N'PL16')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (378, N'PL3', N'PL6')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (379, N'PL11', N'PL14')
GO
INSERT [dbo].[FixtureTemplates] ([TemplateID], [HomeTeam], [AwayTeam]) VALUES (380, N'PL9', N'PL18')
GO
SET IDENTITY_INSERT [dbo].[FixtureTemplates] OFF
GO
SET IDENTITY_INSERT [dbo].[MatchDays] ON 
GO
INSERT [dbo].[MatchDays] ([MatchDayID], [MatchDayName]) VALUES (1, N'Matchday One')
GO
INSERT [dbo].[MatchDays] ([MatchDayID], [MatchDayName]) VALUES (2, N'Matchday Two')
GO
SET IDENTITY_INSERT [dbo].[MatchDays] OFF
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (6, N'Ajegunle Devils')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (12, N'Anthony Peacocks')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (3, N'Bonny Camp Lilywhites')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (4, N'CMS Seagulls')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (10, N'Ejigbo Bees')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (16, N'Enugu Saints')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (13, N'Gbagada Poppies')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (17, N'Ibadan Eagles')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (8, N'Isolo Cottagers')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (9, N'Jakande Reds')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (20, N'Jos Foxes')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (18, N'Kaduna Wolves')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (14, N'Kano Lions')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (1, N'Lekki Gunners')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (7, N'Mushin Magpies')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (5, N'Oshodi Blues')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (15, N'Port Harcourt Irons')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (11, N'Surulere Dogs Of War')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (19, N'Uyo Rangers')
GO
INSERT [dbo].[Teams] ([TeamID], [TeamName]) VALUES (2, N'Victoria Island Citizens')
GO
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_LeagueSeasons]    Script Date: 03/10/2022 1:48:41 PM ******/
ALTER TABLE [dbo].[LeagueSeasons] ADD  CONSTRAINT [IX_LeagueSeasons] UNIQUE NONCLUSTERED 
(
	[SeasonName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MatchDays]    Script Date: 03/10/2022 1:48:41 PM ******/
ALTER TABLE [dbo].[MatchDays] ADD  CONSTRAINT [IX_MatchDays] UNIQUE NONCLUSTERED 
(
	[MatchDayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Teams]    Script Date: 03/10/2022 1:48:41 PM ******/
ALTER TABLE [dbo].[Teams] ADD  CONSTRAINT [IX_Teams] UNIQUE NONCLUSTERED 
(
	[TeamName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[VirtualLeagueResults]  WITH CHECK ADD  CONSTRAINT [FK_VirtualLeagueResults_LeagueSeasons] FOREIGN KEY([SeasonID])
REFERENCES [dbo].[LeagueSeasons] ([SeasonID])
GO
ALTER TABLE [dbo].[VirtualLeagueResults] CHECK CONSTRAINT [FK_VirtualLeagueResults_LeagueSeasons]
GO
ALTER TABLE [dbo].[VirtualLeagueResults]  WITH CHECK ADD  CONSTRAINT [FK_VirtualLeagueResults_MatchDays] FOREIGN KEY([MatchDayID])
REFERENCES [dbo].[MatchDays] ([MatchDayID])
GO
ALTER TABLE [dbo].[VirtualLeagueResults] CHECK CONSTRAINT [FK_VirtualLeagueResults_MatchDays]
GO
ALTER TABLE [dbo].[VirtualLeagueResults]  WITH CHECK ADD  CONSTRAINT [FK_VirtualLeagueResults_Teams] FOREIGN KEY([HomeTeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO
ALTER TABLE [dbo].[VirtualLeagueResults] CHECK CONSTRAINT [FK_VirtualLeagueResults_Teams]
GO
ALTER TABLE [dbo].[VirtualLeagueResults]  WITH CHECK ADD  CONSTRAINT [FK_VirtualLeagueResults_Teams1] FOREIGN KEY([AwayTeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO
ALTER TABLE [dbo].[VirtualLeagueResults] CHECK CONSTRAINT [FK_VirtualLeagueResults_Teams1]
GO
USE [master]
GO
ALTER DATABASE [VirtualLeagueDB] SET  READ_WRITE 
GO

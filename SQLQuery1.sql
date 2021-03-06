
/****** Object:  Table [dbo].[AuthorTable]    Script Date: 02-03-2020 10:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AuthorTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [varchar](50) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookTable]    Script Date: 02-03-2020 10:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](50) NULL,
 CONSTRAINT [PK_BookTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentTable]    Script Date: 02-03-2020 10:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[FatherName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[AuthorID] [int] NULL,
	[BookID] [int] NULL,
 CONSTRAINT [PK_StudentTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 02-03-2020 10:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserLogin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AuthorTable] ON 

GO
INSERT [dbo].[AuthorTable] ([ID], [AuthorName]) VALUES (1, N'Nirmal Singh')
GO
INSERT [dbo].[AuthorTable] ([ID], [AuthorName]) VALUES (2, N'Kamal Singh')
GO
SET IDENTITY_INSERT [dbo].[AuthorTable] OFF
GO
SET IDENTITY_INSERT [dbo].[BookTable] ON 

GO
INSERT [dbo].[BookTable] ([ID], [BookName]) VALUES (1, N'Software Analysis')
GO
INSERT [dbo].[BookTable] ([ID], [BookName]) VALUES (2, N'Computer Basic')
GO
SET IDENTITY_INSERT [dbo].[BookTable] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentTable] ON 

GO
INSERT [dbo].[StudentTable] ([ID], [Name], [FatherName], [Email], [Mobile], [AuthorID], [BookID]) VALUES (1, N'Jaswinder', N'Kamal', N'abc@gmail.com', N'9878675656', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[StudentTable] OFF
GO
SET IDENTITY_INSERT [dbo].[UserLogin] ON 

GO
INSERT [dbo].[UserLogin] ([ID], [UserName], [Password]) VALUES (1, N'admin@gmail.com', N'123456')
GO
SET IDENTITY_INSERT [dbo].[UserLogin] OFF
GO
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_AuthorTable] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[AuthorTable] ([ID])
GO
ALTER TABLE [dbo].[StudentTable] CHECK CONSTRAINT [FK_StudentTable_AuthorTable]
GO
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_BookTable] FOREIGN KEY([BookID])
REFERENCES [dbo].[BookTable] ([ID])
GO
ALTER TABLE [dbo].[StudentTable] CHECK CONSTRAINT [FK_StudentTable_BookTable]
GO
USE [master]
GO
ALTER DATABASE [LibraryManagement] SET  READ_WRITE 
GO

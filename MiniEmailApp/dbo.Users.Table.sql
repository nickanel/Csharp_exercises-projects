USE [Project_Database]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/26/2018 9:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[UserType] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [UserName], [Password], [UserType], [CreationDate]) VALUES (1, N'Nikolaos', N'Kanellopoulos', N'nickanel', N'03071991nkn', 4, CAST(N'2018-04-18T19:38:12.393' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [UserName], [Password], [UserType], [CreationDate]) VALUES (2, N'Nikolaos', N'Stavrianakis', N'nistav', N'1234aaa', 1, CAST(N'2018-04-18T19:40:04.463' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [UserName], [Password], [UserType], [CreationDate]) VALUES (16, N'Anastasios', N'Agiopetritis', N'anastaagiop', N'030122As', 1, CAST(N'2018-04-22T00:15:28.963' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [UserName], [Password], [UserType], [CreationDate]) VALUES (18, N'Giannis', N'Gerogiannis', N'gerojohn', N'03071991nknN', 1, CAST(N'2018-04-22T16:15:22.493' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [UserName], [Password], [UserType], [CreationDate]) VALUES (25, N'Georgakos', N'Pasparakis', N'admin', N'aDmI3$', 3, CAST(N'2018-11-25T18:15:55.493' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF

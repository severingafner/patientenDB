USE [HausarztDB]
GO
/****** Object:  Table [dbo].[Attribute]    Script Date: 24.06.2021 11:45:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attribute](
	[attributeId] [int] IDENTITY(1,1) NOT NULL,
	[attributeValue] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED 
(
	[attributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Node]    Script Date: 24.06.2021 11:45:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Node](
	[nodeId] [int] IDENTITY(1,1) NOT NULL,
	[idObject] [int] NOT NULL,
	[idAttribute] [int] NOT NULL,
	[nodeValue] [nvarchar](300) NULL,
 CONSTRAINT [PK_Node] PRIMARY KEY CLUSTERED 
(
	[nodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Object]    Script Date: 24.06.2021 11:45:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Object](
	[objectId] [int] IDENTITY(1,1) NOT NULL,
	[objectValue] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Object] PRIMARY KEY CLUSTERED 
(
	[objectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Node]  WITH CHECK ADD  CONSTRAINT [FK_Node_Attribute] FOREIGN KEY([idAttribute])
REFERENCES [dbo].[Attribute] ([attributeId])
GO
ALTER TABLE [dbo].[Node] CHECK CONSTRAINT [FK_Node_Attribute]
GO
ALTER TABLE [dbo].[Node]  WITH CHECK ADD  CONSTRAINT [FK_Node_Object] FOREIGN KEY([idObject])
REFERENCES [dbo].[Object] ([objectId])
GO
ALTER TABLE [dbo].[Node] CHECK CONSTRAINT [FK_Node_Object]
GO

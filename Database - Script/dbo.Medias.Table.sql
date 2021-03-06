USE [MediaLibrary]
GO
/****** Object:  Table [dbo].[Medias]    Script Date: 15/06/2020 13:16:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medias](
	[Med_Id] [int] IDENTITY(1,1) NOT NULL,
	[Med_Name] [varchar](50) NOT NULL,
	[Med_Url] [varchar](255) NOT NULL,
	[Med_Placement] [varchar](255) NOT NULL,
	[Med_Type] [int] NOT NULL,
	[Med_Done] [bit] NOT NULL,
	[Med_Cat_Id] [int] NOT NULL,
 CONSTRAINT [PK_Medias] PRIMARY KEY CLUSTERED 
(
	[Med_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Medias]  WITH CHECK ADD  CONSTRAINT [FK_Medias_Category] FOREIGN KEY([Med_Cat_Id])
REFERENCES [dbo].[Categories] ([Cat_Id])
GO
ALTER TABLE [dbo].[Medias] CHECK CONSTRAINT [FK_Medias_Category]
GO

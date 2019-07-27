USE [DeveloperDB12]
GO

/****** Object:  Table [dbo].[client]    Script Date: 27/07/2019 14:05:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key] [uniqueidentifier] NOT NULL,
	[CPF] [varchar](14) NOT NULL,
	[Name] [varchar](70) NOT NULL,
	[Email] [varchar](70) NOT NULL,
	[id_address] [int] NOT NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



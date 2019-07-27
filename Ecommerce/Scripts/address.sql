USE [DeveloperDB12]
GO

/****** Object:  Table [dbo].[address]    Script Date: 27/07/2019 14:10:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[address](
	[id] [int] NOT NULL,
	[key] [uniqueidentifier] NOT NULL,
	[street] [varchar](70) NULL,
	[number] [varchar](70) NULL,
	[neighborhood] [varchar](70) NULL,
	[city] [varchar](70) NULL,
	[state] [varchar](70) NULL
) ON [PRIMARY]
GO



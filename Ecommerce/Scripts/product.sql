USE [DeveloperDB12]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key] [uniqueidentifier] NOT NULL,
	[title] varchar(120) NOT NULL,
	brand  varchar(120) NOT NULL,
	model varchar(120) NOT NULL,
	costprice decimal(10,2)  NOT NULL,
	saleprice decimal(10,2) NOT NULL,
	updatestock int not null,
	[weight] float not null
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



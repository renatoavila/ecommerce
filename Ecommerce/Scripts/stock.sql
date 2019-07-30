USE [DeveloperDB12]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].Stock(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key] [uniqueidentifier] NOT NULL,
    productId int not null,
    AmountStock int not null,
    AmountReserved int not null
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



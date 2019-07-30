USE [DeveloperDB12]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].Orders(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key] [uniqueidentifier] NOT NULL,
	Number varchar(12) Not Null,
	Date datetime not null,
	orderState int not null,
	clientId int not null,
	shopCartId int not null,
	addressId int not null
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



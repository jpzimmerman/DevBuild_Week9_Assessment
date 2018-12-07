USE [PartyDB]
GO

/****** Object:  Table [dbo].[Guest]    Script Date: 12/7/2018 4:15:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Guest](
	[GuestID] [int] IDENTITY(10000,3) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[AttendanceDate] [datetime] NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Guest] [nvarchar](50) NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[GuestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


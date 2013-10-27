USE [ideapod_HealthHack]
GO
/****** Object:  Table [ideapod_healthhack].[Temp_BackUP_File_Details]    Script Date: 27/10/2013 4:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ideapod_healthhack].[Temp_BackUP_File_Details](
	[Mutation_File_ID] [int] IDENTITY(1,1) NOT NULL,
	[Gene] [varchar](20) NULL,
	[Gene_Sequence_Locator] [varchar](50) NULL,
	[Transcript_FileName] [varchar](200) NULL,
	[Transcript_FileSource] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

USE [ideapod_HealthHack]
GO
/****** Object:  Table [ideapod_healthhack].[Temp_BackUP_cDNA]    Script Date: 27/10/2013 4:03:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ideapod_healthhack].[Temp_BackUP_cDNA](
	[Mutation_File_ID] [int] NOT NULL,
	[cDNA_reference] [varchar](20) NULL,
	[MCPosition] [int] NULL,
	[PreviousCodon] [char](3) NULL,
	[MutatedCodon] [char](3) NULL,
	[NextCodon] [char](3) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

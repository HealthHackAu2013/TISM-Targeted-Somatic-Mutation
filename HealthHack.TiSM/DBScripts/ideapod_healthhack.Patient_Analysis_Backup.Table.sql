USE [ideapod_HealthHack]
GO
/****** Object:  Table [ideapod_healthhack].[Patient_Analysis_Backup]    Script Date: 27/10/2013 4:03:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ideapod_healthhack].[Patient_Analysis_Backup](
	[Patient_ID] [int] NULL,
	[Analysis_Type] [varchar](20) NULL,
	[Mutation_type] [varchar](20) NULL,
	[MC_1] [int] NULL,
	[MC_2] [int] NULL,
	[MC_3] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

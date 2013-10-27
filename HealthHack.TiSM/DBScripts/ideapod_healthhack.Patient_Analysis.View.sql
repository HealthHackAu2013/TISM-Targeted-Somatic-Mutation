USE [ideapod_HealthHack]
GO
/****** Object:  View [ideapod_healthhack].[Patient_Analysis]    Script Date: 27/10/2013 4:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE VIEW [ideapod_healthhack].[Patient_Analysis]
AS

select Patient_ID= 5, 
	S.Analysis_TYPE,
	S.Mutation_TYPE,
	ISNULL(MC_1,0) as MC_1,
  ISNULL(MC_2,0) as MC_2,
  ISNULL(MC_3,0) as MC_3
from
ideapod_healthhack.[R_Analysis_structure] S
left join 
(
  select 
  Patient_ID = 5 /* hard coded  as 5 for example */, 
  Analysis_TYPE, 
  Mutation_TYPE,
  SUM(MC_1) as MC_1,
  SUM(MC_2) as MC_2,
  SUM(MC_3) as MC_3
  from 
  (	
	SELECT Patient_ID ,
		Analysis_Type = 'GYW-WRC' ,
		Mutation_Type = WT + '>' + Mut,
		MC_1 = Case when [MCPosition] = 1 then 1 else 0 end,
		MC_2 = Case when [MCPosition] = 2 then 1 else 0 end,
		MC_3 = Case when [MCPosition] = 3 then 1 else 0 end
	FROM [ideapod_healthhack].[ideapod_healthhack].[Mutation_cDNA]
	WHERE WRC_ = 1
	OR _GYW = 1
	union all
	SELECT Patient_ID ,
		Analysis_Type = 'CG-CG' ,
		Mutation_Type = WT + '>' + Mut,
		MC_1 = Case when [MCPosition] = 1 then 1 else 0 end,
		MC_2 = Case when [MCPosition] = 2 then 1 else 0 end,
		MC_3 = Case when [MCPosition] = 3 then 1 else 0 end
	FROM [ideapod_healthhack].[ideapod_healthhack].[Mutation_cDNA]
	WHERE _CG = 1
	OR CG_ = 1
	union all
	SELECT Patient_ID ,
		Analysis_Type = 'WA' ,
		Mutation_Type = WT + '>' + Mut,
		MC_1 = Case when [MCPosition] = 1 then 1 else 0 end,
		MC_2 = Case when [MCPosition] = 2 then 1 else 0 end,
		MC_3 = Case when [MCPosition] = 3 then 1 else 0 end
	FROM [ideapod_healthhack].[ideapod_healthhack].[Mutation_cDNA]
	WHERE WA_ = 1
  ) x
  Group
   by patient_ID, Analysis_TYPE, Mutation_TYPE
  ) results
  ON S.Analysis_TYPE = results.Analysis_TYPE
  AND S.Mutation_TYPE = results.Mutation_TYPE


GO

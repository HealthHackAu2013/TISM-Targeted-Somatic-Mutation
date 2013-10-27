USE [ideapod_HealthHack]
GO
/****** Object:  StoredProcedure [ideapod_healthhack].[SetMutation]    Script Date: 27/10/2013 4:03:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ideapod_healthhack].[SetMutation]
	@PatientId varchar(50),
	@Gene varchar(20),
	@GeneSequenceLocator varchar(50),
	@cDNAReference varchar(20),
	@MCPosition int ,
	@PreviousCodon char(3),
	@MutatedCodon char(3),
	@NextCodon char(3),
	@WT char(1),
	@Mut char(1) ,
	@WA_ char(1) ,
	@_CG char(1) ,
	@CG_ char(1) ,
	@WRC_ char(1) ,
	@_GYW char(1)	

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [ideapod_healthhack].[Mutation_cDNA]
	([Patient_Id],[Gene],[Gene_Sequence_Locator],[cDNA_reference],
	[MCPosition],[PreviousCodon],[MutatedCodon],[NextCodon],
	[WT] ,
	[Mut],
	[WA_] ,
	[_CG] ,
	[CG_] ,
	[WRC_] ,
	[_GYW]
	)
	
	VALUES
	(@PatientId,@Gene,@GeneSequenceLocator,@cDNAReference,
	@MCPosition,@PreviousCodon,@MutatedCodon,@NextCodon,
	@WT,
	@Mut,
	@WA_ ,
	@_CG ,
	@CG_ ,
	@WRC_ ,
	@_GYW 
	)

END

GO

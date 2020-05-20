SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	ѕолучение справочника типов документов
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[getTypeDoc]		 
AS
BEGIN
	SET NOCOUNT ON;

SELECT 
	t.id,t.npp,t.cName,t.ViewAdd,t.ViewArchive,t.isActive 
FROM 
	[ArchiveDoc].[s_TypeDoc] t

END

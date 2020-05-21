SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение тела документа
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_getDocumentBytes]		 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

select 
	d.DocFile
from 
	ArchiveDoc.s_Documents d
where
	d.id = @id

END

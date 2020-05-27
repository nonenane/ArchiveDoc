SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение тела документа
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_getDocuments_vs_DepartmentsPosts]		 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

select 
	id,
	id_DepartmentsPosts 
from 
	ArchiveDoc.Documents_vs_DepartmentsPosts 
where 
	id_Documents = @id

END

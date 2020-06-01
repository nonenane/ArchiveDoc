SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение тела документа
-- =============================================
ALTER PROCEDURE [ArchiveDoc].[spg_getDocuments_vs_DepartmentsPosts]		 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

select 
	dd.id,
	dd.id_DepartmentsPosts,
	dd.id_Documents,
	dd.ArchiveComment,
	dd.id_Status,
	dd.BaseDocumentsArchive,
	dd.isBrowse,
	s.cName as nameStatus
from 
	ArchiveDoc.Documents_vs_DepartmentsPosts dd
		left join ArchiveDoc.s_Status s on s.id = dd.id_Status
where 
	dd.id_Documents = @id

END

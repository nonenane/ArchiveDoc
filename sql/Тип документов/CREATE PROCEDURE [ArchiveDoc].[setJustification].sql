SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Переод документов в архив
-- =============================================
ALTER PROCEDURE [ArchiveDoc].[setJustification]		 
	@id_TypeDoc int,
	@id_user int, 
	@ArchiveComment varchar(max),
	@BaseDocumentsArchive varchar(max)
AS
BEGIN
	SET NOCOUNT ON;

BEGIN TRY 
	
update dd set 
	dd.id_Status = 3, 
	dd.id_Editor = @id_user, 
	dd.DateEdit = GETDATE(),
	dd.ArchiveComment = @ArchiveComment,
	dd.BaseDocumentsArchive = @BaseDocumentsArchive
from 
	ArchiveDoc.Documents_vs_DepartmentsPosts dd
		inner join ArchiveDoc.s_Documents d on dd.id_Documents = d.id
where d.id_TypeDoc = @id_TypeDoc and dd.id_Status<>3

select 1 as id

END TRY 
BEGIN CATCH 
	SELECT -9999 as id
	return;
END CATCH
	
END

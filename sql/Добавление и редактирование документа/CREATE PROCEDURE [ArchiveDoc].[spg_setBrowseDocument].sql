SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	”становка признака просмотренно руководителем
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_setBrowseDocument]		
	@id_documentVsPost int,
	@id_user int
AS
BEGIN
	SET NOCOUNT ON;

 UPDATE ArchiveDoc.Documents_vs_DepartmentsPosts set isBrowse = 1, id_Editor = @id_user, DateEdit = GETDATE() where id = @id_documentVsPost

END

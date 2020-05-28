SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	ѕолучение статуса документа в текущий момент
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_getStatusDocumentsThisMoment]	
		@id_Documents int,
		@id_status int
AS
BEGIN
	SET NOCOUNT ON;
	  
	IF not exists (select top(1) id from ArchiveDoc.s_Documents where id = @id_Documents)
		begin
			select -1 as id;
			return;
		end

	IF exists( select * from ArchiveDoc.Documents_vs_DepartmentsPosts where id_Documents = @id_Documents and  id_Status <> @id_status)
		BEGIN select 1 as id; return; END
	else 
		BEGIN select 0 as id; return; END

END

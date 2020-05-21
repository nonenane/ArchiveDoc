SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение документов для добавления
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_getDocumentsForAdd]		 
AS
BEGIN
	SET NOCOUNT ON;

select 
	d.id,
	d.cName,
	d.FileName,
	t.cName as nameTypeDoc,
	dp.id_Departments,
	dp.id_Posts 
from 
	ArchiveDoc.s_Documents d
		inner join ArchiveDoc.s_TypeDoc t on t.id = d.id_TypeDoc
		inner join ArchiveDoc.Documents_vs_DepartmentsPosts dd on dd.id_Documents = d.id
		inner join [ArchiveDoc].[Departments_vs_Posts] dp on dp.id = dd.id_DepartmentsPosts

END

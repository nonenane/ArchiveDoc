SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение Данных по документу, должности, и типу документа
-- =============================================
ALTER PROCEDURE [ArchiveDoc].[spg_getDoc_TypeDoc_Post]		
		@id_Posts int, 
		@id_Departments int,
		@isAll bit
AS
BEGIN
	SET NOCOUNT ON;

select 
	d.id as idDoc,
	d.cName as nameDoc,
	dd.id_Status,
	s.cName as nameStatus,
	d.id_TypeDoc,
	td.cName as nameTypeDoc,
	dp.id_Posts,
	p.cName as namePost,
	dd.id as id_documentVsPost,
	d.[FileName],
	td.isActive,
	td.ViewArchive,
	td.npp,
	dd.isBrowse,
	dp.id_Departments	
from 
	ArchiveDoc.Documents_vs_DepartmentsPosts dd
		left join ArchiveDoc.Departments_vs_Posts dp on dp.id = dd.id_DepartmentsPosts
		left join ArchiveDoc.s_Documents d on d.id = dd.id_Documents
		left join ArchiveDoc.s_TypeDoc td on td.id = d.id_TypeDoc
		left join ArchiveDoc.s_Status s on s.id = dd.id_Status
		left join ArchiveDoc.s_Posts p on p.id = dp.id_Posts
where 
	(@id_Posts = 0 or dp.id_Posts = @id_Posts) and (@id_Departments = 0 or dp.id_Departments = @id_Departments)
	and (@isAll = 1 or td.isActive = 1)

END

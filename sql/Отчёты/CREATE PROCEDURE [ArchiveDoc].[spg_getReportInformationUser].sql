SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение Данных для отчёта на ознакомление
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_getReportInformationUser]		 
		@id_TypeDoc int
AS
BEGIN
	SET NOCOUNT ON;

select 
	dp.id_Departments,dp.id_Posts,d.cName,dd.DateEdit,ltrim(rtrim(dep.name)) as nameDep,p.cName as namePost
from 
	ArchiveDoc.Documents_vs_DepartmentsPosts dd
		left join ArchiveDoc.Departments_vs_Posts dp on dp.id = dd.id_DepartmentsPosts
		left join ArchiveDoc.s_Documents d on d.id= dd.id_Documents
		left join dbo.departments dep on dep.id = dp.id_Departments
		left join ArchiveDoc.s_Posts p on p.id = dp.id_Posts
where 
	dd.id_Status = 2 and (@id_TypeDoc =0 or d.id_TypeDoc = @id_TypeDoc)
	
END

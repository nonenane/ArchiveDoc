SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение данных о доступе отдела к отделам
-- =============================================
ALTER PROCEDURE [ArchiveDoc].[spg_getDepartmentsAccessView]		 
	@id_Departments int
AS
BEGIN
	SET NOCOUNT ON;

select 
	id,id_DepartmentsView,isActive
from 
	ArchiveDoc.s_DepartmentsAccessView
where 
	id_Departments = @id_Departments --and isActive = 1
	
END

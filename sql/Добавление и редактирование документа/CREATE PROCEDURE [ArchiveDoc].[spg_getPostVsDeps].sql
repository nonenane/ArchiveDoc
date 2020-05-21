SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение списка должностей по отделам
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_getPostVsDeps]		 
AS
BEGIN
	SET NOCOUNT ON;

select 
	dp.id,
	dp.id_Departments,
	dp.id_Posts,
	ltrim(rtrim(p.cName)) as namePost,
	ltrim(rtrim(d.name)) as nameDeps,
	cast(0 as bit) isSelect
from 
	ArchiveDoc.Departments_vs_Posts dp
		inner join ArchiveDoc.s_Posts p on p.id = dp.id_Posts
		inner join dbo.departments d on d.id = dp.id_Departments
where
	dp.isActive = 1
END

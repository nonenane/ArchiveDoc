SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение Истории статусов по движению документа у должности
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_getHistoryStatus]		 
	@id_DocumentsDepartmentsPosts int
AS
BEGIN
	SET NOCOUNT ON;

select 
	h.DateCreate,s.cName,u.FIO
from 
	ArchiveDoc.j_HistoryStatus h 
		left join ArchiveDoc.s_Status s on s.id = h.id_Status
		left join dbo.ListUsers u on u.id = h.id_Creator
where 
	h.id_DocumentsDepartmentsPosts = @id_DocumentsDepartmentsPosts
	
END

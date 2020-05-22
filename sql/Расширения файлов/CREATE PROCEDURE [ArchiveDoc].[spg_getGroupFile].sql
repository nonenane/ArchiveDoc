SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение справочника группа файлов
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_getGroupFile]		 
AS
BEGIN
	SET NOCOUNT ON;

SELECT 
	g.id,g.cName,g.isActive
FROM 
	[ArchiveDoc].[s_GroupFile] g
where	g.isActive = 1

END

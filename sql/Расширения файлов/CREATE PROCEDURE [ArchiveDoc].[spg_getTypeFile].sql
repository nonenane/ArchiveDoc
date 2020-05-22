SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение справочника Типов файлов
-- =============================================
ALTER PROCEDURE [ArchiveDoc].[spg_getTypeFile]		 
AS
BEGIN
	SET NOCOUNT ON;

SELECT 
	t.id,t.Extension,t.isActive,t.isUse,t.id_GroupFile,g.cName
FROM 
	[ArchiveDoc].[s_TypeFile] t
		left join ArchiveDoc.s_GroupFile g on g.id = t.id_GroupFile

END

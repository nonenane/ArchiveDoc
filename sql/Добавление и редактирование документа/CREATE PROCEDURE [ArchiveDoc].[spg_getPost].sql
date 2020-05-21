SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение должностей
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_getPost]		 
AS
BEGIN
	SET NOCOUNT ON;

SELECT 
	p.id,p.cName,p.isActive
FROM 
	[ArchiveDoc].[s_Posts] p

END

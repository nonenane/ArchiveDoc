SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Получение отделов привязанных к должности
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_getPostLinkDep]		 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	select id,id_Departments from ArchiveDoc.Departments_vs_Posts where id_Posts = @id and isActive = 1
	
END

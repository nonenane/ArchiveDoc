SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	��������� ���� ���������
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_getDocuments]		 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

select 
	d.id_TypeDoc,
	d.FileName,
	d.cName	
from 
	ArchiveDoc.s_Documents d 
where
	d.id = @id

END

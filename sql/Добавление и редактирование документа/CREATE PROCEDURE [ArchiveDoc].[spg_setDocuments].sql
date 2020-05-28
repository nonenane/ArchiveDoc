SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Запись документов
-- =============================================
ALTER PROCEDURE [ArchiveDoc].[spg_setDocuments]		 
	@id int,
	@cName varchar(max),
	@fileName varchar(max),
	@docBytes varbinary(max) = null,
	@id_DocType int,	
	@id_user int,
	@result int = 0,
	@isDel int
AS
BEGIN
	SET NOCOUNT ON;

BEGIN TRY 
	IF @isDel = 0
		BEGIN

			IF EXISTS (select TOP(1) id from [ArchiveDoc].[s_Documents] where id <>@id and LTRIM(RTRIM(LOWER(cName))) = LTRIM(RTRIM(LOWER(@cName))))
				BEGIN
					SELECT -1 as id;
					return;
				END

			

			IF @id = 0
				BEGIN
					INSERT INTO [ArchiveDoc].[s_Documents]  (cName,[FileName],DocFile,id_TypeDoc,id_Creator,id_Editor,DateCreate,DateEdit)
					VALUES (@cName,@fileName,@docBytes,@id_DocType,@id_user,@id_user,GETDATE(),GETDATE())

					SELECT  cast(SCOPE_IDENTITY() as int) as id
					return;
				END
			ELSE
				BEGIN
					
					IF @docBytes is null
						select @docBytes = DocFile from [ArchiveDoc].[s_Documents] where id = @id

					UPDATE
						[ArchiveDoc].[s_Documents] 
					set 
						cName = @cName,
						[FileName]=@fileName,
						DocFile=@docBytes,
						id_TypeDoc=@id_DocType,
						id_Editor = @id_user,
						DateEdit = GETDATE()
					where
						id = @id

					SELECT @id as id
					return;
				END
		END
	ELSE
		BEGIN
			IF @result = 0
				BEGIN
					IF NOT EXISTS(select TOP(1) id from [ArchiveDoc].[s_Documents] where id = @id)
						BEGIN
							select -1 as id
							return;
						END
					
					IF exists( select * from ArchiveDoc.Documents_vs_DepartmentsPosts where id_Documents = @id and  id_Status <> 1)
						BEGIN 
							select -2 as id;
							return; 
						END
					
					select 0 as id
					return;
				END
			ELSE
				BEGIN
					DELETE FROM ArchiveDoc.Documents_vs_DepartmentsPosts where id_Documents = @id
					DELETE FROM [ArchiveDoc].[s_Documents] where id = @id
					
					RETURN
				END
		END
END TRY 
BEGIN CATCH 
	SELECT -9999 as id
	return;
END CATCH
	
END

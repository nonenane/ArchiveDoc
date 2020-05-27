SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Запись связки документа и должности
-- =============================================
ALTER PROCEDURE [ArchiveDoc].[spg_setDocuments_vs_DepartmentsPosts]		 
	@id int,
	@ArchiveComment varchar(max),
	@BaseDocumentsArchive varchar(max),
	@id_DepartmentsPosts int,
	@id_Documents int,
	@id_Status int,
	@isBrowse bit,	
	@id_user int,
	@result int = 0,
	@isDel int
AS
BEGIN
	SET NOCOUNT ON;

BEGIN TRY 
	IF @isDel = 0
		BEGIN

			--IF EXISTS (select TOP(1) id from [ArchiveDoc].[Documents_vs_DepartmentsPosts] where id <>@id and LTRIM(RTRIM(LOWER(cName))) = LTRIM(RTRIM(LOWER(@cName))))
			--	BEGIN
			--		SELECT -1 as id;
			--		return;
			--	END

			

			IF @id = 0
				BEGIN
					INSERT INTO [ArchiveDoc].[Documents_vs_DepartmentsPosts]  (ArchiveComment,BaseDocumentsArchive,id_DepartmentsPosts,id_Documents,id_Status,isBrowse,id_Creator,id_Editor,DateCreate,DateEdit)
					VALUES (@ArchiveComment,@BaseDocumentsArchive,@id_DepartmentsPosts,@id_Documents,@id_Status,@isBrowse,@id_user,@id_user,GETDATE(),GETDATE())

					set @id = cast(SCOPE_IDENTITY() as int)
					
					INSERT INTO ArchiveDoc.j_HistoryStatus(id_DocumentsDepartmentsPosts,id_Status,DateCreate,id_Creator)
					values (@id,@id_Status,GETDATE(),@id_user)

					SELECT @id as id
					return;
				END
			ELSE
				BEGIN
					UPDATE [ArchiveDoc].[Documents_vs_DepartmentsPosts] 
					set 
						ArchiveComment=@ArchiveComment,
						BaseDocumentsArchive=@BaseDocumentsArchive,
						id_DepartmentsPosts=@id_DepartmentsPosts,
						id_Documents=@id_Documents,
						id_Status=@id_Status,
						isBrowse = @isBrowse,
						id_Editor = @id_user,DateEdit = GETDATE()
					where id = @id

					INSERT INTO ArchiveDoc.j_HistoryStatus(id_DocumentsDepartmentsPosts,id_Status,DateCreate,id_Creator)
					values (@id,@id_Status,GETDATE(),@id_user)

					SELECT @id as id
					return;
				END
		END
	ELSE
		BEGIN
			IF @result = 0
				BEGIN
					--IF NOT EXISTS(select TOP(1) id from [ArchiveDoc].[s_TypeDoc] where id = @id)
					--	BEGIN
					--		select -1 as id
					--		return;
					--	END
																			
					select 0 as id
					return;
				END
			ELSE
				BEGIN
					DELETE FROM [ArchiveDoc].[Documents_vs_DepartmentsPosts] where id = @id
					RETURN
				END
		END
END TRY 
BEGIN CATCH 
	SELECT -9999 as id
	return;
END CATCH
	
END

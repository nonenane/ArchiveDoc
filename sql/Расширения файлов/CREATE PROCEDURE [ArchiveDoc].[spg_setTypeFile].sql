SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Запись справочника типов файлов
-- =============================================
ALTER PROCEDURE [ArchiveDoc].[spg_setTypeFile]		 
	@id int,
	@id_GroupFile int,
	@Extension varchar(50),
	@isUse bit,
	@isActive bit,
	@id_user int,
	@result int = 0,
	@isDel int
AS
BEGIN
	SET NOCOUNT ON;

BEGIN TRY 
	IF @isDel = 0
		BEGIN

			IF EXISTS (select TOP(1) id from [ArchiveDoc].[s_TypeFile] where id <>@id and LTRIM(RTRIM(LOWER(Extension))) = LTRIM(RTRIM(LOWER(@Extension))))
				BEGIN
					SELECT -1 as id;
					return;
				END
			

			IF @id = 0
				BEGIN
					INSERT INTO [ArchiveDoc].[s_TypeFile]  (id_GroupFile,Extension,isUse,isActive,id_Creator,id_Editor,DateCreate,DateEdit)
					VALUES (@id_GroupFile,@Extension,@isUse,1,@id_user,@id_user,GETDATE(),GETDATE())

					SELECT  cast(SCOPE_IDENTITY() as int) as id
					return;
				END
			ELSE
				BEGIN
					UPDATE [ArchiveDoc].[s_TypeFile] 
					set id_GroupFile=@id_GroupFile,
					Extension = @Extension,
					isUse = @isUse,
					isActive = @isActive,
					id_Editor = @id_user,
					DateEdit = GETDATE()
					where id = @id

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
					
					--IF EXISTS(select TOP(1) id from [ArchiveDoc].[s_Documents] where id_TypeDoc = @id)
					--	BEGIN
					--		select -2 as id
					--		return;
					--	END							
					
					select 0 as id
					return;
				END
			ELSE
				BEGIN
					DELETE FROM [ArchiveDoc].[s_TypeFile] where id = @id
					RETURN
				END
		END
END TRY 
BEGIN CATCH 
	SELECT -9999 as id
	return;
END CATCH
	
END

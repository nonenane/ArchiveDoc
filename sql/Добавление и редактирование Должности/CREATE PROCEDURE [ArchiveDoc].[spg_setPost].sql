SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Запись справочника должностей
-- =============================================
ALTER PROCEDURE [ArchiveDoc].[spg_setPost]		 
	@id int,
	@cName varchar(max),	
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

			IF EXISTS (select TOP(1) id from [ArchiveDoc].[s_Posts] where id <>@id and LTRIM(RTRIM(LOWER(cName))) = LTRIM(RTRIM(LOWER(@cName))))
				BEGIN
					SELECT -1 as id;
					return;
				END

			IF @id = 0
				BEGIN
					INSERT INTO [ArchiveDoc].[s_Posts]  (cName,isActive,id_Creator,id_Editor,DateCreate,DateEdit)
					VALUES (@cName,1,@id_user,@id_user,GETDATE(),GETDATE())

					SELECT  cast(SCOPE_IDENTITY() as int) as id
					return;
				END
			ELSE
				BEGIN
					UPDATE [ArchiveDoc].[s_Posts] 
					set cName = @cName,isActive = @isActive,id_Editor = @id_user,DateEdit = GETDATE()
					where id = @id

					if(@isActive=0)
						UPDATE [ArchiveDoc].[Departments_vs_Posts] SET isActive = 0, DateEdit = GETDATE(), id_Editor = @id_user where id_Posts = @id

					SELECT @id as id
					return;
				END
		END
	ELSE
		BEGIN
			IF @result = 0
				BEGIN
					IF NOT EXISTS(select TOP(1) id from [ArchiveDoc].[s_Posts] where id = @id)
						BEGIN
							select -1 as id
							return;
						END
					
					IF EXISTS(select TOP(1) id from [ArchiveDoc].[Departments_vs_Posts] where id_Posts = @id)
						BEGIN
							select -2 as id
							return;
						END							
					
					select 0 as id
					return;
				END
			ELSE
				BEGIN
					DELETE FROM [ArchiveDoc].[s_Posts] where id = @id
					RETURN
				END
		END
END TRY 
BEGIN CATCH 
	SELECT -9999 as id
	return;
END CATCH
	
END

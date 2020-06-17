SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Запись связи отдела и должности
-- =============================================
ALTER PROCEDURE [ArchiveDoc].[spg_setPostLinkDep]		 
	@id int,
	@id_Departments int,	
	@id_Posts int,	
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

			IF @id = 0
				BEGIN
					INSERT INTO [ArchiveDoc].[Departments_vs_Posts]  (id_Departments,id_Posts,isActive,id_Creator,id_Editor,DateCreate,DateEdit)
					VALUES (@id_Departments,@id_Posts,1,@id_user,@id_user,GETDATE(),GETDATE())

					SELECT  cast(SCOPE_IDENTITY() as int) as id
					return;
				END
			ELSE
				BEGIN
					UPDATE [ArchiveDoc].[Departments_vs_Posts] 
					set id_Departments= @id_Departments,id_Posts = @id_Posts,isActive = @isActive,id_Editor = @id_user,DateEdit = GETDATE()
					where id = @id

					SELECT @id as id
					return;
				END
		END
	ELSE
		BEGIN
			IF @result = 0
				BEGIN
					IF NOT EXISTS(select TOP(1) id from [ArchiveDoc].[Departments_vs_Posts] where id = @id)
						BEGIN
							select -1 as id
							return;
						END
					
					IF EXISTS(select TOP(1) id from [ArchiveDoc].[Documents_vs_DepartmentsPosts] where id_DepartmentsPosts = @id)
						BEGIN
							select -2 as id
							return;
						END							
					
					select 0 as id
					return;
				END
			ELSE
				BEGIN
					
					if exists (select top(1) id from [ArchiveDoc].[Documents_vs_DepartmentsPosts] where id_DepartmentsPosts = @id)
						UPDATE [ArchiveDoc].[Departments_vs_Posts]  set isActive = 0,id_Editor =@id_user,DateEdit = GETDATE() where id = @id
					else
						DELETE FROM [ArchiveDoc].[Departments_vs_Posts] where id = @id
					RETURN
				END
		END
END TRY 
BEGIN CATCH 
	SELECT -9999 as id
	return;
END CATCH
	
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-04-25
-- Description:	Запись данных о доступе отдела к отделам
-- =============================================
CREATE PROCEDURE [ArchiveDoc].[spg_setDepartmentsAccessView]		 
	@id int,
	@id_Departments int,
	@id_DepartmentsView int,
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

			IF not exists(select top(1) id from ArchiveDoc.s_DepartmentsAccessView where id_Departments = @id_Departments and id_DepartmentsView = @id_DepartmentsView)
				BEGIN
					INSERT INTO [ArchiveDoc].[s_DepartmentsAccessView]  (id_Departments,id_DepartmentsView,isActive,id_Creator,id_Editor,DateCreate,DateEdit)
					VALUES (@id_Departments,@id_DepartmentsView,1,@id_user,@id_user,GETDATE(),GETDATE())

					SELECT  cast(SCOPE_IDENTITY() as int) as id
					return;
				END
			ELSE
				BEGIN
					UPDATE [ArchiveDoc].[s_DepartmentsAccessView] 
					set 
					id_Departments = @id_Departments,
					id_DepartmentsView = @id_DepartmentsView,
					isActive = @isActive,
					id_Editor = @id_user,
					DateEdit = GETDATE()
					where id = @id

					SELECT @id as id
					return;
				END
		END
	
END TRY 
BEGIN CATCH 
	SELECT -9999 as id
	return;
END CATCH
	
END

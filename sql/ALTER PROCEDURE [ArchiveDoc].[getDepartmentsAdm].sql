USE [dbase2]
GO
/****** Object:  StoredProcedure [ArchiveDoc].[getDepartmentsAdm]    Script Date: 25.05.2020 12:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:			Камаев А.В.
-- Create date:		<26.02.2020>
-- Description:		<Процедура получения отделов для администратора >
-- =============================================
ALTER PROCEDURE [ArchiveDoc].[getDepartmentsAdm]

AS
BEGIN
select 
		ltrim(rtrim(dep.name)) as name,
		dep.id,
		dep.isOffice,
		dep.isUniversam,
		dep.id_Parent
 from dbo.departments dep
 where ldeyst=1	
order by dep.name
END
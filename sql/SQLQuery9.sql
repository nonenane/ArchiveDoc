select * from ArchiveDoc.Departments_vs_Posts

select * from ArchiveDoc.Documents_vs_DepartmentsPosts

--update ArchiveDoc.s_TypeDoc set isActive = 0 where id = 3

DECLARE @id_TypeDoc int

select * from ArchiveDoc.s_Documents where id_TypeDoc = @id_TypeDoc


select * from [ArchiveDoc].[Documents_vs_DepartmentsPosts]
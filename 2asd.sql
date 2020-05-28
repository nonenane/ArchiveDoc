--select 
--*
--from 
--	ArchiveDoc.s_Documents d where d.id = 12

exec [ArchiveDoc].[spg_getDocuments_vs_DepartmentsPosts]		 20

select * from ArchiveDoc.s_Posts
select * from ArchiveDoc.Documents_vs_DepartmentsPosts

	DECLARE 
		@id_Documents int  = 12,
		@id_status int = 1

	select * from ArchiveDoc.Documents_vs_DepartmentsPosts where id_Documents = @id_Documents

	IF not exists (select top(1) id from ArchiveDoc.s_Documents where id = @id_Documents)
		begin
			select -1 as id;
			return;
		end

	IF exists( select * from ArchiveDoc.Documents_vs_DepartmentsPosts where id_Documents = @id_Documents and  id_Status <> @id_status)
		BEGIN select 1 as id; return; END
	else 
		BEGIN select 0 as id; return; END
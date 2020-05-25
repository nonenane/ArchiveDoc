DECLARE 
	@id_Posts int = 0, @id_Departments int = 99



select 
	d.id as idDoc,
	d.cName as nameDoc,
	dd.id_Status,
	s.cName as nameStatus,
	d.id_TypeDoc,
	td.cName as nameTypeDoc,
	dp.id_Posts,
	p.cName as namePost,
	
from 
	ArchiveDoc.Documents_vs_DepartmentsPosts dd
		left join ArchiveDoc.Departments_vs_Posts dp on dp.id = dd.id_DepartmentsPosts
		left join ArchiveDoc.s_Documents d on d.id = dd.id_Documents
		left join ArchiveDoc.s_TypeDoc td on td.id = d.id_TypeDoc
		left join ArchiveDoc.s_Status s on s.id = dd.id_Status
		left join ArchiveDoc.s_Posts p on p.id = dp.id_Posts
where 
	(@id_Posts = 0 or dp.id_Posts = @id_Posts) and (@id_Departments = 0 or dp.id_Departments = @id_Departments)
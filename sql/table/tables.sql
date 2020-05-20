CREATE TABLE [ArchiveDoc].[s_TypeDoc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[npp]					int				not null,
	[cName]					varchar(max)	not null,
	[ViewArchive]			bit				not null	DEFAULT 0,
	[ViewAdd]				bit				not null	DEFAULT 0,
	[isActive]				bit				not null	DEFAULT 1,
	[id_Creator]			int				not null,
	[DateCreate]			datetime		not null,
	[id_Editor]				int				null,
	[DateEdit]				datetime		null,
 CONSTRAINT [PK_s_TypeDoc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ArchiveDoc].[s_TypeDoc] ADD CONSTRAINT FK_s_TypeDoc_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[s_TypeDoc] ADD CONSTRAINT FK_s_TypeDoc_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO



CREATE TABLE [ArchiveDoc].[Departments_vs_Posts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Departments]		int				not null,
	[id_Posts]				int				not null,		
	[isActive]				bit				not null	DEFAULT 1,
	[id_Creator]			int				not null,
	[DateCreate]			datetime		not null,
	[id_Editor]				int				null,
	[DateEdit]				datetime		null,
 CONSTRAINT [PK_Departments_vs_Posts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ArchiveDoc].[Departments_vs_Posts] ADD CONSTRAINT FK_Departments_vs_Posts_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[Departments_vs_Posts] ADD CONSTRAINT FK_Departments_vs_Posts_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[Departments_vs_Posts] ADD CONSTRAINT FK_Departments_vs_Posts_id_Posts FOREIGN KEY (id_Posts)  REFERENCES [ArchiveDoc].[s_Posts] (id)
GO

ALTER TABLE [ArchiveDoc].[Departments_vs_Posts] ADD CONSTRAINT FK_Departments_vs_Posts_id_Departments FOREIGN KEY (id_Departments)  REFERENCES [dbo].[departments] (id)
GO



CREATE TABLE [ArchiveDoc].[s_Posts](
	[id] [int] IDENTITY(1,1) NOT NULL,	
	[cName]					varchar(max)	not null,	
	[isActive]				bit				not null	DEFAULT 1,
	[id_Creator]			int				not null,
	[DateCreate]			datetime		not null,
	[id_Editor]				int				null,
	[DateEdit]				datetime		null,
 CONSTRAINT [PK_s_Posts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ArchiveDoc].[s_Posts] ADD CONSTRAINT FK_s_Posts_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[s_Posts] ADD CONSTRAINT FK_s_Posts_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO



CREATE TABLE [ArchiveDoc].[s_Documents](
	[id] [int] IDENTITY(1,1) NOT NULL,	
	[cName]					varchar(max)	not null,	
	[FileName]				varchar(max)	not null,	
	[DocFile]				varbinary(max)	not null,
	[id_TypeDoc]			int				not null,
	[id_Creator]			int				not null,
	[DateCreate]			datetime		not null,
	[id_Editor]				int				null,
	[DateEdit]				datetime		null,
 CONSTRAINT [PK_s_Documents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ArchiveDoc].[s_Documents] ADD CONSTRAINT FK_s_Documents_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[s_Documents] ADD CONSTRAINT FK_s_Documents_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[s_Documents] ADD CONSTRAINT FK_s_Documents_id_TypeDoc FOREIGN KEY (id_TypeDoc)  REFERENCES [ArchiveDoc].[s_TypeDoc] (id)
GO




CREATE TABLE [ArchiveDoc].[Documents_vs_DepartmentsPosts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_DepartmentsPosts]	int				not null,
	[id_Documents]			int				not null,
	[id_Status]				int				not null,
	[ArchiveComment]		varchar(max)	null,
	[BaseDocumentsArchive]	varchar(max)	null,	
	[isBrowse]				bit				not null	DEFAULT 0,
	[id_Creator]			int				not null,
	[DateCreate]			datetime		not null,
	[id_Editor]				int				null,
	[DateEdit]				datetime		null,
 CONSTRAINT [PK_Documents_vs_DepartmentsPosts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ArchiveDoc].[Documents_vs_DepartmentsPosts] ADD CONSTRAINT FK_Documents_vs_DepartmentsPosts_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[Documents_vs_DepartmentsPosts] ADD CONSTRAINT FK_Documents_vs_DepartmentsPosts_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[Documents_vs_DepartmentsPosts] ADD CONSTRAINT FK_Documents_vs_DepartmentsPosts_id_Documents FOREIGN KEY (id_Documents)  REFERENCES [ArchiveDoc].[s_Documents] (id)
GO

ALTER TABLE [ArchiveDoc].[Documents_vs_DepartmentsPosts] ADD CONSTRAINT FK_Documents_vs_DepartmentsPosts_id_Status FOREIGN KEY (id_Status)  REFERENCES [ArchiveDoc].[s_Status] (id)
GO

ALTER TABLE [ArchiveDoc].[Documents_vs_DepartmentsPosts] ADD CONSTRAINT FK_Documents_vs_DepartmentsPosts_id_DepartmentsPosts FOREIGN KEY (id_DepartmentsPosts)  REFERENCES [ArchiveDoc].[Departments_vs_Posts] (id)
GO



CREATE TABLE [ArchiveDoc].[s_Status](
	[id] [int] IDENTITY(1,1) NOT NULL,	
	[cName]					varchar(max)	not null,	
	[isActive]				bit				not null	DEFAULT 1,
 CONSTRAINT [PK_s_Status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [ArchiveDoc].[s_Status] (cName,isActive)
values 
	('Новый',1),
	('На ознакомлении',1),
	('Ознакомлен',1),
	('Архив',1)
GO

CREATE TABLE [ArchiveDoc].[j_HistoryStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_DocumentsDepartmentsPosts]	int				not null,	
	[id_Status]				int				not null,
	[id_Creator]			int				not null,
	[DateCreate]			datetime		not null,	
 CONSTRAINT [PK_j_HistoryStatus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ArchiveDoc].[j_HistoryStatus] ADD CONSTRAINT FK_j_HistoryStatus_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[j_HistoryStatus] ADD CONSTRAINT FK_j_HistoryStatus_id_Status FOREIGN KEY (id_Status)  REFERENCES [ArchiveDoc].[s_Status] (id)
GO

ALTER TABLE [ArchiveDoc].[j_HistoryStatus] ADD CONSTRAINT FK_j_HistoryStatus_id_DocumentsDepartmentsPosts FOREIGN KEY (id_DocumentsDepartmentsPosts)  REFERENCES [ArchiveDoc].[Documents_vs_DepartmentsPosts] (id)
GO



CREATE TABLE [ArchiveDoc].[s_TypeFile](
	[id] [int] IDENTITY(1,1) NOT NULL,	
	[Extension]				varchar(50)	not null,	
	[isUser]				bit				not null	DEFAULT 0,
	[isActive]				bit				not null	DEFAULT 1,
	[id_Creator]			int				not null,
	[DateCreate]			datetime		not null,
	[id_Editor]				int				null,
	[DateEdit]				datetime		null,
 CONSTRAINT [PK_s_TypeFile] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ArchiveDoc].[s_TypeFile] ADD CONSTRAINT FK_s_TypeFile_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[s_TypeFile] ADD CONSTRAINT FK_s_TypeFile_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO



CREATE TABLE [ArchiveDoc].[s_DepartmentsAccessView](
	[id] [int] IDENTITY(1,1) NOT NULL,	
	[id_Departments]		int				not null,	
	[id_DepartmentsView]	int				not null,		
	[isActive]				bit				not null	DEFAULT 1,
	[id_Creator]			int				not null,
	[DateCreate]			datetime		not null,
	[id_Editor]				int				null,
	[DateEdit]				datetime		null,
 CONSTRAINT [PK_s_DepartmentsAccessView] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ArchiveDoc].[s_DepartmentsAccessView] ADD CONSTRAINT FK_s_DepartmentsAccessView_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[s_DepartmentsAccessView] ADD CONSTRAINT FK_s_DepartmentsAccessView_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [ArchiveDoc].[s_DepartmentsAccessView] ADD CONSTRAINT FK_s_DepartmentsAccessView_id_Departments FOREIGN KEY (id_Departments)  REFERENCES [dbo].[departments] (id)
GO

ALTER TABLE [ArchiveDoc].[s_DepartmentsAccessView] ADD CONSTRAINT FK_s_DepartmentsAccessView_id_DepartmentsView FOREIGN KEY (id_DepartmentsView)  REFERENCES [dbo].[departments] (id)
GO


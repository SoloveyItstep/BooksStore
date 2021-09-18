use master;
create database BooksStoreDb;

use BooksStoreDb -- connect to db schema

--create tables --

set ansi_nulls off; -- set the system to not follow the ISO rules and on select use comparison on null values

create table [dbo].[Books](
	[Id] UNIQUEIDENTIFIER not null, -- guid id property
	[Title] nvarchar(250) not null,
	[Pages] int null,
	[Description] nvarchar(500) null,
	[Price] decimal(8,3) not null
	constraint [PK_Books] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on, -- can block page
		OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'

 -- TEXTIMAGE_ON [PRIMARY] - unlimited fields (such as nvarchar(max), image, etc) create on file group 'primary'

 insert into [Books]([Id], [Title], [Pages], [Price], [Description])
 values
	(NEWID(), N'Garry Potter on the moon', 20, 10, 'No description'),
	(NEWID(), N'Michal Jackson - Hystory', 120, 17, 'No description'),
	(NEWID(), N'ASP.NET Core from scratch', 920, 48.43, 'No description'),
	(NEWID(), N'Angular - From theory to practice', 80, 21, 'No description'),
	(NEWID(), N'CLR via C#', 892, 32.23, 'No description');

select * from Books


create table [dbo].[ApplicationUsers](
	[Id] UNIQUEIDENTIFIER not null,
	[UserName] nvarchar(35) not null,
	[PasswordHash] VARBINARY(MAX) not null,
	[PasswordSalt] VARBINARY(MAX) not null,
	[Email] varchar(255) null,
	[Phone] varchar(14) null
	constraint [PK_ApplicationUsers] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on, -- can block page
		OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]

--create table [dbo].[ApplicationUsers](
--	[Id] UNIQUEIDENTIFIER not null,
--	[UserName] nvarchar(35) not null,
--	[PasswordHash] nvarchar(64) not null,
--	[PasswordSalt] nvarchar(128) not null
--	constraint [PK_ApplicationUsers] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
--		[Id] ASC
--	)
--	with(
--		PAD_INDEX = off, -- Specifies the sparseness of an index
--		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
--		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
--		ALLOW_ROW_LOCKS = on, -- can block row
--		ALLOW_PAGE_LOCKS = on, -- can block page
--		OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
--	)
--) on [PRIMARY]

--alter table [dbo].[ApplicationUsers] alter column [PasswordHash] VARBINARY(MAX) not null;
--alter table [dbo].[ApplicationUsers] alter column [PasswordSalt] VARBINARY(MAX) not null;

--alter database BooksStoreDb set offline; -- query to copy files
--alter database BooksStoreDb set online;

--alter table [dbo].[ApplicationUsers]
--ADD Email varchar(255);

--alter table [dbo].[ApplicationUsers]
--ADD Phone varchar(14)


-- update column type
--alter table [dbo].[ApplicationUsers] alter column [PasswordHash] nvarchar(64) not null;
--alter table [dbo].[ApplicationUsers] alter column [PasswordSalt] nvarchar(128) not null;
--alter table [dbo].[ApplicationUsers] add [PasswordSalt-new] varbinary(128) null;
--update [dbo].[ApplicationUsers] set [PasswordSalt-new] = cast([PasswordHash] as varbinary(128))
--alter table [dbo].[ApplicationUsers] drop column [PasswordSalt]
--exec sp_rename 'ApplicationUsers.PasswordSalt-new', 'PasswordSalt'
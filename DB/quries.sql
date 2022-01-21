use master;
create database BooksStoreDb;

use BooksStoreDb -- connect to db schema

--create tables --

set ansi_nulls off; -- set the system to not follow the ISO rules and on select use comparison on null values

--create table [dbo].[Books](
--	[Id] UNIQUEIDENTIFIER not null, -- guid id property
--	[Title] nvarchar(250) not null,
--	[Pages] int null,
--	[Description] nvarchar(500) null,
--	[Price] decimal(8,3) not null
--	constraint [PK_Books] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
--		[Id] ASC
--	)
--	with(
--		PAD_INDEX = off, -- Specifies the sparseness of an index
--		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
--		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
--		ALLOW_ROW_LOCKS = on, -- can block row
--		ALLOW_PAGE_LOCKS = on--, -- can block page
--		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
--	)
--) on [PRIMARY]  -- on [primary] - create table on file group 'primary'

-- -- TEXTIMAGE_ON [PRIMARY] - unlimited fields (such as nvarchar(max), image, etc) create on file group 'primary'

-- insert into [Books]([Id], [Title], [Pages], [Price], [Description])
-- values
--	(NEWID(), N'Garry Potter on the moon', 20, 10, 'No description'),
--	(NEWID(), N'Michal Jackson - Hystory', 120, 17, 'No description'),
--	(NEWID(), N'ASP.NET Core from scratch', 920, 48.43, 'No description'),
--	(NEWID(), N'Angular - From theory to practice', 80, 21, 'No description'),
--	(NEWID(), N'CLR via C#', 892, 32.23, 'No description');

--select * from Books


create table [dbo].[ApplicationUsers](
	[Id] UNIQUEIDENTIFIER not null,
	[FirstName] nvarchar(15) not null,
	[LastName] nvarchar(30) not null,
	[Surename] nvarchar(30),
	[PasswordHash] VARBINARY(MAX) not null,
	[PasswordSalt] VARBINARY(MAX) not null,
	[Email] varchar(255) not null,
	[Phone] varchar(14) not null,
	[Birthday] DateTime,
	constraint [PK_ApplicationUsers] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
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


--EXEC sp_rename 'dbo.ApplicationUsers.UserName', 'FirstName', 'COLUMN'; 


--alter table ApplicationUsers
--alter column FirstName nvarchar(15) not null;

--alter table [dbo].[ApplicationUsers]
--ADD LastName varchar(30);

--update ApplicationUsers
--set LastName = 'test';

--alter table ApplicationUsers
--alter column LastName nvarchar(30) not null;

--select * from ApplicationUsers

--alter table ApplicationUsers
--add Surename nvarchar(30);

--alter table ApplicationUsers
--add Birthday DateTime;


-- update column type
--alter table [dbo].[ApplicationUsers] alter column [PasswordHash] nvarchar(64) not null;
--alter table [dbo].[ApplicationUsers] alter column [PasswordSalt] nvarchar(128) not null;
--alter table [dbo].[ApplicationUsers] add [PasswordSalt-new] varbinary(128) null;
--update [dbo].[ApplicationUsers] set [PasswordSalt-new] = cast([PasswordHash] as varbinary(128))
--alter table [dbo].[ApplicationUsers] drop column [PasswordSalt]
--exec sp_rename 'ApplicationUsers.PasswordSalt-new', 'PasswordSalt'

--======== Language ===========--

create table [dbo].[Languages](
	[Id] UNIQUEIDENTIFIER not null,
	[Language] nvarchar(3) not null,
	[LanguageTitle] nvarchar(25) not null,
	constraint [PK] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on -- can block page
	)
) on [PRIMARY]

--EXEC sp_rename '[dbo].[Languages].[PK]', '[PK__Languages]';

insert into [Languages]([Id], [Language], [LanguageTitle])
 values
	(NEWID(), N'ua', 'Ukrainian'),
	(NEWID(), N'en', 'English');

select * from Languages


--============= PROMOTIONS ============--

create table [dbo].[Promotions](
	[Id] UNIQUEIDENTIFIER not null,
	[StartDate] DateTime not null,
	[EndDate] DateTime not null,
	[ImagePath] nvarchar(max) not null,
	constraint [PK_Promotions] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on -- can block page
	)
) on [PRIMARY]

create table [dbo].[PromotionsTranslate](
	[Id] UNIQUEIDENTIFIER not null,
	[Title] nvarchar(200) not null,
	[ShortTitle] nvarchar(200) not null,
	[Description] nvarchar(max) not null,
	[ShortDescription] nvarchar(350) not null,
	primary key clustered([Id] ASC)
	
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on -- can block page
	)
) on [PRIMARY]

drop table [PromotionsTranslate]

alter table [PromotionsTranslate]
	Add [PromotionsId] UNIQUEIDENTIFIER
	constraint [FK_PromotionsTranslate_Promotions]
		FOREIGN KEY (PromotionsId)
		REFERENCES Promotions(Id);


alter table [PromotionsTranslate]
	Add [LanguagesId] UNIQUEIDENTIFIER
	constraint [FK_PromotionsTranslate_Languages]
		FOREIGN KEY (LanguagesId)
		REFERENCES Languages(Id);

alter table [PromotionsTranslate]
	add [ShortDescription] nvarchar(350) not null;


insert into [Promotions] ([Id], [StartDate], [EndDate], [ImagePath])
	values
	(NEWID(), '20220110 00:00:00 AM', '20220117 12:59:59 PM', '/assets/img/promotions/promotion1.png'),
	(NEWID(), '20220113 00:00:00 AM', '20220127 12:59:59 PM', '/assets/img/promotions/promotion2.jpg')
	

select * from Promotions

--70F8FA7A-16BA-4CFD-BEF0-762096A6DB09   en
--8DDD86B0-7D33-49BD-867F-ECF97CADD392   ua

--A2281995-407B-4F43-9E91-657E2F58C757   1
--1A19A59E-3E16-4019-BC93-75168278E7A2   2

--cast('A2281995-407B-4F43-9E91-657E2F58C757' as uniqueidentifier), 
--	cast('8DDD86B0-7D33-49BD-867F-ECF97CADD392' as uniqueidentifier))

use BooksStoreDB;

insert into [PromotionsTranslate] ([Id], [Title], [ShortTitle], [Description], [ShortDescription], [PromotionsId], [LanguagesId])
	values
	(NEWID(), 
	N'Мандрівники', 
	N'Фото-конкурс', 
	N'До участі у конкурсі допускаються фото на тему "Селфі з книгою".<br/>У конкурсі можуть брати участь не більше трьох робіт одного автора.<br/>Можна залишати необмежену кількість коментарів, які мають містити розгорнуту думку.<br/>До участі у конкурсі не допускаються:<br/>1. фото еротичного чи порнографічного змісту;<br/>2. фото, які можуть образити інших учасників конкурса;<br/>3. фото рекламного характера;<br/>4. фото, оброблені у фоторедакторі;<br/>5. фото та кліпарти, завантажені з Інтернету: фотографії мають належати саме вам!<br/><br/>Додана вами фотографія модеруватиметься, після чого буде опублікована на сторінці конкурсу (при виконанні вищевказаних правил);<br/>У разі порушення правил фото буде видалено.', 
	N'Додавай в інстаграм #birdsbook в світлині із книгами та вигравай путівник по Україні',
	'A2281995-407B-4F43-9E91-657E2F58C757', 
	'8DDD86B0-7D33-49BD-867F-ECF97CADD392');

	insert into [PromotionsTranslate] ([Id], [Title], [ShortTitle], [Description], [ShortDescription], [PromotionsId], [LanguagesId])
	values
	(NEWID(), 
	N'Travelers', 
	N'Photo contest', 
	N'Photos on the subject of "Selfie with a book" are allowed to participate in the contest. <br/> No more than three works by one author can take part in the contest. <br/> You can leave an unlimited number of comments that should contain a detailed opinion. <br/> The following are not allowed to participate in the competition: <br/> 1. photos of erotic or pornographic content; <br/> 2. photos that may offend other contestants; <br/> 3. advertising photo; <br/> 4. photos processed in a photo editor; <br/> 5. photos and cliparts downloaded from the Internet: photos must belong to you! <br/> <br/> The photo you added will be moderated and then published on the contest page (if you follow the above rules); <br/> In case of violation of the rules of the photo will be deleted.', 
	N'Add to Instagram #birdsbook in the photo with books and win a guide to Ukraine',
	'A2281995-407B-4F43-9E91-657E2F58C757', 
	'70F8FA7A-16BA-4CFD-BEF0-762096A6DB09');


	insert into [PromotionsTranslate] ([Id], [Title], [ShortTitle], [Description], [ShortDescription], [PromotionsId], [LanguagesId])
	values
	(NEWID(), 
	N'Конкурс нотаток', 
	N'Пишемо нотатки на тему', 
	N'- Щомісяця учасникам групи пропонується вибрати тему із запропонованих ведучим, на яку їм цікаво було б написати замітку.<br/>- На початку кожного місяця вибрана тема публікується окремим повідомленням.<br/>- Протягом місяця учасники мають написати нотатку на тему у своєму блозі.<br/>- Під постом, у якому оголошено тему, необхідно опублікувати посилання на свою замітку – це важливо, щоб ніхто не загубився.<br/>- Нотатка має бути свіжою, тобто написаною у відповідному місяці після опублікування посту з темою місяця.<br/>- При публікації нотатки у блозі у графі "Теми" необхідно вказувати тег за принципом нотатка+ поточні місяць і рік, наприклад, нотатка січня 20, нотатка серпня 20, а також загальний тег конкурс нотаток – це теж важливо.<br/>- Нотатка має бути повністю авторська, жодного копіювання. Допускаються цитати із зазначенням авторства.<br/>- Дозволяється використовувати будь-які фото, картинки, відео.<br/>- Приймаються нотатки будь-якого обсягу та у будь-якому форматі.<br/>- Переможець визначається голосуванням за найкращу замітку місяця на початку наступного місяця.<br/>- Конкурс вважається таким, що відбувся за будь-якої кількості нотаток. Але якщо їх буде п''ять і більше, переможець отримає нагороду у профіль', 
	N'Щомісяця учасники пишуть замітку на задану тему, розширюють кругозір та отримують задоволення. Приєднуйтесь!',
	'1A19A59E-3E16-4019-BC93-75168278E7A2', 
	'8DDD86B0-7D33-49BD-867F-ECF97CADD392');

	insert into [PromotionsTranslate] ([Id], [Title], [ShortTitle], [Description], [ShortDescription], [PromotionsId], [LanguagesId])
	values
	(NEWID(), 
	N'Notation competition', 
	N'Writing notes on the topic', 
	N'- Each month, group members are asked to choose a topic from the facilitator they would like to write a note on. <br/> - At the beginning of each month, the selected topic is published in a separate message. <br/> - During the month, participants should write a note on the topic in their blog. <br/> - Under the post in which the topic is announced, you need to publish a link to your note - it is important that no one gets lost. <br/> - The note should be fresh, ie written in the month following the post with the topic <br/> - When posting a note in a blog, in the "Topics" column, you must specify a note tag + current month and year, for example, January 20 note, August 20 note, and general note contest tag - this is also important. <br/> - The note must be fully copyrighted, no copying. Quotations indicating authorship are allowed. <br/> - Any photos, pictures, videos are allowed. <br/> - Notes of any size and in any format are accepted. <br/> - The winner is determined by voting for the best note of the month at the beginning of the next month. <br/> - The competition is considered to have taken place with any number of notes. But if there are five or more, the winner will receive a prize in the profile', 
	N'Each month, participants write a note on a given topic, broaden their horizons and have fun. Join!',
	'1A19A59E-3E16-4019-BC93-75168278E7A2', 
	'70F8FA7A-16BA-4CFD-BEF0-762096A6DB09');

	--sp_help  'dbo.PromotionsTranslate'

	select * from [dbo].PromotionsTranslate


	--=============update users======================

--	/*
--Deployment script for BooksStoreDb

--This code was generated by a tool.
--Changes to this file may cause incorrect behavior and will be lost if
--the code is regenerated.
--*/

--GO
--SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

--SET NUMERIC_ROUNDABORT OFF;


--GO
--:setvar DatabaseName "BooksStoreDb"
--:setvar DefaultFilePrefix "BooksStoreDb"
--:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\"
--:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\"

--GO
--:on error exit
--GO
--/*
--Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
--To re-enable the script after enabling SQLCMD mode, execute the following:
--SET NOEXEC OFF; 
--*/
--:setvar __IsSqlCmdEnabled "True"
--GO
--IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
--    BEGIN
--        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
--        SET NOEXEC ON;
--    END


--GO
--USE [$(DatabaseName)];


--GO

--IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
--GO
--CREATE TABLE #tmpErrors (Error int)
--GO
--SET XACT_ABORT ON
--GO
--SET TRANSACTION ISOLATION LEVEL READ COMMITTED
--GO
--BEGIN TRANSACTION
--GO
--PRINT N'Altering Table [dbo].[ApplicationUsers]...';


--GO
--ALTER TABLE [dbo].[ApplicationUsers] ALTER COLUMN [Email] VARCHAR (255) NOT NULL;

--ALTER TABLE [dbo].[ApplicationUsers] ALTER COLUMN [Phone] VARCHAR (14) NOT NULL;


--GO
--IF @@ERROR <> 0
--   AND @@TRANCOUNT > 0
--    BEGIN
--        ROLLBACK;
--    END

--IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
--    CREATE TABLE [#tmpErrors] (
--        Error INT
--    );

--IF @@TRANCOUNT = 0
--    BEGIN
--        INSERT  INTO #tmpErrors (Error)
--        VALUES                 (1);
--        BEGIN TRANSACTION;
--    END


--GO

--IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
--GO
--IF @@TRANCOUNT>0 BEGIN
--PRINT N'The transacted portion of the database update succeeded.'
--COMMIT TRANSACTION
--END
--ELSE PRINT N'The transacted portion of the database update failed.'
--GO
--IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
--GO
--GO
--PRINT N'Update complete.';


--GO

	
create table [dbo].[Author](
	[Id] UNIQUEIDENTIFIER not null, -- guid id property
	[Birthday] DateTime null,
	[PhotoPath] nvarchar(max) null,
	constraint [PK_Author] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'

create table [dbo].[AuthorTranslate](
	[Id] UNIQUEIDENTIFIER not null,
	[AuthorName] nvarchar(60) not null,
	[Description] nvarchar(max) not null,
	constraint [PK_AuthorTranslate] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'

alter table [AuthorTranslate]
	Add [AuthorId] UNIQUEIDENTIFIER
	constraint [FK_AuthorTranslate_Author]
		FOREIGN KEY (AuthorId)
		REFERENCES Author(Id);


alter table [AuthorTranslate]
	Add [LanguagesId] UNIQUEIDENTIFIER
	constraint [FK_AuthorTranslate_Languages]
		FOREIGN KEY (LanguagesId)
		REFERENCES Languages(Id);

--drop table [dbo].[Books]

create table [dbo].[Books](
	[Id] UNIQUEIDENTIFIER not null, -- guid id property
	[Pages] int not null,
	[Price] decimal(8,3) not null,
	[Code] int not null,
	[Count] int not null,
	[Year] int not null,
	constraint [PK_Books] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'

--alter table Books
--	alter column Pages int not null

alter table [Books]
	Add [AuthorId] UNIQUEIDENTIFIER
	constraint [FK_Books_Author]
		FOREIGN KEY (AuthorId)
		REFERENCES Author(Id);


create table [dbo].[BooksImages](
	Id UNIQUEIDENTIFIER not null,
	[Path] nvarchar(max) not null,
	[IsMain] bit not null
	constraint [PK_BooksImages] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'

alter table [BooksImages]
	Add [BookId] UNIQUEIDENTIFIER
	constraint [FK_BooksImages_Books]
		FOREIGN KEY (BookId)
		REFERENCES Books(Id);

create table [dbo].[BooksLanguageTranslate](
	[Id] UNIQUEIDENTIFIER not null,
	[Lang] nvarchar(30) not null,
	constraint [PK_BooksLanguageTranslate] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'


alter table [BooksLanguageTranslate]
	Add [BookId] UNIQUEIDENTIFIER
	constraint [FK_BooksLanguageTranslate_Books]
		FOREIGN KEY (BookId)
		REFERENCES Books(Id);

alter table [BooksLanguageTranslate]
	Add [LangId] UNIQUEIDENTIFIER
	constraint [FK_BooksLanguageTranslate_Languages]
		FOREIGN KEY (LangId)
		REFERENCES Languages(Id);


create table [dbo].[BooksTypeTranslate](
	[Id] UNIQUEIDENTIFIER not null,
	[BookType] nvarchar(50) not null,
	constraint [PK_BooksTypeTranslate] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'

alter table [BooksTypeTranslate]
	Add [BookId] UNIQUEIDENTIFIER
	constraint [FK_BooksTypeTranslate_Books]
		FOREIGN KEY (BookId)
		REFERENCES Books(Id);

alter table [BooksTypeTranslate]
	Add [LangId] UNIQUEIDENTIFIER
	constraint [FK_BooksTypeTranslate_Languages]
		FOREIGN KEY (LangId)
		REFERENCES Languages(Id);


create table [dbo].[BooksCoverTranslate](
	[Id] UNIQUEIDENTIFIER not null,
	[Cover] nvarchar(50) not null,
	constraint [PK_BooksCoverTranslate] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'

alter table [BooksCoverTranslate]
	Add [BookId] UNIQUEIDENTIFIER
	constraint [FK_BooksCoverTranslate_Books]
		FOREIGN KEY (BookId)
		REFERENCES Books(Id);

alter table [BooksCoverTranslate]
	Add [LangId] UNIQUEIDENTIFIER
	constraint [FK_BooksCoverTranslate_Languages]
		FOREIGN KEY (LangId)
		REFERENCES Languages(Id);



create table [dbo].[BooksFomatTranslate](
	[Id] UNIQUEIDENTIFIER not null,
	[Fomat] nvarchar(50) not null,
	constraint [PK_BooksFomatTranslate] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'

alter table [BooksFomatTranslate]
	Add [BookId] UNIQUEIDENTIFIER
	constraint [FK_BooksFomatTranslate_Books]
		FOREIGN KEY (BookId)
		REFERENCES Books(Id);

alter table [BooksFomatTranslate]
	Add [LangId] UNIQUEIDENTIFIER
	constraint [FK_BooksFomatTranslate_Languages]
		FOREIGN KEY (LangId)
		REFERENCES Languages(Id);



create table [dbo].[BooksTranslate](
	[Id] UNIQUEIDENTIFIER not null,
	[Desc] nvarchar(max) not null,
	[ShortDesc] nvarchar(300) not null,
	constraint [PK_BooksTranslate] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'

alter table [BooksTranslate]
	Add [BookId] UNIQUEIDENTIFIER
	constraint [FK_BooksTranslate_Books]
		FOREIGN KEY (BookId)
		REFERENCES Books(Id);

alter table [BooksTranslate]
	Add [LangId] UNIQUEIDENTIFIER
	constraint [FK_BooksTranslate_Languages]
		FOREIGN KEY (LangId)
		REFERENCES Languages(Id);

create table [dbo].[BooksPublishmentHouse](
	[Id] UNIQUEIDENTIFIER not null,
	[PublHouse] nvarchar(50) not null,
	constraint [PK_BooksPublishmentHouse] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'

alter table [BooksPublishmentHouse]
	Add [BookId] UNIQUEIDENTIFIER
	constraint [FK_BooksPublishmentHouse_Books]
		FOREIGN KEY (BookId)
		REFERENCES Books(Id);



create table [dbo].[BooksRating](
	[Id] UNIQUEIDENTIFIER not null,
	[Date] DateTime not null,
	[Message] nvarchar(1000) null,
	constraint [PK_BooksRating] primary key clustered(  -- constraint primary key: insert only unique keys (values), clustered - sorted for more faster search by field 
		[Id] ASC
	)
	with(
		PAD_INDEX = off, -- Specifies the sparseness of an index
		STATISTICS_NORECOMPUTE = off, -- Indicates whether distribution statistics have been recalculated 
		IGNORE_DUP_KEY = off, -- on inseart not unique key - show error and cancel all operation
		ALLOW_ROW_LOCKS = on, -- can block row
		ALLOW_PAGE_LOCKS = on--, -- can block page
		--OPTIMIZE_FOR_SEQUENTIAL_KEY = off -- set optimization on insert in last page
	)
) on [PRIMARY]  -- on [primary] - create table on file group 'primary'


alter table [BooksRating]
	Add [BookId] UNIQUEIDENTIFIER
	constraint [FK_BooksRating_Books]
		FOREIGN KEY (BookId)
		REFERENCES Books(Id);

alter table [BooksRating]
	Add [UserId] UNIQUEIDENTIFIER
	constraint [FK_BooksRating_ApplicationUser]
		FOREIGN KEY (UserId)
		REFERENCES AspNetUsers(Id);















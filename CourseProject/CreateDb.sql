/* Monakhov Dmitry, IU7-64
This script creates database for course project
*/

-- Creating database
--CREATE DATABASE SecSystem

use SecSystem

-- Creating tables
create table Locations
(
	Id INT PRIMARY KEY identity(1, 1),
	LocName nvarchar(50) check (LocName != '') not null,
)

create table AccessRules
(
	Id INT PRIMARY KEY identity(1, 1),
	SecLevelId int not null,
	LocId int not null
)

create table Users
(
	Id INT PRIMARY KEY identity(1, 1),
	UserFirstName nvarchar(50) check (UserFirstName != '') not null, 
	UserMiddleName nvarchar(50) check (UserMiddleName != ''), 
	UserLastName nvarchar(50) check (UserLastName != '') not null, 
	IdentDataId int unique,
	SecLevelId int not null,
	DbAccessLevelId int not null
)

create table IdentData
(
	Id INT PRIMARY KEY identity(1, 1),
	PwdDataId int unique not null,
	VoiceDataId int unique not null
)

create table SecLevel
(
	Id INT PRIMARY KEY identity(1, 1),
	LevelName nvarchar(50) unique check (LevelName != '') not null,
	LevelDescription nvarchar(256)
)

create table DbAccessLevel
(
	Id INT PRIMARY KEY identity(1, 1),
	LevelName nvarchar(50) unique check (LevelName != '') not null,
	LevelDescription nvarchar(256),
	LevelCode int unique not null
)


-- References

-- Locations: SecLevelId
/*alter table Locations
add constraint FK_Locations_SecLevel
foreign key (SecLevelId) references SecLevel(Id)
*/

-- AccessRules
alter table AccessRules
add constraint FK_AccessRules_Users
foreign key (SecLevelId) references SecLevel(Id)
alter table AccessRules
add constraint FK_AccessRules_LocId
foreign key (LocId) references Locations(Id)


-- Users
-- IdentDataId
alter table Users
add constraint FK_Users_IdentData
foreign key (IdentDataId) references IdentData(Id)

-- SecLevelId
/*alter table Users
add constraint FK_Locations_SecLevel
foreign key (SecLevelId) references SecLevel(Id)*/

-- DbAccessLevelId
alter table Users
add constraint FK_Users_DbAccessLevel
foreign key (DbAccessLevelId) references DbAccessLevel(Id)



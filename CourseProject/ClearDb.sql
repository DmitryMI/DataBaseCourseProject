use SecSystem

/*alter table Locations
drop constraint FK_Locations_SecLevel*/

alter table AccessRules
drop constraint FK_AccessRules_Users

alter table AccessRules
drop constraint FK_AccessRules_LocId

alter table Users
drop constraint FK_Users_IdentData

alter table Users
drop constraint FK_Users_DbAccessLevel

alter table IdentData
drop constraint FK_IdentData_PwdData
alter table IdentData
drop constraint FK_IdentData_VoiceData

/*alter table IdentData
drop constraint FK_IdentData_Users*/

drop table Locations

drop table AccessRules

drop table Users

drop table IdentData

drop table SecLevel

drop table DbAccessLevel

drop table PwdData

drop table VoiceData

--drop table LoginData






--DROP DATABASE SecSystem
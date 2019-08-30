use SecSystem

go

create procedure AddAccessibleLocation
	@targetSecLevelId int,	
	@locationId int
as
begin
	insert into AccessRules values(@targetSecLevelId, @locationId)
end
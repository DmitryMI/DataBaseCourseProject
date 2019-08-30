use SecSystem

go

create procedure RemoveAccessibleLocation
	@targetSecLevelId int,	
	@locationId int
as
begin
	--insert into AccessRules values(@targetSecLevelId, @locationId)
	delete from AccessRules where AccessRules.SecLevelId = @targetSecLevelId and AccessRules.LocId = @locationId
end
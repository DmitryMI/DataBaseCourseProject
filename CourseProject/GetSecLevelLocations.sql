use SecSystem

drop function GetSecLevelLocations

go

create function GetSecLevelLocations(@secLevelId int)
returns table
as
	return 
	(
		select Locations.Id, Locations.LocName from 
		(Locations join AccessRules on Locations.Id = AccessRules.LocId)
		join SecLevel on SecLevel.Id = AccessRules.SecLevelId		
		where SecLevel.Id = @secLevelId
	)
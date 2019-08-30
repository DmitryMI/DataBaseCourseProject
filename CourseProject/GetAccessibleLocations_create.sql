use SecSystem

drop function GetAccessibleLocations

go

create function GetAccessibleLocations(@userId int)
returns table
as
	return 
	(
		select Locations.Id, Locations.LocName from 
		(Locations join AccessRules on Locations.Id = AccessRules.LocId)
		join SecLevel on SecLevel.Id = AccessRules.SecLevelId
		join Users on SecLevel.Id = Users.SecLevelId
		where Users.Id = @userId
	)
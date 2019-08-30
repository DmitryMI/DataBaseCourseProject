use SecSystem

go

create function GetLocations()
returns table
as
	return 
	(
		select * from Locations
	)

go

select * from dbo.GetLocations()
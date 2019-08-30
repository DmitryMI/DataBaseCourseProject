use SecSystem

go

create function GetLocationById(@id int)
returns table
as
	return 
	(
		select * from 
		Locations
		where Locations.Id = @id
	)
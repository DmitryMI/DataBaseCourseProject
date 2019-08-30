use SecSystem

go

create function GetSecLevels()
returns table
as
	return 
	(
		select * from SecLevel
	)

go

select * from dbo.GetSecLevels()
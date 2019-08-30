use SecSystem

go

create function GetSecLevelById(@id int)
returns table
as
	return 
	(
		select * from 
		SecLevel
		where SecLevel.Id = @id
	)

go

select * from dbo.GetSecLevelById(2)
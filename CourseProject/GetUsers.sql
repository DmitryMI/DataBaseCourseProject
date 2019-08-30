use SecSystem

go

create function GetUsers()
returns table
as
	return 
	(
		select * from Users
	)

go

select * from dbo.GetUsers()
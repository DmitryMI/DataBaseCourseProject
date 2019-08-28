use SecSystem

go

create function GetUserById(@userId int)
returns table
as
	return 
	(
		select * from 
		Users
		where Users.Id = @userId
	)
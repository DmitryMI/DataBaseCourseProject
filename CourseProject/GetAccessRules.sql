use SecSystem

go

create function GetAccessRules()
returns table
as
	return 
	(
		select * from AccessRules
	)

go

select * from dbo.GetAccessRules()
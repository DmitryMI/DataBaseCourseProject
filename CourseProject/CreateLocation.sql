use SecSystem

drop CreateLocation

go

create procedure CreateLocation
	@name nvarchar(50),	
	@Id int output
as
begin
	declare @result table (id INT)
	insert into Locations  OUTPUT INSERTED.ID  into @result values(@name)
	select TOP 1 @Id = id from @result
end
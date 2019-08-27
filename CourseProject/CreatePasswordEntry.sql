use SecSystem

go

create procedure CreatePasswordEntry 
	@passwordHash nvarchar(32),
	@Id int OUTPUT 
as
begin
	declare @result table (id INT)
	insert into PwdData  OUTPUT INSERTED.ID  into @result values(@passwordHash)
	select TOP 1 @Id = id from @result
end
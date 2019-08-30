use SecSystem

drop CreateSecLevel

go

create procedure CreateSecLevel
	@name nvarchar(50),
	@description nvarchar(256),
	@Id int output
as
begin
	declare @result table (id INT)
	insert into SecLevel  OUTPUT INSERTED.ID  into @result values(@name, @description)
	select TOP 1 @Id = id from @result
end
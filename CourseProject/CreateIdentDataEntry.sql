use SecSystem

go

create procedure CreateIdentDataEntry 
	@passwordDataId int,
	@voiceDataId int,
	@Id int OUTPUT 
as
begin
	declare @result table (id INT)
	insert into IdentData  OUTPUT INSERTED.ID  into @result values(@passwordDataId, @voiceDataId)
	select TOP 1 @Id = id from @result
end
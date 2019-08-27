use SecSystem

go

create procedure CreateVoiceDataEntry 
	@voiceData varbinary(8000),
	@Id int OUTPUT 
as
begin
	declare @result table (id INT)
	insert into VoiceData  OUTPUT INSERTED.ID  into @result values(@voiceData)
	select TOP 1 @Id = id from @result
end
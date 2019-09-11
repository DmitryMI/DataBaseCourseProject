use SecSystem

go
drop procedure GetVoiceSample
go

create procedure GetVoiceSample 
	@userId int,
	@voiceSample varbinary(max) output
as
begin
	select @voiceSample = VoiceData.VoiceSample
			from
				Users
				join
				IdentData on Users.IdentDataId = IdentData.Id
				join
				VoiceData on IdentData.VoiceDataId = VoiceData.Id
			where Users.Id = @userId
end

declare @outputVoice int
exec GetVoiceSample 12, @voiceSample = @outputVoice OUTPUT
select @outputVoice

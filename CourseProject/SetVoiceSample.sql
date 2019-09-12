use SecSystem

go
drop procedure SetVoiceSample
go

create procedure SetVoiceSample 
	@userId int,
	@voiceSample VARBINARY (max),
	@Id int output
as
begin
	select @Id = VoiceData.Id
			from
				Users
				join
				IdentData on Users.IdentDataId = IdentData.Id
				join
				VoiceData on IdentData.VoiceDataId = VoiceData.Id
			where Users.Id = @userId

	update VoiceData  
		set VoiceSample = @voiceSample
		where VoiceData.Id = @Id	
end

go

declare @outputId int
declare @testString varchar(50) = 'JELLO WORLD'
declare @testBinary varbinary(max) = CAST (@testString as VARBINARY(max))

exec SetVoiceSample 6, @testBinary, @Id = @outputId OUTPUT
select @outputId
select VoiceData.Id, CAST(VoiceData.VoiceSample as varchar(50)) from VoiceData

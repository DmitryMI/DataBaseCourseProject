use SecSystem

ALTER TABLE VoiceData
ALTER COLUMN VoiceSample varbinary(max); 

select * from VoiceData
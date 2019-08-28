use SecSystem

go

-- TODO
create procedure CheckLoginData
	@UserId int,
	@passwordHash varchar(32),
	@result int output
as
begin
	declare @hash_tmp varchar(32)
	declare @id_tmp int = -1
	select @id_tmp = PwdData.Id, @hash_tmp = PwdData.PasswordHash
	from 
	Users
	join 
	IdentData on Users.IdentDataId = IdentData.Id 
	join
	PwdData on IdentData.PwdDataId = PwdData.Id
	where Users.Id = @UserId and PwdData.PasswordHash = @passwordHash

	if(@id_tmp = @UserId)	
		set @result = 1	
	else
		set @result = 0
end


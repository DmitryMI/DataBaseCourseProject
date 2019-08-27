use SecSystem

go

--drop procedure RegisterUser

go

create procedure RegisterUser
	@firstName nvarchar(50),
	@middleName nvarchar(50),
	@lastName nvarchar(50), 
	@passwordHash nvarchar(50),
	@UserId int output
as
begin
	declare @password_entry_id int
	declare @void_entry_id int
	declare @ident_entry_id int
	exec CreatePasswordEntry @passwordHash,  @Id = @password_entry_id output
	exec CreateVoiceDataEntry NULL,  @Id = @password_entry_id output
	exec CreateIdentDataEntry @password_entry_id, @ident_entry_id,  @Id = @ident_entry_id output

	insert into Users values
	(@firstName, @middleName, @lastName, @ident_entry_id, 1, 1)
end
use SecSystem

-- Fill DbAccessLevel

insert into DbAccessLevel values
(
	'None',	-- Level name
	'This user has no access to data base',
	0
)

insert into DbAccessLevel values
(
	'User',	-- Level name
	'This user has read-only access to data base',
	1
)

insert into DbAccessLevel values
(
	'Administrator',	-- Level name
	'This user has read/write access to data base, except user management',
	2
)

insert into DbAccessLevel values
(
	'Owner',	-- Level name
	'This user has full access to data base, including user management',
	3
)


-- Filling IdentData
insert into IdentData values
(
	1, 1
)

insert into IdentData values
(
	2, 2
)

insert into IdentData values
(
	3, 3
)

insert into IdentData values
(
	4, 4
)

insert into IdentData values
(
	5, 5
)

insert into IdentData values
(
	6, 6
)


-- Fill Users
insert into Users values
('Victor', 'Petrovich', 'Sidorov', 1, 1, 1)				-- Watchman

insert into Users values
('Vladimir', 'Ivanovich', 'Petrov', 2, 1, 1)			-- Watchman

insert into Users values
('Ivan', 'Sergeevich', 'Ivanushkin', 3, 2, 2)				-- Security chief

insert into Users values
('Vladislav', 'Vladimirovich', 'Petushkov', 4, 3, 1)		-- Storage guard

insert into Users values
('Vadim', 'Vladimirovich', 'Levada', 5, 4, 3)				-- Facility director

insert into Users values
('Dmitry', 'Igorevich', 'Monakhov', 6, 5, 3)				-- Owner



-- Fill SecLevels
insert into SecLevel values -- 1
(
	'Watchman', 'This person patrols area'
)

insert into SecLevel values -- 2
(
	'Security chief', 'This person controls work of other watchmen'
)

insert into SecLevel values -- 3
(
	'Storage guard', 'This person guards the storage insides'
)

insert into SecLevel values -- 4
(
	'Director', 'Territory director, full access, except owners office'
)

insert into SecLevel values -- 5
(
	'Owner', 'Full access'
)


-- Fill locations
insert into Locations values
(
	'Outdoors'
)

insert into Locations values
(
	'Storage'
)

insert into Locations values
(
	'Owners office'
)

-- Fille AccessRules
insert into AccessRules values
(
	1, 1 -- Watchman -> Outdoors
)

insert into AccessRules values
(
	2, 1 -- Security chief -> Outdoors
)

insert into AccessRules values
(
	3, 1 -- Storage guard -> Outdoors
)

insert into AccessRules values
(
	3, 2 -- Storage guard -> Storage
)

insert into AccessRules values
(
	4, 1 -- Director -> Outdoors
)

insert into AccessRules values
(
	4, 2 -- Director -> Storage
)

insert into AccessRules values
(
	5, 1 -- Owner -> Outdoors
)

insert into AccessRules values
(
	5, 2 -- Owner -> Storage
)

insert into AccessRules values
(
	5, 3 -- Owner -> Owner's office
)




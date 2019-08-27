use SecSystem

-- Fill DbAccessLevel

insert into DbAccessLevel values
(
	'None',	-- Level name
	'This user has no access to data base',
	0
)
,
(
	'User',	-- Level name
	'This user has read-only access to data base',
	1
)
,
(
	'Administrator',	-- Level name
	'This user has read/write access to data base, except user management',
	2
)
,
(
	'Owner',	-- Level name
	'This user has full access to data base, including user management',
	3
)

-- Creating passwords
insert into PwdData values
(
	'5EB63BBBE01EEED093CB22BB8F5ACDC3' -- hello world
),
(
	'96B409DBA2B20544DF077F08D365F0BA' -- privet mir
),
(
	'25D55AD283AA400AF464C76D713C07AD' -- 12345678
),
(
	'5E8667A439C68F5145DD2FCBECF02209' -- 87654321
),
(
	'ABC35B8D78A399C86D96ED0B78B44FAE' -- get out of here
),
(
	'E220BEBB7182E0F9CDDA2CAA04B532D8' -- <secret>
)

insert into VoiceData values
(
	NULL
),
(
	NULL
),
(
	NULL
),
(
	NULL
),
(
	NULL
),
(
	NULL
)




-- Filling IdentData
insert into IdentData values
(
	1, 1
),
(
	2, 2
),
(
	3, 3
),
(
	4, 4
),
(
	5, 5
),
(
	6, 6
)


-- Fill Users
insert into Users values
('Victor', 'Petrovich', 'Sidorov', 1, 1, 1)				-- Watchman
,
('Vladimir', 'Ivanovich', 'Petrov', 2, 1, 1)			-- Watchman
,
('Ivan', 'Sergeevich', 'Ivanushkin', 3, 2, 2)				-- Security chief
,
('Vladislav', 'Vladimirovich', 'Petushkov', 4, 3, 1)		-- Storage guard
,
('Vadim', 'Vladimirovich', 'Levada', 5, 4, 3)				-- Facility director
,
('Dmitry', 'Igorevich', 'Monakhov', 6, 5, 3)				-- Owner



-- Fill SecLevels
insert into SecLevel values 
	-- 1
(
	'None', 'Security level unset. Must be changed by administration'
),	-- 2
(
	'Watchman', 'This person patrols area'
)
,	-- 3
(
	'Security chief', 'This person controls work of other watchmen'
)
,	-- 4
(
	'Storage guard', 'This person guards the storage insides'
)
,	-- 5
(
	'Director', 'Territory director, full access, except owners office'
)
,	-- 6
(
	'Owner', 'Full access'
)


-- Fill locations
insert into Locations values
(
	'Outdoors'
)
,
(
	'Storage'
)
,
(
	'Owners office'
)

-- Fille AccessRules
insert into AccessRules values
(
	1, 1 -- Watchman -> Outdoors
)
,
(
	2, 1 -- Security chief -> Outdoors
)
,
(
	3, 1 -- Storage guard -> Outdoors
)
,
(
	3, 2 -- Storage guard -> Storage
)
,
(
	4, 1 -- Director -> Outdoors
)
,
(
	4, 2 -- Director -> Storage
)
,
(
	5, 1 -- Owner -> Outdoors
)
,
(
	5, 2 -- Owner -> Storage
)
,
(
	5, 3 -- Owner -> Owner's office
)




use TestDatabase

insert into dbo.users (USERNAME, PASSWORD) VALUES ('Bella_Olivia', 'TestPassword!')

--Delete Users
delete Users where USERNAME = ''

select * from dbo.Users
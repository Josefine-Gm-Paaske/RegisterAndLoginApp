use TestDatabase

insert into dbo.users (USERNAME, PASSWORD) VALUES ('Josse', 'Password1!')

--Delete Users
delete Users where USERNAME = 'Josse'

select * from dbo.Users
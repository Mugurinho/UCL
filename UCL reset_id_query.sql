delete from Users where UserId = 1003
dbcc checkident ('Users', reseed, 0)

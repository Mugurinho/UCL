create table [Users]
(
[UserId] int primary key identity not null,
[FirstName] varchar(30) not null,
[LastName] varchar(30) not null,
[Email] varchar(100) not null,
[FacultyId] int not null FOREIGN KEY REFERENCES Faculties(FacultyId)
)

create table [Faculties]
(
[FacultyId] int primary key identity not null,
[FacultyName] varchar(60) not null,
)

create table [Programmes]
(
[ProgrammeId] int primary key identity not null,
[ProgrammeTitle] varchar(100) not null,
[ProgrammeDescription] varchar(100) not null,
[ProgrammeFee] varchar(100) not null,
[FacultyId] int not null FOREIGN KEY REFERENCES Faculties(FacultyId),
[UserId] int not null FOREIGN KEY REFERENCES Users(UserId)
)

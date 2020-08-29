create database SessionResults
go

use SessionResults

create table Groups
(
	GroupId int primary key identity,
	GroupName varchar(16) unique
)

create table Genders
(
	GenderId int primary key identity,
	Gender varchar(8)
)

create table Marks
(
	MarkId int primary key identity,
	Mark int
)

create table Subjects
(
	SubjectId int primary key identity,
	SubjectName varchar(32),
	SubjectDate date
)

create table Students
(
	StudentId int primary key identity,
	FullName varchar(32) unique,
	GenderId int references Genders(GenderId),
	Birthday date,
	GroupId int references Groups(GroupId)
)

create table StudentSessions
(
	StudentSessionId int primary key identity,
	StudentId int references Students(StudentId),
	SubjectId int references Subjects(SubjectId),
	MarkId int references Marks(MarkId)
)
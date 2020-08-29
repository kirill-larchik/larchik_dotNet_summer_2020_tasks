use SessionResults

insert into Genders(Gender) values 
('Male'), ('Female')

insert into Marks(Mark) values
(1), (2), (3), (4), (5), (6), (7), (8), (9), (10)

insert into Groups(GroupName) values
('Group1'), ('Group2'), ('Group3')

insert into Students(FullName, GenderId, Birthday, GroupId) values
('Ivanon Ivan Ivanovich', 1, '01-01-2000', 1),
('Ivanona Irina Ivanovna', 2, '02-03-2000', 1),
('Petrov Petr Petrovich', 1, '05-01-2000', 2),
('Petrovna Petra Petrovna', 2, '07-05-2000', 2),
('Sidorov Alex Ivanivich', 1, '01-06-2000', 3),
('Sidorovna Darya Grigorevna', 2, '07-02-2000', 3)

insert into Subjects(SubjectName, SubjectDate) values
('mathematic', '30-12-2020'),
('programing', '29-12-2020'),
('mathematic', '28-12-2020'),
('programing', '27-12-2020'),
('mathematic', '26-12-2020'),
('programing', '25-12-2020')

insert into StudentSessions(StudentId, SubjectId, MarkId) values
(1, 1, 9), (1, 2, 8),
(2, 1, 9), (2, 2, 9),
(3, 3, 3), (3, 4, 5),
(4, 3, 7), (4, 4, 6),
(5, 5, 2), (5, 6, 4),
(6, 5, 2), (6, 6, 6)
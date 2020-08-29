using DatabaseLibrary.Dao;
using DatabaseLibrary.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using UniversityLibrary;

namespace DatabaseUnitTest
{
    [TestClass]
    public class StudentDaoUT
    {
        [TestMethod]
        public void Read()
        {
            StudentDaoCreator creator = StudentDaoCreator.GetStudentDaoCreator();
            Dao<Student> studentDao = creator.CreateDao();

            studentDao.ConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
            List<Student> students = studentDao.Read();

            Assert.IsNotNull(students);
        }

        [DataTestMethod]
        [DataRow(3, "Petrov Petr Petrovich", Gender.Male, "2000-01-05", 2)]
        [DataRow(1, "Ivanon Ivan Ivanovich", Gender.Male, "2000-01-01", 1)]
        [DataRow(6, "Sidorovna Darya Grigorevna", Gender.Female, "2000-02-07", 3)]
        public void GetById(int id, string fullName, Gender gender, string birthday, int groupId)
        {
            Student expected = new Student
            {
                StudentId = id,
                FullName = fullName,
                Gender = gender,
                Birthday = DateTime.Parse(birthday),
                GroupId = groupId
            };

            StudentDaoCreator creator = StudentDaoCreator.GetStudentDaoCreator();
            Dao<Student> studentDao = creator.CreateDao();

            studentDao.ConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
            Student actual = studentDao.GetById(id);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("test1 test1 test1", Gender.Female, "2000-01-05", 2)]
        [DataRow("test2 test2 test2", Gender.Male, "2000-01-01", 1)]
        [DataRow("test3 test3 test3", Gender.Female, "2000-02-07", 3)]
        public void Create(string fullName, Gender gender, string birthday, int groupId)
        {
            Student student = new Student
            {
                FullName = fullName,
                Gender = gender,
                Birthday = DateTime.Parse(birthday),
                GroupId = groupId
            };

            StudentDaoCreator creator = StudentDaoCreator.GetStudentDaoCreator();
            Dao<Student> studentDao = creator.CreateDao();

            studentDao.ConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
            bool actual = studentDao.Create(student);

            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow("new1 new1 new1")]
        [DataRow("new2 new2 new2")]
        [DataRow("new3 new3 new3")]
        public void Update(string newFullName)
        {
            StudentDaoCreator creator = StudentDaoCreator.GetStudentDaoCreator();
            Dao<Student> studentDao = creator.CreateDao();

            studentDao.ConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
            List<Student> students = studentDao.Read();

            Student student = students.Last();
            student.FullName = newFullName;

            bool actual = studentDao.Update(student);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Delete()
        {
            StudentDaoCreator creator = StudentDaoCreator.GetStudentDaoCreator();
            Dao<Student> studentDao = creator.CreateDao();

            studentDao.ConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
            List<Student> students = studentDao.Read();

            int id = students.Last().StudentId;

            bool actual = studentDao.Delete(id);

            Assert.IsTrue(actual);
        }
    }
}

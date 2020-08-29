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
    public class StudentSessionDaoUT
    {
        [TestMethod]
        public void Read()
        {
            StudentSessionDaoCreator creator = StudentSessionDaoCreator.GetStudentSessionDaoCreator();
            Dao<StudentSession> studentSessionDao = creator.CreateDao();

            studentSessionDao.ConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
            List<StudentSession> studentSessions = studentSessionDao.Read();

            Assert.IsNotNull(studentSessions);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1, 9)]
        [DataRow(3, 2, 1, 9)]
        [DataRow(6, 3, 4, 5)]
        public void GetById(int id, int studentId, int subjectId, int markId)
        {
            StudentSession expected = new StudentSession
            {
                StudentSessionId = id,
                StudentId = studentId,
                SubjectId = subjectId,
                Mark = (Mark)markId
            };

            StudentSessionDaoCreator creator = StudentSessionDaoCreator.GetStudentSessionDaoCreator();
            Dao<StudentSession> studentSessionDao = creator.CreateDao();

            studentSessionDao.ConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
            StudentSession actual = studentSessionDao.GetById(id);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(2, 2, 2)]
        [DataRow(3, 3, 3)]
        public void Create(int studentId, int subjectId, int markId)
        {
            StudentSession studentSession = new StudentSession
            {
                StudentId = studentId,
                SubjectId = subjectId,
                Mark = (Mark)markId
            };

            StudentSessionDaoCreator creator = StudentSessionDaoCreator.GetStudentSessionDaoCreator();
            Dao<StudentSession> studentSessionDao = creator.CreateDao();

            studentSessionDao.ConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
            bool actual = studentSessionDao.Create(studentSession);

            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(3)]
        [DataRow(3)]
        [DataRow(3)]
        public void Update(int newStudentId)
        {
            StudentSessionDaoCreator creator = StudentSessionDaoCreator.GetStudentSessionDaoCreator();
            Dao<StudentSession> studentSessionDao = creator.CreateDao();

            studentSessionDao.ConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
            List<StudentSession> studentSessions = studentSessionDao.Read();

            StudentSession studentSession = studentSessions.Last();
            studentSession.StudentId = newStudentId;

            bool actual = studentSessionDao.Update(studentSession);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Delete()
        {
            StudentSessionDaoCreator creator = StudentSessionDaoCreator.GetStudentSessionDaoCreator();
            Dao<StudentSession> studentSessionDao = creator.CreateDao();

            studentSessionDao.ConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
            List<StudentSession> studentSessions = studentSessionDao.Read();

            int id = studentSessions.Last().StudentSessionId;

            bool actual = studentSessionDao.Delete(id);

            Assert.IsTrue(actual);
        }
    }
}

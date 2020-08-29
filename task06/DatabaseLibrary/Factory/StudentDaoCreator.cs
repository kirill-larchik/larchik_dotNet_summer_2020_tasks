using DatabaseLibrary.Dao;
using System.Collections.Generic;
using UniversityLibrary;

namespace DatabaseLibrary.Factory
{
    /// <summary>
    /// Class contains factory method to create the student dao.
    /// </summary>
    public class StudentDaoCreator : DaoCreator<Student>
    {
        private static StudentDaoCreator creator;

        private StudentDaoCreator() { }

        /// <summary>
        /// Returns the StudentDaoCreator object.
        /// </summary>
        /// <returns></returns>
        public static StudentDaoCreator GetStudentDaoCreator()
        {
            if (creator == null)
                creator = new StudentDaoCreator();
            return creator;
        }

        public override Dao<Student> CreateDao()
        {
            return new StudentDao();
        }
    }
}

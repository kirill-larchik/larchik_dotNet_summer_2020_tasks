using DatabaseLibrary.Dao;
using UniversityLibrary;

namespace DatabaseLibrary.Factory
{
    /// <summary>
    /// Class contains factory method to create the student dao.
    /// </summary>
    public class StudentSessionDaoCreator : DaoCreator<StudentSession>
    {
        private static StudentSessionDaoCreator creator;

        private StudentSessionDaoCreator() { }

        /// <summary>
        /// Returns the StudentDaoCreator object.
        /// </summary>
        /// <returns></returns>
        public static StudentSessionDaoCreator GetStudentSessionDaoCreator()
        {
            if (creator == null)
                creator = new StudentSessionDaoCreator();
            return creator;
        }

        public override Dao<StudentSession> CreateDao()
        {
            return new StudentSessionDao();
        }
    }
}

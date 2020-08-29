using System.Collections.Generic;

namespace UniversityLibrary
{
    /// <summary>
    /// Class describing a session data of student.
    /// </summary>
    public class StudentSession
    {
        /// <summary>
        /// Id of the student session.
        /// </summary>
        public int StudentSessionId { get; set; }

        /// <summary>
        /// Id of the student.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Id of the subject.
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Mark of the examination subjcet.
        /// </summary>
        public Mark Mark { get; set; }

        public override bool Equals(object obj)
        {
            return obj is StudentSession session &&
                   StudentSessionId == session.StudentSessionId &&
                   StudentId == session.StudentId &&
                   SubjectId == session.SubjectId &&
                   Mark == session.Mark;
        }

        public override int GetHashCode()
        {
            int hashCode = -70741160;
            hashCode = hashCode * -1521134295 + StudentSessionId.GetHashCode();
            hashCode = hashCode * -1521134295 + StudentId.GetHashCode();
            hashCode = hashCode * -1521134295 + SubjectId.GetHashCode();
            hashCode = hashCode * -1521134295 + Mark.GetHashCode();
            return hashCode;
        }
    }
}

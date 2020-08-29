using System;

namespace UniversityLibrary
{
    /// <summary>
    /// Contains the examination mark of a subject.
    /// </summary>
    public enum Mark
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten
    }

    /// <summary>
    /// Class describing a examination subject.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Id of the subject.
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Name of the examination subject.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date of the examination subjcet.
        /// </summary>
        public DateTime Date { get; set; }
    }
}

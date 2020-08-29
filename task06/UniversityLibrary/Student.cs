using System;
using System.Collections.Generic;

namespace UniversityLibrary
{
    /// <summary>
    /// Describing a student gender.
    /// </summary>
    public enum Gender
    {
        Male = 1,
        Female
    }

    /// <summary>
    /// Class describing a student.
    /// </summary>
    public class Student : Group
    {
        /// <summary>
        /// Id of the student.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Full name of the student.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gender of the student.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Birthday of the student.
        /// </summary>
        public DateTime Birthday { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   GroupId == student.GroupId &&
                   GroupName == student.GroupName &&
                   StudentId == student.StudentId &&
                   FullName == student.FullName &&
                   Gender == student.Gender &&
                   Birthday == student.Birthday;
        }

        public override int GetHashCode()
        {
            int hashCode = 1243927544;
            hashCode = hashCode * -1521134295 + GroupId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GroupName);
            hashCode = hashCode * -1521134295 + StudentId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            hashCode = hashCode * -1521134295 + Birthday.GetHashCode();
            return hashCode;
        }
    }
}

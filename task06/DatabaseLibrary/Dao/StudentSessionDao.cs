using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityLibrary;

namespace DatabaseLibrary.Dao
{
    /// <summary>
    /// Class describing CRUD operatiosn for StudentSessions table.
    /// </summary>
    public class StudentSessionDao : Dao<StudentSession>
    {
        public string ConnectionString { get; set; }

        public bool Create(StudentSession obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "insert into StudentSessions(StudentId, SubjectId, MarkId) values (@studentId, @subjectId, @markId);";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@studentId", obj.StudentId);
                    command.Parameters.AddWithValue("@subjectId", obj.SubjectId);
                    command.Parameters.AddWithValue("@markId", (int)obj.Mark);

                    if (command.ExecuteNonQuery() == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "delete from StudentSessions where StudentSessions.StudentSessionId = @id;";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", id);

                    if (command.ExecuteNonQuery() == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public StudentSession GetById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "select * from StudentSessions where StudentSessions.StudentSessionId = @id;";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            StudentSession studentSession = new StudentSession
                            {
                                StudentSessionId = reader.GetInt32(0),
                                StudentId = reader.GetInt32(1),
                                SubjectId = reader.GetInt32(2),
                                Mark = (Mark)reader.GetInt32(3)
                            };

                            return studentSession;
                        }
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<StudentSession> Read()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "select * from StudentSessions where 0 = @value;";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@value", 0);

                    SqlDataReader reader = command.ExecuteReader();

                    List<StudentSession> studentSessions = new List<StudentSession>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            StudentSession studentSession = new StudentSession
                            {
                                StudentSessionId = reader.GetInt32(0),
                                StudentId = reader.GetInt32(1),
                                SubjectId = reader.GetInt32(2),
                                Mark = (Mark)reader.GetInt32(3)
                            };

                            studentSessions.Add(studentSession);
                        }

                        return studentSessions;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Update(StudentSession obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "update StudentSessions set StudentId = @studentId, SubjectId = @subjectId, MarkId = @markId where StudentSessions.StudentSessionId = @id;";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@studentId", obj.StudentId);
                    command.Parameters.AddWithValue("@subjectId", obj.SubjectId);
                    command.Parameters.AddWithValue("@markId", (int)obj.Mark);
                    command.Parameters.AddWithValue("@id", obj.StudentSessionId);

                    if (command.ExecuteNonQuery() == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

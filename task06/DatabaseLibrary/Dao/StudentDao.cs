using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityLibrary;

namespace DatabaseLibrary.Dao
{
    /// <summary>
    /// Class describing CRUD operations for Students table.
    /// </summary>
    public class StudentDao : Dao<Student>
    {
        public string ConnectionString { get; set; }

        public bool Create(Student obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "insert into Students(FullName, GenderId, Birthday, GroupId) values (@fullName, @genderId, @birthday, @groupid);";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@fullName", obj.FullName);
                    command.Parameters.AddWithValue("@genderId", (int)obj.Gender);
                    command.Parameters.AddWithValue("@birthday", obj.Birthday);
                    command.Parameters.AddWithValue("@groupId", obj.GroupId);

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

                    string sql = "delete from Students where Students.StudentId = @id;";

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

        public List<Student> Read()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "select * from Students where 0 = @value;";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@value", 0);

                    SqlDataReader reader = command.ExecuteReader();

                    List<Student> students = new List<Student>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                StudentId = reader.GetInt32(0),
                                FullName = reader.GetString(1),
                                Gender = (Gender)reader.GetInt32(2),
                                Birthday = reader.GetDateTime(3),
                                GroupId = reader.GetInt32(4)
                            };

                            students.Add(student);
                        }

                        return students;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Student GetById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "select * from Students where Students.StudentId = @id;";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                StudentId = reader.GetInt32(0),
                                FullName = reader.GetString(1),
                                Gender = (Gender)reader.GetInt32(2),
                                Birthday = reader.GetDateTime(3),
                                GroupId = reader.GetInt32(4)
                            };

                            return student;
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

        public bool Update(Student obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "update Students set FullName = @fullName, GenderId = @genderId, Birthday = @birthday, GroupId = @groupid where Students.StudentId = @id;";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@fullName", obj.FullName);
                    command.Parameters.AddWithValue("@genderId", (int)obj.Gender);
                    command.Parameters.AddWithValue("@birthday", obj.Birthday);
                    command.Parameters.AddWithValue("@groupId", obj.GroupId);
                    command.Parameters.AddWithValue("@id", obj.StudentId);

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

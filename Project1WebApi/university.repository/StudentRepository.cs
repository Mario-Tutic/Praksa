using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using University.Model.Common;
using University.Model;
using Student.Repository.Common;
using University1.Common;

namespace Student.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<List<StudentInfo>> GetAllStudentsAsync(SortStudent sort, Pagging pagging, StudentFilter filter)
        {
            try
            {
                SqlConnection connection = new SqlConnection("data source=DESKTOP-KTD1H84\\SQLEXPRESS;Database=test;integrated security=SSPI");
                connection.Open();
                SqlCommand command = new SqlCommand(
                "SELECT * FROM student " + filter.Query + " ORDER BY " + sort.Column + " " + sort.Order + " OFFSET " + pagging.Offset + " ROWS FETCH NEXT " + pagging.ElementsPerPage + " ROWS ONLY", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                List<StudentInfo> students = new List<StudentInfo>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var tempStudent = new StudentInfo();
                        tempStudent.Id = Convert.ToInt32(reader["Id"]);
                        tempStudent.Name = Convert.ToString(reader["Name"]);
                        tempStudent.CourseId_fk = Convert.ToInt32(reader["CourseId_fk"]);
                        students.Add(tempStudent);
                    }
                    reader.Close();
                    connection.Close();
                    return students;
                }
                else
                {
                    Console.WriteLine("No rows found.");
                    reader.Close();
                    connection.Close();
                    return (students);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task PostNewStudentAsync(StudentInfo student)
        {
            try
            {
                SqlConnection connection = new SqlConnection("data source=DESKTOP-KTD1H84\\SQLEXPRESS;Database=test;integrated security=SSPI");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Student (Name,CourseId_fk) VALUES('" + student.Name + "'," + student.CourseId_fk + ");", connection);
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection("data source=DESKTOP-KTD1H84\\SQLEXPRESS;Database=test;integrated security=SSPI");
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Student WHERE Id=" + id + ";", connection);
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task PutAsync(StudentInfo student, int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection("data source=DESKTOP-KTD1H84\\SQLEXPRESS;Database=test;integrated security=SSPI");
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Student SET Name = '" + student.Name + "',CourseId_fk = " + student.CourseId_fk + " WHERE Id=" + id + "; ", connection);
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


    }
}

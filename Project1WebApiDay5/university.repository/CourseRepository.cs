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

namespace Student.Repository
{
    public class CourseRepository:ICourseRepository
    {
        public async Task<List<Course>> GetAllCourses()
        {
            try
            {
                SqlConnection connection = new SqlConnection("data source=DESKTOP-KTD1H84\\SQLEXPRESS;Database=test;integrated security=SSPI");
                connection.Open();
                SqlCommand command = new SqlCommand(
                "SELECT * FROM course;", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                List<Course> courses = new List<Course>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var tempCourse = new Course();
                        tempCourse.CourseId = Convert.ToInt32(reader["CourseId"]);
                        tempCourse.CourseName = Convert.ToString(reader["CourseName"]);
                        courses.Add(tempCourse);
                    }
                    reader.Close();
                    connection.Close();
                    return courses;
                }
                else
                {
                    Console.WriteLine("No rows found.");
                    reader.Close();
                    connection.Close();
                    return (courses);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task PostNewCourse(Course course)
        {
            try
            {
                SqlConnection connection = new SqlConnection("data source=DESKTOP-KTD1H84\\SQLEXPRESS;Database=test;integrated security=SSPI");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Course (CourseId, CourseName) VALUES(" + course.CourseId + ", '" + course.CourseName+"');", connection);
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection("data source=DESKTOP-KTD1H84\\SQLEXPRESS;Database=test;integrated security=SSPI");
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Course WHERE Id=" + id + ";", connection);
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}

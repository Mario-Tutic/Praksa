using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;



namespace Project1WebApiDay2.Controllers
{
    public class StudentController : ApiController
    {
        static List<Student> students = new List<Student>();
        Student tempStudent = new Student();
        SqlConnection connection;
        public HttpResponseMessage GetAllStudents()
        {
            try
            {
                SqlConnection connection = new SqlConnection("data source=DESKTOP-KTD1H84\\SQLEXPRESS;Database=test;integrated security=SSPI");
                connection.Open();
                SqlCommand command = new SqlCommand(
                "SELECT * FROM student;", connection);
                SqlDataReader reader = command.ExecuteReader();
                students.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tempStudent.Id = Convert.ToInt32(reader["Id"]);
                        tempStudent.Name = Convert.ToString(reader["Name"]);
                        tempStudent.CourseId_fk= Convert.ToInt32(reader["CourseId_fk"]);
                        students.Add(tempStudent);
                    }
                    reader.Close();
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, students);
                }
                else
                {
                    Console.WriteLine("No rows found.");
                    reader.Close();
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (SqlException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage PostNewStudent(Student student)
        {
            try
            {
                SqlConnection connection = new SqlConnection("data source=DESKTOP-KTD1H84\\SQLEXPRESS;Database=test;integrated security=SSPI");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Student (Id, Name,CourseId_fk) VALUES(" + student.Id+", '"+student.Name+"',"+student.CourseId_fk+");", connection);
                command.ExecuteNonQuery();
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (SqlException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage GetById(int id)
        {
            var existingStudent = students.FirstOrDefault(o => o.Id == id);

                if (existingStudent != null)
                {

                return Request.CreateResponse(HttpStatusCode.OK, existingStudent);
                }
                else
                {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
                }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection("data source=DESKTOP-KTD1H84\\SQLEXPRESS;Database=test;integrated security=SSPI");
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Student WHERE Id="+id+";", connection);
                command.ExecuteNonQuery();
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (SqlException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage Put(Student student, int id)
        {
            var itemToChange = students.FirstOrDefault(o => o.Id == id);

            if (itemToChange != null)
            {
                itemToChange.Name = student.Name;
                itemToChange.Id = student.Id;

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }



}
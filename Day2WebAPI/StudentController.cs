using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project1WebApiDay2.Controllers
{
    public class StudentController : ApiController
    {
        static List<Student> students = new List<Student>();

        public HttpResponseMessage GetAllStudents()
        {

            if (students.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        public HttpResponseMessage PostNewStudent(Student student)
        {
            students.Add(student);
            return Request.CreateResponse(HttpStatusCode.OK);
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
            var itemToRemove = students.FirstOrDefault(o => o.Id == id);

            if (itemToRemove != null)
            {
                students.Remove(itemToRemove);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using University.Model;
using University.Model.Common;
using Student.Service.Common;
using Student.Service;



namespace Student.Controllers
{
    public class StudentController : ApiController
    {
        public HttpResponseMessage GetAllStudents()
        {
            List<StudentInfo> students = new List<StudentInfo>();
            StudentService service = new StudentService();
            students = service.GetAllStudents();
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        public void PostNewStudent(StudentInfo student)
        {
            StudentService Repository = new StudentService();
            Repository.PostNewStudent(student);
            return;
        }

        public void Delete(int id)
        {
            StudentService Service = new StudentService();
            Service.Delete(id);
            return;
        }

        public void Put(StudentInfo student, int id)
        {
            StudentService Service = new StudentService();
            Service.Put(student, id);
            return;
        }



    }
}
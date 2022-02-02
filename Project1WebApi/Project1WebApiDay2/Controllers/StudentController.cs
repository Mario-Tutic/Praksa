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
using System.Threading.Tasks;
using Project1WebApiDay2.Models;
using University1.Common;

namespace Student.Controllers
{
    public class StudentController : ApiController
    {
        public StudentController(IStudentService service)
        {
            this.service = service;
        }
        protected IStudentService service { get; set; }
        public async Task<HttpResponseMessage> GetAllStudentsAsync(string column="", string order="",int offset=0,int elementsPerPage=0,string name="" )
        {
            List<StudentInfo> students;
            List<StudentInfoView> studentsView= new List<StudentInfoView>();
            SortStudent sort = new SortStudent(column,order);
            Pagging pagging = new Pagging(offset, elementsPerPage);
            StudentFilter filter = new StudentFilter(name);
            students = await service.GetAllStudentsAsync(sort, pagging,filter);

            foreach (var student in students)
            {
                StudentInfoView tempStudent = new StudentInfoView();
                tempStudent.Id = student.Id;
                tempStudent.Name = student.Name;
                tempStudent.CourseId_fk = student.CourseId_fk;
                studentsView.Add(tempStudent);

            }
            return Request.CreateResponse(HttpStatusCode.OK, studentsView);
        }

        public async Task<HttpResponseMessage> PostNewStudentAsync(StudentPost tempStudent)
        {
            StudentInfo student = new StudentInfo();
            student.Name = tempStudent.Name;
            student.CourseId_fk = tempStudent.CourseId_fk;
            student.Id = 0;
            await service.PostNewStudentAsync(student);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            await service.DeleteAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> PutAsync(StudentPost tempStudent, int id)
        {
            StudentInfo student = new StudentInfo();
            student.Name = tempStudent.Name;
            student.CourseId_fk = tempStudent.CourseId_fk;
            student.Id = 0;
            await service.PutAsync(student, id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }



    }
}
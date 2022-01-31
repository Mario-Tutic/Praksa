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
        public async Task<HttpResponseMessage> GetAllStudentsAsync(string column="", string order="",int offset=0,int elementsPerPage=0,string name="" )
        {

            List<StudentInfo> students;
            StudentService service = new StudentService();
            List<StudentInfoView> studentsView= new List<StudentInfoView>();
            Sorting Sort = new Sorting(column,order);
            Pagging pagging = new Pagging(offset, elementsPerPage);
            Filter filter = new Filter(name);
            students = await service.GetAllStudentsAsync(Sort, pagging,filter);

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
            StudentService service = new StudentService();
            await service.PostNewStudentAsync(student);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            StudentService Service = new StudentService();
            await Service.DeleteAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> PutAsync(StudentPost tempStudent, int id)
        {
            StudentService Service = new StudentService();
            StudentInfo student = new StudentInfo();
            student.Name = tempStudent.Name;
            student.CourseId_fk = tempStudent.CourseId_fk;
            student.Id = 0;
            await Service.PutAsync(student, id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }



    }
}
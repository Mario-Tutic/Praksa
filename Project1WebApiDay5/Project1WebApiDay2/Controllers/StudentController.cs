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
namespace Student.Controllers
{
    public class StudentController : ApiController
    {
        public async Task<List<StudentInfo>> GetAllStudents()
        {
            List<StudentInfo> students = new List<StudentInfo>();
            StudentService service = new StudentService();
            students = await service.GetAllStudents();
            return students;
        }

        public async Task PostNewStudent(StudentPost tempStudent)
        {
            StudentInfo student = new StudentInfo();
            student.Name = tempStudent.Name;
            student.CourseId_fk = tempStudent.CourseId_fk;
            student.Id = 0;
            StudentService service = new StudentService();
            await service.PostNewStudent(student);
            return;
        }

        public async Task Delete(int id)
        {
            StudentService Service = new StudentService();
            await Service.Delete(id);
            return;
        }

        public async Task Put(StudentInfo student, int id)
        {
            StudentService Service = new StudentService();
            await Service.Put(student, id);
            return;
        }



    }
}
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

namespace Project1WebApiDay2.Controllers
{
    public class CourseController : ApiController
    {
        public async Task<List<Course>> GetAllStudents()
        {
            List<Course> courses = new List<Course>();
            CourseService service = new CourseService();
            courses = await service.GetAllCourses();
            return courses;
        }
        public async Task PostNewCourse(Course course)
        {
            CourseService Repository = new CourseService();
            await Repository.PostNewCourse(course);
            return;
        }

        public async Task Delete(int id)
        {
            CourseService Service = new CourseService();
            await Service.Delete(id);
            return;
        }
    }
}
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


namespace Project1WebApiDay2.Controllers
{
    public class CourseController : ApiController
    {
        public async Task<HttpResponseMessage> GetAllStudentsAsync(string column = "", string order = "", int offset = 0, int elementsPerPage = 0, string name = "")
        {
            List<Course> courses = new List<Course>();
            CourseService service = new CourseService();
            SortCourse sort = new SortCourse(column, order);
            Pagging pagging = new Pagging(offset, elementsPerPage);
            CourseFilter filter = new CourseFilter(name);
            courses = await service.GetAllCoursesAsync(sort, pagging, filter);
            List<CourseView> coursesView = new List<CourseView>();
            foreach (var course in courses)
            {
                CourseView tempCourse = new CourseView();
                tempCourse.CourseId = course.CourseId;
                tempCourse.CourseName = course.CourseName;
                coursesView.Add(tempCourse);
            }
            return Request.CreateResponse(HttpStatusCode.OK, coursesView);
        }
        public async Task<HttpResponseMessage> PostNewCourseAsync(Course course)
        {
            CourseService Repository = new CourseService();
            await Repository.PostNewCourse(course);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            CourseService Service = new CourseService();
            await Service.DeleteAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
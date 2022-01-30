using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//what i added
using Student.Repository.Common;
using Student.Repository;
using University.Model.Common;
using University.Model;
using Student.Service.Common;


namespace Student.Service
{
    public class CourseService:ICourseService
    {
        public async Task<List<Course>> GetAllCourses()
        {
            CourseRepository Repository = new CourseRepository();
            return await Repository.GetAllCourses();
        }
        public async Task PostNewCourse(Course course)
        {
            CourseRepository Repository = new CourseRepository();
            await Repository.PostNewCourse(course);
            return;
        }

        public async Task Delete(int id)
        {
            CourseRepository Repository = new CourseRepository();
            await Repository.Delete(id);
            return;
        }
    }
}

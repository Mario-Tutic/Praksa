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
using University1.Common;


namespace Student.Service
{
    public class CourseService:ICourseService
    {
        public async Task<List<Course>> GetAllCoursesAsync(SortCourse sort, Pagging pagging, CourseFilter filter)
        {
            CourseRepository Repository = new CourseRepository();
            return await Repository.GetAllCoursesAsync(sort, pagging, filter);
        }
        public async Task PostNewCourse(Course course)
        {
            CourseRepository Repository = new CourseRepository();
            await Repository.PostNewCourseAsync(course);
            return;
        }

        public async Task DeleteAsync(int id)
        {
            CourseRepository Repository = new CourseRepository();
            await Repository.DeleteAsync(id);
            return;
        }
    }
}

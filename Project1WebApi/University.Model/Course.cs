using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Model.Common;
namespace University.Model
{
    public class Course :ICourse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}

using University.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.Model
{
    public class StudentInfo: IStudentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId_fk { get; set; }
    }
}
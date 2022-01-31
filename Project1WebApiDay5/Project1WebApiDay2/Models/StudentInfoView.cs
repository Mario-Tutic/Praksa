using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1WebApiDay2.Models
{
    public class StudentInfoView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId_fk { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University1.Common
{
    public class CourseFilter
    {
        private string name = "";
        private string query = "";
        public CourseFilter(string name)
        {
            if (name != "")
            {
                this.name = name;
                query = "WHERE CourseName LIKE '%" + name + "%'";
            }
        }
        public string Name   // property
        {
            get { return name; }   // get method
            set { name = value; }  // set meth
        }

        public string Query   // property
        {
            get { return query; }   // get method
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University1.Common
{
    public class SortCourse
    {
        private string column = "CourseId";
        private string order = "ASC";
        public SortCourse(string column, string order)
        {
            if (column != "")
            {
                this.column = column;
            }
            if (order != "")
            {
                this.order = order;
            }
        }
        public string Column   // property
        {
            get { return column; }   // get method
            set { column = value; }  // set method
        }
        public string Order   // property
        {
            get { return order; }   // get method
            set { order = value; }  // set method
        }
    }
}

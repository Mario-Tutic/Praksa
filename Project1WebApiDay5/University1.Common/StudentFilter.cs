using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University1.Common
{
    public class StudentFilter//Allows searching just by name 
    {
        private string name="";
        private string query="";
        public StudentFilter(string name)
        {
            if (name != "")
            {
                this.name = name;
                query = "WHERE Name LIKE '%" + name + "%'";
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

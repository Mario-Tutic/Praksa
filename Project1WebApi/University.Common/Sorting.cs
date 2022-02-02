using System;
using System.Collections.Generic;
using System.Text;

namespace University.Common
{
    public class Sorting
    {
        string Sort(string column,string order)
        {
            string query = "ORDER BY " + column + "order;";
            return query;
        }
    }
}

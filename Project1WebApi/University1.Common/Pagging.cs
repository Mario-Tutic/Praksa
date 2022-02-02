using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University1.Common
{
    public class Pagging
    {
        private int offset=0, elementsPerPage=3;
        public Pagging(int offset ,int elementsPerPage)
        {
            if (offset != 0)
            {
                this.offset = offset;
            }
            if (elementsPerPage != 0)
            {
                this.elementsPerPage = elementsPerPage;
            }
        }


        public int Offset   // property
        {
            get { return offset; }   // get method
            set { offset = value; }  // set meth
        }
        public int ElementsPerPage   // property
        {
            get { return elementsPerPage; }   // get method
            set { elementsPerPage = value; }  // set method
        }
    }
}

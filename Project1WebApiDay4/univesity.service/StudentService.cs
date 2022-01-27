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
    public class StudentService: IStudentService
    {
        public List<StudentInfo> GetAllStudents()
        {
            StudentRepository Repository = new StudentRepository();
            return Repository.GetAllStudents();
        }

        public void PostNewStudent(StudentInfo student)
        {
            StudentRepository Repository = new StudentRepository();
            Repository.PostNewStudent(student);
            return;
        }

        public void Delete(int id)
        {
            StudentRepository Repository = new StudentRepository();
            Repository.Delete(id);
            return;
        }

        public void Put(StudentInfo student, int id)
        {
            StudentRepository Repository = new StudentRepository();
            Repository.Put(student,id);
            return;
        }
    }
}

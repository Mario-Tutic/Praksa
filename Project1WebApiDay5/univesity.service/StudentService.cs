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
    public class StudentService: IStudentService
    {
        public async Task<List<StudentInfo>> GetAllStudentsAsync(Sorting sort,Pagging pagging,Filter filter)
        {
            StudentRepository Repository = new StudentRepository();
            return await Repository.GetAllStudentsAsync(sort, pagging);
        }

        public async Task PostNewStudentAsync(StudentInfo student)
        {
            StudentRepository Repository = new StudentRepository();
            await Repository.PostNewStudentAsync(student);
            return;
        }

        public async Task DeleteAsync(int id)
        {
            StudentRepository Repository = new StudentRepository();
            await Repository.DeleteAsync(id);
            return;
        }

        public async Task PutAsync(StudentInfo student, int id)
        {
            StudentRepository Repository = new StudentRepository();
            await Repository.PutAsync(student,id);
            return;
        }
    }
}

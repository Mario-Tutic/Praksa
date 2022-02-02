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
    public class StudentService : IStudentService
    {
        public StudentService(IStudentRepository Repository)
        {
            this.Repository = Repository;
        }
        protected IStudentRepository Repository { get; set; }
        public async Task<List<StudentInfo>> GetAllStudentsAsync(SortStudent sort, Pagging pagging, StudentFilter filter)
        {
            return await Repository.GetAllStudentsAsync(sort, pagging, filter);
        }

        public async Task PostNewStudentAsync(StudentInfo student)
        {
            await Repository.PostNewStudentAsync(student);
            return;
        }

        public async Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);
            return;
        }

        public async Task PutAsync(StudentInfo student, int id)
        {
            await Repository.PutAsync(student, id);
            return;
        }
    }
}

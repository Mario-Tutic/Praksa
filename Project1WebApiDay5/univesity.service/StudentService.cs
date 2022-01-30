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
        public async Task<List<StudentInfo>> GetAllStudents()
        {
            StudentRepository Repository = new StudentRepository();
            return await Repository.GetAllStudents();
        }

        public async Task PostNewStudent(StudentInfo student)
        {
            StudentRepository Repository = new StudentRepository();
            await Repository.PostNewStudent(student);
            return;
        }

        public async Task Delete(int id)
        {
            StudentRepository Repository = new StudentRepository();
            await Repository.Delete(id);
            return;
        }

        public async Task Put(StudentInfo student, int id)
        {
            StudentRepository Repository = new StudentRepository();
            await Repository.Put(student,id);
            return;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using University.Model;
using University1.Common;

namespace Student.Repository
{
    public interface IStudentRepository
    {
        Task DeleteAsync(int id);
        Task<List<StudentInfo>> GetAllStudentsAsync(SortStudent sort, Pagging pagging, StudentFilter filter);
        Task PostNewStudentAsync(StudentInfo student);
        Task PutAsync(StudentInfo student, int id);
    }
}
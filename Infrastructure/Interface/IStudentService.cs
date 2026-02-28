using Domain.Models;

namespace Infrastructure.Interface;

public interface IStudentService
{
    int AddStudent(Students students);
    IEnumerable<Students> GetAllStudents();
    Students GetStudentById(int id);
    int UpdateStudent(Students students);
    int DeleteStudent(int id);
}

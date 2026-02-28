using Domain.Models;

namespace Infrastructure.Interface;

public interface IStudentGroups
{
    int AddStudentGroup(StudentGroups studentGroups);
    IEnumerable<StudentGroups> GetAllStudentGroup();
    StudentGroups GetStudentGroupsById(int id);
    int UpdateStudentGroup(StudentGroups studentGroups);
    int DeleteStudentGroup(int id);
}

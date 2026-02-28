using Domain.Models;

namespace Infrastructure.Interface;

public interface ICourseService
{
    int AddCourse(Courses courses);
    IEnumerable<Courses> GetAllCourses();
    Courses GetCourseById(int id);
    int UpdateCourse(Courses courses);
    int DeleteCourses(int id);
}

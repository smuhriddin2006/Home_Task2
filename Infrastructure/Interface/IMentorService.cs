using Domain.Models;

namespace Infrastructure.Interface;

public interface IMentorService
{
    int AddMentor(Mentors mentors);
    IEnumerable<Mentors> GetAllMentors();
    Mentors GetMentorById(int id);
    int UpdateMentor(Mentors mentors);
    int DeleteMentor(int id);
}

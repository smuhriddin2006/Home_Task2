using Domain.Models;

namespace Infrastructure.Interface;

public interface IGroupServices
{
    int AddGroup(Groups groups);
    IEnumerable<Groups> GetAllGroups();
    Groups GetGroupById(int id);
    int UpdateGroup(Groups groups);
    int DeleteGroup(int id);
}

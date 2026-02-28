using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Interface;
using Dapper;
namespace Infrastructure.Services;


   public class StudentGroupsService : IStudentGroups
{
    private readonly DataContext context = new();

    public int AddStudentGroup(StudentGroups studentGroups)
    {
      

        if (string.IsNullOrWhiteSpace(studentGroups.Status))
            throw new ArgumentException("Status can't be empty!");

        using (var connection = context.CreateConnection())
        {
            connection.Open();

            string cmd = @"insert into StudentGroups (StudentId, GroupId, Status)
                           values (@StudentId, @GroupId, @Status)";

            return connection.Execute(cmd, studentGroups);
        }
    }

    public int DeleteStudentGroup(int id)
    {
        using (var connection = context.CreateConnection())
        {
            connection.Open();

            string check = @"select count(*) from StudentGroups
                             where StudentGroupId = @id";

            var exist = connection.ExecuteScalar<int>(check, new { id });

            if (exist == 0)
                throw new ArgumentException($"StudentGroup with id {id} not found!");

            string cmd = @"delete from StudentGroups
                           where StudentGroupId = @id";

            return connection.Execute(cmd, new { id });
        }
    }

    public IEnumerable<StudentGroups> GetAllStudentGroup()
    {
        using (var connection = context.CreateConnection())
        {
            connection.Open();

            string cmd = @"select * from StudentGroups";

            return connection.Query<StudentGroups>(cmd);
        }
    }

    public StudentGroups GetStudentGroupsById(int id)
    {
        using (var connection = context.CreateConnection())
        {
            connection.Open();

            string cmd = @"select * from StudentGroups
                           where StudentGroupId = @id";

            var result = connection.QueryFirstOrDefault<StudentGroups>(cmd, new { id });

            if (result == null)
                throw new ArgumentException($"StudentGroup with id {id} not found!");

            return result;
        }
    }

    public int UpdateStudentGroup(StudentGroups studentGroups)
    {

        if (string.IsNullOrWhiteSpace(studentGroups.Status))
            throw new ArgumentException("Status can't be empty!");

        using (var connection = context.CreateConnection())
        {
            connection.Open();

            string check = @"select count(*) from StudentGroups
                             where StudentGroupId = @StudentGroupId";

            var exist = connection.ExecuteScalar<int>(check, new {studentGroups.GroupId });

            if (exist == 0)
                throw new ArgumentException($"StudentGroup with id {studentGroups.GroupId} not found!");

            string cmd = @"update StudentGroups set
                           StudentId = @StudentId,
                           GroupId = @GroupId,
                           Status = @Status
                           where StudentGroupId = @StudentGroupId";

            return connection.Execute(cmd, studentGroups);
        }
    }
}



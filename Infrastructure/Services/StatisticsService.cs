using Dapper;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class StatisticsService
{
    private readonly DataContext context = new();

    public int GetTotalStudentsCount()
    {
        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = "select count(*) from Students";

                var result = connection.QueryFirstOrDefault<int>(cmd);
                return result;
                
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

     public int GetTotalGroupsCount()
    {
        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = "select count(GroupId) from Groups";

                var result = connection.QueryFirstOrDefault<int>(cmd);
                return result;
                
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public int GetTotalCoursesCount()
    {
        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = "select count(*) from Courses";

                var result = connection.QueryFirstOrDefault<int>(cmd);
                return result;
                
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public int GetTotalMentorsCount()
    {
        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = "select count(MentorId) from Mentors";

                var result = connection.QueryFirstOrDefault<int>(cmd);
                return result;
                
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

}

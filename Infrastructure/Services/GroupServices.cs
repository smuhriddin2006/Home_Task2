using Domain.Models;
using Infrastructure.Interface;
using Dapper;
using Infrastructure.Context;
using System.Text.RegularExpressions;

namespace Infrastructure.Services;

public class GroupServices : IGroupServices
{
    private readonly DataContext context = new();

    public int AddGroup(Groups groups)
    {
        if(string.IsNullOrWhiteSpace(groups.GroupName))
        {
            throw new ArgumentException("The fullname can't be empty!!!");
        }

        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = @"Insert into Groups (GroupName, CourseId, MentorId, StartDate, EndDate)
                               Values (@GroupName, @CourseId, @MentorId, @StartDate, @EndDate)";
                var result = connection.Execute(cmd, groups);
                return result;
            }
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return 0;
        }    
    }

    public int DeleteGroup(int id)
    {
        try
        {
            using (var connection = context.CreateConnection()) 
            {
                connection.Open();

                string cms = @"Select count(*) from Groups
                                where GroupId = @id";
                var exist = connection.ExecuteScalar<int>(cms, new {id});
                
                if(exist == 0)
                {
                    throw new ArgumentException($"There is not Groups with id {id} like this!");
                }

                string cmd = @"delete from Groups
                                where GroupId = @id";
                var result = connection.Execute(cmd, new {id});
                return result;
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }        }

    public IEnumerable<Groups> GetAllGroups()
    {
            try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = @"select GroupId, 
                              GroupName, 
                              CourseId, 
                              MentorId , 
                              StartDate::timestamp AS StartDate,
                              EndDate::timestamp AS EndDate
                              from Groups";
                var result = connection.Query<Groups>(cmd);
                if (result == null) throw new Exception("Groups не найден");
                return result;
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }        }

    public Groups GetGroupById(int id)
    {
        try
        {
            using(var connection = context.CreateConnection())
            {
                connection.Open();
                string cmd = @"select * from Groups
                                where GroupId = @id";
                var result = connection.QueryFirstOrDefault<Groups>(cmd, new {id});
                return result;

            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }    }

    public int UpdateGroup(Groups groups)
    {
try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                
                string cms = @"select count(*) from Groups
                                where GroupId = @GroupId";

                var exist = connection.Execute(cms, groups.GroupId);
                if(exist == 0)
                {
                    throw new ArgumentException($"There is not {groups.GroupId} like that");
                }                

                string cmd = @"Update Groups Set
                                GroupName = @GroupName,
                                CourseId = @CourseId,
                                MentorId = @MentorId,
                                StartDate = @StartDate,
                                EndDate = @EndDate
                                where GroupId = @GroupId";

                var result = connection.Execute(cmd, groups);
                return result;                
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }    }

}


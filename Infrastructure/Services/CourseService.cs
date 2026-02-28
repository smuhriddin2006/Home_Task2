using Domain.Models;
using Infrastructure.Interface;
using Dapper;
using Infrastructure.Context;
using Npgsql;


namespace Infrastructure.Services;

public class CourseService : ICourseService {
 private readonly DataContext context = new();

    public int AddCourse(Courses courses)
    {
        if(string.IsNullOrWhiteSpace(courses.Title))
        {
            throw new ArgumentException("The title can't be empty!!!");
        }

        if (string.IsNullOrWhiteSpace(courses.Description))
        {
            throw new ArgumentException("The description can't be empty!!!");
        }

        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = @"Insert into Courses (Title, Description, DurationWeeks)
                               Values (@Title, @Description, @DurationWeeks)";
                var result = connection.Execute(cmd, courses);
                return result;
            }
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return 0;
        }    }

    public int DeleteCourses(int id)
    {
try
        {
            using (var connection = context.CreateConnection()) 
            {
                connection.Open();

                string cms = @"Select count(*) from Courses
                                where CourseId = @id";
                var exist = connection.ExecuteScalar<int>(cms, new {id});
                
                if(exist == 0)
                {
                    throw new ArgumentException($"There is not course with id {id} like this!");
                }

                string cmd = @"delete from Courses
                                where CourseId = @id";
                var result = connection.Execute(cmd, new {id});
                return result;
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }    }

    public IEnumerable<Courses> GetAllCourses()
    {
        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = @"select CourseId, 
                              Title, 
                              Description, 
                              DurationWeeks 
                             from Courses";
                var result = connection.Query<Courses>(cmd);
                if (result == null) throw new Exception("Студент не найден");
                return result;
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }    
        }

    public Courses GetCourseById(int id)
    {
        try
        {
            using(var connection = context.CreateConnection())
            {
                connection.Open();
                string cmd = @"select * from Courses
                                where CourseId = @id";
                var result = connection.QueryFirstOrDefault<Courses>(cmd, new {id});
                return result;

            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }    }

    public int UpdateCourse(Courses courses)
    {
            try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                
                string cms = @"select count(*) from Courses
                                where CourseId = @CourseId";

                var exist = connection.Execute(cms, courses.CourseId);
                if(exist == 0)
                {
                    throw new ArgumentException($"There is not {courses.CourseId} like that");
                }                

                string cmd = @"Update Courses Set
                                Title = @Title,
                                Description = @Description,
                                DurationWeeks = @DurationWeeks
                                where CourseId = @CourseId";

                var result = connection.Execute(cmd, courses);
                return result;                
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }    }

}
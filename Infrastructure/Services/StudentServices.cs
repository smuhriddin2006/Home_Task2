using Dapper;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Interface;
using Npgsql;

namespace Infrastructure.Services;

public class StudentServices : IStudentService
{
    private readonly DataContext context = new();
    public int AddStudent(Students students)
    {
        if(string.IsNullOrWhiteSpace(students.FullName))
        {
            throw new ArgumentException("The fullname can't be empty!!!");
        }

        if (string.IsNullOrWhiteSpace(students.Email))
        {
            throw new ArgumentException("The email can't be empty!!!");
        }
        if (string.IsNullOrWhiteSpace(students.Phone)){
        throw new ArgumentException("The phone can't be empty!!!");
        }
        if (!students.Email.Contains("@"))
        {
            throw new ArgumentException("The email must have @");
        }

        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = @"Insert into Students (FullName, Email, Phone, EnrollmentDate)
                               Values (@FullName, @Email, @Phone, @EnrollmentDate)";
                var result = connection.Execute(cmd, students);
                return result;
            }
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return 0;
        }
    }

    public int DeleteStudent(int id)
    {

        try
        {
            using (var connection = context.CreateConnection()) 
            {
                connection.Open();

                string cms = @"Select count(*) from students
                                where StudentId = @id";
                var exist = connection.ExecuteScalar<int>(cms, new {id});
                
                if(exist == 0)
                {
                    throw new ArgumentException($"There is not student with id {id} like this!");
                }

                string cmd = @"delete from Students
                                where StudentId = @id";
                var result = connection.Execute(cmd, new {id});
                return result;
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public IEnumerable<Students> GetAllStudents()
    {
        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = @"select StudentId, 
                              FullName, 
                              Email, 
                              Phone, 
                            EnrollmentDate::timestamp AS EnrollmentDate from Students";
                var result = connection.Query<Students>(cmd);
                if (result == null) throw new Exception("Студент не найден");
                return result;
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public Students GetStudentById(int id)
    {
        try
        {
            using(var connection = context.CreateConnection())
            {
                connection.Open();
                string cmd = @"select * from students
                                where StudentId = @id";
                var result = connection.QueryFirstOrDefault<Students>(cmd, new {id});
                return result;

            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public int UpdateStudent(Students students)
    {
        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                
                string cms = @"select count(*) from students
                                where StudentId = @StudentId";

                var exist = connection.Execute(cms, students.StudentId);
                if(exist == 0)
                {
                    throw new ArgumentException($"There is not {students.StudentId} like that");
                }                

                string cmd = @"Update students Set
                                FullName = @FullName,
                                Email = @Email,
                                Phone = @Phone,
                                EnrollmentDate = @EnrollmentDate
                                where StudentId = @StudentId";

                var result = connection.Execute(cmd, students);
                return result;                
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

}

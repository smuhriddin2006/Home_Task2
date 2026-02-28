using Domain.Models;
using Infrastructure.Interface;
using Dapper;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class MentorService : IMentorService{

    private readonly DataContext context = new();


    public int AddMentor(Mentors mentors)
    {
        if(string.IsNullOrWhiteSpace(mentors.FullName))
        {
            throw new ArgumentException("The fullname can't be empty!!!");
        }

        if (string.IsNullOrWhiteSpace(mentors.Email))
        {
            throw new ArgumentException("The email can't be empty!!!");
        }
        if (string.IsNullOrWhiteSpace(mentors.Phone)){
        throw new ArgumentException("The phone can't be empty!!!");
        }
        if (!mentors.Email.Contains("@"))
        {
            throw new ArgumentException("The email must have @");
        }

        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = @"Insert into Mentors (FullName, Email, Phone, Specialization)
                               Values (@FullName, @Email, @Phone, @Specialization)";
                var result = connection.Execute(cmd, mentors);
                return result;
            }
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return 0;
        }    
        }

    public int DeleteMentor(int id)
    {
        try
        {
            using (var connection = context.CreateConnection()) 
            {
                connection.Open();

                string cms = @"Select count(*) from Mentors
                                where MentorId = @id";
                var exist = connection.ExecuteScalar<int>(cms, new {id});
                
                if(exist == 0)
                {
                    throw new ArgumentException($"There is not mentor with id {id} like this!");
                }

                string cmd = @"delete from Mentors
                                where MentorId = @id";
                var result = connection.Execute(cmd, new {id});
                return result;
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }    
        
        }

    public IEnumerable<Mentors> GetAllMentors()
    {
        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();

                string cmd = @"select MentorId, 
                              FullName, 
                              Email, 
                              Phone, 
                            Specialization
                            from Mentors";
                var result = connection.Query<Mentors>(cmd);
                if (result == null) throw new Exception("Студент не найден");
                return result;
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }    }

    public Mentors GetMentorById(int id)
    {
            try
        {
            using(var connection = context.CreateConnection())
            {
                connection.Open();
                string cmd = @"select * from Mentors
                                where MentorId = @id";
                var result = connection.QueryFirstOrDefault<Mentors>(cmd, new {id});
                return result;

            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }    }

    public int UpdateMentor(Mentors mentors)
    {
        try
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                
                string cms = @"select count(*) from Mentors
                                where MentorId = @MentorId";

                var exist = connection.Execute(cms, mentors.MentorId);
                if(exist == 0)
                {
                    throw new ArgumentException($"There is not {mentors.MentorId} like that");
                }                

                string cmd = @"Update Mentors Set
                                FullName = @FullName,
                                Email = @Email,
                                Phone = @Phone,
                                Specialization = @Specialization
                                where MentorId = @MentorId";

                var result = connection.Execute(cmd, mentors);
                return result;                
            }
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }    }

    
}

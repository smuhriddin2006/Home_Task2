using System.Data;
using Npgsql;

namespace Infrastructure.Context;

public class DataContext
{
    private string _connectionString = @"Host=localhost;
                                      Database=CRM;
                                      Username=postgres;
                                      Password=umed008;";
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }                                   
}

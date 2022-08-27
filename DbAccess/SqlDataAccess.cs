using System.Data;
using Dapper;
using MySqlConnector;
using WorkoutAPI.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;
    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T>(string storedProcedure, string connectionId = "Default")
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, string connectionId = "Default")
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure);
    }
}
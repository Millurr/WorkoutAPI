namespace WorkoutAPI.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T>(string storedProcedure, string connectionId = "Default");
    Task SaveData<T>(string storedProcedure, string connectionId = "Default");
}
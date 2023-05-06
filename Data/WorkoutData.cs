using WorkoutAPI.DbAccess;
using WorkoutAPI.Models;

namespace WorkoutAPI.Data;

public class WorkoutData : IWorkoutData
{
    private readonly ISqlDataAccess _db;

    public WorkoutData(ISqlDataAccess db)
    {
        _db = db;
    }   

    public async Task DeleteWorkout(int id)
    {
        string sqlStatement = getAction("WORKOUTS-DELETE").Result;
        string populatedStatement = String.Format(sqlStatement, id);
        await _db.SaveData<WorkoutModel>(populatedStatement, "Default");
    }

    public async Task<WorkoutModel?> GetWorkout(int id)
    {
        string sqlStatement = getAction("WORKOUTS-NORMAL").Result;
        string populatedStatement = String.Format(sqlStatement, id);
        var res = await _db.LoadData<WorkoutModel>(populatedStatement, "Default");
        return res.FirstOrDefault();
    }

    public async Task<IEnumerable<WorkoutModel>> GetWorkouts() 
    {
        string sqlStatement = getAction("WORKOUTS-WIDEOPEN").Result;
        return await _db.LoadData<WorkoutModel>(sqlStatement, "Default");
    }

    public async Task InsertWorkout(WorkoutModel workout)
    {
        string sqlStatement = getAction("WORKOUTS-INSERT").Result;
        string populatedStatement = String.Format(sqlStatement, workout.Name, workout.CategoryId, workout.Complexity);
        await _db.SaveData<WorkoutModel>(populatedStatement, "Default");
    }

    public async Task UpdateWorkout(WorkoutModel workout)
    {
        string sqlStatement = getAction("WORKOUTS-UPDATE").Result;
        string populatedStatement = String.Format(sqlStatement, workout.Name, workout.WorkoutId, workout.CategoryId, workout.Complexity);
        await _db.SaveData<WorkoutModel>(populatedStatement, "Default");
    }

    private async Task<string> getAction(string action) 
    {
        var sqlStatementQuery = await _db.LoadData<SqlStatementModel>(@$"select * from sql_statements where sql_key = '{action}'", "Default");
        string sqlStatement = sqlStatementQuery.First<SqlStatementModel>().SQL_STATEMENT;
        return sqlStatement;
    }
}
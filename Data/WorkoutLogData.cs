using WorkoutAPI.DbAccess;
using WorkoutAPI.Models;

namespace WorkoutAPI.Data;

public class WorkoutLogData : IWorkoutLogData
{
    private readonly ISqlDataAccess _db;

    public WorkoutLogData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task DeleteWorkoutLog(int id)
    {
        string sqlStatement = getAction("WORKOUT-LOG-DELETE").Result;
        string populatedStatement = String.Format(sqlStatement, id);
        await _db.SaveData<WorkoutLogModel>(populatedStatement, "Default");
    }

    public Task<WorkoutLogModel?> GetWorkoutLog(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<WorkoutLogModel>> GetWorkoutLogs()
    {
        string sqlStatement = getAction("WORKOUT-LOG-WIDEOPEN").Result;
        return await _db.LoadData<WorkoutLogModel>(sqlStatement, "Default");
    }

    public async Task<IEnumerable<WorkoutLogModel>> GetWorkoutLogsByUser(string userId)
    {
        string sqlStatement = getAction("WORKOUT-LOG-BY-USER").Result;
        string populatedStatement = String.Format(sqlStatement, userId);
        return await _db.LoadData<WorkoutLogModel>(populatedStatement, "Default");
    }

    public async Task InsertWorkoutLog(WorkoutLogModel workoutLog)
    {
        string sqlStatement = getAction("WORKOUT-LOG-INSERT").Result;
        string populatedStatement = String.Format(sqlStatement, workoutLog.Duration, workoutLog.Reps, workoutLog.Weight, workoutLog.UserId, workoutLog.LogTime, workoutLog.WorkoutId);
        await _db.SaveData<WorkoutLogModel>(populatedStatement, "Default");
    }

    public async Task UpdateWorkoutLog(WorkoutLogModel workoutLog)
    {
        string sqlStatement = getAction("WORKOUT-LOG-UPDATE").Result;
        string populatedStatement = String.Format(sqlStatement, workoutLog.WorkoutLogId, workoutLog.Duration, workoutLog.Reps, workoutLog.Weight, workoutLog.WorkoutId);
        await _db.SaveData<WorkoutLogModel>(populatedStatement, "Default");
    }

    private async Task<string> getAction(string action)
    {
        var sqlStatementQuery = await _db.LoadData<SqlStatementModel>(@$"select * from sql_statements where sql_key = '{action}'", "Default");
        string sqlStatement = sqlStatementQuery.First<SqlStatementModel>().SQL_STATEMENT;
        return sqlStatement;
    }
}

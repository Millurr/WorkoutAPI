using WorkoutAPI.Models;

namespace WorkoutAPI.Data;

public interface IWorkoutLogData
{
    Task DeleteWorkoutLog(int id);
    Task<WorkoutLogModel?> GetWorkoutLog(int id);
    Task<IEnumerable<WorkoutLogModel>> GetWorkoutLogs();
    Task<IEnumerable<WorkoutLogModel>> GetWorkoutLogsByUser(string userId);
    Task InsertWorkoutLog(WorkoutLogModel workoutLog);
    Task UpdateWorkoutLog(WorkoutLogModel workoutLog);
}

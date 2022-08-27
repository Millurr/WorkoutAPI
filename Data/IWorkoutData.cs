using WorkoutAPI.Models;

namespace WorkoutAPI.Data;

public interface IWorkoutData
{
    Task DeleteWorkout(int id);
    Task<WorkoutModel?> GetWorkout(int id);
    Task<IEnumerable<WorkoutModel>> GetWorkouts();
    Task InsertWorkout(WorkoutModel workout);
    Task UpdateWorkout(WorkoutModel workout);
}
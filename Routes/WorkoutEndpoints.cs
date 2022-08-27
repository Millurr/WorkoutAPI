using WorkoutAPI.Data;
using WorkoutAPI.Models;

namespace WorkoutAPI.Routes;

public static class WorkoutEndpoints 
{
    
    public static void ConfigureWorkoutEndpoints(this WebApplication app)
    {
        app.MapGet("/workouts", GetWorkouts);
        app.MapGet("/workouts/{id}", GetWorkout);
        app.MapPost("/workouts", InsertWorkout);
        app.MapPut("/workouts/{id}", UpdateWorkout);
        app.MapDelete("/workouts/{id}", DeleteWorkouts);
    }

    private static async Task<IResult> GetWorkouts(IWorkoutData data)
    {
        try
        {
            return Results.Ok(await data.GetWorkouts());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetWorkout(int id, IWorkoutData data)
    {
        try
        {
            var res = await data.GetWorkout(id);
            if (res == null) return Results.NotFound();
            return Results.Ok(res);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertWorkout(WorkoutModel workout, IWorkoutData data)
    {
        try
        {
            await data.InsertWorkout(workout);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateWorkout(WorkoutModel workout, IWorkoutData data)
    {
        try
        {
            await data.UpdateWorkout(workout);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteWorkouts(int id, IWorkoutData data)
    {
        try
        {
            await data.DeleteWorkout(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
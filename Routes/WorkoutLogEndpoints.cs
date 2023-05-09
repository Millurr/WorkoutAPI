using WorkoutAPI.Data;
using WorkoutAPI.Models;

namespace WorkoutAPI.Routes;

public static class WorkoutLogEndpoints
{

    public static void ConfigureWorkoutLogEndpoints(this WebApplication app)
    {
        app.MapGet("/workout-logs", GetWorkoutLogs);
        app.MapGet("/workout-logs-user/{id}", GetWorkoutLogsByUser);
        app.MapGet("/workout-logs/{id}", GetWorkoutLog);
        app.MapPost("/workout-logs", InsertWorkoutLog);
        app.MapPut("/workout-logs/{id}", UpdateWorkoutLog);
        app.MapDelete("/workout-logs/{id}", DeleteWorkoutLog);
    }

    private static async Task<IResult> GetWorkoutLogs(IWorkoutLogData data)
    {
        try
        {
            return Results.Ok(await data.GetWorkoutLogs());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetWorkoutLog(int id, IWorkoutLogData data)
    {
        try
        {
            var res = await data.GetWorkoutLog(id);
            if (res == null) return Results.NotFound();
            return Results.Ok(res);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetWorkoutLogsByUser(string id, IWorkoutLogData data)
    {
        try
        {
            var res = await data.GetWorkoutLogsByUser(id);
            if (res == null) return Results.NotFound();
            return Results.Ok(res);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertWorkoutLog(WorkoutLogModel workout, IWorkoutLogData data)
    {
        try
        {
            await data.InsertWorkoutLog(workout);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateWorkoutLog(WorkoutLogModel workout, IWorkoutLogData data)
    {
        try
        {
            await data.UpdateWorkoutLog(workout);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteWorkoutLog(int id, IWorkoutLogData data)
    {
        try
        {
            await data.DeleteWorkoutLog(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
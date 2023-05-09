namespace WorkoutAPI.Models
{
    public class WorkoutLogModel : WorkoutModel
    {
        public int WorkoutLogId { get; set; }

        public float Duration { get; set; }

        public int Reps { get; set; }

        public float Weight { get; set; }

        public String UserId { get; set; } = String.Empty;

        public string LogTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    }
}

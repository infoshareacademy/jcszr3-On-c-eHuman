namespace TimeTrackingSystem.Domain.Model
{
    public class ActivityProject
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public Activity Activity { get; set; }
    }
}

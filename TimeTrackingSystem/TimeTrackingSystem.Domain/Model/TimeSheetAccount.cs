namespace TimeTrackingSystem.Domain.Model
{
    public class TimeSheetAccount
    {
        public TimeSheet TimeSheet { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}

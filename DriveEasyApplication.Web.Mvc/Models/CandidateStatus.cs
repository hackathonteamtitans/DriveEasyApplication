namespace DriveEasyApplication.Web.Mvc.Models
{
    public enum CandidateStatus
    {
        Unscheduled = 1,
        Scheduled,
        Rescheduled,
        InProgress,
        Selected,
        Rejected,
        NoShow
    }

    public enum DriveStatus
    {
        NotStarted = 1,
        Scheduled,
        InProgress,
        Completed
    }
}

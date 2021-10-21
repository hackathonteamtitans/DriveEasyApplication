namespace DriveEasyApplication.Web.Mvc.Models
{
    public enum CandidateStatus
    {
        Unscheduled = 1,
        Scheduled = 2,
        Rescheduled = 3,
        InProgress = 4,
        Selected = 5,
        Rejected = 6,
        NoShow = 7
    }

    public enum DriveStatus
    {
        Unscheduled = 1,
        Scheduled = 2,
        InProgress = 3,
        Completed = 4
    }
}

﻿namespace DriveEasyApplication.Web.Mvc.Models
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
}
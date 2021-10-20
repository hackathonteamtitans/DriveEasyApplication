using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveEasyApplication.Web.API.Models
{
    public class InterviewData
    {
        public int? SrNo { get; set; }
        public string Name { get; set; }
        public List<string> SkillSet { get; set; }
        public string Source { get; set; }
        public Show? Show { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public decimal? Experience { get; set; }
        public int? NoticePeriod { get; set; }
        public DateTime? InterviewTime { get; set; }
        public string TechnicalPanel { get; set; }
        public string MeetingLink { get; set; }
        public Status? Status { get; set; }
        public string Feedback { get; set; }
        public string Note { get; set; }
        public string ResumeLink { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            if (SrNo != null) keyValuePairs.Add("SrNo", SrNo.ToString());
            if (Name != null) keyValuePairs.Add("Name", Name);
            if (SkillSet != null) keyValuePairs.Add("SkillSet", string.Join(",", SkillSet));
            if (Show != null) keyValuePairs.Add("Show", ((int)Show).ToString());
            if (Contact != null) keyValuePairs.Add("Contact", Contact);
            if (Email != null) keyValuePairs.Add("Email", Email);
            if (Experience != null) keyValuePairs.Add("Experience", Experience.ToString());
            if (NoticePeriod != null) keyValuePairs.Add("NoticePeriod", NoticePeriod.ToString());
            if (InterviewTime != null) keyValuePairs.Add("InterviewTime", InterviewTime.ToString());
            if (TechnicalPanel != null) keyValuePairs.Add("TechnicalPanel", TechnicalPanel);
            if (MeetingLink != null) keyValuePairs.Add("MeetingLink", MeetingLink);
            if (Status != null) keyValuePairs.Add("Status", ((int)Status).ToString());
            if (Feedback != null) keyValuePairs.Add("Feedback", Feedback);
            if (Note != null) keyValuePairs.Add("Note", Note);
            if (ResumeLink != null) keyValuePairs.Add("ResumeLink", ResumeLink);
            return keyValuePairs;
        }
    }

    public enum Show
    {
        Yes = 0,
        No = 1
    }

    public enum Status
    {
        Selected = 0,
        Rejected = 1
    }
}
using System.Collections.Generic;

namespace DriveEasyApplication.Web.API.Models
{
    public class Candidate
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public List<string> SkillSet { get; set; }
        public string Source { get; set; }
        public Show Show { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Experience { get; set; }
        public string NoticePeriod { get; set; }
        public string InterviewTime { get; set; }
        public string TechnicalPanel { get; set; }
        public string MeetingLink { get; set; }
        public Status Status { get; set; }
        public string Feedback { get; set; }
        public string Note { get; set; }
        public string ResumeLink { get; set; }
    }
}
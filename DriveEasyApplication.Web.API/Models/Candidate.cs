using System;
using System.Collections.Generic;
using System.Linq;

namespace DriveEasyApplication.Web.API.Models
{
    public class Candidate
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public List<string> Skills{ get; set; }
        public Decimal? Experience { get; set; }
        public int? NoticePeriod { get; set; }
        public string Source { get; set; }
        public Show? Confirmed { get; set; }
        public string CurrentOrganization { get; set; }
        public int? DriveID { get; set; }
        public string MeetingLink { get; set; }
        public DateTime InterviewTime { get; set; }
        public string TechnicalPanel { get; set; }
        public Status? Status { get; set; }
        public string FeedbackForm { get; set; }
        public string ResumeLink { get; set; }


        public Dictionary<string,string>ToDictionary()
        {
            Dictionary<string, string> KeyValuePairs = new Dictionary<string, string>();
            if (ID != null) KeyValuePairs.Add("ID", ID.ToString());
            if (Skills != null) KeyValuePairs.Add("Skills", string.Join(",", Skills));
            if (Experience != null) KeyValuePairs.Add("Experience", Experience.ToString());
            if (NoticePeriod != null) KeyValuePairs.Add("NoticePeriod", NoticePeriod.ToString());
            if (Confirmed != null) KeyValuePairs.Add("Confirmed", Confirmed.ToString());
            if (DriveID != null) KeyValuePairs.Add("DriveID", DriveID.ToString());
            if (InterviewTime != null) KeyValuePairs.Add("InterviewTime", InterviewTime.ToString());
            if (Status != null) KeyValuePairs.Add("Status", Status.ToString());

            return KeyValuePairs;
        }

    }
}
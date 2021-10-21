using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class Candidate
    {   
        public int CandidateID { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public int NoticePeriod { get; set; }
        public string Source { get; set; }
        public Show Confirmed { get; set; }
        public string CurrentOrganization { get; set; }
        public int FK_DriveID { get; set; }
        public string MeetingLink { get; set; }
        public DateTime InterviewTime { get; set; }
        public string TechnicalPanel { get; set; }
        public string TechnicalPanelFeedback { get; set; }
        public string ManagerPanel { get; set; }
        public string ManagerPanelFeedback { get; set; }
        public string HRPanel { get; set; }
        public string HRPanelFeedback { get; set; }
        public string FeedbackForm { get; set; }
        public string ResumeLink { get; set; }
        public string Email { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }


        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("CandidateID", CandidateID.ToString());
            keyValuePairs.Add("Name", Name);
            keyValuePairs.Add("Email", Email);
            keyValuePairs.Add("MobileNumber", MobileNumber);
            keyValuePairs.Add("Skills", Skills);
            keyValuePairs.Add("Experience", Experience);
            keyValuePairs.Add("NoticePeriod", NoticePeriod.ToString());
            keyValuePairs.Add("Source", Source);
            keyValuePairs.Add("Confirmed", Confirmed.ToString());
            keyValuePairs.Add("CurrentOrganization", CurrentOrganization);            
            keyValuePairs.Add("FK_DriveID", FK_DriveID.ToString());
            keyValuePairs.Add("MeetingLink", MeetingLink);
            keyValuePairs.Add("InterviewTime", InterviewTime.ToString());
            keyValuePairs.Add("TechnicalPanel", TechnicalPanel);
            keyValuePairs.Add("TechnicalPanelFeedback", TechnicalPanelFeedback);
            keyValuePairs.Add("ManagerPanel", ManagerPanel);
            keyValuePairs.Add("ManagerPanelFeedback", ManagerPanelFeedback);
            keyValuePairs.Add("HRPanel", HRPanel);
            keyValuePairs.Add("HRPanelFeedback", HRPanelFeedback);
            keyValuePairs.Add("FeedbackForm", FeedbackForm);
            keyValuePairs.Add("ResumeLink", ResumeLink);
            return keyValuePairs;
        }

    }
}

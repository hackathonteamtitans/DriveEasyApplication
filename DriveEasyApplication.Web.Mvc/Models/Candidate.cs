using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class Candidate
    {
        public Candidate() { }
        public Candidate(DataRow dataRow)
        {
            SrNo = (int)dataRow["SrNo"];
            CandidateID = (int)dataRow["CandidateID"];
            Name = (string)dataRow["dataRow"];
            MobileNumber = (string)dataRow["MobileNumber"];
            Skills = (string)dataRow["Skills"];
            Experience = (string)dataRow["Experience"];
            NoticePeriod = (int)dataRow["NoticePeriod"];
            Source = (string)dataRow["Source"];
            Confirmed = (Show)dataRow["Confirmed"];
            CurrentOrganization = (string)dataRow["CurrentOrganization"];
            MeetingLink = (string)dataRow["MeetingLink"];
            InterviewTime = (DateTime)dataRow["InterviewTime"];
            TechnicalPanel = (string)dataRow["TechnicalPanel"];
            TechnicalPanelFeedback = (string)dataRow["TechnicalPanelFeedback"];
            ManagerPanel = (string)dataRow["TechnicalPanelFeedback"];
            ManagerPanelFeedback = (string)dataRow["TechnicalPanelFeedback"];
            HRPanel = (string)dataRow["TechnicalPanelFeedback"];
            HRPanelFeedback = (string)dataRow["TechnicalPanelFeedback"];
            FeedbackForm = (string)dataRow["TechnicalPanelFeedback"];
            ResumeLink = (string)dataRow["TechnicalPanelFeedback"];
            Email = (string)dataRow["TechnicalPanelFeedback"];
            FromTime = (DateTime)dataRow["TechnicalPanelFeedback"];
            ToTime = (DateTime)dataRow["TechnicalPanelFeedback"];
        }
        public int SrNo { get; set; }
        public int CandidateID { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public int NoticePeriod { get; set; }
        public string Source { get; set; }
        public Show Confirmed { get; set; }
        public string CurrentOrganization { get; set; }
        public long FK_DriveID { get; set; }
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

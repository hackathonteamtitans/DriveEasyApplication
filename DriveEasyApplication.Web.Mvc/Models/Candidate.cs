using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class Candidate
    {
        public Candidate() { }
        public Candidate(DataRow dataRow)
        {
            CandidateID = Convert.ToInt64(dataRow["CandidateID"]);
            Name = (string)dataRow["Name"];
            MobileNumber = (string)dataRow["MobileNumber"];
            Skills = (string)dataRow["Skills"];
            Experience = (string)dataRow["Experience"];
            NoticePeriod = Convert.ToInt32(dataRow["NoticePeriod"]);
            Source = (string)dataRow["Source"];
            Confirmed = (string)dataRow["Confirmed"];
            CurrentOrganization = (string)dataRow["CurrentOrganization"];
            MeetingLink = (string)dataRow["MeetingLink"];
            if (dataRow["InterviewTime"] == DBNull.Value || dataRow["InterviewTime"].ToString().Trim() == "")
                InterviewTime = null;
            else
                InterviewTime = Convert.ToDateTime(dataRow["InterviewTime"]);
            TechnicalPanel = (string)dataRow["TechnicalPanel"];
            TechnicalPanelFeedback = (string)dataRow["TechnicalPanelFeedback"];
            ManagerPanel = (string)dataRow["ManagerPanel"];
            ManagerPanelFeedback = (string)dataRow["ManagerPanelFeedback"];
            HRPanel = (string)dataRow["HRPanel"];
            HRPanelFeedback = (string)dataRow["HRPanelFeedback"];
            FeedbackForm = (string)dataRow["FeedbackForm"];
            ResumeLink = (string)dataRow["ResumeLink"];
            Email = (string)dataRow["Email"];
            CandidateStatus = Convert.ToInt32(dataRow["CandidateStatus"]);
        }

        public long CandidateID { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public int NoticePeriod { get; set; }
        public string Source { get; set; }
        public string Confirmed { get; set; }
        public string CurrentOrganization { get; set; }
        public long FK_DriveID { get; set; }
        public string MeetingLink { get; set; }
        public DateTime? InterviewTime { get; set; }        
        public int CandidateStatus { get; set; }
        public string FormattedInterviewTime { get; set; }
        public string TechnicalPanel { get; set; }
        public string TechnicalPanelFeedback { get; set; }
        public string ManagerPanel { get; set; }
        public string ManagerPanelFeedback { get; set; }
        public string HRPanel { get; set; }
        public string HRPanelFeedback { get; set; }
        public string FeedbackForm { get; set; }
        public string ResumeLink { get; set; }
        public string Email { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            //keyValuePairs.Add("CandidateID", CandidateID.ToString());
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
            keyValuePairs.Add("CandidateStatus", CandidateStatus.ToString());
            return keyValuePairs;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class Drive
    {
        public Drive()
        {

        }
        public Drive(DataRow dataRow)
        {
            DriveID = Convert.ToInt32(dataRow["DriveID"]);
            Name = (string)dataRow["Name"];
            Organizer = dataRow["Organizer"].ToString();
            SheetLink = (string)dataRow["SheetLink"];
            Department = dataRow["Department"].ToString();
            DriveDate = Convert.ToDateTime(dataRow["DriveDate"]);
            DriveStartTime = Convert.ToDateTime(dataRow["DriveStartTime"]);
            DriveEndTime = Convert.ToDateTime(dataRow["DriveEndTime"]);
            BreakStartTime = Convert.ToDateTime(dataRow["BreakStartTime"]);
            BreakEndTime = Convert.ToDateTime(dataRow["BreakEndTime"]);
            DriveStatus = Convert.ToInt32(dataRow["DriveStatus"]);
        }
        public int? DriveID { get; set; }
        public string Name { get; set; }
        public string SheetLink { get; set; }
        public DateTime DriveDate { get; set; }
        public string Department { get; set; }
        public string Organizer { get; set; }
        public string Status { get; set; }
        public DateTime DriveStartTime { get; set; }
        public DateTime DriveEndTime { get; set; }
        public DateTime BreakStartTime { get; set; }
        public DateTime BreakEndTime { get; set; }
        public int DriveStatus { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> keyValuePair = new Dictionary<string, object>();
            if (DriveID != null)
            {
                keyValuePair.Add("DriveID", DriveID.ToString());
            }            
            keyValuePair.Add("Name", Name);
            keyValuePair.Add("Organizer", Organizer);
            keyValuePair.Add("SheetLink", SheetLink);
            keyValuePair.Add("DriveStatus", DriveStatus.ToString());
            keyValuePair.Add("DriveDate", DriveDate.ToString());
            keyValuePair.Add("Department", Department);
            keyValuePair.Add("DriveStartTime", DriveStartTime.ToString());
            keyValuePair.Add("DriveEndTime", DriveEndTime.ToString());
            keyValuePair.Add("BreakStartTime", BreakStartTime.ToString());
            keyValuePair.Add("BreakEndTime", BreakEndTime.ToString());
            return keyValuePair;
        }
    }

    public enum Show
    {
        Yes = 0,
        No = 1
    }

    public enum Status
    {
        Unscheduled = 0,
        Scheduled = 1,
        Rescheduled = 3,
        InProgress = 4,
        Selected = 5,
        Rejected = 6
    }
}

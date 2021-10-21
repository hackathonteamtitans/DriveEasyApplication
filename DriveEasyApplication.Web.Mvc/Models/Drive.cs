using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class Drive
    {
        public int? DriveID { get; set; }
        public string Name { get; set; }
        public string Organizer { get; set; }
        public string SheetLink { get; set; }
        public DateTime DriveDate { get; set; }
        public string Department { get; set; }
        public DateTime DriveStartTime { get; set; }
        public DateTime DriveEndTime { get; set; }
        public DateTime BreakStartTime { get; set; }
        public DateTime BreakEndTime { get; set; }
        public int DriveStatus { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> keyValuePair = new Dictionary<string, string>();
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

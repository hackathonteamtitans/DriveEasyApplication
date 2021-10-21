using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class Drive
    {
        public int DriveID { get; set; }
        public string Name { get; set; }
        public DateTime DriveDate { get; set; }
        public string Department { get; set; }
        public DateTime DriveStartTime { get; set; }
        public DateTime DriveEndTime { get; set; }
        public DateTime BreakStartTime { get; set; }
        public DateTime BreakEndTime { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> keyValuePair = new Dictionary<string, object>();
            keyValuePair.Add("DriveID", DriveID.ToString());
            keyValuePair.Add("Name", Name);
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

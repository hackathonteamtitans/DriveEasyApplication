using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveEasyApplication.Web.API.Models
{
    public class Drive
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Department { get; set; }
        public DateTime DriveStart { get; set; }
        public DateTime DriveEnd { get; set; }
        public DateTime BreakStart { get; set; }
        public DateTime BreakEnd { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> KeyValuePairs = new Dictionary<string, string>();
            if (ID != null) KeyValuePairs.Add("ID", ID.ToString());
            if (Date != null) KeyValuePairs.Add("Date", Date.ToString());
            if (DriveStart != null) KeyValuePairs.Add("DriveStart", DriveStart.ToString());
            if (DriveEnd != null) KeyValuePairs.Add("DriveEnd", DriveEnd.ToString());
            if (BreakStart != null) KeyValuePairs.Add("BreakStart", BreakStart.ToString());
            if (BreakEnd != null) KeyValuePairs.Add("BreakEnd", BreakEnd.ToString());


            return KeyValuePairs;
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
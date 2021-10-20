using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class PanelAvailability
    {
        public int? ID { get; set; }
        public int? PanelID { get; set; }
        public int? DriveID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> KeyValuePairs = new Dictionary<string, string>();
            if (ID != null) KeyValuePairs.Add("ID", ID.ToString());
            if (PanelID != null) KeyValuePairs.Add("PanelID", PanelID.ToString());
            if (DriveID != null) KeyValuePairs.Add("DriveID", DriveID.ToString());
            if (StartTime != null) KeyValuePairs.Add("StartTime", StartTime.ToString());
            if (EndTime != null) KeyValuePairs.Add("EndTime", EndTime.ToString());

            return KeyValuePairs;
        }
    }
}

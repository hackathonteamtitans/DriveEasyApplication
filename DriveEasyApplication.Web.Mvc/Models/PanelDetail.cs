using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class PanelDetail
    {
        public int PanelID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string EmployeeID { get; set; }
        public string Skills { get; set; }
        public string Manager { get; set; }
        public string Department { get; set; }
        public PanelType PanelType { get; set; }

        public string PanelRole { get; set; }
        public string Experience { get; set; }
        public string Title { get; set; }
        public int ID { get; set; }        
        public int DriveID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> KeyValuePairs = new Dictionary<string, object>();
            KeyValuePairs.Add("PanelID", PanelID.ToString());
            KeyValuePairs.Add("Name", Name);
            KeyValuePairs.Add("Email", Email);
            KeyValuePairs.Add("MobileNumber", MobileNumber.ToString());
            KeyValuePairs.Add("EmployeeID", EmployeeID.ToString());
            KeyValuePairs.Add("Skills", Skills);
            KeyValuePairs.Add("Manager", Manager);
            KeyValuePairs.Add("Department", Department);
            KeyValuePairs.Add("PanelType", PanelRole.ToString());
            KeyValuePairs.Add("Experience", Experience);
            KeyValuePairs.Add("Title", Title);
            return KeyValuePairs;
        }
    }
}

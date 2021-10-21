using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class Panel
    {
        public int PanelID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public int EmployeeID { get; set; }
        public string Skills { get; set; }
        public string Manager { get; set; }
        public string Department { get; set; }
        public PanelType PanelType { get; set; }
        public string Experience { get; set; }
        public string Title { get; set; }


        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> KeyValuePairs = new Dictionary<string, object>();
            KeyValuePairs.Add("PanelID", PanelID.ToString());
            KeyValuePairs.Add("Name", Name);
            KeyValuePairs.Add("Email", Email);
            KeyValuePairs.Add("EmployeeID", EmployeeID.ToString());
            KeyValuePairs.Add("Skills", Skills);
            KeyValuePairs.Add("Manager", Manager);
            KeyValuePairs.Add("Department", Department);
            KeyValuePairs.Add("Manager", Manager);
            KeyValuePairs.Add("PanelType", PanelType.ToString());
            KeyValuePairs.Add("Experience", Experience);
            KeyValuePairs.Add("Title", Title);
            return KeyValuePairs;
        }
    }

    public enum PanelType
    {

    }
}

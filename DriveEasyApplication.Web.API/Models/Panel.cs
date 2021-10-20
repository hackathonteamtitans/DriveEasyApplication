using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveEasyApplication.Web.API.Models
{
    public class Panel
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public int? EmployeeID { get; set; }
        public List<string> Skills { get; set; }
        public string Manager { get; set; }
        public string Team { get; set; }
        public PanelType? PanelType { get; set; }
        public Decimal? Experience { get; set; }
        public string Title { get; set; }


        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> KeyValuePairs = new Dictionary<string, string>();
            if (ID != null) KeyValuePairs.Add("ID", ID.ToString());
            if (EmployeeID != null) KeyValuePairs.Add("EmployeeID", EmployeeID.ToString());
            if (Skills != null) KeyValuePairs.Add("Skills", string.Join(",", Skills));
            if (PanelType != null) KeyValuePairs.Add("PanelType", PanelType.ToString());
            if (Experience != null) KeyValuePairs.Add("Experience", Experience.ToString());

            return KeyValuePairs;
        }
    }

    public enum PanelType
    {
        
    }
}
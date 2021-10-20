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
        public string Experience { get; set; }
        public string Title { get; set; }
        public int ID { get; set; }        
        public int DriveID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

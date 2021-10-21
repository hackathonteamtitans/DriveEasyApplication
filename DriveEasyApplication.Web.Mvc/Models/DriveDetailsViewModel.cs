using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class DriveDetailsViewModel
    {
        public int DriveID { get; set; }
        public string Name { get; set; }
        public string Organizer { get; set; }
        public string SheetLink { get; set; }
        public DateTime DriveDate { get; set; }
        public string Department { get; set; }
        public DateTime DriveStartTime { get; set; }
        public DateTime DriveEndTime { get; set; }
        public DateTime BreakStartTime { get; set; }
        public DateTime BreakEndTime { get; set; }
        public DriveStatus DriveStatus { get; set; }
    }
}

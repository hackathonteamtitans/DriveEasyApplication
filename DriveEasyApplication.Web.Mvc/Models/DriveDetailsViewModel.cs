using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class DriveDetailsViewModel
    {
        public int? DriveID { get; set; }
        [Display(Name = "Drive Name")]
        public string Name { get; set; }
        public string Organizer { get; set; }
        [Display(Name = "Paste Drive Sheet(s) Link")]
        public string SheetLink { get; set; }

        [Display(Name = "Drive Date")]
        public DateTime? DriveDate { get; set; }
        public string Department { get; set; }
        [Display(Name = "Drive Start Time")]
        public DateTime? DriveStartTime { get; set; }

        [Display(Name = "Drive End Time")]
        public DateTime? DriveEndTime { get; set; }

        [Display(Name = "Break Start Time")]
        public DateTime? BreakStartTime { get; set; }

        [Display(Name = "Break End Time")]
        public DateTime? BreakEndTime { get; set; }

        [Display(Name = "Status")]
        public DriveStatus DriveStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveEasyApplication.Web.API.Models
{
    public class Panelist
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string SkillSet { get; set; }
        public string Experience { get; set; }
        public string AvailabilityFrom { get; set; }
        public string AvailabilityTo { get; set; }

    }
}
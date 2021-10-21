﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Models
{
    public class Panel
    {
        public Panel(DataRow dataRow)
        {
            PanelID = Convert.ToInt32(dataRow["PanelID"]);
            Name = (string)dataRow["Name"];
            Email = dataRow["Email"].ToString();
            MobileNumber = (string)dataRow["MobileNumber"];
            EmployeeID = Convert.ToInt32(dataRow["EmployeeID"]);
            Skills = (string)dataRow["Skills"];
            Manager = (string)dataRow["Manager"];
            Department = (string)dataRow["Department"];
            PanelType = (PanelType)dataRow["PanelType"];
            Experience = (string)dataRow["Experience"];
            Title = (string)dataRow["Title"];
        }

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


        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> KeyValuePairs = new Dictionary<string, string>();
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

using Microsoft.AspNetCore.Mvc;
using DriveEasyApplication.Web.Mvc.Models;
using DriveEasyApplication.Web.Mvc.Services;
using System.Data;
using System.Collections.Generic;
using System;

namespace DriveEasyApplication.Web.Mvc.Controllers
{
    public class PanelsController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                List<PanelDetail> panelList = new List<PanelDetail>();
                using (EasyDriveDbServices easyDriveDbServices = new EasyDriveDbServices())
                {
                    var result = easyDriveDbServices.ReadTableAsList("Panel");
                    if (result != null && result.Count > 0)
                    {
                        foreach (DataRow dr in result)
                        {
                            PanelDetail pd = new PanelDetail();
                            pd.PanelID = Convert.ToInt32(dr["PanelID"]);
                            pd.Name = (string)dr["Name"];
                            pd.Email = (string)dr["Email"];
                            pd.MobileNumber = (string)dr["MobileNumber"];
                            pd.EmployeeID = (string)dr["EmployeeID"];
                            pd.Skills = (string)dr["Skills"];
                            pd.Manager = (string)dr["Manager"];
                            pd.Department = (string)dr["Department"];
                            pd.PanelRole = (string)(dr["PanelType"]);
                            pd.Experience = (string)dr["Experience"];
                            pd.Title = (string)dr["Title"];
                            panelList.Add(pd);
                        }
                    }
                    return View(panelList);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult AddPanel(PanelDetail panelDetail)
        {
            try
            {
                using (EasyDriveDbServices easyDriveDbServices = new EasyDriveDbServices())
                {
                    string query = $"insert into panel('Name', 'Email', 'MobileNumber', 'EmployeeID', " +
                        $"'Skills', 'Manager', 'Department', 'PanelType', 'Experience', 'Title')" +
                        $"values('{panelDetail.Name}', '{panelDetail.Email}', '{panelDetail.MobileNumber}', '{panelDetail.EmployeeID}', " +
                        $"'{panelDetail.Skills}', '{panelDetail.Manager}', '{panelDetail.Department}', '{panelDetail.PanelRole}', '{panelDetail.Experience}', '{panelDetail.Title}')";
                    var result = easyDriveDbServices.ExecuteQuerryAsList(query);
                    // easyDriveDbServices.Add<PanelDetail>(panelDetail);
                    return Ok("success");
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Edit(string panelId)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string panelId)
        {
            return RedirectToAction("Index");
        }

    }
}

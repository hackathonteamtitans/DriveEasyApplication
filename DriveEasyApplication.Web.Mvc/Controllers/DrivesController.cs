using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Controllers
{
    public class DrivesController : Controller
    {
        public IActionResult Index()
        {
            GetDriveData();
            return View();
        }
        public IActionResult CandidateDetails()
        {
            return View();
        }

        private void GetDriveData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44356/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Drives");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                   
                }
                else 
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
        }
    }
}

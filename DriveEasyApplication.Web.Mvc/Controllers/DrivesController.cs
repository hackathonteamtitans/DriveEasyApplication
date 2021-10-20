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
            return View();
        }
        public IActionResult CandidateDetails()
        {
            return View();
        }

        private void hhh()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44356/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Values");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<IList<StudentViewModel>>();
                    //readTask.Wait();

                    //students = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    //students = Enumerable.Empty<StudentViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
        }
    }
}

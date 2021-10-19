using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Controllers
{
    public class DrivesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

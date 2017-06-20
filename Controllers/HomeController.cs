using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Excavator.Models;

namespace Excavator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var x = new Dictionary<string, dynamic>();
            x.Add("ProcessCount", System.Environment.ProcessorCount);
            x.Add("Is64BitProcess", System.Environment.Is64BitProcess);
            x.Add("OSVersion", System.Environment.OSVersion);
            x.Add("Is64BitOperatingSystem", System.Environment.Is64BitOperatingSystem);
            x.Add("UserDomainName", System.Environment.UserDomainName);
            x.Add("MachineName", System.Environment.MachineName);
            x.Add("UserName", System.Environment.UserName);
            x.Add("Version", System.Environment.Version);

            ViewData.Add("SysInfo", x);
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

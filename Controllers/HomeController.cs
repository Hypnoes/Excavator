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

            var k = new List<List<string>>();
            
            var j = new List<string>();
            j.Add("1");
            j.Add("job-01");
            j.Add(DateTime.Now.ToString());
            j.Add("100s");
            j.Add("Finish");
            k.Add(j);

            if (Request.QueryString.Value != "")
            {
                var j2 = new List<string>();
                j2.Add(Request.Query["index"]);
                j2.Add(Request.Query["name"]);
                j2.Add(Request.Query["time"]);
                j2.Add(Request.Query["duration"]);
                j2.Add(Request.Query["status"]);
                k.Add(j2);
            }


            ViewData.Add("SysInfo", x);
            ViewData.Add("JobList", k);
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

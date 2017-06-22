using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Excavator.Models;

namespace Excavator.Controllers
{
    public class JobController : Controller
    {
        private readonly appContext _context;

        public JobController(appContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(string uri)
        {
            d = new Digger(_context);
            d.Start(uri);
            return Redirect("/home/Index?index=2&name=job-02&time=&status=Running");
        }

        public IActionResult Detial(int? id)
        {
            if (id == null)
                return NotFound();
            if (d == null)
                ViewData["Flag"] = "Finish";
            else
            {
                ViewData["Flag"] = "Running";
            }
            return View();
        }

        public IActionResult StopJob(int? id)
        {
            if (d != null)
                d.Stop();
            return Redirect("/home/Index?index=2&name=job-02&time=&status=Finish");
        }

        private Digger d { get; set; }
    }
}

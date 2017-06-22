using System;
using Microsoft.AspNetCore.Mvc;

namespace Excavator.Controllers
{
    public class DbController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

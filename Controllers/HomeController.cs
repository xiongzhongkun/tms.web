using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tms.Models;

namespace tms.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var abc = HttpContext.Session["abc"]
            return View();
        }
    }
}

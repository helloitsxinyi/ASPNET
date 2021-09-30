using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettingStarted.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GettingStarted.Controllers
{
    public class ReportController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Message()
        {
            ViewData["Message"] = "Hello View";
            ViewData["From"] = "Controller Message action";
            return View();
            // alt:
            // return View(new MessageViewModel { Message = "Hello View", From = "Controller Message action" });
        }

        
    }
}

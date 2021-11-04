using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TasksCartWS.Controllers
{
    public class LogoutController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            Response.Cookies.Delete("SessionId");
            Response.Cookies.Delete("Username");

            return RedirectToAction("Index","Login");
          
        }
    }
}

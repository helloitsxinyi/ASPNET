using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasksCartWS.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TasksCartWS.Controllers
{ 
    public class TaskController : Controller
    {
        private const int ReserveTimeout = 30;
        private DBContext dbContext;

        public TaskController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllTasks()
        {
            Session session = GetSession();
            if (session == null)
            {
                return RedirectToAction("Index", "Logout");
            }

            long unixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();

            List<Models.Task> tasks = dbContext.Tasks.Where(x => x.User.Id == null && (x.ReserveTime == null || x.ReserveTime + ReserveTimeout < unixTimestamp)).ToList();

            ViewData["Tasks"] = tasks;
            return View();
        }

        public IActionResult MyTasks()
        {
            Session session = GetSession();
            if (session == null)
            {
                return RedirectToAction("Index", "Logout");
            }

            List<Models.Task> tasks = dbContext.Tasks.Where(x => x.User.Id == session.UserId).OrderBy(x => x.DueDate).ThenBy(x => x.EffortDays).ToList();

            ViewData["Tasks"] = tasks;
            return View();
        }

        private Session GetSession()
        {
            if (Request.Cookies["SessionId"] == null)
            {
                return null;
            }

            Guid sessionId = Guid.Parse(Request.Cookies["sessionId"]);
            Session session = dbContext.Sessions.FirstOrDefault(x=> x.Id == sessionId);

            return session;            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasksCartWS.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TasksCartWS.Controllers
{ 
    public class TasksController : Controller
    {
        private const int ReserveTimeout = 30;
        private DBContext dbContext;

        public TasksController(DBContext dbContext)
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

        public IActionResult AddTasks([FromBody] ReservedTasks tasks)
        {
            Session session = GetSession();
            if (session == null)
            {
                return Json(new { status = "fail" });
            }

            foreach (string id in tasks.TaskIds)
            {
                Guid taskId = Guid.Parse(id);

                Models.Task task = dbContext.Tasks.FirstOrDefault(x => x.Id == taskId);
                task.ReserveTime = null;
                task.User = session.User;

                dbContext.SaveChanges();             
            }
            return Json(new { status = "success" });
        }

        public IActionResult ReserveTask([FromBody] ReserveReq req)
        {
            Session session = GetSession();
            if (session == null)
            {
                return Json(new { status = "fail" });
            }

            Guid taskId = Guid.Parse(req.TaskId);

            if (req.ToReserve)
            {
                long unixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                Models.Task task = dbContext.Tasks.FirstOrDefault(x => (x.Id == taskId && x.User == null)
                && (x.ReserveTime == null || x.ReserveTime + ReserveTimeout < unixTimestamp));

                if (task == null)
                {
                    return Json(new { status = "fail" });
                }

                task.ReserveTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            }
            else
            {
                Models.Task task = dbContext.Tasks.FirstOrDefault(x =>
                    x.Id == taskId
                );

                if (task == null)
                {
                    return Json(new { status = "fail" });
                }

                task.ReserveTime = null;
            }

            dbContext.SaveChanges();

            return Json(new { status = "success" });
        }

        public IActionResult ClearReservedTasks([FromBody] ReservedTasks tasks)
        {
            Session session = GetSession();
            if (session == null)
            {
                return Json(new { status = "fail" });
            }

            foreach (string id in tasks.TaskIds)
            {
                Guid taskId = Guid.Parse(id);
                Models.Task task = dbContext.Tasks.FirstOrDefault(x =>
                    x.Id == taskId
                );
                if (task != null)
                {
                    task.ReserveTime = null;
                }
            }

            dbContext.SaveChanges();

            return Json(new { status = "success" });
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksCartWS.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TasksCartWS.Controllers
{
    public class LoginController : Controller
    {
        private DBContext dbContext;

        public LoginController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            // alr have session Id, redirect accordingly.            
            if (Request.Cookies["SessionId"] != null)
            {
                Guid sessionId = Guid.Parse(Request.Cookies["SessionId"]);
                Session session = dbContext.Sessions.FirstOrDefault(x => x.Id == sessionId);

                if (session == null)
                {
                    return RedirectToAction("Index", "Logout");
                }

                return RedirectToAction("AllTasks", "Tasks");
            }
            //no session ID = show login page
            return View();
        }

        // no session Id, login and create cookie
        public IActionResult Login(IFormCollection form)
        { 
            //takes in value from name property in form
            string username = form["username"];
            string password = form["password"];

            HashAlgorithm sha = SHA256.Create();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(username + password));

            User user = dbContext.Users.FirstOrDefault(x => x.Username == username && x.PassHash == hash);

            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //create new session
            Session session = new Session() { User = user };

            dbContext.Sessions.Add(session);
            dbContext.SaveChanges();

            // important to add in username and sessionId data. Session Id is for retrieving info, Username to display in the Tasks page
            Response.Cookies.Append("SessionId", session.Id.ToString());
            Response.Cookies.Append("Username", user.Username);
 
            return RedirectToAction("AllTasks", "Tasks");
        }

      
    }
}

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
    public class SignupController : Controller
    {       
        private DBContext dbContext;

        public SignupController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    
    public IActionResult Signup(IFormCollection form)
        {
            string username = form["username"];
            string password = form["password"];

            HashAlgorithm sha = SHA256.Create();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(username + password));
                       
            dbContext.Add(new User { Username = username, PassHash = hash });
            dbContext.SaveChanges();

            return RedirectToAction("SignupSuccess", "Signup");
        }

        public IActionResult SignupSuccess()
        {
            return View();
        }
    }
}

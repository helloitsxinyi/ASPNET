using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchUsers.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchUsers.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Person> persons = new List<Person>();

            persons.Add(new Person
            {
                LastName = "Tan",
                FirstName = "Jerry",
                JobTitle = "Engineer",
                YearsExperience = 12
            });
            persons.Add(new Person
            {
                LastName = "Wong",
                FirstName = "Hogan",
                JobTitle = "Data Scientist",
                YearsExperience = 5
            });
            persons.Add(new Person
            {
                LastName = "Lee",
                FirstName = "Jean",
                JobTitle = "HR Manager",
                YearsExperience = 15
            });
            persons.Add(new Person
            {
                LastName = "Lai",
                FirstName = "Kelly",
                JobTitle = "Flight Attendant",
                YearsExperience = 8
            });

            ViewData["persons"] = persons;

            return View();
        }
    }
}

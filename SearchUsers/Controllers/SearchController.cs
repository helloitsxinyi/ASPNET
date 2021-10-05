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
        private DBContext dbContext;

        public SearchController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index(string searchStr)
        {
           if (searchStr == null)
            {
                searchStr = "";
            }

            // Where method returns enumerable, so need to convert to list
            List<Person> persons = dbContext.Persons.Where(x =>
             x.FirstName.Contains(searchStr) || x.LastName.Contains(searchStr) || x.JobTitle.Contains(searchStr)
            ).ToList();

            ViewData["SearchStr"] = searchStr;
            ViewData["persons"] = persons;
            return View();
        }
    }
}

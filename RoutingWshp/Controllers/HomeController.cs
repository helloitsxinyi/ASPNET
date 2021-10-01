using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoutingWshp.Models;


namespace RoutingWshp.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger)
      {
         _logger = logger;
      }

      public IActionResult Index()
      {
         return View();
      }

      /*
       * TODO 2a: 
       * Construct a URL on your browser to access this 
       * action-method. The URL should contain a query-string that
       * carries values for the two parameters 'a' and 'b'.
       *  
       * If successfully, you should see the sum of 'a' and 'b' displayed
       * on your browser.
       */
      public int Sum(int a, int b)
      {
         return a + b;
      }

      /*
       * TODO 2b: 
       * A Convention-based Route for this action-method 
       * has been created but you are not getting the expected result.
       *  
       * For example, typing "https://localhost:44354/Home/Greetings/Tom/Ranger"
       * on the browser's address bar should display "Hello, Ranger Tom!" on the 
       * browser. However, your browser is displaying "Hello, Tom!" instead.
       *  
       * Please fix the problem.
       */
      public string Greetings(string name, string designation)
      {
         return string.Format("Hello, {0} {1}!", designation, name);
      }

      public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}

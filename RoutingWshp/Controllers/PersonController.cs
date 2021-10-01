using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoutingWshp.Models;

namespace RoutingWshp.Controllers
{
   public class PersonController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }

      /*
       * TODO 3a:
       * Create a Attribute-based Route for this action 
       * method that can accept data with this URL pattern -
       * "https://localhost:44354/CreatePerson/John/45",
       * where 45 is John's age.
       * 
       * Using the debugger, examine the "person" parameter 
       * and ensures that it contains "John" and 45 as values.
       */
      public string CreatePerson(Person person)
      {
         return "Name: " + person.Name + "\n"
             + "Age: " + person.Age;
      }

      /*
       * TODO 3b: 
       * Redirect user to "CreateUser" action method
       * if the user accesses this page
       *  
       * For example, if URL is
       * https://localhost:44354/Person/OldCreatePerson?name=John&Age=45,
       * then the "person" parameter in the "CreateUser" action method
       * should contain "John" and 45 as values.
       */
      public IActionResult OldCreatePerson(string name, string age)
      {
         // Change this implementation
         return null;
      }

      /*
       * TODO 3c:
       * Enter an appropriate URL to your Browser to receive the following
       * string displayed in the Browser:
       * Clark Kent, 62 is older than Bruce Wayne, 61
       */
      public IActionResult CompareTwoPerson(Person p1, Person p2)
      {
         if (p1.Age < p2.Age)
         {
            return Content(string.Format("{0} is younger than {1}", p1, p2));
         }
         else
         {
            return Content(string.Format("{0} is older than {1}", p1, p2));
         }
      }

      /*
       * TODO 3d:
       * Using POSTMAN, create an appropriate HTTP Request 
       * to receive a 200 OK HTTP Response saying that update successfully
       */
      [HttpPost]
      public IActionResult UpdatePerson(
            [FromHeader] string clientCredential,
            [FromForm] string name,
            [FromForm] Person person)
      {
         if (clientCredential == null || clientCredential != "dipSA")
         {
            return Unauthorized();
         }

         if (name != "Nicole Tan") // in reality, need to check against DB
         {
            return NotFound();
         }

         if (person.Name == null || person.Age == 0)
         {
            return new ConflictResult();
         }

         // update the Person having name Nicole Tan to the given values
         return Content("<html><body><p>Update successfully!</body></html>");
      }
   }
}

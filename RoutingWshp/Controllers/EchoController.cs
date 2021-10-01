using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoutingWshp.Controllers
{
   public class EchoController : Controller
   {
      public IActionResult Index()
      {
         return View();
        }

        /*
         * TODO 1a: 
         * Reach this action by typing 
         * the appropriate URL on your browser.
         *  
         * If successful, you should see the word
         * "ReachByConventionRoute" on your browser.
         *  
         */

        // route: /echo/reachbyconventionroute


        /*
         * TODO 1b: 
         * Instead of the current "/Home/Index"
         * as the default page when launched, change
         * the default page to be this action-method.
         *  
         * If successful, you should see the word
         * "ReachByConventionRoute" on your browser
         * when you start the application.
         */

        //change pattern in Startup.cs
        //app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllerRoute(
        //            name: "default",
        //            pattern: "{controller=Echo}/{action=ReachByConventionRoute}/{id?}");

      public IActionResult ReachByConventionRoute()
      {
         return Content("<html><body>ReachByConventionRoute</body></html>",
             "text/html");
      }

      /*
       * TODO 1c: 
       * Create a Attribute-based route,
       * with the pattern "/ReachByAttributeRoute",
       * for this action method. 
       * 
       * Then type the 
       * appropriate URL on your browser to access it.
       * If successfuly, you should see the word
       * "ReachByAttributeRoute" on your browser.
       *  
       * Note: This returns a "string" (use Chrome 
       * dev tools to verify it https://www.youtube.com/watch?v=nl8iKlo2NeM).
       */
      [Route("/ReachByAttributeRoute")]
      public string ReachByAttributeRoute()
      {
         return "ReachByAttributeRoute";
      }
   }
}
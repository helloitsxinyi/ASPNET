using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AvgRespTime.Models;

namespace AvgRespTime.Controllers
{
    public class HomeController : Controller
    {    
        private readonly DBContext dbContext;
                
        public HomeController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            double readDuration = 0;
            double writeDuration = 0;

            List<ResponseStat> reads = dbContext.ResponseStat.Where(x => x.Url.Contains("Read")).ToList();

            if (reads.Count > 0)
            {
                readDuration = reads.Average(x => x.Duration);
            }

            List<ResponseStat> writes = dbContext.ResponseStat.Where(x => x.Url.Contains("write")).ToList();

            if (writes.Count > 0)
            {
                writeDuration = writes.Average(x => x.Duration);
            }

            //original duration data is in millisecs
            ViewData["readDuration"] = Math.Round(readDuration/1000, 3);
            ViewData["writeDuration"] = Math.Round(writeDuration/1000, 3);
            return View();
        }

        public IActionResult Read()
        {
            string key = null;
            MockData data = dbContext.MockData.OrderBy(x => x.CreateTimestamp).LastOrDefault();
            if (data != null)
            {
                key = data.Key;
            }

            ViewData["key"] = key;

            return View();
        }

        public IActionResult Write()
        {
            string key = Guid.NewGuid().ToString();

            dbContext.MockData.Add(new MockData
            {
                Key = key,
                CreateTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
            });
            dbContext.SaveChanges();

            ViewData["key"] = key;
            return View();
        }

    }
}

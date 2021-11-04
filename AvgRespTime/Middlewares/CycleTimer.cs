using System;
using System.Threading.Tasks;
using AvgRespTime.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvgRespTime.Middlewares
{
    public class CycleTimer
    {
        private readonly RequestDelegate next;       

        public CycleTimer(RequestDelegate next)
        {
            this.next = next;        
        }

        public async Task Invoke(HttpContext context, [FromServices] DBContext dbContext)
        {
            long startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            await next(context);

            long endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            int diff = (int)(endTime - startTime);

            dbContext.ResponseStat.Add(new ResponseStat
            {
                Duration = diff,
                Url = context.Request.Path
            });

            dbContext.SaveChanges();
        }
    }
}

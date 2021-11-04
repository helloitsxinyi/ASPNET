using System;
using Microsoft.EntityFrameworkCore;

namespace AvgRespTime.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<MockData> MockData { get; set; }
        public DbSet<ResponseStat> ResponseStat { get; set; }
    }
}

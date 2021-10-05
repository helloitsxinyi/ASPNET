using System;
using Microsoft.EntityFrameworkCore;

namespace SearchUsers.Models
{

    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
             
        public DbSet<Person> Persons { get; set; }
   
    }
}

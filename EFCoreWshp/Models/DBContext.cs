using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWshp.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }


        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassDays> ClassDays { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}

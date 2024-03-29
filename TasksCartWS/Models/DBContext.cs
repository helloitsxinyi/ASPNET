﻿using System;
using Microsoft.EntityFrameworkCore;

namespace TasksCartWS.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) 
        {
        }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

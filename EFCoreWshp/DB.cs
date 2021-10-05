using System;
using EFCoreWshp.Models;

namespace EFCoreWshp
{
    public class DB
    {
        private DBContext dbContext;

        public DB(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            SeedModules();
            SeedLecturers();
            SeedStudents();
            SeedClasses();
            SeedClassDays();
            SeedClassStudent();
        }

        private void SeedModules()
        {
            dbContext.Add(new Module
            {
                RefCode = "NETC",
                Title = "NET Core",
                Desc = "Learn Web Development with .NET Core"
            });

            dbContext.Add(new Module
            {
                RefCode = "MLPY",
                Title = "Machine Learning in Python",
                Desc = "Learn ML Techniques with Python"
            });

            dbContext.SaveChanges();
        }

        private void SeedLecturers()
        {
            dbContext.Add(new Lecturer
            {
                FirstName = "Kim",
                LastName = "Tan"
            });

            dbContext.Add(new Lecturer
            {
                FirstName = "Lynn",
                LastName = "Wong"
            });
        
        }

        private void SeedStudents()
        {
            dbContext.Add(new Student
            {
                FirstName = "Jean",
                LastName = "Sim"
            });

            dbContext.Add(new Student
            {
                FirstName = "Kate",
                LastName = "Lim"
            });

            dbContext.Add(new Student
            {
                FirstName = "Lynn",
                LastName = "Ho"
            });

            dbContext.Add(new Student
            {
                FirstName = "James",
                LastName = "See"
            });

            dbContext.SaveChanges();
        }

        private void SeedClasses()
        {
            // add it this way so that can tag it to module,
            // otherwise also no way to tag to moduleId thru Add since no ModuleRefCode field also.

            // query DBSet Modules of DBContext, followed by
            // FirstOrDefault: return the first element of sequence where module's refcode is NETC
            // and assign this to the variable module.
            Module module = dbContext.Modules.FirstOrDefault(x => x.RefCode == "NETC");

            // impt to check if null
            if (module != null)
            {
                module.Classes.Add(new Class
                {
                    RefCode = "ISS001",
                    Fee = 300
                });

                module.Classes.Add(new Class
                {
                    RefCode = "ISS002",
                    Fee = 600
                });

                dbContext.SaveChanges();
            }
           
        }

        private void SeedClassDays()
        {

        }

        private void SeedClassStudent()
        {

        }
    }
}

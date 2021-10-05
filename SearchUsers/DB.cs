using System;
using SearchUsers.Models;

namespace SearchUsers
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
            SeedPersons();
        }

        private void SeedPersons()
        {
            //List<Person> persons = new List<Person>();

            dbContext.Add(new Person
            {
                LastName = "Tan",
                FirstName = "Jerry",
                JobTitle = "Software Engineer",
                YearsExperience = 12
            });

            dbContext.Add(new Person
            {
                LastName = "Wong",
                FirstName = "Hogan",
                JobTitle = "Data Scientist",
                YearsExperience = 5
            });

            dbContext.Add(new Person
            {
                LastName = "Lee",
                FirstName = "Jean",
                JobTitle = "Consultant",
                YearsExperience = 15
            });

            dbContext.Add(new Person
            {
                LastName = "Lai",
                FirstName = "Kelly",
                JobTitle = "Software Engineer",
                YearsExperience = 8
            });

            dbContext.Add(new Person
            {
                LastName = "Tan",
                FirstName = "John",
                JobTitle = "Consultant",
                YearsExperience = 10
            });

            dbContext.Add(new Person
            {
                LastName = "Tan",
                FirstName = "Kim",
                JobTitle = "Data Scientist",
                YearsExperience = 10
            });

            dbContext.Add(new Person
            {
                LastName = "Wong",
                FirstName = "Larry",
                JobTitle = "Consultant",
                YearsExperience = 5
            });


            //ViewData["persons"] = persons;

            dbContext.SaveChanges();
        }
    }
}

using System;
namespace SearchUsers.Models
{
    public class Person
    {
        public Person()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public int YearsExperience { get; set; }
    }
}

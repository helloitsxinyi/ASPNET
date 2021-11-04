using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TasksCart.Models;


namespace TasksCart
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
            SeedUsersTable();
            SeedTasksTable();
        }

        public void SeedUsersTable()
        {
            HashAlgorithm sha = SHA256.Create();

            string[] usernames = { "john", "jean", "james", "kate" };

            foreach (string username in usernames)
            {
                // assuming user's password is the same as username
                // we are concatenating (i.e. username + password) to generate
                // a password hash to store in the database
                string combo = username + username;
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(combo));

                dbContext.Add(new User
                {
                    Username = username,
                    PassHash = hash
                });
            }

            dbContext.SaveChanges();
        }

        public void SeedTasksTable()
        {
            Random rand = new Random();

            for (int i = 1; i <= 30; i++)
            {
                dbContext.Add(new Task
                {
                    Desc = String.Format("Task {0} description here.", i),
                    EffortDays = rand.Next(2, 11),
                    DueDate = new DateTime(
                        rand.Next(2021, 2023), /* random year - 2021 or 2022 */
                        rand.Next(10, 13), /* random month - Oct, Nov or Dec */
                        1, 9, 0, 0, DateTimeKind.Local),
                    ReserveTime = null
                });
            }

            dbContext.SaveChanges();
        }
    }
}

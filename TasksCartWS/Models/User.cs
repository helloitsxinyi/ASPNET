using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TasksCartWS.Models
{
    public class User
    {
        public User()
        {
            Id = new Guid();
            Tasks = new List<Task>();           
        }

        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public byte[] PassHash { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

    }
}

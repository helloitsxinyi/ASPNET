using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreWshp.Models
{
    public class Lecturer
    {
        public Lecturer()
        {
            Id = new Guid();
            ClassDays = new List<ClassDays>();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(36)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(36)]
        public string LastName { get; set; }

        public virtual ICollection<ClassDays> ClassDays { get; set; }
    }
}

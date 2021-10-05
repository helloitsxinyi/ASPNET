using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreWshp.Models
{
    public class Class
    {
        public Class()
        {
            Id = new Guid();
            ClassDays = new List<ClassDays>();
            Students = new List<Student>();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(6)]
        public string RefCode { get; set; }

        //dont need required bc value types cannot be null.
        public float Fee { get; set; }

        // why should use Guid type here instead of Module type?
        public virtual Guid ModuleId { get; set; }
        public virtual ICollection<ClassDays> ClassDays { get; set; }
        // impt to have the s in students! so that new ClassStudent table will have cols StudentsId with s, not studentId
        public virtual ICollection<Student> Students { get; set; }

    }
}

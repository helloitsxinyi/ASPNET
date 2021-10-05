using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreWshp.Models
{
    public class Module
    {
        public Module()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(6)]
        public string RefCode { get; set; }

        [Required]
        [MaxLength(48)]
        public string Title { get; set; }

        [MaxLength(512)]
        public string Desc { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}

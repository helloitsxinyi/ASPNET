using System;
namespace EFCoreWshp.Models
{
    public class ClassDays
    {
        public ClassDays()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
               
        public DateTime RunDate { get; set; }

        public virtual Guid ClassId { get; set; }

        public virtual Guid LecturerId { get; set; }
    }


}

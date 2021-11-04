using System;
namespace TasksCartWS.Models
{
    public class Task
    {
        public Task()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
        public string Desc { get; set; }
        public int EffortDays { get; set; }
        public DateTime DueDate { get; set; }
        public long? ReserveTime { get; set; }

        public virtual User User { get; set; }
    }
}

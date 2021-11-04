using System;
namespace TasksCartWS.Models
{
    public class ReserveReq
    {
        public bool ToReserve { get; set; }
        public string TaskId { get; set; }
    }
}
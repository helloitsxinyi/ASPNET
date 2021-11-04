using System;
using System.ComponentModel.DataAnnotations;

namespace AvgRespTime.Models
{
    public class ResponseStat
    {
        public ResponseStat()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }

        [Required]
        public string Url { get; set; }
        public int Duration { get; set; }
    }
}

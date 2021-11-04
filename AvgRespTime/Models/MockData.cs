using System;
using System.ComponentModel.DataAnnotations;

namespace AvgRespTime.Models
{
    public class MockData
    {
        public MockData()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(36)]
        public string Key { get; set; }

        public long CreateTimestamp { get; set; }
    }
}
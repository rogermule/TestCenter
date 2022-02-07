using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestCenter.Core.Models
{
    public class TestCenterAvailability
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("PcrCenterId")]
        public int PcrCenterId { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan DayTime { get; set; }
        public string Status { get; set; }

        public PcrCenter TestCenters { get; set; }
        public Booking Booking { get; set; }

    }
}

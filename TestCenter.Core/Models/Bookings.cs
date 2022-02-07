using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestCenter.Core.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("PcrCenterId")]
        public int PcrCenterId { get; set; }

        [ForeignKey("AvailabilityId")]
        public int AvailabilityId { get; set; }
        public string Status { get; set; }

        public virtual User Users { get; set; }
        public virtual PcrCenter TestCenters { get; set; }
        public virtual TestCenterAvailability Availabilities { get; set; }

    }
}

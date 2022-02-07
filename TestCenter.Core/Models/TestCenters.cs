using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestCenter.Core.Models
{
    public class PcrCenter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public List<TestCenterAvailability> Availabilities { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}

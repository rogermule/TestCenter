using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCenter.Core.Models;
using TestCenter.Data.Context;

namespace TestCenter.Data.Repository
{
    public static class DbInitializer
    {
        public static void Initialize(TestCenterContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.PcrCenters.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Email = "rog@gmail.com",Password ="123456",  Phone ="+251916407365", Role ="Patient", Name = "Roger", Address ="Addis Ababa, Ethiopia" },
                new User{Email = "dave@gmail.com", Password = "123456", Phone ="+251916505050", Role ="Admin", Name = "Dave", Address ="Addis Ababa, Ethiopia" }

            };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var testCenter = new PcrCenter[]
            {
                new PcrCenter{City = "Addis Ababa", Location ="Piassa", Name ="Pcr AA1", State = "AA" },
                new PcrCenter{City = "Addis Ababa", Location ="Summit", Name ="Pcr AA2", State = "AA" },
                new PcrCenter{City = "Hawassa", Location ="Piassa", Name ="Pcr HW1", State = "SD" },
                new PcrCenter{City = "Adama", Location ="Piassa", Name ="Pcr AD1", State = "OR" },

            };
            foreach (PcrCenter s in testCenter)
            {
                context.PcrCenters.Add(s);
            }
            context.SaveChanges();

            var testCenterAvailabilities = new TestCenterAvailability[]
            {
            new TestCenterAvailability{PcrCenterId = 1, Day = DateTime.Today, DayTime = DateTime.Now.TimeOfDay, Status = "Active"},
            new TestCenterAvailability{PcrCenterId = 1, Day = DateTime.Today, DayTime = DateTime.Now.TimeOfDay, Status = "Active"},
            new TestCenterAvailability{PcrCenterId = 2, Day = DateTime.Today, DayTime = DateTime.Now.TimeOfDay, Status = "Active"},
            };
            foreach (TestCenterAvailability c in testCenterAvailabilities)
            {
                context.TestAvailabilities.Add(c);
            }
            context.SaveChanges();


            var bookings = new Booking[]
            {
                new Booking{UserId = 1, PcrCenterId = 1, AvailabilityId = 1,  Status = "Booked"},
                new Booking{UserId = 1, PcrCenterId = 1, AvailabilityId = 2,  Status = "Booked"},

            };
            foreach (Booking c in bookings)
            {
                context.Booking.Add(c);
            }
            context.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestCenter.Core.Models;

namespace TestCenter.Data.Context
{
    public class TestCenterContext : DbContext
    {
        public TestCenterContext(DbContextOptions<TestCenterContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PcrCenter> PcrCenters { get; set; }
        public DbSet<TestCenterAvailability> TestAvailabilities { get; set; }
        public DbSet<TestReport> TestReports { get; set; }
        public DbSet<Booking> Booking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<PcrCenter>().ToTable("PcrCenters");
            modelBuilder.Entity<TestCenterAvailability>().ToTable("TestCenterAvailabilities");
            modelBuilder.Entity<TestReport>().ToTable("TestReports");
            modelBuilder.Entity<Booking>().ToTable("Bookings");

            modelBuilder.Entity<User>().HasKey(entity => entity.Id);
            modelBuilder.Entity<PcrCenter>().HasKey(entity => entity.Id);
            modelBuilder.Entity<TestCenterAvailability>().HasKey(entity => entity.Id);
            modelBuilder.Entity<TestReport>().HasKey(entity => entity.Id);
            modelBuilder.Entity<Booking>().HasKey(entity => entity.Id);

            modelBuilder.Entity<Booking>().HasOne(b => b.Users)
                        .WithMany();
            modelBuilder.Entity<Booking>().HasOne(b => b.TestCenters)
                     .WithMany();

            modelBuilder.Entity<Booking>().HasOne(b => b.TestCenters)
                .WithMany(d => d.Bookings);

            modelBuilder.Entity<Booking>().HasOne(b => b.Users)
                .WithMany(d => d.Bookings);

            modelBuilder.Entity<TestCenterAvailability>().HasOne(b => b.Booking)
                .WithOne(d => d.Availabilities).HasForeignKey<Booking>(d => d.AvailabilityId);

            modelBuilder.Entity<TestCenterAvailability>().HasOne(b => b.TestCenters)
                .WithMany(d => d.Availabilities);


        }
    }
}

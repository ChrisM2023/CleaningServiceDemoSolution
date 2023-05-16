using CleaningAppDemo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningAppDemo.DataAccess.Context
{
    public class CleaningAppDemoDbContext : DbContext
    {
        public CleaningAppDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected CleaningAppDemoDbContext()
        {
        }
        public virtual DbSet<CleaningAppDemoModels> CleaningAppDemoModels { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CleaningAppDemoModels>(
                entity =>
                {
                    entity.ToTable("CleaningAppDemo");
                    entity.HasKey(e => e.AppointmentId);
                    entity.Property(e => e.AppointmentId);
                    entity.Property(e => e.Name);
                    entity.Property(e => e.ClientAddress);
                    entity.Property(e => e.Email);
                    entity.Property(e => e.Notes);
                    entity.Property(e => e.DepartureTime);
                    entity.Property(e => e.Appointment);
                    entity.Property(e => e.DestinationAddress);
                    entity.Property(e => e.Mileage);
                    entity.Property(e => e.ArrivalTime);
                    entity.Property(e => e.NumberOfRooms);
                    entity.Property(e => e.EstimatedTimeToComplete);

                }
                );
        }
    }
}











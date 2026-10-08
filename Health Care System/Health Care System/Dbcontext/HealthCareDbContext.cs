using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Health_Care_System.models;
namespace Health_Care_System.Dbcontext
{
    internal class HealthCareDbContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3F9J0A1;Database=HealthCareDb;Trusted_Connection=True;");
        }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Appointment> appointments { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
                 modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.PatientId, a.DoctorId, a.AppointmentDate });

                 modelBuilder.Entity<Appointment>()
                .HasOne(a => a.patients)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);


                 modelBuilder.Entity<Appointment>()
                .HasOne(a => a.doctors)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.
                Entity<Doctor>()
                .Property(d => d.Name)
                .IsRequired();
             modelBuilder.Entity<Patient>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentDate)
                .IsRequired();
            modelBuilder.Entity<Appointment>()
                .Property(a => a.PatientId)
                .IsRequired();
            modelBuilder.Entity<Appointment>()
                .Property(a => a.DoctorId)
                .IsRequired();  
        
        }
    }
}

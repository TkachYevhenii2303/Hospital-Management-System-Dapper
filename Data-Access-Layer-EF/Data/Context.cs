using Data_Access_Layer_EF.Base_Model;
using Data_Access_Layer_EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_EF.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Apointment_Status> Apointment_Statuses { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
        
        public DbSet<Clinic> Clinics { get; set; }
        
        public DbSet<Department> Departments { get; set; }
        
        public DbSet<Documents> Documents { get; set; }

        public DbSet<Document_type> Document_type { get; set; }
        
        public DbSet<Employees> Employees { get; set; }

        public DbSet<In_Department> In_Departments { get; set; }

        public DbSet<Patients> Patients { get; set; }

        public DbSet<Patients_Case> Patients_Cases { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Shedule> Shedules { get; set; }

        /// <summary>
        /// Method for set the base configuration for this database and tables 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // We need to create base dafault values for Base Entity and other classes
            // Using Reflections I can get the Entity class and all its fields 
            foreach (var entity in modelBuilder.Model.GetEntityTypes() 
                .Where(options => typeof(Entity).IsAssignableFrom(options.ClrType)))
            {
                // I can get the all fields and set the default values using Sql Server tools 
                modelBuilder.Entity(entity.Name).Property(nameof(Entity.Id))
                    .IsRequired().HasDefaultValueSql("NewID()");

                modelBuilder.Entity(entity.Name).Property(nameof(Entity.Created_at))
                    .IsRequired().HasDefaultValueSql("GetDate()");

                modelBuilder.Entity(entity.Name).Property(nameof(Entity.Updated_at))
                    .IsRequired().HasDefaultValueSql("GetDate()");
            }

            // Change name of generated Join table ( Many to Many ) for Employees_and_Roles
            modelBuilder.Entity<Employees>()
                .HasMany(left => left.Roles)
                .WithMany(right => right.Employees)
                .UsingEntity(result => result.ToTable("Has_Role"));

            modelBuilder.Entity<Appointment>()
                .HasMany(left => left.Apointment_Status)
                .WithMany(right => right.Appointments)
                .UsingEntity(result => result.ToTable("Status_History"));

            // Disable cascading delete with Fluent API for Documents
            modelBuilder.Entity<Patients>()
                .HasMany<Documents>(entity => entity.Documents)
                .WithOne(result => result.Patients)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Patients_Case>()
                .HasMany<Documents>(entity => entity.Documents)
                .WithOne(result => result.Patients_Case)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Patients_Case>()
             .HasMany<Documents>(entity => entity.Documents)
             .WithOne(result => result.Patients_Case)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<In_Department>()
             .HasMany<Documents>(entity => entity.Documents)
             .WithOne(result => result.In_Department)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>()
             .HasMany<Documents>(entity => entity.Documents)
             .WithOne(result => result.Appointment)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Document_type>()
             .HasMany<Documents>(entity => entity.Documents)
             .WithOne(result => result.Document_Type)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

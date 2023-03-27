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
        }
    }
}

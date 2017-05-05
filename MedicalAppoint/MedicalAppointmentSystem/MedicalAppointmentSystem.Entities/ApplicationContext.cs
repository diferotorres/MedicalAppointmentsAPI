using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MedicalAppointmentSystem.Entities.Model;

namespace MedicalAppointmentSystem.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleDoctor> SchedulesDoctor { get; set; }

        public ApplicationContext() : base("name=ApplicationEntities")
        {
            Database.SetInitializer(new ApplicationInitialiser());
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Schedule>().HasMany(e => e.ScheduleDoctors).WithRequired(f=>f.Schedule).WillCascadeOnDelete(true);
        }
    }
}
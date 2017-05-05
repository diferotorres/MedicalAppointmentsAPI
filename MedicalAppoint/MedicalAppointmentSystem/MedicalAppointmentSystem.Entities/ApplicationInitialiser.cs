using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MedicalAppointmentSystem.Entities.Model;

namespace MedicalAppointmentSystem.Entities
{
    public class ApplicationInitialiser : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        public override void InitializeDatabase(ApplicationContext context)
        {
            base.InitializeDatabase(context);

        }
        protected override void Seed(ApplicationContext context)
        {
            SeedSchedules(context);
            base.Seed(context);
        }

        private void SeedSchedules(ApplicationContext context)
        {
            for (int i = DateTime.Now.Year; i < 2020; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    for (int k = 1; k < DateTime.DaysInMonth(i,j); k++)
                    {
                        for (int l = 0; l < 23; l++)
                        {
                            var startDate = new DateTime(i, j, k, l, 0, 0);
                            var endDate = new DateTime(i, j, k, l+1, 0, 0);
                            context.Schedules.Add(new Schedule() { StartDate = startDate, EndDate = endDate });
                        }
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
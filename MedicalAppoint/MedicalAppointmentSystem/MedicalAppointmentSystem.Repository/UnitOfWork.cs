using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalAppointmentSystem.Entities;
using MedicalAppointmentSystem.Entities.Model;

namespace MedicalAppointmentSystem.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext _appContext;
        public readonly IRepository<Schedule> ScheduleRepository;
        public readonly IRepository<ScheduleDoctor> ScheduleDoctorRepository;

        public UnitOfWork(IRepository<Schedule> scheduleRepository, IRepository<ScheduleDoctor> scheduleDoctorRepository, ApplicationContext context)
        {
            ScheduleRepository = scheduleRepository;
            ScheduleDoctorRepository = scheduleDoctorRepository; 
            _appContext = context;
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _appContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
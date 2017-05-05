using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedicalAppointmentSystem.Entities.Model;
using MedicalAppointmentSystem.Repository;

namespace MedicalAppointmentSystem.Controllers
{
    public class ScheduleController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public ScheduleController(IUnitOfWork uow)
        {
            _unitOfWork = (UnitOfWork)uow;
        }
       
        // GET: api/Schedule
        public IEnumerable<Schedule> Get()
        {
            var schedules = _unitOfWork.ScheduleRepository.GetAll();
            return schedules;
        }
    }
}

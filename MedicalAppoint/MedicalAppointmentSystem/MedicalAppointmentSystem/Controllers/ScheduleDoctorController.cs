using System.Collections;
using System.Web.Http;
using MedicalAppointmentSystem.BussinessLogic.ScheduleDoctor;
using MedicalAppointmentSystem.TransferObjects;

namespace MedicalAppointmentSystem.Controllers
{
    public class ScheduleDoctorController : ApiController
    {
        private readonly IScheduleDoctorLogic _scheduleDoctorLogic;
        public ScheduleDoctorController(IScheduleDoctorLogic scheduleDoctorLogic)
        {
            _scheduleDoctorLogic = scheduleDoctorLogic;
        }

        // GET: api/ScheduleDoctor
        public IEnumerable Get()
        {
            return _scheduleDoctorLogic.GetAllMedicalAppointments();
        }

        // GET: api/ScheduleDoctor/5
        public object Get(int id)
        {
            return _scheduleDoctorLogic.GetMedicalAppointmentsById(id);
        }
        
        [HttpPost]
        public bool Post([FromBody]PatientSchedule patientSchedule)
        {
            return _scheduleDoctorLogic.SetMedicalAppointment(patientSchedule.PatientId, patientSchedule.ScheduleId);
        }

        // PUT: api/ScheduleDoctor/5
        public bool Put(int id, [FromBody]AppointmentUpdate newAppointment)
        {
            return _scheduleDoctorLogic.UpdateMedicalAppointments(id, newAppointment.ScheduleId);
        }

        // DELETE: api/ScheduleDoctor/5
        public void Delete(int id)
        {
            _scheduleDoctorLogic.DeleteMedicalAppointmentsById(id);
        }
    }
}

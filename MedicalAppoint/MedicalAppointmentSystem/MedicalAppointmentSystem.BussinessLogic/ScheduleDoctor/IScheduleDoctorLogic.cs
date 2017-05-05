using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentSystem.BussinessLogic.ScheduleDoctor
{
    public interface IScheduleDoctorLogic
    {
        bool SetMedicalAppointment(int patientId, int scheduleId);
        IEnumerable GetAllMedicalAppointments();
        IEnumerable GetMedicalAppointmentsById(int id);
        void DeleteMedicalAppointmentsById(int id);
        bool UpdateMedicalAppointments(int appointmentId, int scheduleId);
    }
}

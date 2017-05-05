using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalAppointmentSystem.Entities.Model
{
    public class ScheduleDoctor
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        //public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
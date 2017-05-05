using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalAppointmentSystem.Entities.Model
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
        //public int ScheduleDoctorId { get; set; }
        //public virtual ScheduleDoctor ScheduleDoctor { get; set; }
        public virtual ICollection<ScheduleDoctor> ScheduleDoctors { get; set; }
    }
}
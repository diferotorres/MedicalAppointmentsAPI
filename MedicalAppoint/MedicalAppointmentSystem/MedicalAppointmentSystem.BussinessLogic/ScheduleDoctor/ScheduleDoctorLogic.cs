using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using MedicalAppointmentSystem.Entities.Model;
using MedicalAppointmentSystem.Repository;

namespace MedicalAppointmentSystem.BussinessLogic.ScheduleDoctor
{
    public class ScheduleDoctorLogic : IScheduleDoctorLogic
    {
        private readonly UnitOfWork _unitOfWork;
        private static List<Doctor> _doctorList;
        private static List<Patient> _patientList;

        public ScheduleDoctorLogic(IUnitOfWork uow)
        {
            _unitOfWork = (UnitOfWork)uow;
            _doctorList = ExternalEntitiesService.GetDoctors();
            _patientList = ExternalEntitiesService.GetPatients();
        }

        public bool SetMedicalAppointment(int patientId, int scheduleId)
        {
            foreach (var doctor in _doctorList)
            {
                var canCreateAppointment = !_unitOfWork.ScheduleDoctorRepository.GetAll(d=>d.ScheduleId == scheduleId && d.DoctorId == doctor.Id).Any();
                if(canCreateAppointment)
                {
                    _unitOfWork.ScheduleDoctorRepository.Add(new Entities.Model.ScheduleDoctor()
                    {
                        PatientId = patientId,
                        ScheduleId = scheduleId,
                        DoctorId = doctor.Id
                    });

                    _unitOfWork.Save();

                    return true;
                }
            }
            return false;
        }

        public IEnumerable GetAllMedicalAppointments()
        {
            return _unitOfWork.ScheduleDoctorRepository.GetAll().AsEnumerable().Select(a => new
                {
                    AppointmentId = a.Id, 
                    Doctor = _doctorList.FirstOrDefault(d => d.Id == a.DoctorId),
                    Patient = _patientList.FirstOrDefault(p => p.Id == a.PatientId),
                    Schedule = new { a.ScheduleId, a.Schedule.StartDate, a.Schedule.EndDate }
                }
            );
        }

        public IEnumerable GetMedicalAppointmentsById(int id)
        {
            return _unitOfWork.ScheduleDoctorRepository.GetAll(a=>a.Id == id).AsEnumerable().Select(a => new
            {
                AppointmentId = a.Id,
                Doctor = _doctorList.FirstOrDefault(d => d.Id == a.DoctorId),
                Patient = _patientList.FirstOrDefault(p => p.Id == a.PatientId),
                Schedule = new { a.ScheduleId, a.Schedule.StartDate, a.Schedule.EndDate }
            }
            );
        }

        public void DeleteMedicalAppointmentsById(int id)
        {
            var entity = _unitOfWork.ScheduleDoctorRepository.Get(a => a.Id == id);
            _unitOfWork.ScheduleDoctorRepository.Delete(entity);
            _unitOfWork.Save();
        }

        public bool UpdateMedicalAppointments(int appointmentId, int scheduleId)
        {
            var entity = _unitOfWork.ScheduleDoctorRepository.Get(a => a.Id == appointmentId);
            var patientId = entity.PatientId;
            _unitOfWork.ScheduleDoctorRepository.Delete(entity);

            foreach (var doctor in _doctorList)
            {
                var canCreateAppointment = !_unitOfWork.ScheduleDoctorRepository.GetAll(d => d.ScheduleId == scheduleId && d.DoctorId == doctor.Id).Any();
                if (canCreateAppointment)
                {
                    _unitOfWork.ScheduleDoctorRepository.Add(new Entities.Model.ScheduleDoctor()
                    {
                        PatientId = patientId,
                        ScheduleId = scheduleId,
                        DoctorId = doctor.Id
                    });
                }
                _unitOfWork.Save();
                return true;
            }

            return false;
        }
    }
}
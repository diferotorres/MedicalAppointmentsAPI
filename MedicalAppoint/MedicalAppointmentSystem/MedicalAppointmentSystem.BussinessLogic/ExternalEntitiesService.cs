using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using MedicalAppointmentSystem.Entities.Model;

namespace MedicalAppointmentSystem.BussinessLogic
{
    public class ExternalEntitiesService
    {
        public static List<Doctor> GetDoctors()
        {
            var client = new WebClient();
            var text = client.DownloadString(System.Configuration.ConfigurationManager.AppSettings["doctorsApiUrl"]);
            var jsonSerializer = new JavaScriptSerializer();
            object desSerializedObject = jsonSerializer.DeserializeObject(text);

            var doctors = new List<Doctor>();
            if (desSerializedObject != null)
            {
                var rawDoctorList = (object[])desSerializedObject;
                foreach (var rawDoctor in rawDoctorList)
                {
                    var doctorKeyValue = (Dictionary<string, object>)rawDoctor;
                    var doctor = new Doctor
                    {
                        Id = int.Parse(doctorKeyValue["id"].ToString()),
                        Identification = doctorKeyValue["identification"].ToString(),
                        FirstName = doctorKeyValue["first_name"].ToString(),
                        LastName = doctorKeyValue["last_name"].ToString(),
                        BloodType = doctorKeyValue["blood_type"].ToString(),
                        SpecialityField = MapSpeciality(doctorKeyValue["specialty_field"])
                    };

                    doctors.Add(doctor);
                }
            }
            return doctors;
        }

        public static Speciality MapSpeciality(object rawSpeciality)
        {
            var specialityKeyValue = (Dictionary<string, object>)rawSpeciality;
            return new Speciality() {
                Id = int.Parse(specialityKeyValue["id"].ToString()),
                SpecialityType = specialityKeyValue["specialty_type"]?.ToString()
            };
        }

        public static List<Patient> GetPatients()
        {
            var client = new WebClient();
            var text = client.DownloadString(System.Configuration.ConfigurationManager.AppSettings["patientsApiUrl"]);
            var jsonSerializer = new JavaScriptSerializer();
            object desSerializedObject = jsonSerializer.DeserializeObject(text);

            var patients = new List<Patient>();
            if (desSerializedObject != null)
            {
                var serializedObject = (object[])desSerializedObject;
                foreach (var rawPatients in serializedObject)
                {
                    var keyValue = (Dictionary<string, object>)rawPatients;
                    var patient = new Patient
                    {
                        Id = int.Parse(keyValue["id"].ToString()),
                        History = keyValue["history"].ToString(),
                        Identification = keyValue["identification"].ToString(),
                        FirstName = keyValue["first_name"].ToString(),
                        LastName = keyValue["last_name"].ToString(),
                        BloodType = keyValue["blood_type"].ToString(),
                        Genre = keyValue["genre"].ToString(),
                        CivilStatus = keyValue["civil_status"].ToString(),
                        DateBirth = Convert.ToDateTime(keyValue["date_birth"]),
                        CityBirth = keyValue["city_birth"].ToString(),
                    };

                    patients.Add(patient);
                }
            }
            return patients;
        }
    }
}
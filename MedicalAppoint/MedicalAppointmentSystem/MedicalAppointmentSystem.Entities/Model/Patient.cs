using System;

namespace MedicalAppointmentSystem.Entities.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string History { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Genre { get; set; }
        public string CivilStatus { get; set; }
        public string BloodType { get; set; }
        public DateTime DateBirth { get; set; }
        public string CityBirth { get; set; }
    }
}
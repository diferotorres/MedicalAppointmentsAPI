namespace MedicalAppointmentSystem.Entities.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string BloodType { get; set; }
        public Speciality SpecialityField { get; set; }
    }

    public class Speciality
    {
        public int Id { get; set; }
        public string SpecialityType { get; set; }
    }
}
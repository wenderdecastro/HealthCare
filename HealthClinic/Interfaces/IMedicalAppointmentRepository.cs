using HealthClinic.Domains;

namespace HealthClinic.Interfaces
{
    public interface IMedicalAppointmentRepository
    {

        void Create(MedicalAppointment medAppointment);
        void Cancel(int id);
        List<MedicalAppointment> List();
        MedicalAppointment SearchById(int id);
        List<MedicalAppointment> SearchByPatient(MedicalAppointment medAppointment, Guid userId);
        void Update(int id, string description);
    }
}

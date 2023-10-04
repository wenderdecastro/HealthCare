using HealthClinic.Domains;

namespace HealthClinic.Interfaces
{
    public interface IMedicalAppointmentRepository
    {

        void Create(MedicalAppointment medAppointment);
        void Cancel(Guid medAppointmentId);
        List<MedicalAppointment> List();
        MedicalAppointment SearchById(Guid medAppointmentId);
        List<MedicalAppointment> SearchByPatient(Guid userId);

        List<MedicalAppointment> SearchByMedic(Guid medicId);
    }
}

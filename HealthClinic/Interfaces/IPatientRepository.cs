using HealthClinic.Domains;

namespace HealthClinic.Interfaces
{
    public interface IPatientRepository
    {
        void Create(Patient patient);
        void Delete(Guid id);
        List<Patient> List();
    }
}

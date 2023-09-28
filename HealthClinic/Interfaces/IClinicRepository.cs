using HealthClinic.Domains;

namespace HealthClinic.Interfaces
{
    public interface IClinicRepository
    {
        void Create(Clinic clinic);
        void Delete(Guid id);
        List<Clinic> List();
    }
}

using HealthClinic.Domains;

namespace HealthClinic.Interfaces
{
    public interface IClinicRepository
    {
        void Create(MedicalSpecialty medSpecialty);
        void Delete(Guid id);
        List<MedicalSpecialty> List();
    }
}

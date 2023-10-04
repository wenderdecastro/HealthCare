using HealthClinic.Domains;

namespace HealthClinic.Interfaces
{
    public interface IMedicalSpecialtyRepository
    {
        void Create(MedicalSpecialty medicalSpecialty);
        void Delete(Guid specialtyId);
        List<MedicalSpecialty> List();
        //List<MedicalSpecialty> GetByMedic(Guid medicId);
    }
}

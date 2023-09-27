using HealthClinic.Domains;

namespace HealthClinic.Interfaces
{
    public interface IMedicRepository
    {
        void Create(Medic medic);
        void Delete(Guid id);
        List<Medic> List();
    }
}

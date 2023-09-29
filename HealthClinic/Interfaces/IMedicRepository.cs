using HealthClinic.Domains;

namespace HealthClinic.Interfaces
{
    public interface IMedicRepository
    {
        void Create(Medic medic);
        void Delete(Guid medicId);
        List<Medic> List();
    }
}

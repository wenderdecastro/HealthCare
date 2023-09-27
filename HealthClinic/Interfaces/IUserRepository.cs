using HealthClinic.Domains;

namespace HealthClinic.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);
        void Delete(Guid id);
        List<User> List();
        User SearchById(Guid id);
        User SearchByEmailAndPassword(User user);
        void Update(Guid id, User user);
    }
}

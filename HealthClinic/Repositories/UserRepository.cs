using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using HealthClinic.Utils.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HealthClinicContext _clinicContext;
        public UserRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

        public void Create(User user)
        {
            try
            {
                user.Password = PasswordHashing.GenerateHash(user.Password!);

                _clinicContext.Users.Add(user);
                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Delete(Guid id)
        {

            try
            {
                _clinicContext.Users.Where(u => u.UserId == id).ExecuteDelete();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<User> List()
        {
            try
            {
                return _clinicContext.Users.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User SearchByEmailAndPassword(User user)
        {
            try
            {
                User foundUser = _clinicContext.Users.FirstOrDefault(u => u.Email == user.Email);

                if (foundUser != null && PasswordHashing.VerifyHash(user.Password, foundUser.Password))
                {
                    return foundUser;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public User SearchById(Guid id)
        {
            try
            {
                User foundUser = _clinicContext.Users.FirstOrDefault(u => u.UserId == id);

                if (foundUser != null)
                {
                    return foundUser;
                }

                return foundUser;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Update(Guid id, User user)
        {
            try
            {
                User foundUser = _clinicContext.Users.Find(id);

                if (foundUser != null)
                {
                    user.Password = PasswordHashing.GenerateHash(user.Password!);
                    foundUser.Name = user.Name;
                    foundUser.Email = user.Email;
                    foundUser.Password = user.Password;

                    _clinicContext.Users.Update(foundUser);

                    _clinicContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

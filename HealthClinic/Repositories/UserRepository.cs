using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using HealthClinic.Utils.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    /// <summary>
    /// Repositório para operações relacionadas a usuários.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Contexto do banco de dados da clínica de saúde.
        /// </summary>
        private readonly HealthClinicContext _clinicContext;

        /// <summary>
        /// Construtor padrão que inicializa o contexto do banco de dados.
        /// </summary>
        public UserRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="user">O usuário a ser criado.</param>
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

        /// <summary>
        /// Exclui um usuário por ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser excluído.</param>
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

        /// <summary>
        /// Lista todos os usuários.
        /// </summary>
        /// <returns>Uma lista de usuários.</returns>
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

        /// <summary>
        /// Procura um usuário por e-mail e senha.
        /// </summary>
        /// <param name="user">O usuário contendo e-mail e senha.</param>
        /// <returns>O usuário encontrado ou nulo se não encontrado.</returns>
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

        /// <summary>
        /// Procura um usuário por ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser procurado.</param>
        /// <returns>O usuário encontrado ou nulo se não encontrado.</returns>
        public User SearchById(Guid id)
        {
            try
            {
                User foundUser = _clinicContext.Users.FirstOrDefault(u => u.UserId == id);

                return foundUser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Atualiza um usuário por ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser atualizado.</param>
        /// <param name="user">O usuário com informações atualizadas.</param>
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

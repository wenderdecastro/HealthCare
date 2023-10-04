using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    /// <summary>
    /// Repositório para operações relacionadas a médicos.
    /// </summary>
    public class MedicRepository : IMedicRepository
    {
        /// <summary>
        /// Contexto do banco de dados da clínica de saúde.
        /// </summary>
        private readonly HealthClinicContext _clinicContext;

        /// <summary>
        /// Construtor padrão que inicializa o contexto do banco de dados.
        /// </summary>
        public MedicRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

        /// <summary>
        /// Cria um novo médico.
        /// </summary>
        /// <param name="medic">O médico a ser criado.</param>
        public void Create(Medic medic)
        {
            try
            {
                _clinicContext.Medic.Add(medic);
                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Exclui um médico por ID.
        /// </summary>
        /// <param name="id">O ID do médico a ser excluído.</param>
        public void Delete(Guid id)
        {
            try
            {
                _clinicContext.Medic.Where(m => m.MedicId == id).ExecuteDelete();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lista todos os médicos.
        /// </summary>
        /// <returns>Uma lista de médicos.</returns>
        public List<Medic> List()
        {
            try
            {
                return _clinicContext.Medic.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

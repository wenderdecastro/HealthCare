using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    /// <summary>
    /// Repositório para operações relacionadas a especialidades médicas.
    /// </summary>
    public class MedicalSpecialtyRepository : IMedicalSpecialtyRepository
    {
        /// <summary>
        /// Contexto do banco de dados da clínica de saúde.
        /// </summary>
        private readonly HealthClinicContext _clinicContext;

        /// <summary>
        /// Construtor padrão que inicializa o contexto do banco de dados.
        /// </summary>
        public MedicalSpecialtyRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

        /// <summary>
        /// Cria uma nova especialidade médica.
        /// </summary>
        /// <param name="specialty">A especialidade médica a ser criada.</param>
        public void Create(MedicalSpecialty specialty)
        {
            try
            {
                _clinicContext.MedicalSpecialties.Add(specialty);
                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Exclui uma especialidade médica por ID.
        /// </summary>
        /// <param name="id">O ID da especialidade médica a ser excluída.</param>
        public void Delete(Guid id)
        {
            try
            {
                _clinicContext.MedicalSpecialties.Where(ms => ms.MedicalSpecialtyId == id).ExecuteDelete();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lista todas as especialidades médicas.
        /// </summary>
        /// <returns>Uma lista de especialidades médicas.</returns>
        public List<MedicalSpecialty> List()
        {
            try
            {
                return _clinicContext.MedicalSpecialties.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

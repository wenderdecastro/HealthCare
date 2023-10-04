using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using HealthClinic.Utils.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    /// <summary>
    /// Repositório para operações relacionadas a clínicas médicas.
    /// </summary>
    public class ClinicRepository : IClinicRepository
    {
        /// <summary>
        /// Contexto do banco de dados da clínica de saúde.
        /// </summary>
        private readonly HealthClinicContext _clinicContext;

        /// <summary>
        /// Construtor padrão que inicializa o contexto do banco de dados.
        /// </summary>
        public ClinicRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

        /// <summary>
        /// Cria uma nova clínica médica.
        /// </summary>
        /// <param name="clinic">A clínica médica a ser criada.</param>
        public void Create(Clinic clinic)
        {
            try
            {
                _clinicContext.Clinics.Add(clinic);
                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Exclui uma clínica médica por ID.
        /// </summary>
        /// <param name="id">O ID da clínica médica a ser excluída.</param>
        public void Delete(Guid id)
        {
            try
            {
                _clinicContext.Clinics.Where(u => u.ClinicId == id).ExecuteDelete();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lista todas as clínicas médicas.
        /// </summary>
        /// <returns>Uma lista de clínicas médicas.</returns>
        public List<Clinic> List()
        {
            try
            {
                return _clinicContext.Clinics.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

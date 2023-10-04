using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    /// <summary>
    /// Repositório para operações relacionadas a pacientes.
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        /// <summary>
        /// Contexto do banco de dados da clínica de saúde.
        /// </summary>
        private readonly HealthClinicContext _clinicContext;

        /// <summary>
        /// Construtor padrão que inicializa o contexto do banco de dados.
        /// </summary>
        public PatientRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

        /// <summary>
        /// Cria um novo paciente.
        /// </summary>
        /// <param name="patient">O paciente a ser criado.</param>
        public void Create(Patient patient)
        {
            try
            {
                _clinicContext.Patients.Add(patient);
                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Exclui um paciente por ID.
        /// </summary>
        /// <param name="id">O ID do paciente a ser excluído.</param>
        public void Delete(Guid id)
        {
            try
            {
                _clinicContext.Patients.Where(p => p.PatientId == id).ExecuteDelete();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lista todos os pacientes.
        /// </summary>
        /// <returns>Uma lista de pacientes.</returns>
        public List<Patient> List()
        {
            try
            {
                return _clinicContext.Patients.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

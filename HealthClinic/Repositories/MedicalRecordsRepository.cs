using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    /// <summary>
    /// Repositório para operações relacionadas aos registros médicos.
    /// </summary>
    public class MedicalRecordsRepository : IMedicalRecordsRepository
    {
        /// <summary>
        /// Contexto do banco de dados da clínica de saúde.
        /// </summary>
        private readonly HealthClinicContext _clinicContext;

        /// <summary>
        /// Construtor padrão que inicializa o contexto do banco de dados.
        /// </summary>
        public MedicalRecordsRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

        /// <summary>
        /// Cria um novo registro médico.
        /// </summary>
        /// <param name="medRecord">O registro médico a ser criado.</param>
        public void Create(MedicalRecords medRecord)
        {
            try
            {
                _clinicContext.MedicalRecords.Add(medRecord);
                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lista todos os registros médicos.
        /// </summary>
        /// <returns>Uma lista de registros médicos.</returns>
        public List<MedicalRecords> List()
        {
            try
            {
                return _clinicContext.MedicalRecords.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Procura um registro médico pelo ID do paciente.
        /// </summary>
        /// <param name="patientId">O ID do paciente para buscar.</param>
        /// <returns>O registro médico encontrado, ou null se não encontrado.</returns>
        public MedicalRecords SearchByPatient(Guid patientId)
        {
            try
            {
                return _clinicContext.MedicalRecords.FirstOrDefault(u => u.PatientId == patientId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Atualiza um registro médico existente.
        /// </summary>
        /// <param name="medRecordId">O ID do registro médico a ser atualizado.</param>
        /// <param name="medRecord">Os novos dados do registro médico.</param>
        public void Update(Guid medRecordId, MedicalRecords medRecord)
        {
            try
            {
                MedicalRecords foundMedRecord = _clinicContext.MedicalRecords.Find(medRecordId);

                if (foundMedRecord != null)
                {
                    // Atualiza os campos do registro médico com os novos dados.
                    foundMedRecord.ChiefComplaint = medRecord.ChiefComplaint;
                    foundMedRecord.Symptoms = medRecord.Symptoms;
                    foundMedRecord.Diagnostic = medRecord.Diagnostic;
                    foundMedRecord.Allergies = medRecord.Allergies;
                    foundMedRecord.Prescription = medRecord.Prescription;
                    foundMedRecord.MedicalHistory = medRecord.MedicalHistory;

                    _clinicContext.Update(foundMedRecord);
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

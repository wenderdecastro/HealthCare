using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    /// <summary>
    /// Repositório para operações relacionadas a consultas médicas.
    /// </summary>
    public class MedicalAppointmentRepository : IMedicalAppointmentRepository
    {
        /// <summary>
        /// Contexto do banco de dados da clínica de saúde.
        /// </summary>
        private readonly HealthClinicContext _clinicContext;

        /// <summary>
        /// Construtor padrão que inicializa o contexto do banco de dados.
        /// </summary>
        public MedicalAppointmentRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

        /// <summary>
        /// Cancela uma consulta médica por ID.
        /// </summary>
        /// <param name="id">O ID da consulta médica a ser cancelada.</param>
        public void Cancel(Guid id)
        {
            try
            {
                MedicalAppointment foundAppointment = _clinicContext.MedicalAppointments.Find(id);
                if (foundAppointment != null)
                {
                    foundAppointment.IsActive = false;

                    _clinicContext.Update(foundAppointment);
                    _clinicContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cria uma nova consulta médica.
        /// </summary>
        /// <param name="medAppointment">A consulta médica a ser criada.</param>
        public void Create(MedicalAppointment medAppointment)
        {
            try
            {
                _clinicContext.MedicalAppointments.Add(medAppointment);
                medAppointment.IsActive = true;
                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lista todas as consultas médicas.
        /// </summary>
        /// <returns>Uma lista de consultas médicas.</returns>
        public List<MedicalAppointment> List()
        {
            return _clinicContext.MedicalAppointments.ToList();
        }

        /// <summary>
        /// Procura uma consulta médica por ID.
        /// </summary>
        /// <param name="id">O ID da consulta médica a ser pesquisada.</param>
        /// <returns>A consulta médica encontrada, ou null se não encontrada.</returns>
        public MedicalAppointment SearchById(Guid id)
        {
            MedicalAppointment foundAppointment = _clinicContext.MedicalAppointments.Find(id);

            return foundAppointment;
        }

        /// <summary>
        /// Procura consultas médicas por ID do paciente.
        /// </summary>
        /// <param name="patientId">O ID do paciente para buscar.</param>
        /// <returns>Uma lista de consultas médicas do paciente.</returns>
        public List<MedicalAppointment> SearchByPatient(Guid patientId)
        {
            return _clinicContext.MedicalAppointments.Where(u => u.PatientId == patientId).ToList();
        }

        /// <summary>
        /// Procura consultas médicas por ID do médico.
        /// </summary>
        /// <param name="medicId">O ID do médico para buscar.</param>
        /// <returns>Uma lista de consultas médicas do médico.</returns>
        public List<MedicalAppointment> SearchByMedic(Guid medicId)
        {
            return _clinicContext.MedicalAppointments.Where(m => m.MedicId == medicId).ToList();
        }
    }
}

using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    public class MedicalAppointmentRepository : IMedicalAppointmentRepository
    {
        private readonly HealthClinicContext _clinicContext;
        public MedicalAppointmentRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

        public void Cancel(int id)
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

        public void Create(MedicalAppointment medAppointment)
        {
            try
            {
                _clinicContext.MedicalAppointments.Add(medAppointment);
                medAppointment.IsActive= true;
                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MedicalAppointment> List()
        {
            return _clinicContext.MedicalAppointments.ToList();
        }

        public MedicalAppointment SearchById(int id)
        {
            MedicalAppointment foundAppointment = _clinicContext.MedicalAppointments.Find(id);

            return foundAppointment;
        }

        public List<MedicalAppointment> SearchByPatient(MedicalAppointment medAppointment, Guid patientId)
        {
            return _clinicContext.MedicalAppointments.Where(u => u.PatientId == patientId).ToList();
        }

        public void Update(int id, string description)
        {
            MedicalAppointment foundAppointment = _clinicContext.MedicalAppointments.Find(id);

            if (foundAppointment != null)
            {
                foundAppointment.Description = description;
            }
        }
    }
}

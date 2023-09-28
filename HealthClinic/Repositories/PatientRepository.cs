using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HealthClinicContext _clinicContext;
        public PatientRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

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

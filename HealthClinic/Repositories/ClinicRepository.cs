using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using HealthClinic.Utils.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly HealthClinicContext _clinicContext;
        public ClinicRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

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

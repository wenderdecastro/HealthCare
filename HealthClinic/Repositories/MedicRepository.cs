using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    public class MedicRepository : IMedicRepository
    {
        private readonly HealthClinicContext _clinicContext;
        public MedicRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
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

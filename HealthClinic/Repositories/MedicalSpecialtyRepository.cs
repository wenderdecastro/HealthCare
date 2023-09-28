using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Repositories
{
    public class MedicalSpecialtyRepository : IMedicalSpecialtyRepository
    {
        private readonly HealthClinicContext _clinicContext;
        public MedicalSpecialtyRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

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

        public List<MedicalSpecialty> GetByMedic(Medic medic)
        {
            throw new NotImplementedException();
        }

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

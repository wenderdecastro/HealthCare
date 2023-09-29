using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;

namespace HealthClinic.Repositories
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly HealthClinicContext _clinicContext;
        public FeedBackRepository()
        {
            _clinicContext = new HealthClinicContext();
        }
        public void Create(FeedBack feedBack)
        {
            try
            {
                _clinicContext.FeedBacks.Add(feedBack);
                _clinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<FeedBack> List()
        {
            try
            {
                return _clinicContext.FeedBacks.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FeedBack> SearchByUser(Guid patientId)
        {
            try
            {
                return _clinicContext.FeedBacks.Where(f => f.PatientId == patientId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ToggleShow(Guid id)
        {
            try
            {
                FeedBack foundComment = _clinicContext.FeedBacks.Find(id);
                if (foundComment != null)
                {
                    foundComment.IsShown = !foundComment.IsShown;

                    _clinicContext.FeedBacks.Update(foundComment);
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

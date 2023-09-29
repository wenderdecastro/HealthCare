using HealthClinic.Domains;

namespace HealthClinic.Interfaces
{
    public interface IFeedBackRepository
    {
        void Create(FeedBack feedBack);
        List<FeedBack> List();
        void ToggleShow(Guid id);
        List<FeedBack> SearchByUser(Guid userId);
    }
}

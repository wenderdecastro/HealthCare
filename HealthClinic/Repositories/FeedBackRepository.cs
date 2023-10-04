using HealthClinic.Contexts;
using HealthClinic.Domains;
using HealthClinic.Interfaces;

namespace HealthClinic.Repositories
{
    /// <summary>
    /// Repositório para operações relacionadas a feedbacks.
    /// </summary>
    public class FeedBackRepository : IFeedBackRepository
    {
        /// <summary>
        /// Contexto do banco de dados da clínica de saúde.
        /// </summary>
        private readonly HealthClinicContext _clinicContext;

        /// <summary>
        /// Construtor padrão que inicializa o contexto do banco de dados.
        /// </summary>
        public FeedBackRepository()
        {
            _clinicContext = new HealthClinicContext();
        }

        /// <summary>
        /// Cria um novo feedback.
        /// </summary>
        /// <param name="feedBack">O feedback a ser criado.</param>
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

        /// <summary>
        /// Lista todos os feedbacks.
        /// </summary>
        /// <returns>Uma lista de feedbacks.</returns>
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

        /// <summary>
        /// Procura feedbacks por ID do paciente.
        /// </summary>
        /// <param name="patientId">O ID do paciente para buscar feedbacks.</param>
        /// <returns>Uma lista de feedbacks do paciente.</returns>
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

        /// <summary>
        /// Alterna a visibilidade de um feedback por ID.
        /// </summary>
        /// <param name="id">O ID do feedback para alterar a visibilidade.</param>
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

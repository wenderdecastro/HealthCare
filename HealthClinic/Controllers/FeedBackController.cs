using HealthClinic.Domains;
using HealthClinic.Interfaces;
using HealthClinic.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HealthClinic.Controllers
{
    /// <summary>
    /// Controlador para operações relacionadas a feedbacks.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FeedBackController : ControllerBase
    {
        /// <summary>
        /// Repositório de feedbacks.
        /// </summary>
        private readonly IFeedBackRepository _feedBackRepository;

        /// <summary>
        /// Construtor padrão que inicializa o repositório de feedbacks.
        /// </summary>
        public FeedBackController()
        {
            _feedBackRepository = new FeedBackRepository();
        }

        /// <summary>
        /// Obtém uma lista de feedbacks.
        /// </summary>
        /// <returns>Uma resposta HTTP contendo a lista de feedbacks.</returns>
        [HttpGet]
        [Authorize(Roles = "True, False")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_feedBackRepository.List());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cria um novo feedback.
        /// </summary>
        /// <param name="feedBack">O feedback a ser criado.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da criação.</returns>
        [HttpPost]
        [Authorize(Roles = "True, False")]
        public IActionResult Create(FeedBack feedBack)
        {
            try
            {
                return Created("Feedback created.", feedBack);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtém feedbacks por ID de usuário.
        /// </summary>
        /// <param name="userId">O ID do usuário para o qual buscar feedbacks.</param>
        /// <returns>Uma resposta HTTP contendo a lista de feedbacks do usuário.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "True")]
        public IActionResult GetByUserId(Guid userId)
        {
            try
            {
                return Ok(_feedBackRepository.SearchByUser(userId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Alterna a exibição de um feedback por ID.
        /// </summary>
        /// <param name="feedBackId">O ID do feedback para o qual alternar a exibição.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da operação.</returns>
        [HttpPatch]
        [Authorize(Roles = "True")]
        public IActionResult ToggleShow(Guid feedBackId)
        {
            try
            {
                _feedBackRepository.ToggleShow(feedBackId);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }
    }
}

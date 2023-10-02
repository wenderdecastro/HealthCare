using HealthClinic.Domains;
using HealthClinic.Interfaces;
using HealthClinic.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackRepository _feedBackRepository;

        public FeedBackController()
        {
            _feedBackRepository = new FeedBackRepository();
        }

        [HttpGet]
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

        [HttpPost]
        public IActionResult Create(FeedBack feedBack)
        {
            try
            {
                return Created("Patient created.", feedBack);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
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

        [HttpPatch]
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

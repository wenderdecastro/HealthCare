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
    public class ClinicController : ControllerBase
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicController()
        {
            _clinicRepository = new ClinicRepository();
        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                return Ok(_clinicRepository.List());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Clinic clinic)
        {
            try
            {
                _clinicRepository.Create(clinic);
                return Created("Clinic created.", clinic);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

    }
}

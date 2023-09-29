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
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController()
        {
            _patientRepository = new PatientRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_patientRepository.List());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            try
            {
                _patientRepository.Create(patient);
                return Created("Patient created.", patient);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public IActionResult Delete(Guid patientId)
        {
            try
            {
                _patientRepository.Delete(patientId);
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

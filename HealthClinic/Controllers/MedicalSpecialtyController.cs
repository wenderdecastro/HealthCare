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
    public class MedicalSpecialtyController : ControllerBase
    {
        private readonly IMedicalSpecialtyRepository _medicalspecialtyrepository;

        public MedicalSpecialtyController()
        {
            _medicalspecialtyrepository = new MedicalSpecialtyRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_medicalspecialtyrepository.List());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public IActionResult Create(MedicalSpecialty medicalSpecialty)
        {
            try
            {
                _medicalspecialtyrepository.Create(medicalSpecialty);
                return Created("MedicalSpecialty created.", medicalSpecialty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid specialtyId)
        {
            try
            {
                _medicalspecialtyrepository.Delete(specialtyId);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/{MedicId}")]
        public IActionResult GetByMedic(Guid medicId)
        {
            try
            {
                return Ok(_medicalspecialtyrepository.GetByMedic(medicId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }
    }
}

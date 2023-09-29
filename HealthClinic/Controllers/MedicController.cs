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
    public class MedicController : ControllerBase
    {
        private readonly IMedicRepository _medicRepository;

        public MedicController()
        {
            _medicRepository = new MedicRepository();
        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                return Ok(_medicRepository.List());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Medic medic)
        {
            try
            {
                _medicRepository.Create(medic);
                return Created("Medic created.", medic);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid medicId)
        {
            try
            {
                _medicRepository.Delete(medicId);
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

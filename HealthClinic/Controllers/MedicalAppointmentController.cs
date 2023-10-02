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
    public class MedicalAppointmentController : ControllerBase
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;

        public MedicalAppointmentController()
        {
            _medicalAppointmentRepository = new MedicalAppointmentRepository();
        }

        [HttpPost]
        public IActionResult Create(MedicalAppointment medicalAppointment)
        {
            try
            {
                _medicalAppointmentRepository.Create(medicalAppointment);
                return Created("MedicalAppointment created.", medicalAppointment);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                return Ok(_medicalAppointmentRepository.List());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Cancel(Guid medAppointmentId)
        {
            try
            {
                _medicalAppointmentRepository.Cancel(medAppointmentId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult SearchById(Guid medAppointmentId)
        {
            try
            {
                MedicalAppointment foundMedAppoint = _medicalAppointmentRepository.SearchById(medAppointmentId);
                return Ok(foundMedAppoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{patientId}")]
        public IActionResult SearchByPatient(Guid patientId)
        {
            try
            {
                return Ok(_medicalAppointmentRepository.SearchByPatient(patientId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        public IActionResult Update(Guid medAppointmentId, string description)
        {
            try
            {
                _medicalAppointmentRepository.UpdateDescription(medAppointmentId, description);
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

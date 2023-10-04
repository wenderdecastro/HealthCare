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
    /// Controlador para operações relacionadas a pacientes.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        /// <summary>
        /// Construtor padrão que inicializa o repositório de pacientes.
        /// </summary>
        public PatientController()
        {
            _patientRepository = new PatientRepository();
        }

        /// <summary>
        /// Obtém uma lista de pacientes.
        /// </summary>
        /// <returns>Uma resposta HTTP contendo a lista de pacientes.</returns>
        [HttpGet]
        [Authorize(Roles = "True, False")]
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

        /// <summary>
        /// Cria um novo paciente.
        /// </summary>
        /// <param name="patient">O paciente a ser criado.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da criação.</returns>
        [HttpPost]
        [Authorize(Roles = "True")]
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

        /// <summary>
        /// Exclui um paciente por ID.
        /// </summary>
        /// <param name="patientId">O ID do paciente a ser excluído.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da exclusão.</returns>
        [HttpDelete]
        [Authorize(Roles = "True")]  
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

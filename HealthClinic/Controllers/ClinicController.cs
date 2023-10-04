using HealthClinic.Domains;
using HealthClinic.Interfaces;
using HealthClinic.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic.Controllers
{
    /// <summary>
    /// Controlador para operações relacionadas a clínicas médicas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicController : ControllerBase
    {
        /// <summary>
        /// Repositório de clínicas médicas.
        /// </summary>
        private readonly IClinicRepository _clinicRepository;

        /// <summary>
        /// Construtor padrão que inicializa o repositório de clínicas médicas.
        /// </summary>
        public ClinicController()
        {
            _clinicRepository = new ClinicRepository();
        }

        /// <summary>
        /// Obtém uma lista de clínicas médicas.
        /// </summary>
        /// <returns>Uma resposta HTTP contendo a lista de clínicas médicas.</returns>
        [HttpGet]
        [Authorize(Roles = "True, False")]
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

        /// <summary>
        /// Cria uma nova clínica médica.
        /// </summary>
        /// <param name="clinic">A clínica médica a ser criada.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da criação.</returns>
        [HttpPost]
        [Authorize(Roles = "True")]
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

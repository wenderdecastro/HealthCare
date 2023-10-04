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
    /// Controlador para operações relacionadas a médicos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicController : ControllerBase
    {
        private readonly IMedicRepository _medicRepository;

        /// <summary>
        /// Construtor padrão que inicializa o repositório de médicos.
        /// </summary>
        public MedicController()
        {
            _medicRepository = new MedicRepository();
        }

        /// <summary>
        /// Obtém uma lista de médicos.
        /// </summary>
        /// <returns>Uma resposta HTTP contendo a lista de médicos.</returns>
        [HttpGet]
        [Authorize(Roles = "True, False")]
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

        /// <summary>
        /// Cria um novo médico.
        /// </summary>
        /// <param name="medic">O médico a ser criado.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da criação.</returns>
        [HttpPost]
        [Authorize(Roles = "True")]
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

        /// <summary>
        /// Exclui um médico por ID.
        /// </summary>
        /// <param name="medicId">O ID do médico a ser excluído.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da exclusão.</returns>
        [HttpDelete]
        [Authorize(Roles = "True")]
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

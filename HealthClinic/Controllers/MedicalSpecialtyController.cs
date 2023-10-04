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
    /// Controlador para operações relacionadas a especialidades médicas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicalSpecialtyController : ControllerBase
    {
        private readonly IMedicalSpecialtyRepository _medicalspecialtyrepository;

        /// <summary>
        /// Construtor padrão que inicializa o repositório de especialidades médicas.
        /// </summary>
        public MedicalSpecialtyController()
        {
            _medicalspecialtyrepository = new MedicalSpecialtyRepository();
        }

        /// <summary>
        /// Obtém uma lista de especialidades médicas.
        /// </summary>
        /// <returns>Uma resposta HTTP contendo a lista de especialidades médicas.</returns>
        [HttpGet]
        [Authorize(Roles = "True, False")]
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

        /// <summary>
        /// Cria uma nova especialidade médica.
        /// </summary>
        /// <param name="medicalSpecialty">A especialidade médica a ser criada.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da criação.</returns>
        [HttpPost]
        [Authorize(Roles = "True")]
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

        /// <summary>
        /// Exclui uma especialidade médica por ID.
        /// </summary>
        /// <param name="specialtyId">O ID da especialidade médica a ser excluída.</param>
        /// <returns>Uma resposta HTTP indicando o sucesso da exclusão.</returns>
        [Authorize(Roles = "True")]
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

        // [HttpGet("/{MedicId}")]
        // public IActionResult GetByMedic(Guid medicId)
        // {
        //     try
        //     {
        //         return Ok(_medicalspecialtyrepository.GetByMedic(medicId));
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e.InnerException);
        //         return BadRequest(e.Message);
        //     }
        // }
    }
}
